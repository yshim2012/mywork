using System;
using System.IO;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;
using System.Xml;
using System.Xml.Serialization;
using IBatisNet.DataMapper;
using YTWMS.Business;
using DataMapper;
using System.Web.Security;
using Elmah;

namespace YTWMS.WebService
{
    /// <summary>
    /// RFService 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
    // [System.Web.Script.Services.ScriptService]
    public class RFService : System.Web.Services.WebService
    {
        private string ProgramPath = ConfigurationManager.AppSettings["ProgramPath"].ToString();

        [WebMethod]
        [Description("检测服务是否能连上")]
        public bool CheckService()
        {
            return true;
        }

        #region 程序下载更新
        [WebMethod]
        [Description("获取版本号")]
        public string GetVersion()
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(ProgramPath + "files.config.xml");
                return doc.GetElementsByTagName("Version")[0].InnerText;
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }

        [WebMethod]
        [Description("得到所有下载更新的文件名")]
        public string[] GetAllFiles()
        {
            try
            {
                if (Directory.Exists(ProgramPath))
                {
                    string[] files = Directory.GetFiles(ProgramPath);
                    for (int i = 0; i < files.Length; i++)
                        files[i] = files[i].Substring(files[i].LastIndexOf("\\") + 1);

                    return files;
                }

                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }

        [WebMethod]
        [Description("下载文件")]
        public byte[] DownLoadFile(string FileName)
        {
            FileStream fs = null;
            fs = File.Open(ProgramPath + FileName, FileMode.Open, FileAccess.Read, FileShare.Read);
            byte[] filebytes = new byte[fs.Length];
            fs.Read(filebytes, 0, (int)fs.Length);
            fs.Close();
            fs = null;
            return filebytes;
        }
        #endregion

        #region 操作

        [WebMethod]
        [Description("登入")]
        [XmlInclude(typeof(LtUser))]
        public LtUser Login(string Acount, string Password)
        {
            if (string.IsNullOrEmpty(Acount) || string.IsNullOrEmpty(Password))
                return null;

            return UserService.Login(Acount, FormsAuthentication.HashPasswordForStoringInConfigFile(Password, "MD5"));
        }

        [WebMethod]
        [Description("查询排序订单")]
        public DataTable GetSortParts(string sortNo, int warehouseId)
        {
            if (sortNo == string.Empty || warehouseId == 0)
                return null;

            return SortServices.GetSortPart(sortNo, warehouseId);
        }

        [WebMethod]
        [Description("查询仓库所有车辆")]
        public DataTable GetWareHouseTrcuks(int warehouseId)
        {
            try
            {
                if (warehouseId == 0)
                    return null;

                return TruckServices.GetTruckTable(warehouseId);
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        [WebMethod]
        [Description("发货确认")]
        public string SendConfirm(string sortNo, int userId, int warehouseId, string strDock, string strDriver, string strTruck)
        {
            return SortServices.ConfirmQueue(sortNo, userId, warehouseId, strDock, strDriver, strTruck);
        }

        [WebMethod]
        [Description("查询发货记录")]
        [XmlInclude(typeof(SendInfo))]
        public SendInfo getSendInfo(SendInfo info)
        {
            return null;
        }

        [WebMethod]
        [Description("查询排序单")]
        public DataTable getQueueInfo(string no, int warehouseId)
        {
            try
            {
                if (no == "0" || warehouseId == 0)
                    return null;

                return SortServices.GetSortPart(no, warehouseId);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [WebMethod]
        [Description("查询仓库供应商")]
        public DataTable GetWareHouseSupplier(int warehouseId)
        {
            try
            {
                if (warehouseId == 0)
                    return null;

                return WareHouseServices.GetSupplier(warehouseId);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [WebMethod]
        [Description("查询仓库大项目")]
        public DataTable GetWareHouseProject(int warehouseId)
        {
            try
            {
                if (warehouseId == 0)
                    return null;

                return WareHouseServices.GetProject(warehouseId);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region 整箱收货
        [WebMethod]
        [Description("检查箱号信息")]
        public string CheckBoxInfo(int warehouseId, string strJson)
        {
            return ReceiveServices.CheckBoxInfo(warehouseId, strJson);
        }

        [WebMethod]
        [Description("整箱收货")]
        public string PackageReceive(string documentNo, int userId, string strJson, int warehouseId)
        {
            return ReceiveServices.PackageReceive(documentNo, userId, strJson, warehouseId);
        }
        #endregion


        #region 整箱发货
        [WebMethod]
        [Description("退供应商发货")]
        public string BackSupplier(int supplierId, int userId, int warehouseId, string truckNo, string driver, string tel, string jsonBox)
        {
            return SendServices.BackSupplier(supplierId, userId, warehouseId, truckNo, driver, tel, jsonBox);
        }

        [WebMethod]
        [Description("整箱拉动发货")]
        public string PullPackageSend(string planNO, int userId, int warehouseId, string truckNo, string driver, string tel, string jsonBox)
        {
            return SendServices.PullPackageSend(planNO, userId, warehouseId, truckNo, driver, tel, jsonBox);
        }

        [WebMethod]
        [Description("查询拉动单")]
        public DataTable getPlanInfo(string no, int warehouseId)
        {
            try
            {
                return SendServices.GetPullPlan(no, warehouseId);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [WebMethod]
        [Description("查询箱号库存")]
        public string CheckBoxStock(string boxNO, string partCode, int warehouseId)
        {
            return SendServices.CheckBoxStock(boxNO, partCode, warehouseId);
        }

        #endregion
    }
}
