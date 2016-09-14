using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace YTWMS.RFClient
{
    /// <summary>
    /// 进入配制窗口前的密码验证窗口类
    /// </summary>
    public partial class ConfigLoginForm : Form
    {
        private Form parentForm;

        public ConfigLoginForm(Form parentForm)
        {
            InitializeComponent();
            this.parentForm = parentForm;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            this.lbMessage.Text = string.Empty;
            if (this.txtPassword.Text.Trim() == string.Empty)
            {
                this.lbMessage.Text = "请输入密码";
                this.txtPassword.Focus();
            }
            else if (this.txtPassword.Text != "123123")
            {
                this.lbMessage.Text = "密码错误";
                this.txtPassword.Focus();
            }
            else
            {
                ConfigForm config = new ConfigForm(this.parentForm);
                config.ShowDialog();
                this.parentForm.Show();
                this.Close();
                this.Dispose();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.parentForm.Show();
            this.Close();
            this.Dispose();
        }
    }
}