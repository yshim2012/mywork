using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LDV.WMS.RF.DataMapper;
using LDV.WMS.RF.Utility;

namespace LDV.WMS.RF.Business
{
    public class PlanCheckService
    {
         /// <summary>
        /// 更新子表状态
        /// </summary>
        /// <param name="UserId"></param>
        /// <param name="NewPwd"></param>
        /// <returns></returns>
        public static int UpdateStatus(double id, double User_id,string state)
        {
            try
            {
                SqlParamSet sqlParam = new SqlParamSet();
                sqlParam.AddParam("ID", id);
                sqlParam.AddParam("STATE", state);
                sqlParam.AddParam("LAST_MODIFY_DATE", DBDateTimeGenerator.GetDBDateTime());
                sqlParam.AddParam("LAST_MODIFY_USER_ID", User_id);
                return LdvPlanCheck.Update("UpdateSection", sqlParam.GetParams());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
