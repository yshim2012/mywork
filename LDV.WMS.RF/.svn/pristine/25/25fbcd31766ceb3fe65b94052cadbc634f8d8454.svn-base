using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Launcher
{
    public partial class configLoginForm : Form
    {
        updateClientForm form;
        public configLoginForm(updateClientForm form)
        {
            InitializeComponent();
            this.form = form;
            txtPassword.Focus();
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text.Trim() == "123123")
            {
                configForm myForm = new configForm(this.form);
                myForm.Show();
                this.Close();
            }
            else
            {
                txtPassword.Text = string.Empty;
                txtPassword.Focus();
                MessageBox.Show("密码错误");
            }            
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                this.btnConfirm_Click(this, new EventArgs());
        }
    }
}