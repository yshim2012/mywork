using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ClientForward;
namespace LDV.WMS.RF.ClientForm.Receiving
{
    public partial class ReceivingPQ : Form
    {
        public ReceivingPQ(string _OrderNumber, ReceivingPQSelect _RdFm)
        {
            InitializeComponent();
            txtReceivingNumber.Focus();
            //--------update huzhenfei 2014-07-30 09:30:54--------
            this.txtReceivingNumber.Text = _OrderNumber;
            BindGrid();
            this.txtReceivingNumber.Focus();
            this.txtReceivingNumber.ReadOnly = true;
            Cursor.Current = Cursors.Default;
        }
        private void BindGrid()
        {
            //开始预收货
            lblMessage.Text = string.Empty;
            dataGrid1.DataSource = null;
            Cursor.Current = Cursors.WaitCursor;
            string OrderNumber = txtReceivingNumber.Text.Trim();
            if (OrderNumber == string.Empty)
            {
                lblMessage.Text = "收货单号不能为空!";
                Cursor.Current = Cursors.Default;
                return;
            }
            DataTable data;
            try
            {
                data = CC.Singleton().service().LoadMainDoc(OrderNumber, double.Parse(mainForm._logUser.ID.ToString()));
            }
            catch (Exception ex)
            {
                lblMessage.Text = "网络错误:" + ex.Message;
                return;
            }
            data.TableName = "OrderList";
            this.dataGrid1.DataSource = data;
            Cursor.Current = Cursors.Default;
        }
        private void btnReturn_Click(object sender, EventArgs e)
        {
            //关闭窗口
            this.Close();
        }

        private void menuItem2_Click(object sender, EventArgs e)
        {
          
        }

        private void dataGrid1_MouseUp(object sender, MouseEventArgs e)
        {
            //if (dataGrid1.CurrentRowIndex > 0)
            //{
            //    dataGrid1.Select(dataGrid1.CurrentRowIndex);
            //}
            System.Drawing.Point pt = new Point(e.X, e.Y);
            DataGrid.HitTestInfo hti = dataGrid1.HitTest(e.X, e.Y);
            if (hti.Type == DataGrid.HitTestType.Cell)
            {
                dataGrid1.CurrentCell = new DataGridCell(hti.Row, hti.Column);
                dataGrid1.Select(hti.Row);
            }   
        }

        private void btnStartReceiving_Click(object sender, EventArgs e)
        {

            //开始包装
            lblMessage.Text = string.Empty;
            dataGrid1.DataSource = null;
            Cursor.Current = Cursors.WaitCursor;
            string OrderNumber = txtReceivingNumber.Text.Trim();
            if (OrderNumber == string.Empty)
            {
                lblMessage.Text = "收货单号不能为空!";
                Cursor.Current = Cursors.Default;
                return;
            }
            DataTable data;
            try
            {
                data = CC.Singleton().service().LoadMainDoc(OrderNumber, double.Parse(mainForm._logUser.ID.ToString()));
                if (data.TableName == "OrderRV")
                {
                    data.TableName = "OrderList";
                }
                
            }
            catch (Exception ex)
            {
                lblMessage.Text = "网络错误:" + ex.Message;
                return;
            }
            if (data.Rows.Count < 1)
            {
                lblMessage.Text = "收货单号不存在!";
                txtReceivingNumber.SelectAll();
                Cursor.Current = Cursors.Default;
                return;
            }

            if (data.TableName.Equals("OrderPQ") || data.TableName.Equals("OrderCL"))
            {
                lblMessage.Text = "收货单包装已完成!";
                txtReceivingNumber.SelectAll();
                data.TableName = "OrderList";
                this.dataGrid1.DataSource = data;
                Cursor.Current = Cursors.Default;
                return;
            }
            if (!data.TableName.Equals("OrderList"))
            {
                lblMessage.Text = "收货单正在被" + data.TableName.Substring(1,data.TableName.Length-1)+ "包装!";
                txtReceivingNumber.SelectAll();
                data.TableName = "OrderList";
                this.dataGrid1.DataSource = data;
                Cursor.Current = Cursors.Default;
                return;
            }
            //data.TableName = "OrderList";
            this.dataGrid1.DataSource = data;
            try
            {
                if (!CC.Singleton().service().IsUserLoginOtherDevice(mainForm._logUser.LOGIN_NAME, mainForm._logUser.EXTEND_COLUMN_0))
                {
                    lblMessage.Text = "该账号已经在别处登陆!请重新登陆!";
                    Cursor.Current = Cursors.Default;
                    return;
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = "验证用户出现异常,请检查网络后重试!";
                return;
            }

            //显示窗口
            ReceivingPQDetail Scan = new ReceivingPQDetail(data, OrderNumber, this);
            Scan.ShowDialog();
            BindGrid();
            Cursor.Current = Cursors.Default;
            txtReceivingNumber.SelectAll();
            //this.Close();
        }

        private void txtReceivingNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)    //Enter
            {
                btnStartReceiving_Click(null, null);
                return;
            }
        }

