using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using LDV.WMS.RF.DataMapper;
using LDV.WMS.RF.Utility;
using IBatisNet.DataMapper;

namespace LDV.WMS.RF.Business
{
    public class PlanMoveServices
    {
        /// <summary>
        /// 移库计划查询
        /// </summary>
        /// <param name="LocCode">库位</param>
        /// <param name="ItemCode">商品</param>
        /// <returns></returns>
        public static DataTable QueryMovePlan()
        {
            try
            {
                SqlParamSet sqlParam = new SqlParamSet();
                return LdvPlanMoveLoc.QueryDataTable("SelectMovePlan", sqlParam.GetParams());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 查询移库计划明细
        /// </summary>
        /// <param name="detailId"></param>
        /// <returns></returns>
        public static DataTable QueryMovePlanDetail(int detailId)
        {
            try
            {
                SqlParamSet sqlParam = new SqlParamSet();
                sqlParam.AddParam("ID", detailId);
                return LdvPlanMoveLocDetail.QueryDataTable("SelectMoveDetail", sqlParam.GetParams());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// 查询移库计划明细
        /// </summary>
        /// <param name="detailId"></param>
        /// <returns></returns>
        public static DataTable QueryMovePlanDetailByPlanNo(string planNO)
        {
            try
            {
                SqlParamSet sqlParam = new SqlParamSet();
                sqlParam.AddParam("MOVE_LOC_NUM", planNO);
                return LdvPlanMoveLocDetail.QueryDataTable("SelectMoveDetailByPlanNo", sqlParam.GetParams());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 移库计划确认
        /// </summary>
        /// <param name="detailId"></param>
        /// <returns></returns>
        public static bool ConfirmMovePlanDetail(string userName,int userId, int PlanId, int DetailId, int LocId, int TargetLocId, int MoveQty, DataTable litem)
        {
            IBatisNet.DataMapper.ISqlMapper sqlMapper = Sql_Mapper.Instance();
            sqlMapper.BeginTransaction();
            try
            {
                VWmsInvDetail vid = new VWmsInvDetail();
                vid.ID = double.Parse(litem.Rows[0]["ID"].ToString());
                //vid = (VWmsInvDetail)sqlMapper.QueryForObject("SelectById", vid);
                vid = vid.QueryObject(sqlMapper, "SelectById");
                if (vid.QTY < MoveQty)
                {
                    new Exception("异常:库存数量小于移库数量!");
                }

                VWmsInvDetail InvDt = new VWmsInvDetail();
                InvDt.ID = double.Parse(litem.Rows[0]["ID"].ToString());
                InvDt.QTY = vid.QTY - MoveQty;
                InvDt.Update(sqlMapper, "UpdateSection");

                VWmsInvDetail Sda = new VWmsInvDetail();
                Sda.LOC_ID = TargetLocId;
                Sda.MU_ID = vid.MU_ID;
                Sda.UID_ID = vid.UID_ID;
                Sda.STATUS = "V";
                Sda.ITEM_STATUS = "N";
                VWmsInvDetail exitDa = Sda.QueryObject(sqlMapper, "SelectByParam");
                if (exitDa != null)
                {
                    exitDa.QTY = exitDa.QTY + float.Parse(MoveQty.ToString());
                    exitDa.Update(sqlMapper, "UpdateQty");
                }
                else
                {
                    Sda.QTY = MoveQty;
                    Sda.VERSION_TRANSACTION = 0;
                    Sda.PLAN_PICK_QTY = 0;
                    Sda.Save(sqlMapper);//新建零件
                }

                //写仓库日志记录
                VWmsInvTransaction Tran = new VWmsInvTransaction();
                Tran.TRANSACTION_CODE = "com.vtradex.wms.inbound.MoveItem";
                Tran.WHSE_ID = double.Parse(litem.Rows[0]["WHSE_ID"].ToString());
                Tran.LOC_ID = double.Parse(litem.Rows[0]["LOC_ID"].ToString());
                Tran.T_LOC_ID = LocId;
                Tran.COMPANY_ID = 1;
                Tran.ITEM_ID = double.Parse(litem.Rows[0]["ITEM_ID"].ToString());
                Tran.LOT = litem.Rows[0]["LOT"].ToString();
                Tran.F_QTY = float.Parse(litem.Rows[0]["QTY"].ToString());
                Tran.T_QTY = float.Parse(litem.Rows[0]["QTY"].ToString());
                Tran.F_MU_ID = double.Parse(litem.Rows[0]["MU_ID"].ToString());
                Tran.T_MU_ID = double.Parse(litem.Rows[0]["MU_ID"].ToString());
                Tran.F_STATUS = "V";
                Tran.T_STATUS = "V";
                Tran.F_ITEM_STATUS = "N";
                Tran.T_ITEM_STATUS = "N";
                Tran.DESCRIPTION = "10";
                Tran.USER_ID = userName;
                Tran.CREATED_TIME = DBDateTimeGenerator.GetDBDateTime(sqlMapper);
                Tran.F_GOODSTYPE = "P";
                Tran.T_GOODSTYPE = "P";
                Tran.Save(sqlMapper);

                LdvPlanMoveLocDetail lpmld = new LdvPlanMoveLocDetail();
                lpmld.ID = DetailId;
                lpmld.STATE = "FI";
                lpmld.MOVE_QTY = MoveQty;
                //lpmld.QTY = Convert.ToInt32(vid.QTY);
                lpmld.MOVE_USER_ID = userId;
                lpmld.LAST_MODIFY_USER_ID = userId;

                int i = lpmld.Update(sqlMapper, "UpdateState");
                if (i <= 0)
                {
                    sqlMapper.RollBackTransaction();
                    return false;
                }

                ///移库计划确认
                if (!ConfirmMovePlan(sqlMapper, PlanId, userId))
                {
                    sqlMapper.RollBackTransaction();
                    return false;
                }

                sqlMapper.CommitTransaction();
                return true;

            }
            catch (Exception ex)
            {
                sqlMapper.RollBackTransaction();
                throw ex;
            }
        }

        /// <summary>
        /// 检测移库计划是否完成
        /// </summary>
        /// <param name="?"></param>
        /// <returns></returns>
        public static bool ConfirmMovePlan(IBatisNet.DataMapper.ISqlMapper sqlMap, int planId, int UserId)
        {
            try
            {
                 SqlParamSet sqlParam = new SqlParamSet();
                 sqlParam.AddParam("ID", planId);
                int iCount = LdvPlanMoveLoc.QueryDataTable(sqlMap, "SelectMovePlan", sqlParam.GetParams()).Rows.Count;

                LdvPlanMoveLoc lml = new LdvPlanMoveLoc();
                lml.ID = planId;
                lml.LAST_MODIFY_USER_ID = UserId;
                if (iCount <= 0)
                    lml.STATE = "FI";
                else
                    lml.STATE = "OP";
                int i=lml.Update(sqlMap, "UpdateState");
                if (i <= 0)
                    return false;
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
