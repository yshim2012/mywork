using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IBatisNet.DataMapper;
using System.Data;
using DataMapper;
using Utility;

namespace YTWMS.Business
{
    public class WareHouseServices
    {
        /// <summary>
        /// 获取流水号的方法
        /// </summary>
        /// <param name="warehousecode">仓库代码（'SQ'）</param>
        /// <param name="type">类型</param>
        /// <returns></returns>
        public static string GetSerialNo(string warehousecode, string type)
        {
            try
            {
                string serialno = string.Empty;
                StringBuilder strsql = new StringBuilder();
                strsql.Append("DECLARE @warehouse VARCHAR(20) ;")
                    .Append("DECLARE @typename VARCHAR(20)")
                    .Append("DECLARE @SerialNumbers VARCHAR(20)")
                    .Append("SET @warehouse='" + warehousecode + "'")
                    .Append("SET @typename='" + type + "'")
                    .Append("EXEC SP_GET_SERIAL_NUM @warehouse ,@typename,@SerialNumbers OUTPUT;")
                    .Append(" Select @SerialNumbers AS Serial_no");

                DataTable dt = new DataTable();

                ISqlMapper sqlMapper = Sql_Mapper.Instance();
                dt = sqlMapper.ExecuteSqlWithQueryDataTable(strsql.ToString(), "Serial_Table");
                if (dt != null && dt.Rows.Count > 0)
                {
                    return dt.Rows[0]["Serial_no"].ToString();
                }
                return "";
            }
            catch (Exception ex)
            {
                RunTimeLogger.Debug(DateTime.Now.ToString() + ":" + ex.Message);
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// 获取流水号的方法
        /// </summary>
        /// <param name="warehousecode">仓库代码（'SQ'）</param>
        /// <param name="type">类型</param>
        /// <returns></returns>
        public static string GetSerialNo(string warehousecode, string type, ISqlMapper sqlMapper)
        {
            try
            {
                string serialno = string.Empty;
                StringBuilder strsql = new StringBuilder();
                strsql.Append("DECLARE @warehouse VARCHAR(20) ;")
                    .Append("DECLARE @typename VARCHAR(20)")
                    .Append("DECLARE @SerialNumbers VARCHAR(20)")
                    .Append("SET @warehouse='" + warehousecode + "'")
                    .Append("SET @typename='" + type + "'")
                    .Append("EXEC SP_GET_SERIAL_NUM @warehouse ,@typename,@SerialNumbers OUTPUT;")
                    .Append(" Select @SerialNumbers AS Serial_no");

                DataTable dt = new DataTable();

                dt = sqlMapper.ExecuteSqlWithQueryDataTable(strsql.ToString(), "Serial_Table");
                if (dt != null && dt.Rows.Count > 0)
                {
                    return dt.Rows[0]["Serial_no"].ToString();
                }
                return "";
            }
            catch (Exception ex)
            {
                RunTimeLogger.Debug(DateTime.Now.ToString() + ":" + ex.Message);
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// 获取仓库信息
        /// </summary>
        /// <param name="sqlMapper"></param>
        /// <param name="wareHouse"></param>
        /// <returns></returns>
        public static WareHouse GetWareHouseID(WareHouse wareHouse)
        {
            try
            {
                ISqlMapper sqlMapper = Sql_Mapper.Instance();
                return (WareHouse)sqlMapper.QueryForObject("WareHouse.SelectWID", wareHouse);
            }
            catch (Exception ex)
            {
                RunTimeLogger.Debug(DateTime.Now.ToString() + ":" + ex.Message);
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// 获取退货供应商
        /// </summary>
        /// <param name="warehouseId"></param>
        /// <returns></returns>
        public static DataTable GetSupplier(int warehouseId)
        {
            try
            {
                WareHouse supplier = new WareHouse() { WAREHOUSE_ID = warehouseId, IS_DISABLE=EnumParser.GetEnumFiledValue(Is_Disable.有效).ToString(),
                                                       TYPE = EnumParser.GetEnumFiledValue(WareHouseType.供应商).ToString()};

                ISqlMapper sqlMapper = Sql_Mapper.Instance();
                return sqlMapper.QueryForDataTable("WareHouse.SelectWID", supplier, "Supplier");
            }
            catch (Exception ex)
            {
                RunTimeLogger.Debug(DateTime.Now.ToString() + ":" + ex.Message);
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// 获取仓库大项目
        /// </summary>
        /// <param name="warehouseId"></param>
        /// <returns></returns>
        public static DataTable GetProject(int warehouseId)
        {
            try
            {
                SqlParamSet sqlParam = new SqlParamSet();
                sqlParam.AddParam("WAREHOUSE_ID", warehouseId);
                sqlParam.AddParam("IS_DISABLE", "0");
                sqlParam.AddParam("PROJECT_TYPE", EnumParser.GetEnumFiledValue(ProjectType.大项目).ToString());

                ISqlMapper sqlMapper = Sql_Mapper.Instance();
                return sqlMapper.QueryForDataTable("Project.SelectByParam", sqlParam.GetParams(), "Supplier");
            }
            catch (Exception ex)
            {
                RunTimeLogger.Debug(DateTime.Now.ToString() + ":" + ex.Message);
                throw new Exception(ex.Message);
            }
        }
    }
}
