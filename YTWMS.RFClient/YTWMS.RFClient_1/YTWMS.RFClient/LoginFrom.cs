using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using SalesPoint.Device.Scan;
using SalesPoint.Device.Core;
using System.Threading;

namespace YTWMS.RFClient
{
    /// <summary>
    /// 登入窗口
    /// </summary>
    public partial class LoginFrom : Form
    {       
        public LoginFrom()
        {
            InitializeComponent();
        }

        
        /// <summary>
        /// Load事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoginFrom_Load(object sender, EventArgs e)
        {

            //this.txtUserName.Text = "ws-admin";
            //this.txtPassword.Text = "password!1";

            this.txtUserName.Focus();
            //本地版本信息
            string Path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase) + "\\files.config.xml";
            
            XmlDocument doc = new XmlDocument();
            doc.Load(Path);
            string LocVersion = doc.GetElementsByTagName("Version")[0].InnerText;
            this.lblVersion.Text = "版本:" + LocVersion;

            try
            {
                string SerVersion = ExceService.GetServiceVersion();
                //MessageBox.Show(SerVersion);
                if (LocVersion != SerVersion)
                {
                    this.lbMessage.Text = "有较新的服务端版本:" + SerVersion;                   
                }
            }
            catch (Exception ex)
            {
                this.lbMessage.Text = "服务出现问题，请检查服务地址";
            }
        }

        #region 回车事件
        /// <summary>
        /// 密码    回车事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                this.btnLogin_Click(null, null);
            }
        }
        #endregion

        #region 按钮事件

        /// <summary>
        /// 退出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 登入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLogin_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            this.lbMessage.Text = string.Empty;
            if (string.IsNullOrEmpty(this.txtUserName.Text.Trim()))
            {
                this.lbMessage.Text = "请输入用户";
                this.txtUserName.Focus();
                Cursor.Current = Cursors.Default;
            }
            else if (string.IsNullOrEmpty(this.txtPassword.Text.Trim()))
            {
                this.lbMessage.Text = "请输入密码";
                this.txtPassword.Focus();
                Cursor.Current = Cursors.Default;
            }
            else
            {
                Cursor.Current = Cursors.WaitCursor;
                try
                {
                    RFService.LtUser user = ExceService.Login(this.txtUserName.Text.Trim(), this.txtPassword.Text.Trim());
                    if (user == null)
                    {
                        this.txtUserName.Focus();
                        this.lbMessage.Text = "登入失败:用户或密码错误";
                        Cursor.Current = Cursors.Default;
                    }
                    else
                    {
                        LoginInfo info = LoginInfo.GetInstance();
                        info.SetLoginUser(user);

                        Cursor.Current = Cursors.Default;

                        MenuForm form = new MenuForm(this);
                        form.ShowDialog();

                        this.txtUserName.Text = string.Empty;
                        this.txtPassword.Text = string.Empty;
                    }
                }
                catch (Exception ex)
                {
                    this.lbMessage.Text = "无法连接到服务器！";
                }
                finally
                {
                    Cursor.Current = Cursors.Default;
                }
            }
        }
        #endregion

        #region 菜单事件
        /// <summary>
        /// 系统更新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mItemUpdate_Click(object sender, EventArgs e)
        {
            DownLoadForm form = new DownLoadForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("请退出系统，重新起动！");
                this.Close();
            }
        }

        /// <summary>
        /// 系统设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mItemConfig_Click(object sender, EventArgs e)
        {
            ConfigLoginForm configLoginForm = new ConfigLoginForm(this);            
            configLoginForm.Show();
            this.Hide();
        }
        #endregion
    }
}