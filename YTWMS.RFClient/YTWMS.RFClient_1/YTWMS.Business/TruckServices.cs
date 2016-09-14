using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IBatisNet.Common;
using Utility;
using DataMapper;


namespace YTWMS.Business
{
    public class TruckServices
    {
        /// <summary>
        /// 获取所有车辆信息
        /// </summary>
        /// <returns></returns>
        public static DataTable GetTruckTable(int WAREHOUSE_ID)
        {
            try
            {
                SqlParamSet sqlParam = new SqlParamSet();
                sqlParam.AddParam("WAREHOUSE_ID", WAREHOUSE_ID);
                sqlParam.AddParam("IS_DISABLE", "0");

                return Truck.QueryDataTable("SelectByParam", sqlParam.GetParams());

            }
            catch (Exception ex)
            {
                RunTimeLogger.Debug(DateTime.Now.ToString() + ":" + ex.Message);
                return null;
            }
        }
    }
}
