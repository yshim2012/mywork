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
    public partial class UserEdit : Form
    {
        public UserEdit()
        {
            InitializeComponent();

            this.txtLoginName.Text = mainForm._logUser.LOGIN_NAME.Trim();
        }

        /// <summary>
        /// 确定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCommit_Click(object sender, EventArgs e)
        {
            this.UpdatePWD();
        }

        /// <summary>
        /// 返回
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 确定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuItem1_Click(object sender, EventArgs e)
        {
            this.UpdatePWD();

        }

        /// <summary>
        /// 返回
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuItem2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 修改密码
        /// </summary>
        private void UpdatePWD()
        {
            if (this.CheckInfo())
            {
                try
                {
                    string Mess = string.Empty;
                    bool isSucess = CC.Singleton().service().UpdatePwd(mainForm._logUser.ID.Value, this.txtNewPWD.Text.Trim(), out Mess);
                    if (isSucess == true)
                        mainForm._logUser.ENCRYPTED_PASSWORD = this.txtNewPWD.Text.Trim();
                    this.lblMessage.Text = Mess;
                }
                catch (Exception ex)
                {
                    lblMessage.Text = "网络错误:" + ex.Message;
                    return;
                }
            }
        }

        private bool CheckInfo()
        { 
            if (this.txtOldPWD.Text.Trim() == string.Empty)
            {
                this.lblMessage.Text = "请输入旧密码";
                this.txtOldPWD.Focus();
                return false;
            }
            if (this.txtNewPWD.Text.Trim() == string.Empty)
            {
                this.lblMessage.Text = "请输入新密码";
                this.txtNewPWD.Focus();
                return false;
            }
            if (this.txtRePWD.Text.Trim() == string.Empty)
            {
                this.lblMessage.Text = "请输入确认密码";
                this.txtRePWD.Focus();
                return false;
            }

            if (this.txtOldPWD.Text.Trim() != mainForm._logUser.ENCRYPTED_PASSWORD)
            {
                this.lblMessage.Text = "旧密码不正确，请重新输入";
                this.txtOldPWD.Text = string.Empty;
                this.txtNewPWD.Text = string.Empty;
                this.txtRePWD.Text = string.Empty;
                this.txtOldPWD.Focus();
                return false;
            }

            if (this.txtRePWD.Text.Trim() != this.txtNewPWD.Text.Trim())
            {
                this.lblMessage.Text = "二次输入的密码不一致";
                this.txtNewPWD.Text = string.Empty;
                this.txtRePWD.Text = string.Empty;
                this.txtNewPWD.Focus();
                return false;
            }

            return true;
        }

        private void txtOldPWD_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)    //Enter
            {
                txtNewPWD.Focus();
            }
        }

        private void txtNewPWD_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)    //Enter
            {
                txtRePWD.Focus();
            }
        }

        private void txtRePWD_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)    //Enter
            {
                btnCommit_Click(null, null);
            }
        }
    }
}