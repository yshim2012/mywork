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
    public class POSCarrierApiController : ApiController
    {
        public string GetPOSCarrier()
        {
            POSCarrier _POSCarrier = new POSCarrier();
            var POSCarrierList = _POSCarrier.QueryList("SelectAll");
            var jsonStr = JsonSerializationHandler.Serialize<IList<POSCarrier>>(POSCarrierList);
            return jsonStr;

        }

        [HttpPost]
        public int CreatePOSCarrier(dynamic _POSCarrier)
        {
            if (_POSCarrier != null)
            {
                POSCarrier newPOSCarrier = new POSCarrier();
                newPOSCarrier.CarrierId = _POSCarrier["CarrierId"].ToString();
              //  newPOSCarrier.Status = _POSCarrier["Status"].ToString();
           //     newPOSCarrier.CreateTime = _POSCarrier["CreateTime"].ToString();
                newPOSCarrier.CreateUserId = _POSCarrier["CreateUserId"].ToString();
           //     newPOSCarrier.UpdateTime = _POSCarrier["UpdateTime"].ToString();
                newPOSCarrier.UpdateUserId = _POSCarrier["UpdateUserId"].ToString();
                newPOSCarrier.POSId = _POSCarrier["POSId"].ToString();
                newPOSCarrier.Status = 0;
                newPOSCarrier.Save("InsertPOSCarrier");
                return 1;
            }
            return 2;
        }

        [HttpPost]
        public string PostPOSCarrier(dynamic parm)
        {
            IDictionary paramHashtable1 = new Hashtable();
            if (parm != null)
            {
                if (parm["CarrierId"] != null)
                {
                    paramHashtable1.Add("CarrierId", parm["CarrierId"].ToString().Trim());
                }
                //if (parm["CreateUserId"] != null)
                //{
                //    paramHashtable1.Add("CreateUserId", parm["CreateUserId"].ToString().Trim());
                //}
                //if (parm["LocAddress"] != null)
                //{
                //    paramHashtable1.Add("LocCode", parm["LocAddress"].ToString().Trim());
                //}
                if (parm["POSId"] != null)
                {
                    paramHashtable1.Add("POSId", parm["POSId"].ToString().Trim());
                }
                if (parm["Status"] != null)
                {
                    paramHashtable1.Add("Status", parm["Status"].ToString().Trim());
                }

            }

            var dtPOSCarrier = POSCarrier.QueryDataTable("SelectPOSCarrier", paramHashtable1);
            var jsonStr = JsonSerializationHandler.Serialize<DataTable>(dtPOSCarrier);
            return jsonStr; 
        }

        [HttpPost]
        public void ExportPOSCarrier(dynamic parm)
        {
            try
            {
                IDictionary paramHashtable1 = new Hashtable();
                if (parm != null)
                {
                    if (parm["CarrierId"] != null)
                    {
                        paramHashtable1.Add("CreateUserId", parm["CreateUserId"].ToString().Trim());
                    }
                    if (parm["POSId"] != null)
                    {
                        paramHashtable1.Add("POSId", parm["POSId"].ToString().Trim());
                    }
                    //if (parm["LocAddress"] != null)
                    //{
                    //    paramHashtable1.Add("LocCode", parm["LocAddress"].ToString().Trim());
                    //}
                    if (parm["Status"] != null)
                    {
                        paramHashtable1.Add("Status", parm["Status"].ToString().Trim());
                    }
                }

                var dtPOSCarrier = POSCarrier.QueryDataTable("SelectPOSCarrier", paramHashtable1);
                NPOIExcelHelper.DataTableToExcel(dtPOSCarrier, "POS机与承运商信息", "C:/mytest1.xls");
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        [HttpPost]
        public int EditPOSCarrier(dynamic _POSCarrier)
        {
            if (_POSCarrier != null)
            {
                POSCarrier newPOSCarrier = new POSCarrier();
                newPOSCarrier.Id = int.Parse(_POSCarrier["LocId"].ToString());
                newPOSCarrier.CarrierId = _POSCarrier["LocCode"].ToString();
                newPOSCarrier.POSId = _POSCarrier["LocName"].ToString();
                newPOSCarrier.UpdateUserId = _POSCarrier["Province_Code"].ToString();
                newPOSCarrier.Status = 0;
             //   newPOSCarrier.UpdateUserId = 1;
                newPOSCarrier.Update("UpdatePOSCarrier");
                return 1;
            }
            return 2;
        }
    }
}
