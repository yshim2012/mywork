using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LDV.WMS.RF.DataMapper;
using LDV.WMS.RF.Utility;

namespace LDV.WMS.RF.Business
{
    public class PickBatchService
    {
        /// <summary>
        /// 更新拣货计划表状态
        /// </summary>
        /// <param name="UserId"></param>
        /// <param name="NewPwd"></param>
        /// <returns></returns>
        public static int UpdateBatchStatus(double id)
        {
            try
            {
                SqlParamSet sqlParam = new SqlParamSet();
                sqlParam.AddParam("ID", id);

                return VWmsPickBatch.Update("Update", sqlParam.GetParams());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
