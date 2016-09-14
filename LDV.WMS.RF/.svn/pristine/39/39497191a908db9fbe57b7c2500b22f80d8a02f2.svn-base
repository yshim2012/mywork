using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LDV.WMS.RF.DataMapper;
using LDV.WMS.RF.Utility;
using IBatisNet.DataMapper;

namespace LDV.WMS.RF.Business
{
    public class PickQueueActService
    {
        /// <summary>
        /// 更新拣货计划表状态
        /// </summary>
        /// <param name="UserId"></param>
        /// <param name="NewPwd"></param>
        /// <returns></returns>
        public static int UpdateStatus(double id)
        {
            try
            {
                SqlParamSet sqlParam = new SqlParamSet();
                sqlParam.AddParam("PICK_TICKET_ID", id);

                return VWmsPickQueueAct.Update("UpdateStatus", sqlParam.GetParams());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void InsertQueueAct(double batch_id, double pick_queue_id, double loc_id, double mu_id, double uid_id, double allocated_qty, double picked_qty, string loginName, double pick_ticket_id, string line_no, string INV_DETAIL_ID, ISqlMapper sqlMapper)
        {
           
            try
            {
                
               
                VWmsPickQueueAct VwmsPickQueueAct = new VWmsPickQueueAct();
                VwmsPickQueueAct.BATCH_ID = batch_id;
                VwmsPickQueueAct.PICK_QUEUE_ID = pick_queue_id;
                VwmsPickQueueAct.LOC_ID = loc_id;
                VwmsPickQueueAct.MU_ID = mu_id;
                VwmsPickQueueAct.UID_ID = uid_id;
                VwmsPickQueueAct.ALLOCATED_QTY = allocated_qty;
                VwmsPickQueueAct.PICKED_QTY = picked_qty;
                VwmsPickQueueAct.USER_ID = loginName;
                VwmsPickQueueAct.PICKED_TIME = DBDateTimeGenerator.GetDBDateTime(sqlMapper);
                VwmsPickQueueAct.IS_DISABLED = "0";
                VwmsPickQueueAct.LAST_MODIFIED = DBDateTimeGenerator.GetDBDateTime(sqlMapper);
                VwmsPickQueueAct.EXTEND_COLUMN_0 = "CL";
                VwmsPickQueueAct.EXTEND_COLUMN_1 = "0";
                VwmsPickQueueAct.EXTEND_COLUMN_2 = "";
                VwmsPickQueueAct.EXTEND_COLUMN_3 = "";
                VwmsPickQueueAct.EXTEND_COLUMN_4 = "";
                VwmsPickQueueAct.SHIP_TIME = DBDateTimeGenerator.GetDBDateTime(sqlMapper);
                VwmsPickQueueAct.INV_DETAIL_ID = INV_DETAIL_ID;
                VwmsPickQueueAct.Save(sqlMapper);
                //return true;
            }
            catch (Exception ex)
            {
                sqlMapper.RollBackTransaction();
                throw ex;
            }
        }

    }
}
