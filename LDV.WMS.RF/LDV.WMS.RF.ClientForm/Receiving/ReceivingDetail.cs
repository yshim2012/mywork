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
    public partial class ReceivingDetail : Form
    {
        public ReceivingDetail()
        {
            InitializeComponent();
            txtReceivingNumber.Focus();
        }

        private void btnStartReceiving_Click(object sender, EventArgs e)
        {
            //开始收货
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
                if (data.TableName.Equals("OrderPQ"))
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
            if (data.TableName.Equals("OrderCL"))
            {
                lblMessage.Text = "收货单已完成!";
                txtReceivingNumber.SelectAll();
                data.TableName = "OrderList";
                this.dataGrid1.DataSource = data;
                Cursor.Current = Cursors.Default;
                return;
            }
            if (data.TableName.Equals("OrderRV"))
            {
                //判断是否有包装数据
                if (data.Select("PQQTY>0").Length == 0)
                {
                    lblMessage.Text = "请先进行包装！";
                    txtReceivingNumber.SelectAll();
                    data.TableName = "OrderList";
                    this.dataGrid1.DataSource = data;
                    Cursor.Current = Cursors.Default;
                    return;
                }
                else
                {
                    data.TableName = "OrderList";
                }
            }
            if (!data.TableName.Equals("OrderList"))
            {
                lblMessage.Text = "收货单正在被" + data.TableName+"收货!";
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
          //  ReceivingScan Scan = new ReceivingScan(data,OrderNumber,this);
          //  Scan.ShowDialog();
            txtReceivingNumber.SelectAll();
            //this.Close();
        }

        private void menuItem2_Click(object sender, EventArgs e)
        {
            //关闭窗口
            this.Close();
        }

        private void menuItem1_Click(object sender, EventArgs e)
        {
            btnStartReceiving_Click(null, null);
        }

        
        private void txtReceivingNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)    //Enter
            {
                btnStartReceiving_Click(null, null);
                return;
            }
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {

        }

        private void dataGrid1_MouseUp(object sender, MouseEventArgs e)
        {
            if (dataGrid1.CurrentRowIndex > 0)
            {
                dataGrid1.Select(dataGrid1.CurrentRowIndex);
            }
        }

        private void dataGrid1_CurrentCellChanged(object sender, EventArgs e)
        {

        }
    }
}