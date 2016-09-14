using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace Launcher
{
    public partial class configForm : Form
    {
        updateClientForm form;
        public configForm(updateClientForm form)
        {
            InitializeComponent();
            this.form = form;

            string configFile = form.path + "\\files.config.xml";

            XmlDocument config = new XmlDocument();
            config.Load(configFile);
            txtServer.Text = config.GetElementsByTagName("serverURL")[0].InnerText;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtServer.Text.Trim() == string.Empty)
            {
                MessageBox.Show("服务器地址不能为空！");
                txtServer.Focus();
                return;
            }


            #region 检查参数是否正确
            try
            {
                System.Net.WebRequest myTest = System.Net.WebRequest.Create("http://" + txtServer.Text + "/LdvRfWebService.asmx");
                myTest.Timeout = 5000;
                System.Net.WebResponse myRespTest;
                myRespTest = myTest.GetResponse();
            }
            catch (Exception ex)
            {
                MessageBox.Show("无法连接到服务器，详细信息：" + ex.Message);
                txtServer.Focus();
                return;
            }
            #endregion

            #region 保存配置
            string configFile = form.path + "\\files.config.xml";

            XmlDocument config = new XmlDocument();
            config.Load(configFile);
            config.GetElementsByTagName("serverURL")[0].InnerText = txtServer.Text;
            config.Save(configFile);
            #endregion

            MessageBox.Show("配置保存完毕！");
            this.btClose_Click(sender, e);
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
            this.form.initConfig();
            this.form.Show();
        }

        private void txtServer_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnSave_Click(null, null);
            }
        }

    }
}