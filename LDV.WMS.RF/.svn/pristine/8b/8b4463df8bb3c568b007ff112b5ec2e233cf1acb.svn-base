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
    public partial class PartsQuery : Form
    {
        public PartsQuery()
        {
            InitializeComponent();
            txtWareHouse.Focus();
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            //查询 CC.Singleton().service()
            labMessage.Text = string.Empty;
            this.dgList.DataSource = null;
            string ItemCode=txtPartCode.Text.ToString();
            string LocCode=txtWareHouse.Text.ToString();
            if (LocCode == string.Empty && ItemCode == string.Empty)
            {
                labMessage.Text = "库位跟零件必须输入一个!";
                txtWareHouse.Focus();
                return;
            }
            try
            {
                DataTable Order = CC.Singleton().service().QueryPartQty(LocCode, ItemCode, mainForm._logUser.ID.ToString());

                if (Order.Rows.Count < 1)
                {
                    labMessage.Text = "未查询到数据!";
                    return;
                }
                Order.TableName = "OrderList";
                this.dgList.DataSource = Order;
                txtWareHouse.SelectAll();
            }
            catch (Exception ex)
            {
                labMessage.Text = "网络错误:" + ex.Message;
                return;
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            //返回
            this.Close();
        }

        private void menuQuery_Click(object sender, EventArgs e)
        {
            btnQuery_Click(null, null);
        }

        private void menuBack_Click(object sender, EventArgs e)
        {
            btnBack_Click(null, null);
        }

        private void txtWareHouse_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)    //Enter
            {
                txtPartCode.Focus();
            }
        }

        private void txtPartCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)    //Enter
            {
                btnQuery_Click(null, null);
            }
        }
    }
}