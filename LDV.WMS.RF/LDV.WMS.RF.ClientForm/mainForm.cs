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
    public partial class mainForm : Form
    {
        public static User _logUser;

        public mainForm(User logUser)
        {
            InitializeComponent();

            _logUser = logUser;
        }

        /// <summary>
        /// 返回
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuItem2_Click(object sender, EventArgs e)
        {
            LogonForm frm = new LogonForm();
            this.Close();
            frm.ShowDialog();
            
        }

        /// <summary>
        /// 收发货管理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPickTask_Click(object sender, EventArgs e)
        {
            ReceivingOutManager frm = new ReceivingOutManager();
            frm.ShowDialog();
        }

        /// <summary>
        /// 盘点管理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCheckTask_Click(object sender, EventArgs e)
        {
            InventoryMain inventoryMain = new InventoryMain();
            inventoryMain.ShowDialog();
        }

        /// <summary>
        /// 数据查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDataQuery_Click(object sender, EventArgs e)
        {
            DataQueryMain main = new DataQueryMain();
            main.ShowDialog();
        }

        /// <summary>
        /// 个人密码修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpDatePWD_Click(object sender, EventArgs e)
        {
            UserEdit frm = new UserEdit();
            frm.ShowDialog();
        }
    }
}