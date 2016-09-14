using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DataMapper;
using IBatisNet.DataMapper;
using System.Data;

namespace tongqinche.Controllers
{
    public class RouteApiController : ApiController
    {
        [HttpPost]
        public string ShowRouteList(dynamic parm)
        {
            SqlParamSet para = new SqlParamSet();
            if (parm != null)
            {
                if (parm["routeCode"] != null)
                {
                    para.AddParam("routeCode", parm["routeCode"].ToString().Trim());
                }
                if (parm["routeName"] != null)
                {
                    para.AddParam("routeName", parm["routeName"].ToString().Trim());
                }
                if (parm["routeLoc"] != null)
                {
                    para.AddParam("routeLoc", parm["routeLoc"].ToString().Trim());
                }
                if (parm["status"] != null)
                {
                    para.AddParam("status", parm["status"].ToString().Trim());
                }
            }
            var routeData = Route.QueryDataTable("SelectRoute", para.GetParams());
            var jsonStr = JsonSerializationHandler.Serialize<DataTable>(routeData);
            return jsonStr;
        }
    }
}
