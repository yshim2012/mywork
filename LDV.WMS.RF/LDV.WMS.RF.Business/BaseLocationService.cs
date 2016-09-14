using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Collections;
using LDV.WMS.RF.DataMapper;
using LDV.WMS.RF.Utility;
using IBatisNet.DataMapper;

namespace LDV.WMS.RF.Business
{
    public class BaseLocationService
    {
        /// <summary>
        /// 查询空库位
        /// </summary>
        /// <param name="param"></param>
        /// <returns>DataTable</returns>
        public static DataTable QueryDataTableByParam(string locNumber, double userId)
        {
            SqlParamSet sqlParam = new SqlParamSet();
            sqlParam.AddParam("LOC_CODE", locNumber);
            sqlParam.AddParam("USER_ID", userId);
            try
            {
                return VWmsBaseLocation.QueryDataTable("SelectForNull", sqlParam.GetParams());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 查询主库位
        /// </summary>
        /// <param name="LocCode">库位</param>
        /// <returns></returns>
        public static DataTable QueryMainLoc(string LocCode)
        {
            SqlParamSet sqlParam = new SqlParamSet();
            sqlParam.AddParam("LOC_CODE", LocCode);

            try
            {
                return VWmsBaseLocation.QueryDataTable("SelectMainLoc", sqlParam.GetParams());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 根据库位代码查ID
        /// </summary>
        /// <param name="LocCode">库位</param>
        /// <returns></returns>
        public static DataTable QueryByLocId(string LocCode, ISqlMapper sqlMapper)
        {
            SqlParamSet sqlParam = new SqlParamSet();
            sqlParam.AddParam("LOC_CODE", LocCode);

            try
            {
                return VWmsBaseLocation.QueryDataTable(sqlMapper, "SelectCheckLocById", sqlParam.GetParams());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 根据库位代码查ID
        /// </summary>
        /// <param name="LocCode">库位</param>
        /// <returns></returns>
        public static DataTable QueryByLocId(string LocCode)
        {
            SqlParamSet sqlParam = new SqlParamSet();
            sqlParam.AddParam("LOC_CODE", LocCode);

            try
            {
                return VWmsBaseLocation.QueryDataTable("SelectCheckLocById", sqlParam.GetParams());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 拣货移零件
        /// </summary>
        /// <param name="Count"></param>
        /// <param name="litem"></param>
        /// <param name="LocId"></param>
        public static void MovePickItem(int Count, DataTable litem, double LocId, string LoginNames)
        {
            IBatisNet.DataMapper.ISqlMapper sqlMapper = Sql_Mapper.Instance();
            sqlMapper.BeginTransaction();
            double CurrCount = 0;
            try
            {
                foreach (DataRow item in litem.Rows)//移零件
                {
                    if (double.Parse(item["QTY"].ToString()) == (Count - CurrCount))//数量合适，直接修改库位
                    {
                        VWmsInvDetail InvDt = new VWmsInvDetail();
                        InvDt.ID = double.Parse(item["ID"].ToString());
                        InvDt.LOC_ID = LocId;
                        InvDt.Update(sqlMapper, "UpdateSection");

                        //写仓库日志记录
                        VWmsInvTransaction Tran = new VWmsInvTransaction();
                        Tran.TRANSACTION_CODE = "com.vtradex.wms.anji.inventory.FrozenInv";
                        Tran.WHSE_ID = double.Parse(item["WHSE_ID"].ToString());
                        Tran.LOC_ID = double.Parse(item["LOC_ID"].ToString());
                        Tran.T_LOC_ID = LocId;
                        Tran.COMPANY_ID = 1;
                        Tran.ITEM_ID = double.Parse(item["ITEM_ID"].ToString());
                        Tran.LOT = item["LOT"].ToString();
                        Tran.F_QTY = float.Parse(item["QTY"].ToString());
                        Tran.T_QTY = float.Parse(item["QTY"].ToString());
                        Tran.F_MU_ID = double.Parse(item["MU_ID"].ToString());
                        Tran.T_MU_ID = double.Parse(item["MU_ID"].ToString());
                        Tran.F_STATUS = "V";
                        Tran.T_STATUS = "V";
                        Tran.F_ITEM_STATUS = "N";
                        Tran.T_ITEM_STATUS = "N";
                        Tran.DESCRIPTION = "10";
                        Tran.USER_ID = LoginNames;
                        Tran.CREATED_TIME = DBDateTimeGenerator.GetDBDateTime(sqlMapper);
                        Tran.F_GOODSTYPE = "P";
                        Tran.T_GOODSTYPE = "P";
                        Tran.Save(sqlMapper);
                        break;
                    }
                    if (double.Parse(item["QTY"].ToString()) > Count - CurrCount)//零件库存大于移动库存
                    {
                        VWmsInvDetail InvDt = new VWmsInvDetail();
                        InvDt.ID = double.Parse(item["ID"].ToString());
                        InvDt.QTY = float.Parse(item["QTY"].ToString()) - float.Parse((Count - CurrCount).ToString());
                        InvDt.Update(sqlMapper, "UpdateSection");

                        VWmsInvDetail Sda = new VWmsInvDetail();
                        Sda.LOC_ID = LocId;
                        Sda.MU_ID = double.Parse(item["MU_ID"].ToString());
                        Sda.UID_ID = double.Parse(item["UID_ID"].ToString());
                        Sda.STATUS = "V";
                        Sda.ITEM_STATUS = "N";
                        Sda.QTY = float.Parse((Count - CurrCount).ToString());
                        Sda.VERSION_TRANSACTION = 0;
                        Sda.Save(sqlMapper);//新建零件

                        VWmsInvTransaction Tran = new VWmsInvTransaction();
                        Tran.TRANSACTION_CODE = "com.vtradex.wms.anji.inventory.FrozenInv";
                        Tran.WHSE_ID = double.Parse(item["WHSE_ID"].ToString());
                        Tran.LOC_ID = double.Parse(item["LOC_ID"].ToString());
                        Tran.T_LOC_ID = LocId;
                        Tran.COMPANY_ID = 1;
                        Tran.ITEM_ID = double.Parse(item["ITEM_ID"].ToString());
                        Tran.LOT = item["LOT"].ToString();
                        Tran.F_QTY = float.Parse(item["QTY"].ToString());
                        Tran.T_QTY = InvDt.QTY;
                        Tran.F_MU_ID = double.Parse(item["MU_ID"].ToString()); ;
                        Tran.T_MU_ID = double.Parse(item["MU_ID"].ToString());
                        Tran.F_STATUS = "V";
                        Tran.T_STATUS = "V";
                        Tran.F_ITEM_STATUS = "N";
                        Tran.T_ITEM_STATUS = "N";
                        Tran.DESCRIPTION = "10";
                        Tran.USER_ID = LoginNames;
                        Tran.CREATED_TIME = DBDateTimeGenerator.GetDBDateTime(sqlMapper);
                        Tran.F_GOODSTYPE = "P";
                        Tran.T_GOODSTYPE = "P";
                        Tran.Save(sqlMapper);
                        break;
                    }
                    if (double.Parse(item["QTY"].ToString()) < Count - CurrCount)//零件库存 小于移动库存 
                    {
                        if (double.Parse(item["QTY"].ToString()) < (Count - CurrCount))
                        {
                            VWmsInvDetail InvDt = new VWmsInvDetail();
                            InvDt.ID = double.Parse(item["ID"].ToString());
                            InvDt.LOC_ID = LocId;
                            InvDt.Update(sqlMapper, "UpdateSection");
                            CurrCount += double.Parse(item["QTY"].ToString());

                            VWmsInvTransaction Tran = new VWmsInvTransaction();
                            Tran.TRANSACTION_CODE = "com.vtradex.wms.anji.inventory.FrozenInv";
                            Tran.WHSE_ID = double.Parse(item["WHSE_ID"].ToString());
                            Tran.LOC_ID = double.Parse(item["LOC_ID"].ToString());
                            Tran.T_LOC_ID = LocId;
                            Tran.COMPANY_ID = 1;
                            Tran.ITEM_ID = double.Parse(item["ITEM_ID"].ToString());
                            Tran.LOT = item["LOT"].ToString();
                            Tran.F_QTY = float.Parse(item["QTY"].ToString());
                            Tran.T_QTY = float.Parse(item["QTY"].ToString());
                            Tran.F_MU_ID = double.Parse(item["MU_ID"].ToString()); ;
                            Tran.T_MU_ID = double.Parse(item["MU_ID"].ToString());
                            Tran.F_STATUS = "V";
                            Tran.T_STATUS = "V";
                            Tran.F_ITEM_STATUS = "N";
                            Tran.T_ITEM_STATUS = "N";
                            Tran.DESCRIPTION = "10";
                            Tran.USER_ID = LoginNames;
                            Tran.CREATED_TIME = DBDateTimeGenerator.GetDBDateTime(sqlMapper);
                            Tran.F_GOODSTYPE = "P";
                            Tran.T_GOODSTYPE = "P";
                            Tran.Save(sqlMapper);
                            continue;
                        }
                        if (double.Parse(item["QTY"].ToString()) > (Count - CurrCount))
                        {
                            VWmsInvDetail InvDt = new VWmsInvDetail();
                            InvDt.ID = double.Parse(item["ID"].ToString());
                            InvDt.QTY = float.Parse(item["QTY"].ToString()) - float.Parse((Count - CurrCount).ToString());
                            InvDt.Update(sqlMapper, "UpdateSection");

                            VWmsInvDetail Sda = new VWmsInvDetail();
                            Sda.LOC_ID = LocId;
                            Sda.MU_ID = double.Parse(item["MU_ID"].ToString());
                            Sda.UID_ID = double.Parse(item["UID_ID"].ToString());
                            Sda.STATUS = "V";
                            Sda.ITEM_STATUS = "N";
                            Sda.QTY = float.Parse((Count - CurrCount).ToString());
                            Sda.VERSION_TRANSACTION = 0;
                            Sda.Save(sqlMapper);//新建零件

                            VWmsInvTransaction Tran = new VWmsInvTransaction();
                            Tran.TRANSACTION_CODE = "com.vtradex.wms.anji.inventory.FrozenInv";
                            Tran.WHSE_ID = double.Parse(item["WHSE_ID"].ToString());
                            Tran.LOC_ID = double.Parse(item["LOC_ID"].ToString());
                            Tran.T_LOC_ID = LocId;
                            Tran.COMPANY_ID = 1;
                            Tran.ITEM_ID = double.Parse(item["ITEM_ID"].ToString());
                            Tran.LOT = item["LOT"].ToString();
                            Tran.F_QTY = float.Parse(item["QTY"].ToString());
                            Tran.T_QTY = InvDt.QTY;
                            Tran.F_MU_ID = double.Parse(item["MU_ID"].ToString());
                            Tran.T_MU_ID = double.Parse(item["MU_ID"].ToString());
                            Tran.F_STATUS = "V";
                            Tran.T_STATUS = "V";
                            Tran.F_ITEM_STATUS = "N";
                            Tran.T_ITEM_STATUS = "N";
                            Tran.DESCRIPTION = "10";
                            Tran.USER_ID = LoginNames;
                            Tran.CREATED_TIME = DBDateTimeGenerator.GetDBDateTime(sqlMapper);
                            Tran.F_GOODSTYPE = "P";
                            Tran.T_GOODSTYPE = "P";
                            Tran.Save(sqlMapper);
                            break;
                        }
                    }
                }
                sqlMapper.CommitTransaction();
            }
            catch (Exception ex)
            {
                sqlMapper.RollBackTransaction();
                throw ex;
            }
        }
        public static bool Pick(int Count, DataRow dtRow, string userId, DataTable litem, string LocId, string LoginName)
        {
            IBatisNet.DataMapper.ISqlMapper sqlMapper = Sql_Mapper.Instance();
            string inDlistid = string.Empty;
            try
            {
                sqlMapper.BeginTransaction();
                //移库
                inDlistid = MovePickItemRdID(dtRow, Count, litem, double.Parse(LocId), LoginName, userId, sqlMapper);
                if (inDlistid == "")
                {
                    sqlMapper.RollBackTransaction();
                    return false;
                }
                //提交拣货信息数据
                bool pickScan = PickSubmit(Count, dtRow, userId, inDlistid,LoginName, sqlMapper);
                if (pickScan == false)
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
                return false;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Count">拣货数量</param>
        /// <param name="dtRow">拣货单数据</param>
        /// <param name="userId"></param>
        /// <param name="inDlistid"></param>
        /// <param name="sqlMapper"></param>
        /// <returns></returns>
        public static bool PickSubmit(double Count, DataRow dtRow, string userId, string inDlistid,string loginName, ISqlMapper sqlMapper)
        {
            double muId = double.Parse(dtRow["MU_ID"].ToString());
            double uId = double.Parse(dtRow["UID_ID"].ToString());
            string OldLoc = dtRow["LOC_CODE"].ToString();
            string PartCode = dtRow["ITEM_CODE"].ToString();
            double wantCount = double.Parse(dtRow["ALLOCATED_QTY"].ToString());//要求拣货数
            double detailId = double.Parse(dtRow["DETAIL_ID"].ToString());
            double pickId = double.Parse(dtRow["TICKET_ID"].ToString());
            double queueId = double.Parse(dtRow["PICK_ID"].ToString());
            double BatchId = double.Parse(dtRow["BATCH_ID"].ToString());
            double vpaId = double.Parse(dtRow["VPA_ID"].ToString());
            double vpqId = double.Parse(dtRow["VPQ_ID"].ToString());
            double pickQty = double.Parse(dtRow["PICKED_QTY"].ToString());
            double vpaQty = double.Parse(dtRow["ACT_QTY"].ToString());
            string lineNo = dtRow["LINE_NO"].ToString();
            double order_plan_qty = double.Parse(dtRow["ORDER_QTY"].ToString());
            try
            {
                DataTable dtLoc = BaseLocationService.QueryByLocId(OldLoc, sqlMapper);
                double loc_id = double.Parse(dtLoc.Select("LOC_CODE='" + OldLoc + "'")[0]["LOC_ID"].ToString());
                if (pickQty + Count > order_plan_qty)
                {
                    sqlMapper.RollBackTransaction();
                    return false;
                }
                if (Count == wantCount)
                {
                    PickQueueActService.InsertQueueAct(BatchId, vpqId, loc_id, muId, uId, wantCount, Count, loginName, pickId, lineNo, inDlistid, sqlMapper);
                    PickQueueService.UpdateActQty(vpaId, vpaQty + Count, sqlMapper);
                    if (pickQty + Count == order_plan_qty)
                    {
                        PickTickDetailService.UpdateStatus(detailId, pickQty + Count, pickQty + Count, "BL", sqlMapper);
                        PickTicketService.UpdateStatus(pickId, sqlMapper);
                        PickQueueService.UpdateStatus(queueId, pickQty + Count, sqlMapper);
                    }
                    else
                    {
                        PickTickDetailService.UpdateStatus(detailId, pickQty + Count, pickQty + Count, "BL", sqlMapper);
                        PickQueueService.UpdateQueueQty(queueId, pickQty + Count, sqlMapper);
                    }

                }
                else if (Count < wantCount)
                {

                    if (Count.ToString().Trim() != string.Empty)
                    {
                        PickQueueActService.InsertQueueAct(BatchId, vpqId, loc_id, muId, uId, wantCount, Count, loginName, pickId, lineNo, inDlistid, sqlMapper);
                    }

                    //double pickQty = Convert.ToDouble(detailDt.Rows[0]["PICKED_QTY"].ToString());
                    if (pickQty.ToString().Trim() == string.Empty)
                    {
                        PickTickDetailService.UpdateStatus(detailId, Count, Count, "BL", sqlMapper);
                        PickQueueService.UpdateQueueQty(queueId, Count, sqlMapper);
                        PickQueueService.UpdateActQty(vpaId, Count, sqlMapper);
                    }
                    else
                    {
                        double aa = Convert.ToDouble(Count.ToString()) + pickQty;
                        double bb = Convert.ToDouble(Count.ToString()) + vpaQty;
                        PickTickDetailService.UpdateStatus(detailId, aa, aa, "BL", sqlMapper);
                        PickQueueService.UpdateQueueQty(queueId, aa, sqlMapper);
                        PickQueueService.UpdateActQty(vpaId, bb, sqlMapper);

                    }

                }
                return true;
            }
            catch (Exception ex)
            {
                sqlMapper.RollBackTransaction();
                throw ex;
            }
        }
        /// <summary>
        /// 拣货移零件
        /// </summary>
        /// <param name="Count"></param>
        /// <param name="litem"></param>
        /// <param name="LocId"></param>
        public static string MovePickItemRdID(DataRow dtRow, int Count, DataTable litem, double LocId, string LoginNames, string userId, ISqlMapper sqlMapper)
        {

            int Qty = 0;
            string ivDid = "";
            try
            {
                foreach (DataRow item in litem.Rows)//移零件
                {
                    //写仓库日志记录
                    VWmsInvTransaction Tran = new VWmsInvTransaction();
                    Tran.TRANSACTION_CODE = "com.vtradex.wms.anji.inventory.FrozenInv";
                    Tran.WHSE_ID = double.Parse(item["WHSE_ID"].ToString());
                    Tran.LOC_ID = double.Parse(item["LOC_ID"].ToString());
                    Tran.T_LOC_ID = LocId;
                    Tran.COMPANY_ID = 1;
                    Tran.ITEM_ID = double.Parse(item["ITEM_ID"].ToString());
                    Tran.LOT = item["LOT"].ToString();
                    Tran.F_QTY = float.Parse(item["QTY"].ToString());
                    Tran.T_QTY = Count - Qty;
                    Tran.F_MU_ID = double.Parse(item["MU_ID"].ToString());
                    Tran.T_MU_ID = double.Parse(item["MU_ID"].ToString());
                    Tran.F_STATUS = "V";
                    Tran.T_STATUS = "V";
                    Tran.F_ITEM_STATUS = "N";
                    Tran.T_ITEM_STATUS = "N";
                    Tran.DESCRIPTION = dtRow["BATCH_ID"].ToString();
                    Tran.USER_ID = LoginNames;
                    Tran.CREATED_TIME = DBDateTimeGenerator.GetDBDateTime(sqlMapper);
                    Tran.F_GOODSTYPE = "P";
                    Tran.T_GOODSTYPE = "P";
                    Tran.Save(sqlMapper);

                    if (double.Parse(item["QTY"].ToString()) == Count - Qty)//数量合适，直接修改库位
                    {

                        VWmsInvDetail InvDt = new VWmsInvDetail();
                        InvDt.ID = double.Parse(item["ID"].ToString());
                        InvDt.LOC_ID = LocId;
                        InvDt.PLAN_PICK_QTY = 0;
                        InvDt.Update(sqlMapper, "UpdateSection");
                        ivDid += item["ID"].ToString() + ',';

                        return ivDid.Substring(0, ivDid.Length - 1);

                    }
                    else if (double.Parse(item["QTY"].ToString()) > Count - Qty)//零件库存 大于移动库存 
                    {
                        VWmsInvDetail InvDt = new VWmsInvDetail();
                        InvDt.ID = double.Parse(item["ID"].ToString());
                        InvDt.QTY = float.Parse(item["QTY"].ToString()) - float.Parse((Count - Qty).ToString());
                        if (float.Parse(item["PLAN_PICK_QTY"].ToString()) - float.Parse((Count - Qty).ToString()) > 0)
                            InvDt.PLAN_PICK_QTY = float.Parse(item["PLAN_PICK_QTY"].ToString()) - float.Parse((Count - Qty).ToString());
                        else
                            InvDt.PLAN_PICK_QTY = 0;
                        InvDt.Update(sqlMapper, "UpdateSection");

                        VWmsInvDetail Sda = new VWmsInvDetail();
                        Sda.LOC_ID = LocId;
                        Sda.MU_ID = double.Parse(item["MU_ID"].ToString());
                        Sda.UID_ID = double.Parse(item["UID_ID"].ToString());
                        Sda.STATUS = "V";
                        Sda.ITEM_STATUS = "N";
                        Sda.QTY = float.Parse((Count - Qty).ToString());
                        Sda.VERSION_TRANSACTION = 0;
                        Sda.PLAN_PICK_QTY = 0;
                        Sda.Save(sqlMapper);//新建零件
                        ivDid += Sda.ID.ToString() + ',';

                        return ivDid.Substring(0, ivDid.Length - 1);

                    }
                    else
                    {
                        VWmsInvDetail InvDt = new VWmsInvDetail();
                        InvDt.ID = double.Parse(item["ID"].ToString());
                        InvDt.LOC_ID = LocId;
                        InvDt.PLAN_PICK_QTY = 0;
                        InvDt.Update(sqlMapper, "UpdateSection");
                        Qty += int.Parse(item["QTY"].ToString());
                        ivDid += InvDt.ID + ',';
                    }

                }
                if (ivDid.Length > 0)
                {

                    return ivDid.Substring(0, ivDid.Length - 1);
                }
                else
                {
                    return "";
                }
            }
            catch (Exception ex)
            {
                sqlMapper.RollBackTransaction();
                throw ex;
            }
        }
        /// <summary>
        /// 库内移位移零件
        /// </summary>
        /// <param name="Count"></param>
        /// <param name="litem"></param>
        /// <param name="LocId"></param>
        public static void MoveItem(int Count, DataTable litem, double LocId, string LoginNames)
        {
            IBatisNet.DataMapper.ISqlMapper sqlMapper = Sql_Mapper.Instance();
            sqlMapper.BeginTransaction();
            double CurrCount = 0;
            try
            { 
                foreach (DataRow item in litem.Rows)//移零件
                {
                    double PlanQty = double.Parse(item["PLAN_PICK_QTY"].ToString());
                    if (double.Parse(item["QTY"].ToString()) - PlanQty == (Count - CurrCount) )//数量合适，直接修改库位
                    {
                        if (float.Parse(item["QTY"].ToString()) - float.Parse((Count - CurrCount).ToString()) < 0 || (Count - CurrCount) < 0)
                        {
                            new Exception("异常:库存不能是负数!");
                        }
                        VWmsInvDetail InvDt = new VWmsInvDetail();
                        InvDt.ID = double.Parse(item["ID"].ToString());
                        InvDt.QTY = float.Parse(item["QTY"].ToString()) - float.Parse((Count - CurrCount).ToString());
                        InvDt.Update(sqlMapper, "UpdateSection");

                        VWmsInvDetail Sda = new VWmsInvDetail();
                        Sda.LOC_ID = LocId;
                        Sda.MU_ID = double.Parse(item["MU_ID"].ToString());
                        Sda.UID_ID = double.Parse(item["UID_ID"].ToString());
                        Sda.STATUS = "V";
                        Sda.ITEM_STATUS = "N";
                        VWmsInvDetail exitDa = Sda.QueryObject(sqlMapper, "SelectByParam");
                        if (exitDa != null)
                        {
                            exitDa.QTY = exitDa.QTY + float.Parse((Count - CurrCount).ToString());
                            exitDa.Update(sqlMapper, "UpdateQty");
                        }
                        else
                        {
                            Sda.QTY = float.Parse((Count - CurrCount).ToString());
                            Sda.VERSION_TRANSACTION = 0;
                            Sda.PLAN_PICK_QTY = 0;
                            Sda.Save(sqlMapper);//新建零件
                        }

                        //写仓库日志记录
                        VWmsInvTransaction Tran = new VWmsInvTransaction();
                        Tran.TRANSACTION_CODE = "com.vtradex.wms.inbound.MoveItem";
                        Tran.WHSE_ID = double.Parse(item["WHSE_ID"].ToString());
                        Tran.LOC_ID = double.Parse(item["LOC_ID"].ToString());
                        Tran.T_LOC_ID = LocId;
                        Tran.COMPANY_ID = 1;
                        Tran.ITEM_ID = double.Parse(item["ITEM_ID"].ToString());
                        Tran.LOT = item["LOT"].ToString();
                        Tran.F_QTY = float.Parse(item["QTY"].ToString());
                        Tran.T_QTY = float.Parse(item["QTY"].ToString());
                        Tran.F_MU_ID = double.Parse(item["MU_ID"].ToString());
                        Tran.T_MU_ID = double.Parse(item["MU_ID"].ToString());
                        Tran.F_STATUS = "V";
                        Tran.T_STATUS = "V";
                        Tran.F_ITEM_STATUS = "N";
                        Tran.T_ITEM_STATUS = "N";
                        Tran.DESCRIPTION = "10";
                        Tran.USER_ID = LoginNames;
                        Tran.CREATED_TIME = DBDateTimeGenerator.GetDBDateTime(sqlMapper);
                        Tran.F_GOODSTYPE = "P";
                        Tran.T_GOODSTYPE = "P";
                        Tran.Save(sqlMapper);
                        break;
                    }
                    else if (double.Parse(item["QTY"].ToString()) - PlanQty > Count - CurrCount )//零件库存大于移动库存
                    {
                        if (float.Parse(item["QTY"].ToString()) - float.Parse((Count - CurrCount).ToString()) < 0 || (Count - CurrCount) < 0)
                        {
                            new Exception("异常:库存不能是负数!");
                        }
                        VWmsInvDetail InvDt = new VWmsInvDetail();
                        InvDt.ID = double.Parse(item["ID"].ToString());
                        InvDt.QTY = float.Parse(item["QTY"].ToString()) - float.Parse((Count - CurrCount).ToString());
                        InvDt.Update(sqlMapper, "UpdateSection");

                        VWmsInvDetail Sda = new VWmsInvDetail();
                        Sda.LOC_ID = LocId;
                        Sda.MU_ID = double.Parse(item["MU_ID"].ToString());
                        Sda.UID_ID = double.Parse(item["UID_ID"].ToString());
                        Sda.STATUS = "V";
                        Sda.ITEM_STATUS = "N";
                        VWmsInvDetail exitDa = Sda.QueryObject(sqlMapper, "SelectByParam");
                        if (exitDa != null)
                        {
                            exitDa.QTY = exitDa.QTY + float.Parse((Count - CurrCount).ToString());
                            exitDa.Update(sqlMapper, "UpdateQty");
                        }
                        else
                        {
                            Sda.QTY = float.Parse((Count - CurrCount).ToString());
                            Sda.VERSION_TRANSACTION = 0;
                            Sda.PLAN_PICK_QTY = 0;
                            Sda.Save(sqlMapper);//新建零件
                        }

                        VWmsInvTransaction Tran = new VWmsInvTransaction();
                        Tran.TRANSACTION_CODE = "com.vtradex.wms.inbound.MoveItem";
                        Tran.WHSE_ID = double.Parse(item["WHSE_ID"].ToString());
                        Tran.LOC_ID = double.Parse(item["LOC_ID"].ToString());
                        Tran.T_LOC_ID = LocId;
                        Tran.COMPANY_ID = 1;
                        Tran.ITEM_ID = double.Parse(item["ITEM_ID"].ToString());
                        Tran.LOT = item["LOT"].ToString();
                        Tran.F_QTY = float.Parse(item["QTY"].ToString());
                        Tran.T_QTY = InvDt.QTY;
                        Tran.F_MU_ID = double.Parse(item["MU_ID"].ToString());
                        Tran.T_MU_ID = double.Parse(item["MU_ID"].ToString());
                        Tran.F_STATUS = "V";
                        Tran.T_STATUS = "V";
                        Tran.F_ITEM_STATUS = "N";
                        Tran.T_ITEM_STATUS = "N";
                        Tran.DESCRIPTION = "10";
                        Tran.USER_ID = LoginNames;
                        Tran.CREATED_TIME = DBDateTimeGenerator.GetDBDateTime(sqlMapper);
                        Tran.F_GOODSTYPE = "P";
                        Tran.T_GOODSTYPE = "P";
                        Tran.Save(sqlMapper);
                        break;
                    }
                    else
                    {
                        if (float.Parse(item["QTY"].ToString())< 0)
                        {
                            new Exception("异常:库存不能是负数!");
                        }
                        //判断是否有捡货分配数量  hzf 2014-11-26 10:20:24
                        if (PlanQty == 0)
                        {
                            VWmsInvDetail InvDt = new VWmsInvDetail();
                            InvDt.ID = double.Parse(item["ID"].ToString());
                            InvDt.LOC_ID = LocId;
                            InvDt.Update(sqlMapper, "UpdateSection");
                          
                        }
                        else
                        {
                          //捡配数量不为0 则新建数据
                            VWmsInvDetail invAdd = new VWmsInvDetail();
                            invAdd.LOC_ID = LocId;
                            invAdd.MU_ID = double.Parse(item["MU_ID"].ToString());
                            invAdd.UID_ID = double.Parse(item["UID_ID"].ToString());
                            invAdd.STATUS = item["STATUS"].ToString();
                            invAdd.ITEM_STATUS = item["ITEM_STATUS"].ToString();
                            invAdd.QTY =float.Parse((double.Parse(item["QTY"].ToString())-PlanQty).ToString());
                            invAdd.VERSION_TRANSACTION = double.Parse(item["VERSION_TRANSACTION"].ToString());
                            invAdd.PLAN_PICK_QTY = 0;
                            invAdd.Save(sqlMapper);

                            VWmsInvDetail Invupdate = new VWmsInvDetail();
                            Invupdate.ID = double.Parse(item["ID"].ToString());
                            Invupdate.QTY = float.Parse(PlanQty.ToString());
                            Invupdate.Update(sqlMapper, "UpdateSection");

                        }
                        CurrCount += double.Parse(item["QTY"].ToString()) - PlanQty;

                        VWmsInvTransaction Tran = new VWmsInvTransaction();
                        Tran.TRANSACTION_CODE = "com.vtradex.wms.inbound.MoveItem";
                        Tran.WHSE_ID = double.Parse(item["WHSE_ID"].ToString());
                        Tran.LOC_ID = double.Parse(item["LOC_ID"].ToString());
                        Tran.T_LOC_ID = LocId;
                        Tran.COMPANY_ID = 1;
                        Tran.ITEM_ID = double.Parse(item["ITEM_ID"].ToString());
                        Tran.LOT = item["LOT"].ToString();
                        Tran.F_QTY = float.Parse(item["QTY"].ToString());
                        Tran.T_QTY = float.Parse(item["QTY"].ToString());
                        Tran.F_MU_ID = double.Parse(item["MU_ID"].ToString());
                        Tran.T_MU_ID = double.Parse(item["MU_ID"].ToString());
                        Tran.F_STATUS = "V";
                        Tran.T_STATUS = "V";
                        Tran.F_ITEM_STATUS = "N";
                        Tran.T_ITEM_STATUS = "N";
                        Tran.DESCRIPTION = "10";
                        Tran.USER_ID = LoginNames;
                        Tran.CREATED_TIME = DBDateTimeGenerator.GetDBDateTime(sqlMapper);
                        Tran.F_GOODSTYPE = "P";
                        Tran.T_GOODSTYPE = "P";
                        Tran.Save(sqlMapper);
                        continue;
                    }
                }
                sqlMapper.CommitTransaction();
            }
            catch (Exception ex)
            {
                sqlMapper.RollBackTransaction();
                throw ex;
            }
        }

        /// <summary>
        /// 根据物料编码/原库位 获取批号；
        /// add by xhy 2014年9月25日
        /// </summary>
        /// <param name="itemCode"></param>
        /// <param name="locCode"></param>
        /// <returns></returns>
        public static string GetLotByItemLoc(string itemCode, string locCode)
        {
            try
            {
                string strLots = string.Empty;

                SqlParamSet sqlP = new SqlParamSet();
                sqlP.AddParam("ITEM_CODE", itemCode);
                sqlP.AddParam("LOC_CODE", locCode);

                DataTable dt = VWmsBaseLocation.QueryDataTable("SelectLotsByItemLoc", sqlP.GetParams());
                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        strLots += dt.Rows[i]["LOT"].ToString() + ",";
                    }
                }

                return strLots;
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }

        #region 查询零件主库位 add by mjy 2016-07-12
        /// <summary>
        /// 查询零件主库位
        /// </summary>
        /// <param name="param"></param>
        /// <returns>DataTable</returns>
        public static DataTable GetMainLocByPartCode(string partCode, string userId)
        {
            SqlParamSet sqlParam = new SqlParamSet();
            sqlParam.AddParam("ITEM_CODE", partCode);
            sqlParam.AddParam("USER_ID", userId);
            try
            {
                return VWmsItem.QueryDataTable("GetMainLocByPartCode", sqlParam.GetParams());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
