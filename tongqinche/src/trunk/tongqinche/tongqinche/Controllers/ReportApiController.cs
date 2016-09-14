﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DataMapper;
using Common;
using System.Collections;
using System.Data;
using System.Configuration;
using System.IO;

namespace tongqinche.Controllers
{
    public class ReportApiController : ApiController
    {
        /// <summary>
        /// 每月乘车汇总
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpPost]
        public string SelectMonthlyRideReport(dynamic parm)
        {
            SqlParamSet pa = new SqlParamSet();
            if (parm != null)
            {
                if (parm["rideBeginDate"] != null)
                {
                    pa.AddParam("rideBeginDate", parm["rideBeginDate"].ToString());
                }
                if (parm["ridEndDate"] != null)
                {
                    pa.AddParam("ridEndDate", DateTime.Parse(parm["ridEndDate"].ToString()).AddDays(1));
                }
                if (parm["rideType"] != null)
                {
                    pa.AddParam("rideType", parm["rideType"].ToString().Trim());
                }
                if (parm["cardType"] != null)
                {
                    pa.AddParam("cardType", parm["cardType"].ToString().Trim());
                }
                if (parm["company"] != null)
                {
                    pa.AddParam("company", parm["company"].ToString().Trim());
                }
                if (parm["carrierName"] != null)
                {
                    pa.AddParam("carrierName", parm["carrierName"].ToString().Trim());
                }

            }
            var dtMonthlyRideReport = RideData.QueryDataTable("SelectMonthlyRideReport", pa.GetParams());
            string jsonStr = JsonSerializationHandler.Serialize<DataTable>(dtMonthlyRideReport);
            return jsonStr;
        }

