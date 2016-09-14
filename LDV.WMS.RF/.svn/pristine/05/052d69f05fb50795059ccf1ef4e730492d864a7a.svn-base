using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LDV.WMS.RF.Utility;
using LDV.WMS.RF.DataMapper;
using System.Data;
using IBatisNet.DataMapper;

namespace LDV.WMS.RF.Business
{
    public class PickTickDetailService
    {
        public static int UpdateStatus(double id,double allowQty,double pickedQty,string status,ISqlMapper sqlMapper)
        {
            try
            {
                SqlParamSet sqlParam = new SqlParamSet();
                sqlParam.AddParam("ID", id);
                sqlParam.AddParam("ALLOCATED_QTY", allowQty);
                sqlParam.AddParam("PICKED_QTY", pickedQty);
                sqlParam.AddParam("STATUS", status);
                return VWmsPickTicketDetail.Update(sqlMapper,"Update", sqlParam.GetParams());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

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
                return VWmsPickTicketDetail.QueryDataTable("SelectDetailByID", sqlParam.GetParams());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
