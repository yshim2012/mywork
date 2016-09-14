using Common;
using DataMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;
using System.Configuration;
using System.IO;

namespace tongqinche.Controllers
{
    public class WhiteListApiController : ApiController
    {
        [HttpPost]
        public string ShowEmployeeList(dynamic parm)
        {
            Employee em = new Employee();
            if (parm != null)
            {
                if (parm["company"] != null)
                {
                    em.Company = parm["company"].ToString().Trim();
                }
                if (parm["department"] != null)
                {
                    em.Department = parm["department"].ToString().Trim();
                }
                if (parm["employeeNumber"] != null)
                {
                    em.EmployeeNo = parm["employeeNumber"].ToString().Trim();
                }
                if (parm["name"] != null)
                {
                    em.Name = parm["name"].ToString().Trim();
                }
                if (parm["importType"] != null)
                {
                    em.ImportType = parm["importType"].ToString().Trim();
                }
                if (parm["status"] != null)
                {
                    em.Status = parm["status"].ToString().Trim();
                }
            }

            var dataList = em.QueryList("SelectWhiteList");
            var jsonStr = JsonSerializationHandler.Serialize<IList<Employee>>(dataList);
            return jsonStr;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="whiteList"></param>
        [HttpPost]
        public void ImportExcel(dynamic data)
        {
            try
            {
                if (data != null)
                {
                    DataTable dtFile = NPOIExcelHelper.Import(data["filePath"].ToString());
                    Employee employee = new Employee();
                    for (int i = 0; i < dtFile.Rows.Count; i++)
                    {
                        employee.EmployeeNo = dtFile.Rows[i][0].ToString();
                        employee.CardNo = dtFile.Rows[i][1].ToString();

                        employee.Name = "";
                        employee.Phone = "";
                        employee.ListType = 0;
                        employee.Status = 0;
                        employee.CreateUserId = 0;
                        employee.UpdateUserId = 0;

                        employee.Save("InsertEmployee");
                    }
                    //DealExcel(data["fileType"].ToString(), dtFile);
                    //var jsonStr = JsonSerializationHandler.Serialize<IList<whiteList>>(whiteListList);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public void DeleteEmployee(dynamic idList)
        {
            string[] idArr = JsonSerializationHandler.Deserialize<string[]>(idList.ToString());
          for (int i = 0; i < idArr.Length; i++)
            {
                Employee em = new Employee();
                em.Id = idList[i];
                em.Delete();
            }
        }


        public void DealExcel(string fileType, DataTable dt)
        {
            switch (fileType)
            {
                case "AIC":
                    break;
                case "SAP":
                    break;
                case "LADP":
                    break;
                default:
                    break;
            }
        }

        public void DealSAPFiles(DataTable dt)
        {
            for (int i = 1; i < dt.Rows.Count; i++)
            {
                SapModel sap = new SapModel();
                sap.EmployeeNo = dt.Rows[i][0].ToString();
                sap.TicketType = dt.Rows[i][1].ToString();
                sap.CreateTime = DateTime.Now;
                sap.UpdateTime = DateTime.Now;
            }
        }


        [HttpPost]
        public void ExportWhiteList(dynamic whiteList)
        {
            try
            {
                Employee parmEmployee = new Employee();
                if (whiteList != null)
                {
                    if (whiteList["company"] != null)
                    {
                        parmEmployee.Company = whiteList["company"].ToString().Trim();
                    }
                    if (whiteList["department"] != null)
                    {
                        parmEmployee.Department = whiteList["department"].ToString().Trim();
                    }
                    if (whiteList["employeeNumber"] != null)
                    {
                        parmEmployee.EmployeeNo = whiteList["employeeNumber"].ToString().Trim();
                    }
                    if (whiteList["name"] != null)
                    {
                        parmEmployee.Name = whiteList["name"].ToString().Trim();
                    }
                    if (whiteList["importType"] != null)
                    {
                        parmEmployee.ImportType = whiteList["importType"].ToString().Trim();
                    }
                    if (whiteList["status"] != null)
                    {
                        parmEmployee.Status = whiteList["status"].ToString().Trim();
                    }

                }
                string path = ConfigurationManager.AppSettings["FilePath"];
                var whiteListList = parmEmployee.QueryDataTable("SelectExportWhiteList");
                if (!File.Exists(path))
                {
                    File.Create(path);
                }
                string newPath = Path.Combine(path, DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls");
                NPOIExcelHelper.DataTableToExcel(whiteListList, "白名单", newPath);
                //var jsonStr = JsonSerializationHandler.Serialize<IList<whiteList>>(whiteListList);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

    }
}