        private void ReceivingPQ_Load(object sender, EventArgs e)
        {
           
        }

        private void btnclose_Click(object sender, EventArgs e)
        {

            try
            {
                //如果状态OP，包装完成，上架数量相同，则更新零件状态为AP，如果全部零件状态为AP，则更新订单状态为CL
                int count = 0; //差异数量
                string Status = string.Empty; //零件状态
                string ItemS = "NOT";  //订单状态
                string Deo = string.Empty; //零件号
                //lbinfo  
                int rowIndex = this.dataGrid1.CurrentRowIndex;
                Deo = dataGrid1[rowIndex, 0].ToString();

                if (Deo == string.Empty)
                {
                    lblMessage.Text = "请选择需要关闭包装流程的零件！";
                    return;
                }
                if (Convert.ToInt32(dataGrid1[rowIndex, 2]) == Convert.ToInt32(dataGrid1[rowIndex, 3]))
                {
                    lblMessage.Text = "该零件已全部包装完成！";
                    return;
                }


                DataTable Newdata = CC.Singleton().service().LoadMainDoc(txtReceivingNumber.Text.Trim(), double.Parse(mainForm._logUser.ID.ToString())); //获取最新的数据
                DataRow[] dr = Newdata.Select("ITEM_CODE='" + Deo.Trim() + "'");
                DataTable dtt = Newdata.Clone();
                foreach (DataRow item in dr)
                {
                    dtt.Rows.Add(item.ItemArray);
                }
                int EXPECTED_QTY = Convert.ToInt32(dtt.Compute("SUM(EXPECTED_QTY)", "DID>0"));
                int PQQTY = Convert.ToInt32(dtt.Compute("SUM(PQQTY)", "DID>0"));
                int ACTUAL_QTY=Convert.ToInt32(dtt.Rows[0]["ACTUAL_QTY"]);
                if (dtt.Rows.Count > 0)
                {

                    if (dtt.Rows[0]["EXTEND_COLUMN_2"].ToString() == "PQ" || dtt.Rows[0]["EXTEND_COLUMN_2"].ToString() == "AP")
                    {
                        lblMessage.Text = "该零件已完成包装！";
                        return;
                    }

                    if (dtt.Rows[0]["EXTEND_COLUMN_2"].ToString() == "OP")
                    {
                        //(MRow.Compute("SUM(EXPECTED_QTY)", "DID>0").ToString())
                        //上架完成，但和预收货存在差异
                       // if (Convert.ToInt32(dtt.Rows[0]["EXPECTED_QTY"]) == Convert.ToInt32(dtt.Rows[0]["PQQTY"]))
                        if (EXPECTED_QTY == PQQTY)
                        {

                            #region 不存在这种情况
                            #endregion
                        }
                        else
                        {

                            //不限制包装数为0时包装完成操作
                            //if (PQQTY == 0)
                            //{
                            //    lblMessage.Text = "零件" + Deo + "包装数为0,不能进行包装完成操作！";
                            //    return;
                            //}
                            count = EXPECTED_QTY - PQQTY; //差异数量
                            string msg = string.Empty;
                            //XX零件XX数量未包装是否确认完成包装任务
                            if (count > 0)
                            {
                                msg = "零件：" + Deo + ",数量：" + count.ToString() + "个未包装是否确认完成包装任务?";
                            }
                            else
                            {
                                msg = "是否关闭整个包装及上架流程?";
                            }


                            DialogResult rst = MessageBox.Show(msg, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                            if (rst == DialogResult.Yes)
                            {
                                //判断包装数量是否与上架数量相同
                                if (PQQTY == ACTUAL_QTY)
                                {
                                    if (Newdata.Rows.Count > 1)
                                    {
                                        //除了这次零件外，其他零件是否已经包装完成
                                        if (Newdata.Select("Status='AP' and ITEM_CODE<>'" + Deo.Trim() + "'").Length == (Newdata.Rows.Count - 1))
                                        {

                                            Status = "AP";
                                            ItemS = "CL";
                                        }
                                        else
                                        {
                                            Status = "AP";
                                        }
                                    }
                                    else
                                    {
                                        Status = "AP";
                                        ItemS = "CL";
                                    }
                                }
                                else
                                {
                                    Status = "PQ";
                                }
                                string DetailID = dtt.Rows[0]["DID"].ToString();
                                string DOCID = dtt.Rows[0]["RID"].ToString();
                                //UpdatePQStatusByClose
                                if (CC.Singleton().service().UpdatePQStatusByClose(Status, ItemS, DetailID, DOCID, count))
                                {

                                    lblMessage.Text = "包装已完成！";
                                    GC.Collect();

                                }
                            }

                        }
                    }
                }
            }
            catch(Exception ex) {
                lblMessage.Text = "包装完成操作失败！";
            }
            BindGrid();
        }

        private void dataGrid1_CurrentCellChanged(object sender, EventArgs e)
        {
          
        }

       
    }
}