        /// <summary>
        /// 每日乘车明细
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpPost]
        public string SelectDailyRideReport(dynamic parm)
        {
            IDictionary paramHashtable1 = new Hashtable();
            if (parm != null)
            {
                if (parm["ui_date_picker_range_from"] != null)
                {
                    paramHashtable1.Add("ui_date_picker_range_from", parm["ui_date_picker_range_from"].ToString().Trim());
                }
                if (parm["ui_date_picker_range_to"] != null)
                {
                    paramHashtable1.Add("ui_date_picker_range_to", DateTime.Parse(parm["ui_date_picker_range_to"].ToString()).AddDays(1));
                }
                if (parm["RideType"] != null)
                {
                    paramHashtable1.Add("COMMUNTE_TYPE", parm["RideType"].ToString().Trim());
                }
                if (parm["CardType"] != null)
                {
                    paramHashtable1.Add("CARD_TYPE", parm["CardType"].ToString().Trim());
                }
                if (parm["Company"] != null)
                {
                    paramHashtable1.Add("CO", parm["Company"].ToString().Trim());
                }
                if (parm["CarrierName"] != null)
                {
                    paramHashtable1.Add("CARRIER_NAME", parm["CarrierName"].ToString().Trim());
                }

            }

            var dtDailyRideReport = RideData.QueryDataTable("SelectDailyRideReport", paramHashtable1);
            var jsonStr = JsonSerializationHandler.Serialize<DataTable>(dtDailyRideReport);
            return jsonStr;
        }

        /// <summary>
        /// 乘车计费月度统计
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpPost]
        public string SelectMonthRideSummaryReport(dynamic parm)
        {
            SqlParamSet pa = new SqlParamSet();
            if (parm != null)
            {
                if (parm["rideBeginDate"] != null)
                {
                    pa.AddParam("rideBeginDate", parm["rideBeginDate"].ToString());
                }
                if (parm["ridEndDate"] != null)
                {
                    pa.AddParam("ridEndDate", DateTime.Parse(parm["ridEndDate"].ToString()).AddDays(1));
                }
                if (parm["cardType"] != null)
                {
                    pa.AddParam("cardType", parm["cardType"].ToString().Trim());
                }
                if (parm["company"] != null)
                {
                    pa.AddParam("company", parm["company"].ToString().Trim());
                }
                if (parm["locType"] != null)
                {
                    pa.AddParam("locType", parm["locType"].ToString().Trim());
                }
            }
            var dtMonthlyRideReport = RideData.QueryDataTable("SelectMonthRideSummaryReport", pa.GetParams());
            string jsonStr = JsonSerializationHandler.Serialize<DataTable>(dtMonthlyRideReport);
            return jsonStr;
        }

        /// <summary>
        /// 乘车计费月度统计导出
        /// </summary>
        /// <param name="parm"></param>
        [HttpPost]
        public void ExportMonthRideSummaryReport(dynamic parm)
        {
            SqlParamSet pa = new SqlParamSet();
            if (parm != null)
            {
                if (parm["rideBeginDate"] != null)
                {
                    pa.AddParam("rideBeginDate", parm["rideBeginDate"].ToString());
                }
                if (parm["ridEndDate"] != null)
                {
                    pa.AddParam("ridEndDate", DateTime.Parse(parm["ridEndDate"].ToString()).AddDays(1));
                }
                if (parm["cardType"] != null)
                {
                    pa.AddParam("cardType", parm["cardType"].ToString().Trim());
                }
                if (parm["company"] != null)
                {
                    pa.AddParam("company", parm["company"].ToString().Trim());
                }
                if (parm["locType"] != null)
                {
                    pa.AddParam("locType", parm["locType"].ToString().Trim());
                }
            }
            var dtMonthlyRideReport = RideData.QueryDataTable("SelectMonthRideSummaryReport", pa.GetParams());
            string path = ConfigurationManager.AppSettings["FilePath"];
            string fileName = DateTime.Now.ToString("yyyyMMddHHmmss") + "乘车计费月度统计" + ".xls";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            NPOIExcelHelper.DataTableToExcel(dtMonthlyRideReport, "乘车计费月度统计", Path.Combine(path, fileName));
        }

        /// <summary>
        /// 每月乘车汇总导出
        /// </summary>
        /// <param name="parm"></param>
        [HttpPost]
        public void ExportMonthlyRideReport(dynamic parm)
        {
            SqlParamSet pa = new SqlParamSet();
            if (parm != null)
            {
                if (parm["rideBeginDate"] != null)
                {
                    pa.AddParam("rideBeginDate", parm["rideBeginDate"].ToString());
                }
                if (parm["ridEndDate"] != null)
                {
                    pa.AddParam("ridEndDate", DateTime.Parse(parm["ridEndDate"].ToString()).AddDays(1));
                }
                if (parm["rideType"] != null)
                {
                    pa.AddParam("rideType", parm["rideType"].ToString().Trim());
                }
                if (parm["cardType"] != null)
                {
                    pa.AddParam("cardType", parm["cardType"].ToString().Trim());
                }
                if (parm["company"] != null)
                {
                    pa.AddParam("company", parm["company"].ToString().Trim());
                }
                if (parm["carrierName"] != null)
                {
                    pa.AddParam("carrierName", parm["carrierName"].ToString().Trim());
                }

            }
            var dtMonthlyRideReport = RideData.QueryDataTable("SelectMonthlyRideReport", pa.GetParams());
            string path = ConfigurationManager.AppSettings["FilePath"];
            string fileName = DateTime.Now.ToString("yyyyMMddHHmmss") + "每月乘车汇总" + ".xls";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            NPOIExcelHelper.DataTableToExcel(dtMonthlyRideReport, "每月乘车汇总", Path.Combine(path, fileName));
        }

        /// <summary>
        /// 每日乘车明细导出
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpPost]
        public void SelectExportDailyRideReport(dynamic parm)
        {
            IDictionary paramHashtable1 = new Hashtable();
            if (parm != null)
            {
                if (parm["ui_date_picker_range_from"] != null)
                {
                    paramHashtable1.Add("ui_date_picker_range_from", parm["ui_date_picker_range_from"].ToString().Trim());
                }
                if (parm["ui_date_picker_range_to"] != null)
                {
                    paramHashtable1.Add("ui_date_picker_range_to", DateTime.Parse(parm["ui_date_picker_range_to"].ToString()).AddDays(1));
                }
                if (parm["RideType"] != null)
                {
                    paramHashtable1.Add("COMMUNTE_TYPE", parm["RideType"].ToString().Trim());
                }
                if (parm["CardType"] != null)
                {
                    paramHashtable1.Add("CARD_TYPE", parm["CardType"].ToString().Trim());
                }
                if (parm["Company"] != null)
                {
                    paramHashtable1.Add("CO", parm["Company"].ToString().Trim());
                }
                if (parm["CarrierName"] != null)
                {
                    paramHashtable1.Add("CARRIER_NAME", parm["CarrierName"].ToString().Trim());
                }

            }

            var dtDailyRideReport = RideData.QueryDataTable("SelectExportDailyRideReport", paramHashtable1);
            string path = ConfigurationManager.AppSettings["FilePath"];
            string fileName = DateTime.Now.ToString("yyyyMMddHHmmss") + "每日乘车明细" + ".xls";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            NPOIExcelHelper.DataTableToExcel(dtDailyRideReport, "每日乘车明细", Path.Combine(path, fileName));
        }
    }
}
