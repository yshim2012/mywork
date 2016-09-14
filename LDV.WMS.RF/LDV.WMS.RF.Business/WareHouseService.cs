using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using LDV.WMS.RF.Utility;
using LDV.WMS.RF.DataMapper;

namespace LDV.WMS.RF.Business
{
    public class WareHouseService
    {
        /// <summary>
        /// 查询对像LIST
        /// </summary>
        /// <param name="param"></param>
        /// <returns>DataTable</returns>
        public static DataTable QueryDataTableByParam(double id)
        {
            SqlParamSet sqlParam = new SqlParamSet();
            sqlParam.AddParam("ID", id);
            try
            {

                DataTable dt = VWmsBaseWarehouse.QueryDataTable("SelectByWare", sqlParam.GetParams());
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
