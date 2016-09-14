using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;
using System.IO;

namespace LDV.WMS.RF.UCWebService
{
    /// <summary>
    /// Service1 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
    // [System.Web.Script.Services.ScriptService]
    public class Service1 : System.Web.Services.WebService
    {

        private string path = System.Configuration.ConfigurationManager.AppSettings["PathToClientFiles"].ToString();
        //版本
        [WebMethod]
        public string GetVersion()
        {
            string version = "1.0.0.0";
            try
            {
                XElement root = XElement.Load(path + "files.config.xml");
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

        [WebMethod]
        public string[] GetAllFiles()
        {
            try
            {
                DirectoryInfo info = new DirectoryInfo(path);
                IList<string> list = GetFullPathFiles(info, string.Empty);

                string[] fnames = new string[list.Count];
                for (int i = 0; i < list.Count; i++)
                {
                    fnames[i] = list[i];
                }

                return fnames;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private IList<string> GetFullPathFiles(DirectoryInfo info, string DirName)
        {
            IList<string> list = new List<string>();
            FileInfo[] fInfo = info.GetFiles();
            foreach (FileInfo fi in fInfo)
            {
                if (DirName != string.Empty)
                    list.Add(DirName + "/" + fi.Name);
                else
                    list.Add(fi.Name);
            }

            DirectoryInfo[] childDirInfo = info.GetDirectories();
            foreach (DirectoryInfo i in childDirInfo)
            {
                IList<string> chList = new List<string>();
                if (DirName != string.Empty)
                    chList = GetFullPathFiles(i, DirName + "/" + i.Name);
                else
                    chList = GetFullPathFiles(i, i.Name);

                if (chList != null && chList.Count > 0)
                    foreach (string str in chList)
                    {
                        list.Add(str);
                    }
            }

            return list;
        }

        //下载文件
        [WebMethod]
        public byte[] DowLoadFile(string fName)
        {
            FileStream fs = null;
            fs = File.Open(path + fName, FileMode.Open, FileAccess.Read, FileShare.Read);
            byte[] filebytes = new byte[fs.Length];
            fs.Read(filebytes, 0, (int)fs.Length);
            fs.Close();
            fs = null;
            return filebytes;
        }
    }
}
