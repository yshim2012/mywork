using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LDV.WMS.RF.DataMapper;
using LDV.WMS.RF.Utility;
using IBatisNet.DataMapper;

namespace LDV.WMS.RF.Business
{
    public class PickQueueService
    {
        /// <summary>
        /// 更新拣货计划表状态
        /// </summary>
        /// <param name="UserId"></param>
        /// <param name="NewPwd"></param>
        /// <returns></returns>
        public static int UpdateStatus(double id,double count,ISqlMapper sqlMapper)
        {
            try
            {
                SqlParamSet sqlParam = new SqlParamSet();
                sqlParam.AddParam("PICK_TICKET_ID", id);
                sqlParam.AddParam("ALLOC_QTY", count);
                sqlParam.AddParam("PICKED_QTY", count);
                return VWmsPickQueue.Update(sqlMapper,"UpdateStatus", sqlParam.GetParams());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 更新拣货计划表状态
        /// </summary>
        /// <param name="UserId"></param>
        /// <param name="NewPwd"></param>
        /// <returns></returns>
        public static int UpdateQueueQty(double id, double count,ISqlMapper sqlMapper)
        {
            try
            {
                SqlParamSet sqlParam = new SqlParamSet();
                sqlParam.AddParam("PICK_TICKET_ID", id);
                sqlParam.AddParam("ALLOC_QTY", count);
                sqlParam.AddParam("PICKED_QTY", count);
                return VWmsPickQueue.Update(sqlMapper,"UpdateQueueQty", sqlParam.GetParams());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// 更新数量
        /// </summary>
        /// <param name="UserId"></param>
        /// <param name="NewPwd"></param>
        /// <returns></returns>
        public static int UpdateQty(double id,double qty)
        {
            try
            {
                SqlParamSet sqlParam = new SqlParamSet();
                sqlParam.AddParam("ID", id);
                sqlParam.AddParam("ALLOCATED_QTY", qty);
                return VWmsPickQueuePlanact.Update("UpdateQty", sqlParam.GetParams());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 更新数量
        /// </summary>
        /// <param name="UserId"></param>
        /// <param name="NewPwd"></param>
        /// <returns></returns>
        public static int UpdateActQty(double id, double qty,ISqlMapper sqlMapper)
        {
            try
            {
                SqlParamSet sqlParam = new SqlParamSet();
                sqlParam.AddParam("ID", id);
                sqlParam.AddParam("ACT_QTY", qty);
                return VWmsPickQueuePlanact.Update(sqlMapper,"UpdateActQty", sqlParam.GetParams());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
