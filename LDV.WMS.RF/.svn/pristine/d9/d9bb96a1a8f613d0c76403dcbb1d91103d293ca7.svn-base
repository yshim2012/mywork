using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ClientForward;
using System.Collections;

namespace LDV.WMS.RF.ClientForm
{
    public partial class PickCheckBox : Form
    {
        public PickCheckBox()
        {
            InitializeComponent();
        }

        
        private void PickCheckOrder_Load(object sender, EventArgs e)
        {
            try
            {
                //DataTable dt = CC.Singleton().service().SelectOrder(mainForm._logUser.LOGIN_NAME.ToString(), Convert.ToDouble(mainForm._logUser.ID));
                //dt.TableName = "OrderList";
                //this.dataGrid1.DataSource = dt;
                //if (dt.Rows.Count > 0)
                //{
                //    this.txtOrderNumber.Text = dt.Rows[0]["PICK_TICKET_CODE"].ToString().Trim();
                //}
                this.txtOrderNumber.Focus();
                this.txtOrderNumber.SelectAll();
            }
            catch(Exception ex)
            {
                this.lblMessage.Text = ex.Message;
            }
        }


        /// <summary>
        /// 文本回车事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtOrderNumber_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == 13)
            {

                if (txtOrderNumber.Text != "")
                {

                    try
                    {
                        ArrayList list = new ArrayList();
                        DataTable dt = CC.Singleton().service().SelectOrderBoxInfo( mainForm._logUser.LOGIN_NAME, Convert.ToDouble(mainForm._logUser.ID), txtOrderNumber.Text);
                        if (dt != null && dt.Rows.Count > 0)
                        {
                            //string ordernum = dt.Rows[0][2].ToString();
                            string ordernum = dt.Rows[0][0].ToString();
                            DataTable userAll = CC.Singleton().service().GetUserOrder(ordernum);

                            if (userAll != null && userAll.Rows.Count > 0 && userAll.Rows[0][3].ToString() != mainForm._logUser.LOGIN_NAME.ToString())
                            {
                                this.lblMessage.Text = "该订单正在被" + userAll.Rows[0][3].ToString().Trim() + "拣货";
                                this.txtOrderNumber.SelectAll();
                                Cursor.Current = Cursors.Default;
                                return;
                            }
                            if (dataGrid1.DataSource != null)
                            {
                                DataTable dtorder = DT(dataGrid1);
                                if (dtorder == null || dtorder.Rows.Count == 0)
                                {
                                    dt.TableName = "OrderList";
                                    this.dataGrid1.DataSource = dt;
                                }
                                else
                                {
                                    foreach (DataRow dr in dt.Rows)
                                    {
                                        if (getIsTable(dtorder, dr))
                                        {
                                            this.lblMessage.Text = "已扫描此箱号请扫描其它箱号！！！";
                                            this.txtOrderNumber.SelectAll();
                                            Cursor.Current = Cursors.Default;
                                            return;
                                        }
                                        DataRow drnew = dtorder.NewRow();
                                        drnew[0] = dr[0];
                                        drnew[1] = dr[1];
                                        drnew[2] = dr[2];
                                        drnew[3] = dr[3];
                                        drnew[4] = dr[4];
                                        dtorder.Rows.Add(drnew);
                                    }
                                    dtorder.TableName = "OrderList";
                                    dataGrid1.DataSource = dtorder;
                                }
                            }
                            else
                            {
                                dt.TableName = "OrderList";
                                this.dataGrid1.DataSource = dt; 
                            }
                           
                        }
                        else
                        {
                            this.lblMessage.Text = "扫描箱号无效请重新扫描！！！";
                            this.txtOrderNumber.SelectAll();
                            Cursor.Current = Cursors.Default;
                            return;
                        }
                        this.txtOrderNumber.SelectAll();
                        Cursor.Current = Cursors.Default;
                    }
                    catch (Exception ex)
                    {
                        this.lblMessage.Text = ex.Message;
                        lblMessage.Text = lblMessage.Text.Replace("服务器无法处理请求。 --->", "");
                        Cursor.Current = Cursors.Default;
                        return;
                    }
                }
            }
        }
        private bool getIsTable(DataTable dt, DataRow dr)
        {
            foreach (DataRow gvdr in dt.Rows)
            {
                if (gvdr[0].ToString() == dr[0].ToString() && gvdr[2].ToString() == dr[2].ToString())
                    return true;
            }
            return false;
        }
        private void dataGrid1_CurrentCellChanged(object sender, EventArgs e)
        {
             int rowIndex=this.dataGrid1.CurrentRowIndex;
             this.txtOrderNumber.Text = dataGrid1[rowIndex, 1].ToString();
             this.txtOrderNumber.SelectAll();
        }

        private void dataGrid1_Click(object sender, EventArgs e)
        {
            this.txtOrderNumber.Focus();
        }

