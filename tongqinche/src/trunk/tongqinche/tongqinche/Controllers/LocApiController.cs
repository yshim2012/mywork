using Common;
using DataMapper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace tongqinche.Controllers
{
    public class LocApiController : ApiController
    {
        public string GetLoc()
        {
            Loc loc = new Loc();
            var locList = loc.QueryList("SelectAll");
            var jsonStr = JsonSerializationHandler.Serialize<IList<Loc>>(locList);
            return jsonStr;

        } 
        [HttpPost]
        public int CreateLoc(dynamic loc)
        {
            if (loc != null)
            {
                Loc newLoc = new Loc();
                newLoc.LocCode = loc["locCode"].ToString();
                newLoc.LocName = loc["locName"].ToString();
                newLoc.ProvinceCode = loc["province"].ToString();
                newLoc.CityCode = loc["city"].ToString();
                newLoc.DistrictCode = loc["district"].ToString();
                newLoc.LocType = loc["locType"].ToString();
                newLoc.Status = 0;
                newLoc.CreateUserid = 1;
                newLoc.Longitude = "116.415498";
                newLoc.Latitude = "31.280086";
                newLoc.Save("InsertLoc");
                return 1;
            }
            return 2;
        }

        [HttpPost]
        public string PostLoc(dynamic parm)
        {
            IDictionary paramHashtable1 = new Hashtable();
            if (parm != null)
            {
                if (parm["LocCode"] != null)
                {
                    paramHashtable1.Add("LocCode", parm["LocCode"].ToString().Trim());
                }
                if (parm["LocName"] != null)
                {
                    paramHashtable1.Add("LocName", parm["LocName"].ToString().Trim());
                }
                //if (parm["LocAddress"] != null)
                //{
                //    paramHashtable1.Add("LocCode", parm["LocAddress"].ToString().Trim());
                //}
                if (parm["LocType"] != null)
                {
                    paramHashtable1.Add("LocType", parm["LocType"].ToString().Trim());
                }
                if (parm["LocStatus"] != null)
                {
                    paramHashtable1.Add("Status", parm["LocStatus"].ToString().Trim());
                }

            }

            var dtLoc = Loc.QueryDataTable("SelectLoc", paramHashtable1);
            var jsonStr = JsonSerializationHandler.Serialize<DataTable>(dtLoc);
            return jsonStr;
        }

        [HttpPost]
        public void ExportLoc(dynamic parm)
        {
            try
            {
                IDictionary paramHashtable1 = new Hashtable();
                if (parm != null)
                {
                    if (parm["LocCode"] != null)
                    {
                        paramHashtable1.Add("LocCode", parm["LocCode"].ToString().Trim());
                    }
                    if (parm["LocName"] != null)
                    {
                        paramHashtable1.Add("LocName", parm["LocName"].ToString().Trim());
                    }
                    //if (parm["LocAddress"] != null)
                    //{
                    //    paramHashtable1.Add("LocCode", parm["LocAddress"].ToString().Trim());
                    //}
                    if (parm["LocType"] != null)
                    {
                        paramHashtable1.Add("LocType", parm["LocType"].ToString().Trim());
                    }
                    if (parm["LocStatus"] != null)
                    {
                        paramHashtable1.Add("Status", parm["LocStatus"].ToString().Trim());
                    }

                }

                var dtLoc = Loc.QueryDataTable("SelectLoc", paramHashtable1);
                string path = ConfigurationManager.AppSettings["FilePath"];
                string fileName = DateTime.Now.ToString("yyyyMMddHHmmss") + "站点" + ".xls";
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                NPOIExcelHelper.DataTableToExcel(dtLoc, "站点", Path.Combine(path, fileName));

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [HttpPost]
        public int EditLoc(dynamic loc)
        {
            if (loc != null)
            {
                Loc newLoc = new Loc();
                newLoc.Id = int.Parse(loc["LocId"].ToString());
                newLoc.LocCode = loc["LocCode"].ToString();
                newLoc.LocName = loc["LocName"].ToString();
                newLoc.ProvinceCode = loc["Province_Code"].ToString();
                newLoc.CityCode = loc["City_Code"].ToString();
                newLoc.DistrictCode = loc["District_Code"].ToString();
                newLoc.LocType = loc["LocType"].ToString();
                newLoc.UpdateUserid = 1;
                newLoc.Update("UpdateLoc");
                return 1;
            }
            return 2;
        }

        [HttpPost]
        public int DeleteLoc(dynamic idList)
        {
            string[] idArr = JsonSerializationHandler.Deserialize<string[]>(idList.ToString());
            for (int i = 0; i < idArr.Length; i++)
            {
                Loc newLoc = new Loc();
                newLoc.Id = idList[i];
                newLoc.Status = 1;
                newLoc.UpdateUserid = 1;
                newLoc.Update("DeleteLoc");
            }
            return 1;
        }
    }
}
