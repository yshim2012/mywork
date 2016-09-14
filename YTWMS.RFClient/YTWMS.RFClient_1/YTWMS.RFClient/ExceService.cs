using System;
using System.Data;
using System.Xml;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using YTWMS.RFClient.RFService;
using System.Text.RegularExpressions;
using System.Xml.Serialization;

namespace YTWMS.RFClient
{
    public class ExceService
    {
        private static RFService.RFService Server()
        {
            string FilePath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase) + "\\files.config.xml";

            XmlDocument doc = new XmlDocument();
            doc.Load(FilePath);
            string Url = doc.GetElementsByTagName("serverURL")[0].InnerText;

            RFService.RFService rf = new YTWMS.RFClient.RFService.RFService();
            rf.Url = string.Format("http://{0}/RFService.asmx", Url);

            return rf;
        }

        /// <summary>
        /// 检测服务地址
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static bool CheckService(string url)
        {
            try
            {
                RFService.RFService rf = new YTWMS.RFClient.RFService.RFService();
                rf.Url = string.Format("http://{0}/RFService.asmx", url);

                return rf.CheckService();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 检查网络地址
        /// </summary>
        /// <returns></returns>
        public static bool CheckService()
        {
            try
            {
                RFService.RFService rf = Server();
                return rf.CheckService();
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        #region 下载更新
        /// <summary>
        /// 得到服务端的版本信息
        /// </summary>
        /// <returns></returns>
        public static string GetServiceVersion()
        {
            RFService.RFService rf = Server();
            return rf.GetVersion();
        }

        /// <summary>
        /// 得到所有要下载的文件名
        /// </summary>
        /// <returns></returns>
        public static string[] GetAllFilesForDownLoad()
        {
            RFService.RFService rf = Server();
            return rf.GetAllFiles();
        }

        /// <summary>
        /// 下载文件
        /// </summary>
        /// <param name="FileName"></param>
        /// <returns></returns>
        public static byte[] DownLoadFile(string FileName)
        {
            RFService.RFService rf = Server();
            return rf.DownLoadFile(FileName);
        }
        #endregion

        #region 登入 菜单
        /// <summary>
        /// 登入
        /// </summary>
        /// <param name="Acount">登入帐号</param>
        /// <param name="Password">密码</param>
        /// <returns></returns>
        public static RFService.LtUser Login(string Acount, string Password)
        {
            RFService.RFService rf = Server();
            return rf.Login(Acount, Password);
        }

        /// <summary>
        /// 获取排序单
        /// </summary>
        /// <returns></returns>
        public static DataTable GetSortParts(string pullNo, int warehouseId)
        {
            RFService.RFService rf = Server();
            return rf.GetSortParts(pullNo, warehouseId);
        }


        /// <summary>
        /// 获取仓库车辆
        /// </summary>
        /// <returns></returns>
        public static DataTable GetWareHouseTrcuks(int warehouseId)
        {
            RFService.RFService rf = Server();
            return rf.GetWareHouseTrcuks(warehouseId);
        }


        /// <summary>
        /// 发货确认
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public static string SendConfirm(string sortNo, int userId, int warehouseId, string strDock, string strDriver, string strTruck)
        {
            RFService.RFService rf = Server();
            return rf.SendConfirm(sortNo, userId, warehouseId, strDock, strDriver, strTruck);
        }

        /// <summary>
        /// 查询供应商
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public static DataTable GetWareHouseSupplier(int warehouseId)
        {
            RFService.RFService rf = Server();
            return rf.GetWareHouseSupplier(warehouseId);
        }

        /// <summary>
        /// 查询项目
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public static DataTable GetWareHouseProject(int warehouseId)
        {
            RFService.RFService rf = Server();
            return rf.GetWareHouseProject(warehouseId);
        }

        /// <summary>
        /// 筛选Byte数据,GS, RS字符软件不体现 替换成 空
        /// </summary>
        /// <returns></returns>
        public static string FilterByte(string str)
        {
            try
            {
                byte[] strBytes = System.Text.Encoding.UTF8.GetBytes(str);

                for (int i = 0; i < strBytes.Length; i++)
                {
                    if (strBytes[i] == 30 || strBytes[i] == 29)
                    {
                        strBytes[i] = 32;
                    }
                }

                return System.Text.Encoding.UTF8.GetString(strBytes, 0, strBytes.Length);
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// 是否整箱二维码格式
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsBoxFormart(string str)
        {
            // 格式：[)> 06 P84012175 Q4 1JUN65466528040021517 20LJQCPGA K  TLS16134 C
            if (str.Split(' ').Length < 5)
                return false;

            if (str.Split(' ')[2].Substring(0, 1).ToString() != "P")
                return false;

            if (str.Split(' ')[3].Substring(0, 1).ToString() != "Q")
                return false;

            if (str.Split(' ')[4].Substring(0, 2).ToString() != "1J")
                return false;

            return true;
        }

        /// <summary>
        /// 是否总成零件二维码格式
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsPartFormart(string str)
        {
            //[)> 06 Y1210000000000X P24106816 12V653811398 T11143552MA4X0176
            if (str.Split(' ').Length < 4)
                return false;
            if (str.Split(' ')[3].Substring(0, 1) != "P")
                return false;
            return true;
        }

        /// <summary>
        /// 检查箱号信息
        /// </summary>
        /// <param name="warehouseId"></param>
        /// <param name="strJson"></param>
        /// <returns></returns>
        public static string CheckBoxInfo(int warehouseId, string strJson)
        {
            RFService.RFService rf = Server();
            return rf.CheckBoxInfo(warehouseId, strJson);
        }

        #endregion


        #region 收货
        /// <summary>
        /// 查询项目
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public static string PackageReceive(string documentNo, int userId,
            string strJson, int warehouseId)
        {
            RFService.RFService rf = Server();
            return rf.PackageReceive(documentNo, userId, strJson, warehouseId);
        }
        #endregion

        #region 发货
        /// <summary>
        /// 退供应商发货
        /// </summary>
        /// <param name="supplierId"></param>
        /// <param name="userId"></param>
        /// <param name="warehouseId"></param>
        /// <param name="truckNo"></param>
        /// <param name="driver"></param>
        /// <param name="tel"></param>
        /// <param name="jsonBox"></param>
        /// <returns></returns>
        public static string BackSupplier(int supplierId, int userId, int warehouseId, string truckNo, string driver, string tel, string jsonBox)
        {
            RFService.RFService rf = Server();
            return rf.BackSupplier(supplierId, userId, warehouseId, truckNo, driver, tel, jsonBox);
        }

        /// <summary>
        /// 退供应商发货
        /// </summary>
        /// <param name="supplierId"></param>
        /// <param name="userId"></param>
        /// <param name="warehouseId"></param>
        /// <param name="truckNo"></param>
        /// <param name="driver"></param>
        /// <param name="tel"></param>
        /// <param name="jsonBox"></param>
        /// <returns></returns>
        public static string PullPackageSend(string pullNo, int userId, int warehouseId, string truckNo, string driver, string tel, string jsonBox)
        {
            RFService.RFService rf = Server();
            return rf.PullPackageSend(pullNo, userId, warehouseId, truckNo, driver, tel, jsonBox);
        }


        /// <summary>
        /// 检查拉动单信息
        /// </summary>
        /// <param name="warehouseId"></param>
        /// <param name="strJson"></param>
        /// <returns></returns>
        public static DataTable getPlanInfo(string no, int warehouseId)
        {
            RFService.RFService rf = Server();
            return rf.getPlanInfo(no, warehouseId);
        }

        /// <summary>
        /// 检查箱号信息
        /// </summary>
        /// <param name="warehouseId"></param>
        /// <param name="strJson"></param>
        /// <returns></returns>
        public static string CheckBoxStock(string boxNO, string partCode, int warehouseId)
        {
            RFService.RFService rf = Server();
            return rf.CheckBoxStock(boxNO, partCode, warehouseId);
        }

        #endregion


    }
}
