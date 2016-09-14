using System;
using System.Xml;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace YTWMS.RFClient
{
    public partial class ConfigForm : Form
    {
        private string Path;
        private Form parentForm;

        public ConfigForm()
        {
            InitializeComponent();
            this.Path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
        }
        public ConfigForm(Form parentForm)
        {
            InitializeComponent();
            this.Path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
            this.parentForm = parentForm;
        }
        private void ConfigForm_Load(object sender, EventArgs e)
        {
            try
            {
                string ConfigFile = this.Path + "\\files.config.xml";

                XmlDocument doc = new XmlDocument();
                doc.Load(ConfigFile);
                this.txtServer.Text = doc.GetElementsByTagName("serverURL")[0].InnerText;
            }
            catch (Exception ex)
            {
                this.lbMessage.Text = ex.Message;
            }
        }

        /// <summary>
        /// 核验并保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            this.lbMessage.Text = string.Empty;
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                if (this.txtServer.Text.Trim() == string.Empty)
                {
                    this.lbMessage.Text = "请输入服务地址";
                    this.txtServer.Focus();
                }
                else
                {
                    ExceService.CheckService(this.txtServer.Text);
                }
            }
            catch (Exception ex)
            {
                this.lbMessage.Text = "无法连接到服务器";
                return;
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }


            try
            {
                string ConfigFile = this.Path + "\\files.config.xml";

                XmlDocument doc = new XmlDocument();
                doc.Load(ConfigFile);
                doc.GetElementsByTagName("serverURL")[0].InnerText = this.txtServer.Text.Trim();
                doc.Save(ConfigFile);

                this.lbMessage.Text = "保存成功";
            }
            catch (Exception XmlEx)
            {
                this.lbMessage.Text = XmlEx.Message;
            }
        }

        /// <summary>
        /// 退出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            //this.Close();  
            this.parentForm.Show();
            this.Close();
            this.Dispose();
        }
    }
}