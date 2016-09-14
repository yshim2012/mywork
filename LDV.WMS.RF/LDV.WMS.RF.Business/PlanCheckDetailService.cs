using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using LDV.WMS.RF.Utility;
using LDV.WMS.RF.DataMapper;

namespace LDV.WMS.RF.Business
{
    public class PlanCheckDetailService
    {
        /// <summary>
        /// 查询对像LIST
        /// </summary>
        /// <param name="param"></param>
        /// <returns>DataTable</returns>
        public static DataTable QueryDataTableByParam(string checkCredence, string login_name,double UserId)
        {
            SqlParamSet sqlParam = new SqlParamSet();
            sqlParam.AddParam("CHECK_CREDENCE", checkCredence);
            sqlParam.AddParam("LOGINNAME", login_name);
            sqlParam.AddParam("USER_ID", UserId);
            try
            {
                return LdvPlanCheckDetail.QueryDataTable("SelectForCheck", sqlParam.GetParams());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 更新子表状态
        /// </summary>
        /// <param name="UserId"></param>
        /// <param name="NewPwd"></param>
        /// <returns></returns>
        public static int UpdateStatus(double id, double User_id,double qty,string state)
        {
            try
            {
                SqlParamSet sqlParam = new SqlParamSet();
                sqlParam.AddParam("ID", id);
                sqlParam.AddParam("STATE", "FI");
                sqlParam.AddParam("LAST_MODIFY_DATE", DBDateTimeGenerator.GetDBDateTime());
                sqlParam.AddParam("LAST_MODIFY_USER_ID", User_id);
                sqlParam.AddParam("CHECK_USER_ID", User_id);
                sqlParam.AddParam("CHECK_QTY", qty);
                return LdvPlanCheckDetail.Update("UpdateSection", sqlParam.GetParams());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
