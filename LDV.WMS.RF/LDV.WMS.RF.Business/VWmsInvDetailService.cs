using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using LDV.WMS.RF.DataMapper;
using LDV.WMS.RF.Utility;
using IBatisNet.DataMapper;

namespace LDV.WMS.RF.Business
{
    /// <summary>
    /// 库存
    /// </summary>
    public class VWmsInvDetailService
    {
        /// <summary>
        /// 库存查询
        /// </summary>
        /// <param name="LocCode">库位</param>
        /// <param name="ItemCode">商品</param>
        /// <returns></returns>
        public static IList<LocItem>  QueryVWmsInvDetail(string LocCode, string ItemCode)
        {
            SqlParamSet sqlParam = new SqlParamSet();
            sqlParam.AddParam("LOC_CODE", LocCode);
            sqlParam.AddParam("ITEM_CODE", ItemCode);

            try
            {
                return LocItem.QueryList("SelectLocItemByParam", sqlParam.GetParams());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable QueryVWmsInvDetailForDataTable(string LocCode, string ItemCode)
        {
            SqlParamSet sqlParam = new SqlParamSet();
            sqlParam.AddParam("LOC_CODE", LocCode);
            sqlParam.AddParam("ITEM_CODE", ItemCode);

            try
            {
                return VWmsInvDetail.QueryDataTable("SelectLocItemByParam", sqlParam.GetParams());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        //add by xhy  扩展，添加批号
        public static DataTable QueryVWmsInvDetailForDataTable(string LocCode, string ItemCode,string lotNo)
        {
            SqlParamSet sqlParam = new SqlParamSet();
            sqlParam.AddParam("LOC_CODE", LocCode);
            sqlParam.AddParam("ITEM_CODE", ItemCode);
            sqlParam.AddParam("LOT_NO", lotNo);

            try
            {
                return VWmsInvDetail.QueryDataTable("SelectLocItemByParam", sqlParam.GetParams());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable QueryVWmsInvDetailForDataTable(string LocCode, string ItemCode, double muId, double uId)
        {
            SqlParamSet sqlParam = new SqlParamSet();
            sqlParam.AddParam("LOC_CODE", LocCode);
            sqlParam.AddParam("ITEM_CODE", ItemCode);
            sqlParam.AddParam("MU_ID", muId);
            sqlParam.AddParam("UID_ID", uId);

            try
            {
                return VWmsInvDetail.QueryDataTable("SelectLocItemByParam", sqlParam.GetParams());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable QueryVWmsInvDetailForDataTable1(string LocCode, string ItemCode, double muId, double uId)
        {
            SqlParamSet sqlParam = new SqlParamSet();
            sqlParam.AddParam("LOC_CODE", LocCode);
            sqlParam.AddParam("ITEM_CODE", ItemCode);
            sqlParam.AddParam("MU_ID", muId);
            sqlParam.AddParam("UID_ID", uId);

            try
            {
                return VWmsInvDetail.QueryDataTable("SelectLocItemByParam1", sqlParam.GetParams());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        ///// <summary>
        ///// 更新分配数量
        ///// </summary>
        ///// <param name="UserId"></param>
        ///// <param name="NewPwd"></param>
        ///// <returns></returns>
        //public static int UpdatePlanPickQty(double id, double qty, ISqlMapper sqlMapper)
        //{
        //    try
        //    {
        //        SqlParamSet sqlParam = new SqlParamSet();
        //        sqlParam.AddParam("ID", id);
        //        sqlParam.AddParam("PLAN_PICK_QTY", qty);
        //        return VWmsInvDetail.Update(sqlMapper, "UpdateSection", sqlParam.GetParams());
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        /// <summary>
        /// 库存明细查询
        /// </summary>
        /// <param name="loc_id">库位</param>
        /// <param name="mu_id"></param>
        /// <param name="uid_id"></param>
        /// <returns></returns>
        public static VWmsInvDetail QueryInvDetail(double loc_id, double mu_id, double uid_id,ISqlMapper sqlMapper)
        {
            SqlParamSet sqlParam = new SqlParamSet();
            sqlParam.AddParam("LOC_ID", loc_id);
            sqlParam.AddParam("MU_ID", mu_id);
            sqlParam.AddParam("UID_ID", uid_id);
            try
            {
                return VWmsInvDetail.QueryObject(sqlMapper, "SelectByParam", sqlParam.GetParams());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 零件库存查询
        /// </summary>
        /// <param name="LOT_CODE">库位</param>
        /// <param name="ITEM_CODE">零件代码</param>
        /// <param name="UserId">用户ID</param>
        /// <returns></returns>
        public static DataTable QueryPartQty(string LOC_CODE, string ITEM_CODE, string UserId)
        {
            try
            {
                SqlParamSet sqlParam = new SqlParamSet();
                if (LOC_CODE != string.Empty)
                {
                    sqlParam.AddParam("LOC_CODE", LOC_CODE);
                }
                if (ITEM_CODE != string.Empty)
                {
                    sqlParam.AddParam("ITEM_CODE", ITEM_CODE);
                }
                sqlParam.AddParam("ID", UserId);
                DataTable Result = VWmsInvDetail.QueryDataTable("SelectByPartQty", sqlParam.GetParams());
                Result.TableName = "OrderList";
                return Result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 零件库存查询
        /// </summary>
        /// <param name="LOT_CODE">库位</param>
        /// <param name="ITEM_CODE">零件代码</param>
        /// <param name="UserId">用户ID</param>
        /// <returns></returns>
        public static DataTable QueryPartSupplierLoc(string ITEM_CODE)
        {
            try
            {
                SqlParamSet sqlParam = new SqlParamSet();
              
                if (ITEM_CODE != string.Empty)
                {
                    sqlParam.AddParam("ITEM_CODE", ITEM_CODE);
                }
                DataTable Result = VWmsInvDetail.QueryDataTable("SelectByPartSupplierLoc", sqlParam.GetParams());
                Result.TableName = "OrderList";
                return Result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //add by xhy  根据库存ID查询库存信息 2015年6月25日 14:12:45
        public static DataTable QueryVWmsInvDetailByInvId(int ID)
        {
            SqlParamSet sqlParam = new SqlParamSet();
            sqlParam.AddParam("ID", ID);
            try
            {
                return VWmsInvDetail.QueryDataTable("SelectLocItemByParam", sqlParam.GetParams());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