        private void dataGrid1_MouseUp(object sender, MouseEventArgs e)
        {
            System.Drawing.Point pt = new Point(e.X, e.Y);
            DataGrid.HitTestInfo hti = dataGrid1.HitTest(e.X,e.Y);
            if (hti.Type == DataGrid.HitTestType.Cell)
            {
                dataGrid1.CurrentCell = new DataGridCell(hti.Row, hti.Column);
                dataGrid1.Select(hti.Row);
            }   

        }
        public DataTable DT(DataGrid dg)
        {
            try
            {
                DataTable dt = null;

                if (dg.DataSource is DataView)
                {
                    dt = (dg.DataSource as DataView).Table;
                }
                else if (dg.DataSource is DataTable)
                {
                    dt = dg.DataSource as DataTable;
                }
                else if (dg.DataSource is DataSet)
                {
                    dt = (dg.DataSource as DataSet).Tables[0];
                }
                return dt;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        private void btnStartPick_Click(object sender, EventArgs e)
        {
            try
            {
                this.lblMessage.Text = string.Empty;
                Cursor.Current = Cursors.WaitCursor;
                DataTable dbox = DT(dataGrid1);
                if (dbox == null || dbox.Rows.Count==0)
                {
                    this.lblMessage.Text = "请扫描箱号！！！";
                    this.txtOrderNumber.SelectAll();
                    Cursor.Current = Cursors.Default;
                    return;
                }

                ArrayList list = new ArrayList();
                string boxNo = "";
                string orderlist = "";
                for (int i = 0; i < dbox.Rows.Count; i++)
                {
                    if (boxNo != "")
                    {
                        boxNo += ",";
                    }
                    boxNo += dbox.Rows[i][0].ToString();

                    DataTable userAll = CC.Singleton().service().GetUserOrder(dbox.Rows[i][2].ToString());

                    if (userAll != null && userAll.Rows.Count > 0 && userAll.Rows[0][3].ToString() != mainForm._logUser.LOGIN_NAME.ToString())
                    {
                        this.lblMessage.Text = dbox.Rows[i][2].ToString() + "订单正在被" + userAll.Rows[0][3].ToString().Trim() + "拣货";
                        dbox.Rows.Remove(dbox.Rows[i]);
                        dataGrid1.DataSource = dbox;
                        this.txtOrderNumber.SelectAll();
                        Cursor.Current = Cursors.Default;
                        return;
                    }
                    if (orderlist != "")
                    {
                        orderlist += ",";
                    }
                    orderlist += dbox.Rows[i][2].ToString();
                }

                DataTable dt = CC.Singleton().service().SelectOrderBoxList(orderlist, Convert.ToDouble(mainForm._logUser.ID), boxNo);
                foreach (DataRow item in dt.Rows)
                {
                    string NAME = item["LOGINNAME"].ToString();
                    string a = item["PICK_ID"].ToString();
                    string b = item["QITEM"].ToString();
                    if (!item["PICK_ID"].ToString().Equals(item["TICKET_ID"].ToString()) && !item["QITEM"].ToString().Equals(item["DITEM"].ToString()))
                    {
                        dt.TableName = "NOPICK";
                        break;
                    }
                  
                    if (item["ORDER_STATUS"].ToString() == "BL" || item["ORDER_STATUS"].ToString() == "PI")
                    {
                        list.Add(1);
                    }
                    if (list.Count == dt.Rows.Count)
                    {
                        dt.TableName = "PICKING";
                        break;
                    }                   
                    else
                    {
                        dt.TableName = "OrderList";
                    }
                }

               
                if (dt.Rows.Count == 0)
                {
                    this.lblMessage.Text = "该订单不存在！";
                    this.txtOrderNumber.SelectAll();
                    Cursor.Current = Cursors.Default;
                    return;
                }

                if (getCount(dt) != dbox.Rows.Count)
                {
                    this.lblMessage.Text = " 部分订单已完成";
                    this.txtOrderNumber.SelectAll();
                    Cursor.Current = Cursors.Default;
                    return;
                }


                NewPickScan scan = new NewPickScan(dt, orderlist, this, boxNo);
                 //NewPickScan scan = new NewPickScan(dt, orderlist, this);
                
                scan.ShowDialog();
            }
            catch (Exception ex)
            {
                this.lblMessage.Text = ex.Message;
                lblMessage.Text = lblMessage.Text.Replace("服务器无法处理请求。 --->", "");
                Cursor.Current = Cursors.Default;
                return;
            }
        }
        private int getCount(DataTable dt)
        {
            Hashtable keyTable = new Hashtable();
            foreach(DataRow dr in dt.Rows)
            {
                if (!keyTable.Contains(dr[1].ToString() + dr[30].ToString()))
                {
                    keyTable.Add(dr[1].ToString() + dr[30].ToString(),dr[1].ToString() + dr[30].ToString());
                }
            }
            return keyTable.Count;
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}