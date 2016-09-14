using Common;
using DataMapper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace tongqinche.Controllers
{
    public class RouteShiftApiController : ApiController
    {
        [HttpPost]
        public string PostRouteShift(dynamic routeShift)
        {
            // RouteShift parmrouteShift = new RouteShift();
            IDictionary paramHashtable1 = new Hashtable();
            if (routeShift != null)
            {
                if (routeShift["ShiftCode"] != null)
                {
                    paramHashtable1.Add("SHIFT_NAME", routeShift["ShiftCode"].ToString().Trim());
                }
                if (routeShift["RouteName"] != null)
                {
                    paramHashtable1.Add("Route_Name", routeShift["RouteName"].ToString().Trim());
                }
                if (routeShift["LocName"] != null)
                {
                    paramHashtable1.Add("Loc_Name", routeShift["LocName"].ToString().Trim());
                }
                if (routeShift["TableName"] != null)
                {
                    paramHashtable1.Add("Table_Name", routeShift["TableName"].ToString().Trim());
                }
                if (routeShift["IsValid"] != null)
                {
                    paramHashtable1.Add("status", routeShift["IsValid"].ToString().Trim());
                }
                if (routeShift["Ui_date_picker_range_from"] != null)
                {
                    paramHashtable1.Add("departure_time_start", routeShift["Ui_date_picker_range_from"].ToString().Trim());
                }
                if (routeShift["Ui_date_picker_range_to"] != null)
                {
                    paramHashtable1.Add("departure_time_end", routeShift["Ui_date_picker_range_to"].ToString().Trim());
                }

            }
            var dtRouteShift = RouteShift.QueryDataTable("SelectRouteShift", paramHashtable1);
            var jsonStr = JsonSerializationHandler.Serialize<DataTable>(dtRouteShift);
            return jsonStr;
        }
    }
}
