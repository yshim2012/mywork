using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace YTWMS.RFClient
{
    public partial class DownLoadForm : Form
    {
        private string TempPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase) + "\\Temp";
        private int Flag = 0;//下载标实:0，未下载；1，下载成功；-1，下载失败
        public DownLoadForm()
        {
            InitializeComponent();
            this.Flag = 0;//默认:未下载
        }

        /// <summary>
        /// 下载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDownLaod_Click(object sender, EventArgs e)
        {
            this.txtMessage.Text = "开始下载更新...";
            this.Flag = 1;//假设:下载成功
            try
            {
                if (!Directory.Exists(this.TempPath))
                    Directory.CreateDirectory(this.TempPath);

                string[] files = ExceService.GetAllFilesForDownLoad();
                foreach (string f in files)
                {
                    this.DownLoadFile(f);
                }

                this.txtMessage.Text += "\r\n下载更新完成！";
                this.btnDownLoad.Enabled = false;
            }
            catch (Exception)
            {
                this.txtMessage.Text += "\r\n获取文件名失败，请检查服务器地址";
                this.Flag = -1;//下载失败
            }
        }

        /// <summary>
        /// 退出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();

            if (this.Flag == 0)
            {
                this.DialogResult = DialogResult.Cancel;
            }
            else if (this.Flag == -1)
            {
                //清空下载目录中的所有文件
                if (Directory.Exists(this.TempPath))
                {
                    string[] Files = Directory.GetFiles(this.TempPath);
                    foreach (string f in Files)
                    {
                        if (File.Exists(f))
                            File.Delete(f);
                    }
                }

                this.DialogResult = DialogResult.Cancel;
            }
            else
            {
                this.DialogResult = DialogResult.OK;
            }
        }

        /// <summary>
        /// 下载并
        /// </summary>
        /// <param name="FileName"></param>
        private void DownLoadFile(string FileName)
        {
            this.txtMessage.Text += "\r\n正在下载:" + FileName;
            try
            {
                byte[] bytes = ExceService.DownLoadFile(FileName);

                FileStream fs = null;
                try
                {
                    fs = new FileStream(this.TempPath + "\\" + FileName, FileMode.Create);
                    fs.Write(bytes, 0, bytes.Length);

                    this.txtMessage.Text += "\r\n成功！";
                }
                catch (Exception e)
                {
                    this.txtMessage.Text += "\r\n失败:" + e.Message;
                    this.Flag = -1;//下载失败
                }
                finally
                {
                    if (fs != null)
                        fs.Close();
                    fs = null;
                }
            }
            catch (Exception ex)
            {
                this.txtMessage.Text += "\r\n失败:" + ex.Message;
                this.Flag = -1;//下载失败
            }
        }
    }
}