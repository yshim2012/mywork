using System;
using System.Linq;
using System.Xml.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Domain.Services;
using ClientForward;
using System.Reflection;

namespace LDV.WMS.RF.ClientForm
{
    public partial class LogonForm : Form
    {
        public LogonForm()
        {
            InitializeComponent();
        }

        private void btnExist_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLogon_Click(object sender, EventArgs e)
        {
            this.lbMessage.Text = string.Empty;
            Cursor.Current = Cursors.WaitCursor;
            string LoginName = this.txtUserName.Text.Trim().PadRight(30, ' ');
            string pwd = this.txtPwd.Text.Trim();
            if (string.IsNullOrEmpty(LoginName) || string.IsNullOrEmpty(pwd))
            {
                this.lbMessage.Text = "用户名或密码不能为空！";
            }
            else
            {
                try
                {
                    string version = CC.Singleton().service().GetServiceVersion();
                    string clientVersion = this.GetVersion();
                    if (clientVersion.CompareTo(version) < 0)
                    {
                        this.lbMessage.Text += "有新版本，请退出重新进入系统，进行更新";
                        Cursor.Current = Cursors.Default;
                        return;
                    }

                    User LogUser = CC.Singleton().service().login(LoginName, pwd);
                    if (LogUser != null)
                    {
                        mainForm mform = new mainForm(LogUser);
                        mform.Show();
                        this.Close();
                    }
                    else
                    {
                        lbMessage.Text = "用户名或密码错误!";
                        //this.txtPwd.Text = string.Empty;
                        //txtUserName.Text = string.Empty;
                        //txtUserName.Focus();
                        txtPwd.SelectAll();
                        txtPwd.Focus();
                    }
                }
                catch (Exception ex)
                {
                    lbMessage.Text = "登陆异常:" + ex.Message;
                }
            }
            Cursor.Current = Cursors.Default;
        }

        private string GetVersion()
        {
            string version = "1.0.0.0";
            try
            {
                string path = string.Empty;
                path = Assembly.GetExecutingAssembly().ManifestModule.FullyQualifiedName;
                path = path.Substring(0, path.LastIndexOf('\\'));

                XElement root = XElement.Load(path + "\\files.config.xml");
                var vs = from v in root.Descendants("Version") select v.Value;
                foreach (var v in vs)
                    version = v;

                return version;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void LogonForm_Load(object sender, EventArgs e)
        {
            this.lbSersion.Text = "版本 V" + this.GetVersion();
        }

        private void txtPwd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)    //Enter
            {
                btnLogon_Click(null, null);
                return;
            }
        }

        private void txtUserName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)    //Enter
            {
                txtPwd.Focus();
            }
        }
    }
}