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
    public partial class ShipmentsCheckOrder : Form
    {
        public ShipmentsCheckOrder()
        {
            InitializeComponent();
            txtOrderNumber.Focus();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            lblMessage.Text = string.Empty;
            //确认
            if (txtOrderNumber.Text.Trim() == string.Empty)
            {
                lblMessage.Text = "请输入核料单号!";
                txtOrderNumber.Focus();
                return;
            }
            try
            {
                string Mesg;
                DataTable Order = CC.Singleton().service().LoadShipOrder(txtOrderNumber.Text.Trim(), mainForm._logUser.ID.ToString(), out Mesg);
                if (Order == null||Order.Rows.Count<1)
                {
                    lblMessage.Text = Mesg;
                    
                    ShipmentsCheckOrder_Load(null, null);
                    txtOrderNumber.SelectAll();
                    return;
                }
                else
                {
                    if (!CC.Singleton().service().IsUserLoginOtherDevice(mainForm._logUser.LOGIN_NAME, mainForm._logUser.EXTEND_COLUMN_0))
                    {
                        lblMessage.Text = "该账号已经在别处登陆!请重新登陆!";
                        return;
                    }
                    else
                    {
                        Cursor.Current = Cursors.WaitCursor;
                        Order.TableName = "OrderList";
                        ShipmentsOrderDetail SDeta = new ShipmentsOrderDetail(Order);
                        SDeta.ShowDialog();
                        txtOrderNumber.SelectAll();

                        //dataGrid1.CurrentRowIndex = 0;
                        
                    }
                }
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                lblMessage.Text = "网络错误:"+ex.Message;
            }
        }

        private void ShipmentsCheckOrder_Load(object sender, EventArgs e)
        {
            //打开窗口查询
            string Mesg;
            try
            {
                DataTable Order = CC.Singleton().service().LoadShipOrder(string.Empty, mainForm._logUser.ID.ToString(), out Mesg);
                if (Order == null)
                {
                    lblMessage.Text = Mesg;
                    return;
                }
                Order.TableName = "OrderList";
                dataGrid1.DataSource = Order;
                dataGrid1.Select(0);
                txtOrderNumber.Text = dataGrid1[0, 0].ToString();
                txtOrderNumber.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("网络错误!"+ex.Message);
                this.Close();
            }
        }

        private void dataGrid1_CurrentCellChanged(object sender, EventArgs e)
        {
            txtOrderNumber.Text = dataGrid1[dataGrid1.CurrentRowIndex, 0].ToString();
            txtOrderNumber.Focus();
            //txtOrderNumber.SelectAll();
        }

        private void txtOrderNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)    //Enter
            {
                btnOK_Click(null, null);
            }
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void menuItem1_Click(object sender, EventArgs e)
        {
            btnOK_Click(null, null);    
        }

        private void menuItem2_Click(object sender, EventArgs e)
        {
            btnReturn_Click(null, null);
        }

        private void dataGrid1_MouseUp(object sender, MouseEventArgs e)
        {
            dataGrid1.Select(dataGrid1.CurrentRowIndex);
            
        }
    }
}