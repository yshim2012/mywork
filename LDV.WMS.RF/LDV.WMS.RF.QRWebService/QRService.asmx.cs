using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;
using LDV.WMS.RF.DataMapper;
using LDV.WMS.RF.Business;

namespace LDV.WMS.RF.QRService
{
    /// <summary>
    /// 说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
    // [System.Web.Script.Services.ScriptService]
    public class QRService : System.Web.Services.WebService
    {
        private string path = System.Configuration.ConfigurationManager.AppSettings["PathToClientFiles"].ToString();

        #region mjy 入库数据同步接口 2016-05-04
        [WebMethod]
        public string Get_OrderList(string date)
        {
            return GetListService.Get_OrderList(date);
        }
        #endregion

        #region mjy 出库装箱数据同步接口 2016-05-04
        [WebMethod]
        public string Get_PackingList(string date)
        {
            return GetListService.Get_PackingList(date);
        }
        #endregion

        #region mjy 二维码数据同步接口 2016-05-12
        [WebMethod]
        public string Get_QRCodeList(string date)
        {
            return GetListService.Get_QRCodeList(date);
        }
        #endregion
    }
}
