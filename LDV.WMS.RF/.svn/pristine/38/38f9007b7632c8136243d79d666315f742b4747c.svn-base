using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Xml;
using System.Xml.Linq;
using System.Reflection;

namespace Launcher
{
    public partial class updateClientForm : Form
    {
        string server = "192.168.1.121";
        string serverTemplate = "http://{0}/LdvRfWebService.asmx";
        public string path = "\\Program files\\Launcher";

        public updateClientForm()
        {
            InitializeComponent();
            initConfig();
        }

        private void btUpdate_Click(object sender, EventArgs e)
        {
            //更新应用
            this.btUpdate.Enabled = false;
            this.updateDLL();
            this.btUpdate.Enabled = true;
        }

        private void btStart_Click(object sender, EventArgs e)
        {
            //进入系统
            this.btStart.Enabled = false;
            callMainForm();
            this.btStart.Enabled = true;
        }

        private void menuExit_Click(object sender, EventArgs e)
        {
            //退出系统
            try
            {                
                this.Dispose();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void menuConfig_Click(object sender, EventArgs e)
        {
            try
            {
                //配置
                configLoginForm form = new configLoginForm(this);
                form.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        #region 加载应用，执行登录
        private void callMainForm()
        {
            //this.lblMessage.Text += "\n\n加载应用...";
            //Dynamic Call Form using Assembly
            Form frm = new Form();
            try
            {
                Assembly assembly = Assembly.LoadFrom(@path + "\\LDV.WMS.RF.ClientForm.dll");
                frm = assembly.CreateInstance(assembly.GetName().Name + ".LogonForm") as Form;
                frm.ShowDialog();
            }
            catch (Exception e)
            {
                MessageBox.Show("加载程序失败！" + e.Message);
                this.Close();
            }
            finally
            {
                if (!frm.IsDisposed)
                {
                    frm.Dispose();
                }
            }
        }
        #endregion

        #region 初始化
        public void initConfig()
        {
            path = Assembly.GetExecutingAssembly().ManifestModule.FullyQualifiedName;
            path = path.Substring(0, path.LastIndexOf('\\'));

            XmlDocument config = new XmlDocument();
            config.Load(path + "\\files.config.xml");

            this.server = string.Format(serverTemplate, config.GetElementsByTagName("serverURL")[0].InnerText);

            this.lblMessage.Text = "设备：" + System.Net.Dns.GetHostName();
            //this.lblMessage.Text += "\n" + GetDeviceID();

            this.lblMessage.Text += "\n服务器：" + config.GetElementsByTagName("serverURL")[0].InnerText;

            this.lblMessage.Text += "\n当前版本：" + config.GetElementsByTagName("Version")[0].InnerText;
        }
        #endregion

        #region 更新程序
        private void updateDLL()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                this.lblMessage.Text = "\n检查文件更新情况...";
                string version = CC.Singleton().service().GetServiceVersion();
                string clientVersion = this.GetVersion();
                if (clientVersion.CompareTo(version) >= 0)
                {
                    this.lblMessage.Text += "\n无须更新（当前已是最高版本：" + clientVersion + "）";
                }
                else
                {
                    this.lblMessage.Text += "\n本地版本：" + clientVersion + "；服务器版本：" + version;

                    string[] files = CC.Singleton().service().GetFileNames();
                    int i = 0;
                    foreach (string f in files)
                    {
                        if (f == "files.config.xml")
                            continue;

                        i++;
                        this.lblMessage.Text += "\n" + f;

                        #region 下载并保存文件
                        byte[] bytes = CC.Singleton().service().dowloadFile(f);

                        FileStream fs = null;
                        try
                        {
                            fs = new FileStream(path +"\\"+ f, FileMode.Create);
                            fs.Write(bytes, 0, bytes.Length);
                            fs.Close();
                            fs = null;
                        }
                        catch (Exception e)
                        {
                            this.lblMessage.Text += "\n错误：" + e.Message;
                            this.btUpdate.Enabled = true;
                            return;
                        }
                        finally
                        {
                            if (fs != null)
                                fs.Close();
                            fs = null;

                            this.SaveSersion(clientVersion);
                        }
                        #endregion
                    }

                    if (i == 0)
                        this.lblMessage.Text += "\n没有更新文件";
                    else
                    {
                        this.lblMessage.Text += "\n文件更新成功";
                        this.SaveSersion(version);
                    }
                }
            }
            catch (Exception ex)
            {
                this.lblMessage.Text += "\n异常" + ex.Message;
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }
        #endregion

        private string GetVersion()
        {
            string version = "1.0.0.0";
            try
            {
                XElement root = XElement.Load(this.path + "\\files.config.xml");
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

        private void SaveSersion(string version)
        {
            string configFile = this.path + "\\files.config.xml";

            XmlDocument config = new XmlDocument();
            config.Load(configFile);
            config.GetElementsByTagName("Version")[0].InnerText = version;
            config.Save(configFile);
        }
    }
}