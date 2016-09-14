using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.Xml;

namespace YTWMS.RFStart
{
    public partial class Form1 : Form
    {
        public string path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
        public string TempPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase) + "\\Temp";

        ////方法1
        //string appPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
        ////方法2
        //string appPath2 = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().ManifestModule.FullyQualifiedName);

        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 启动系统
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            Form frm = new Form();
            try
            {
                if (Directory.Exists(this.TempPath))
                {
                    string[] files = Directory.GetFiles(this.TempPath);
                    foreach (string f in files)
                    {
                        string fName = f.Substring(f.LastIndexOf("\\") + 1);
                        if (fName == "files.config.xml")
                        {
                            //更新版本信息
                            XmlDocument docServ = new XmlDocument();
                            docServ.Load(this.TempPath + "\\files.config.xml");
                            string ver = docServ.GetElementsByTagName("Version")[0].InnerText;

                            XmlDocument docLoc = new XmlDocument();
                            docLoc.Load(this.path + "\\files.config.xml");
                            docLoc.GetElementsByTagName("Version")[0].InnerText = ver;
                            docLoc.Save(this.path + "\\files.config.xml");

                            File.Delete(f);
                        }
                        else if (fName == "YTWMS.exe")
                        {
                            File.Delete(f);
                        }
                        else
                        {
                            if (File.Exists(f))
                            {
                                File.Copy(f, this.path + "\\" + fName, true);
                                File.Delete(f);
                            }
                        }
                    }


                }

                Assembly assembly = Assembly.LoadFrom(@path + "\\YTWMS.RFClient.dll");
                frm = assembly.CreateInstance(assembly.GetName().Name + ".LoginFrom") as Form;
                //frm = assembly.CreateInstance(assembly.GetName().Name + ".SortSend") as Form;
                frm.ShowDialog();
                frm.Activate();
            }
            catch (Exception ex)
            {
                MessageBox.Show("系统崩溃，请联系系统管理员！"+ex.Message);                
            }
            finally
            {
                if (frm != null)
                {
                    frm.Close();
                    frm.Dispose();
                }
                this.Close();
            }
        }
    }
}