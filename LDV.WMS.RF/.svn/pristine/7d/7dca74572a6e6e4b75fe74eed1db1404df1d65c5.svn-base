using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ClientForward;

namespace LDV.WMS.RF.ClientForm
{
    public partial class ShipmentsOrderDetail : Form
    {
        DataTable Order;
        public ShipmentsOrderDetail(DataTable _Order)
        {
            InitializeComponent();
            Order = _Order;
            if (Order.Rows.Count > 0)
            {
                try
                {
                    Order.TableName = "OrderList";
                    dataGrid1.DataSource = Order;
                    txtCustomerName.Text = Order.Rows[0]["EXTEND_COLUMN_3"].ToString();
                    txtOrderNumber.Text = Order.Rows[0]["PICK_TICKET_CODE"].ToString();

                    try
                    {
                        CC.Singleton().service().UpdateUserState(double.Parse(mainForm._logUser.ID.ToString()), txtOrderNumber.Text, "CO");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("网络错误,请检查后重试!" + ex.Message);
                        Cursor.Current = Cursors.Default;
                        this.Close();
                    }

                    txtPackgeNumber.Focus();
                    Cursor.Current = Cursors.Default;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    Cursor.Current = Cursors.Default;
                    this.Close();
                }
                
            }
            else
            {
                MessageBox.Show("没有查询到数据!");
                this.Close();
                Cursor.Current = Cursors.Default;
            }
        }


        private void btnNextPart_Click(object sender, EventArgs e)
        {

            lblMessage.Text = string.Empty;
            //
            double PickQTYs = double.Parse(Order.Compute("SUM(PICKED_QTY)", "PICKED_QTY>0").ToString());
            double OrdeQtys = double.Parse(Order.Compute("SUM(ORDER_QTY)", "PICKED_QTY>0").ToString());
            double ShipQtys = double.Parse(Order.Compute("SUM(SHIP_QTY)", "PICKED_QTY>0").ToString());
            if (PickQTYs == OrdeQtys && PickQTYs == ShipQtys)
            {
                MessageBox.Show("出库全部完成,请返回主界面重新选择单据!");
                //this.Close();
                return;
            }
            if (txtPackgeNumber.Text.Trim() == string.Empty)
            {
                lblMessage.Text = "请输入包装箱号!";
                txtPackgeNumber.Focus();
                return;
            }
            else
            {
                try
                {
                    //Cursor.Current = Cursors.WaitCursor;
                    if (!CC.Singleton().service().IsUserLoginOtherDevice(mainForm._logUser.LOGIN_NAME, mainForm._logUser.EXTEND_COLUMN_0))
                    {
                        lblMessage.Text = "该账号已经在别处登陆!请重新登陆!";
                        return;
                    }
                    DataTable CPackge = CC.Singleton().service().CheckPackge(txtPackgeNumber.Text.Trim());
                    if (CPackge == null)
                    {
                        lblMessage.Text = "包装箱" + txtPackgeNumber.Text + "不存在，请重新输入!";
                        txtPackgeNumber.SelectAll();
                        return;
                    }
                    //if (CPackge.Rows[0]["WHSE_ID"] != DBNull.Value &&
                    //    CPackge.Rows[0]["WHSE_ID"].ToString() != Order.Rows[0]["WHSE_ID"].ToString())
                    if ((CPackge.Select("WHSE_ID IS NULL").Length + CPackge.Select("WHSE_ID =" + Order.Rows[0]["WHSE_ID"]).Length) < CPackge.Rows.Count)
                    {
                        lblMessage.Text = txtPackgeNumber.Text + "已经被其他客户使用,请重新输入!";
                        txtPackgeNumber.SelectAll();
                        return;
                    }                    
                    if (CPackge.Rows[0]["STATUS"].ToString().Equals("CL"))
                    {
                        lblMessage.Text = txtPackgeNumber.Text + "已出库,请重新输入!";
                        txtPackgeNumber.SelectAll();
                        return;
                    }
                    if ((CPackge.Select("PICK_TICKET_CODE IS NULL").Length + CPackge.Select("PICK_TICKET_CODE ='" + txtOrderNumber.Text+"'").Length) < CPackge.Rows.Count)
                    {
                        lblMessage.Text = txtPackgeNumber.Text + "已经被使用,请重新输入!";
                        txtPackgeNumber.SelectAll();
                        return;
                    }
                    bool isNew=false;
                    if (CPackge.Rows[0]["STATUS"].ToString().Equals("OP"))
                    {
                        isNew = true;
                    }
                    ShipmentsScan Scan = new ShipmentsScan(Order, txtPackgeNumber.Text.Trim(),
                        CPackge.Rows[0]["ID"].ToString(), txtOrderNumber.Text, txtCustomerName.Text, isNew);
                    if (Scan.ShowDialog() == DialogResult.OK)
                    {
                        Order = null;
                        string Mesg;
                        Order = CC.Singleton().service().LoadShipOrder(txtOrderNumber.Text, mainForm._logUser.ID.ToString(), out Mesg);
                        Order.TableName = "OrderList";
                        dataGrid1.DataSource = Order;
                    }
                    txtPackgeNumber.SelectAll();

                    
                    Cursor.Current = Cursors.Default;
                }
                catch (Exception ex)
                {
                    lblMessage.Text = "网络错误:" +ex.Message;
                    Cursor.Current = Cursors.Default;
                }
                    

            }
        }


        private void btnReturn_Click_1(object sender, EventArgs e)
        {
            //返回
            this.Close();
            try
            {
                CC.Singleton().service().UpdateUserState(double.Parse(mainForm._logUser.ID.ToString()), "", "");
            }
            catch (Exception ex)
            {
                MessageBox.Show("网络错误:" + ex.Message);
                this.Close();
            }
        }

        private void txtPackgeNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)    //Enter
            {
                btnNextPart_Click(null, null);
            }
        }

        private void dataGrid1_MouseUp(object sender, MouseEventArgs e)
        {
            dataGrid1.Select(dataGrid1.CurrentRowIndex);
        }
    }
}