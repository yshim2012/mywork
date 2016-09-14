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
    public partial class PickCheckOrder : Form
    {
        public PickCheckOrder()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 开始拣货
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //private void menuItem1_Click(object sender, EventArgs e)
        //{
        //    this.lblMessage.Text = string.Empty;
        //    Cursor.Current = Cursors.WaitCursor;
        //    string OrderNumber = this.txtOrderNumber.Text.Trim();
        //    DataTable dt = CC.Singleton().service().SelectOrder(OrderNumber, mainForm._logUser.LOGIN_NAME,Convert.ToDouble(mainForm._logUser.ID));
            
        //    foreach (DataRow item in dt.Rows)
        //    {
        //        string NAME = item["LOGINNAME"].ToString();
        //        string a = item["PICK_ID"].ToString();
        //        string b = item["QITEM"].ToString();
        //        if (!item["PICK_ID"].ToString().Equals(item["TICKET_ID"].ToString()) && !item["QITEM"].ToString().Equals(item["DITEM"].ToString()))
        //        {
        //            dt.TableName = "NOPICK";
        //            break;
        //        }
        //        //|| item["PICK_STATUS"].ToString() != "AC"
        //        if (item["ORDER_STATUS"].ToString() == "BL" || item["ORDER_STATUS"].ToString()=="PI")
        //        {
        //            dt.TableName = "PICKING";
        //            break;
        //        }
        //        if (item["LOGINNAME"].ToString().Trim() != mainForm._logUser.LOGIN_NAME.ToString().Trim() && item["USER_PICK"].ToString() ==OrderNumber)
        //        {
        //            dt.TableName = item["LOGINNAME"].ToString();
        //            break;
        //        }
        //        else
        //        {
        //            dt.TableName = "OrderList";
        //        }
        //    }

        //    if (OrderNumber == string.Empty)
        //    {
        //        this.lblMessage.Text = "订单号不能为空";
        //        Cursor.Current = Cursors.Default;
        //        return;
        //    }
        //    if (dt.Rows.Count == 0)
        //    {
        //        this.lblMessage.Text = "该订单不存在！";
        //        this.txtOrderNumber.SelectAll();
        //        Cursor.Current = Cursors.Default;
        //        return;
        //    }
        //    if (dt.TableName.Equals("NOPICK"))
        //    {
        //        this.lblMessage.Text = "该订单还未生成拣货单";
        //        this.txtOrderNumber.SelectAll();
        //        Cursor.Current = Cursors.Default;
        //        return;
        //    }
        //    if (dt.TableName.Equals("PICKING"))
        //    {
        //        this.lblMessage.Text = "该订单已完成";
        //        this.txtOrderNumber.SelectAll();
        //        Cursor.Current = Cursors.Default;
        //        return;
        //    }
        //    if (!dt.TableName.Equals("OrderList") && !dt.TableName.Equals("PICKING") && !dt.TableName.Equals("NOPICK"))
        //    {
        //        this.lblMessage.Text = "该订单正在被" + dt.TableName + "拣货";
        //        this.txtOrderNumber.SelectAll();
        //        Cursor.Current = Cursors.Default;
        //        return;
        //    }
        //    //dt.TableName = "OrderList";
        //    this.dataGrid1.DataSource = dt;
        //    PickScan scan = new PickScan(dt, OrderNumber,this);
        //    this.Hide();
        //    scan.ShowDialog();
            
        //}

        ///// <summary>
        ///// 返回
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void menuItem2_Click(object sender, EventArgs e)
        //{
        //    ReceivingOutManager manager = new ReceivingOutManager();
        //    this.Close();
        //    manager.Show();
            
        //}
       

        private void PickCheckOrder_Load(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = CC.Singleton().service().SelectOrder(mainForm._logUser.LOGIN_NAME.ToString(), Convert.ToDouble(mainForm._logUser.ID));
                dt.TableName = "OrderList";
                this.dataGrid1.DataSource = dt;
                if (dt.Rows.Count > 0)
                {
                    this.txtOrderNumber.Text = dt.Rows[0]["PICK_TICKET_CODE"].ToString().Trim();
                }
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
                btnStartPick_Click(null, null);
            }
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


        private void btnStartPick_Click(object sender, EventArgs e)
        {
            try
            {
                this.lblMessage.Text = string.Empty;
                Cursor.Current = Cursors.WaitCursor;
                string OrderNumber = this.txtOrderNumber.Text.Trim();
                if (OrderNumber == string.Empty)
                {
                    this.lblMessage.Text = "订单号不能为空";
                    Cursor.Current = Cursors.Default;
                    return;
                }
                ArrayList list = new ArrayList();
                DataTable dt = CC.Singleton().service().SelectOrder(OrderNumber, mainForm._logUser.LOGIN_NAME, Convert.ToDouble(mainForm._logUser.ID));
                //ArrayList list3 = new ArrayList();
                foreach (DataRow item in dt.Rows)
                {
                    string NAME = item["LOGINNAME"].ToString();
                    string a = item["PICK_ID"].ToString();
                    string b = item["QITEM"].ToString();
                    //string c = item["ORDER_QTY"].ToString();
                    //string d = item["PICK_QTY"].ToString();
                    if (!item["PICK_ID"].ToString().Equals(item["TICKET_ID"].ToString()) && !item["QITEM"].ToString().Equals(item["DITEM"].ToString()))
                    {
                        dt.TableName = "NOPICK";
                        break;
                    }
                    //if (item["ORDER_QTY"].ToString() == item["PICK_QTY"].ToString())
                    //{
                    //    list3.Add(1);
                    //    continue;
                    //}
                    //|| item["PICK_STATUS"].ToString() != "AC"
                    //if (item["ORDER_STATUS"].ToString() == "BL" || item["ORDER_STATUS"].ToString() == "PI")
                    //{
                    //    dt.TableName = "PICKING";
                    //    break;
                    //}
                    if (item["ORDER_STATUS"].ToString() == "BL" || item["ORDER_STATUS"].ToString() == "PI")
                    {
                        list.Add(1);
                    }
                    if (list.Count == dt.Rows.Count)
                    {
                        dt.TableName = "PICKING";
                        break;
                    }
                    if (item["LOGINNAME"].ToString().Trim() != mainForm._logUser.LOGIN_NAME.ToString().Trim() && item["USER_PICK"].ToString() == OrderNumber)
                    {
                        dt.TableName = item["LOGINNAME"].ToString();
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
                if (dt.TableName.Equals("NOPICK"))
                {
                    this.lblMessage.Text = "该订单还未生成拣货单";
                    this.txtOrderNumber.SelectAll();
                    Cursor.Current = Cursors.Default;
                    return;
                }
                if (dt.TableName.Equals("PICKING"))
                {
                    this.lblMessage.Text = "该订单已完成";
                    this.txtOrderNumber.SelectAll();
                    Cursor.Current = Cursors.Default;
                    return;
                }
                //if (list3.Count !=dt.Rows.Count)
                //{
                //    this.lblMessage.Text = "该订单分配拣货零件已完成";
                //    this.txtOrderNumber.SelectAll();
                //    Cursor.Current = Cursors.Default;
                //    return;
                //}
                if (!dt.TableName.Equals("OrderList") && !dt.TableName.Equals("PICKING") && !dt.TableName.Equals("NOPICK"))
                {
                    this.lblMessage.Text = "该订单正在被" + dt.TableName.ToString().Trim() + "拣货";
                    this.txtOrderNumber.SelectAll();
                    Cursor.Current = Cursors.Default;
                    return;
                }
                //dt.TableName = "OrderList";
                //this.dataGrid1.DataSource = dt;
                PickScan scan = new PickScan(dt, OrderNumber, this);
                //this.Hide();
                scan.ShowDialog();
            }
            catch (Exception ex)
            {
                this.lblMessage.Text = ex.Message;
                lblMessage.Text = lblMessage.Text.Replace("服务器无法处理请求。 --->", "");
                return;
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}