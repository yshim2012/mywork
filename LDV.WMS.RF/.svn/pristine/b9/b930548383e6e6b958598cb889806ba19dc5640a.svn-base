using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using ClientForward;
using ClientForward.WebReference;

namespace Domain.Services
{
    public class ReportService
    {
        private string serverUrl;

        public ReportService(string serverUrl)
        {
            this.serverUrl = serverUrl;
        }

        private LdvRfWebService service()
        {
            LdvRfWebService handler = new LdvRfWebService();
            if (!string.IsNullOrEmpty(serverUrl))
                handler.Url = serverUrl;

            return handler;
        }

        //得到版本
        public string GetServiceVersion()
        {
            return service().GetVersion();
        }
        public DataTable GetUserAll()
        {
            return service().GetUserAll();
        }
        public DataTable GetUserOrder(string orderNum)
        {
            return service().GetUserOrder(orderNum);
        }
        //登入
        public User login(String userID, String password)
        {
            VPhrSecUsr loguser = service().Login(userID, password);

            if (loguser == null)
                return null;
            else
            {
                User user = new User();
                user.ID = loguser.ID.Value;
                user.LOGIN_NAME = loguser.LOGIN_NAME;
                user.ENCRYPTED_PASSWORD = loguser.ENCRYPTED_PASSWORD;
                user.EXTEND_COLUMN_0 = loguser.EXTEND_COLUMN_0;

                return user;
            }
        }

        //修改密码
        public bool UpdatePwd(double UserId, string NewPwd, out string Mess)
        {
            return service().UpdatePwd(UserId, NewPwd, out Mess);
        }

        //空库位
        public DataTable SelectNullLoc(string locCode, double userId)
        {
            return service().SelectNullLoc(locCode, userId);
        }

        #region 收货

        /// <summary>
        /// 包装完成操作
        /// </summary>
        public bool UpdatePQStatusByClose(string Status, string ItemS, string DetailID, string DOCID, int count)
        {
            return service().UpdatePQStatusByClose(Status, ItemS, DetailID, DOCID, count);
        }
        /// <summary>
        /// 读取收货单信息
        /// </summary>
        /// <param name="OrderNumber"></param>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public DataTable LoadMainDoc(string OrderNumber, double UserId)
        {
            return service().LoadMainDoc(OrderNumber, UserId);
        }

        public DataTable LoadMainDocByStatus(string Status, string UserID)
        {
            return service().LoadMainDocByStatus(Status, UserID);
        }
        /// <summary>
        /// 保存收货零件
        /// </summary>
        /// <param name="ID">收货单子表ID</param>
        /// <param name="ACTUAL_QTY">此次收货数量</param>
        /// <param name="OLD_ACTUAL_QTY">原有收货数量</param>
        /// <returns></returns>
        public bool SaveOrderDetail(string ID, string ITEM_ID, float InCount, float ACTUAL_QTY, float EXPECTED_QTY, float oldap_qty,
            string LocID, double WhseID, string LotDate, bool ISLOC, double SUPPLIER_ID, double User_ID, string RID, out string OutMsg)
        {
            return service().SaveOrderDetail(ID, ITEM_ID, InCount, ACTUAL_QTY, EXPECTED_QTY, oldap_qty, LocID, WhseID, LotDate, ISLOC, SUPPLIER_ID, User_ID, RID, out OutMsg);
        }
        /// <summary>
        /// 查询订单零件信息
        /// </summary>
        /// <returns></returns>
        public DataTable SelectOrderPartInfo(int UserID, string item_code)
        {
            return service().SelectOrderPartInfo(UserID, item_code);
        }
        //-----------------huzhenfei 2014-07-14 10:54:18----------------------------------------------
        /// <summary>
        /// 读取预收货单信息
        /// </summary>
        /// <param name="OrderNumber"></param>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public DataTable LoadMainDocRV(string OrderNumber, double UserId)
        {
            return service().LoadMainDocRV(OrderNumber, UserId);
        }
        /// <summary>
        /// 保存预收货零件
        /// </summary>
        /// <param name="ID">收货单子表ID</param>
        /// <param name="ACTUAL_QTY">此次收货数量</param>
        /// <param name="OLD_ACTUAL_QTY">原有收货数量</param>
        /// <returns></returns>
        public bool SaveAllReceivingRV(string ID, string ITEM_ID, float InCount, float ACTUAL_QTY, float EXPECTED_QTY,
            string LocID, double WhseID, string LotDate, bool ISLOC, double SUPPLIER_ID, double User_ID, string RID, out string OutMsg)
        {
            return service().SaveAllReceivingRV(ID, ITEM_ID, InCount, ACTUAL_QTY, EXPECTED_QTY, LocID, WhseID, LotDate, ISLOC, SUPPLIER_ID, User_ID, RID, out OutMsg);
        }

        /// <summary>
        /// 保存包装零件
        /// </summary>
        /// <param name="ID">收货单子表ID</param>
        /// <param name="ACTUAL_QTY">此次收货数量</param>
        /// <param name="OLD_ACTUAL_QTY">原有收货数量</param>
        /// <returns></returns>
        public bool SaveAllReceivingPQ(string ID, string ITEM_ID, float InCount, float ACTUAL_QTY, float EXPECTED_QTY,
            string LocID, double WhseID, string LotDate, bool ISLOC, double SUPPLIER_ID, double User_ID, string RID, out string OutMsg)
        {
            return service().SaveAllReceivingPQ(ID, ITEM_ID, InCount, ACTUAL_QTY, EXPECTED_QTY, LocID, WhseID, LotDate, ISLOC, SUPPLIER_ID, User_ID, RID, out OutMsg);
        }
        //-----------------------------------------------------------------------------------------------
        /// <summary>
        /// 查询订单信息
        /// </summary>
        public DataTable SelectReceivingStatus(string Number_ID)
        {
            return service().SelectReceivingStatus(Number_ID);
        }
        /// <summary>
        /// 修改收货主表状态
        /// </summary>
        /// <param name="Row"></param>
        /// <returns></returns>
        public bool SaveOrderMain(string Row)
        {
            //return service().SaveOrderMain(Row);
            return false;
        }
        #endregion

        /// <summary>
        /// 修改用户登陆状态跟当前操作单号
        /// </summary>
        /// <param name="Userid">用户ID</param>
        /// <param name="CurrOrder">操作单号</param>
        /// <param name="OpState">操作类型</param>
        /// <returns></returns>
        public bool UpdateUserState(double Userid, string CurrOrder, string OpState)
        {
            return service().UpdateUserState(Userid, CurrOrder, OpState);
        }


        /// <summary>
        /// 检查用户是否异地登陆
        /// </summary>
        /// <param name="LoginName"></param>
        /// <param name="LoginTime"></param>
        /// <returns></returns>
        public bool IsUserLoginOtherDevice(string LoginName, string LoginTime)
        {
            return service().IsUserLoginOtherDevice(LoginName, LoginTime);
        }

        //初始查询订单
        public DataTable SelectOrder(string loginName, double user_id)
        {
            return service().SelectOrder(loginName, user_id);
        }

        //初始查询拣货单号
        public DataTable SelectOrderBoxList(string orderlist, double user_id, string boxNo)
        {
            return service().SelectOrderBoxList(orderlist, user_id, boxNo);
        }

        //查询箱号订单
        public DataTable SelectOrderBoxInfo(string loginName, double user_id, string boxNolist)
        {
            return service().SelectOrderBoxInfo(loginName, user_id, boxNolist);
        }

        //根据订单号查询
        public DataTable SelectOrder(string orderCode, string loginName, double user_id)
        {
            return service().SelectOrderBy(orderCode, loginName, user_id);
        }
        //修改订单状态
        public bool UpdateStatus(string OrderNumber)
        {
            return service().UpdateStatus(OrderNumber);
        }

        /// <summary>
        /// 根据零件代码，库位代码，仓库查询库存:零件查询
        /// </summary>
        /// <param name="LOC_CODE"></param>
        /// <param name="ITEM_CODE"></param>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public DataTable QueryPartQty(string LOC_CODE, string ITEM_CODE, string UserId)
        {
            return service().QueryPartQty(LOC_CODE, ITEM_CODE, UserId);
        }
        ////修改订单子表状态
        //public bool UpdatePickDetailStatus(double id,double allowQty,double pickedQty,string status)
        //{
        //    return service().UpdatePickDetailStatus(id,allowQty,pickedQty,status);
        //}

        //根据ID查PICK_TICKET_DETAIL表
        public DataTable QueryDetailById(double id)
        {
            return service().QueryDetailById(id);
        }
        ////修改拣货单子表状态
        //public bool UpdatePickQueueStatus(double id,double count)
        //{
        //    return service().UpdatePickQueueStatus(id,count);
        //}
        //修改拣货单执行情况状态 
        public bool UpdatePickQueueActStatus(double id)
        {
            return service().UpdatePickQueueActStatus(id);
        }
        //
        public int UpdateQty(double id, double qty)
        {
            return service().UpdateQty(id, qty);
        }
        //修改拣货单状态
        public bool UpdatePickBatchStatus(double id)
        {
            return service().UpdatePickBatchStatus(id);
        }

        //库内移位
        public bool MovLoc(string LoginName, string LoginTime, string OldLoc, string NewLoc, string PartCode, int Count, out string Mess, out string ErrType)
        {
            return service().MovLoc(LoginName, LoginTime, OldLoc, NewLoc, PartCode, Count, out Mess, out ErrType);
        }

        //库内移位-new 批号
        public bool MovLocWithLot(string LoginName, string LoginTime, string OldLoc, string NewLoc, string PartCode, int Count, string lot, out string Mess, out string ErrType)
        {
            return service().MovLocWithLot(LoginName, LoginTime, OldLoc, NewLoc, PartCode, Count, lot, out Mess, out ErrType);
        }

        ////保存分配执行情况表
        //public bool InsertQueueAct(double batch_id, double pick_queue_id, double loc_id, double mu_id, double uid_id, double allocated_qty, double picked_qty, string userId, double pick_ticket_id, string line_no, string INV_DETAIL_ID)
        //{
        //    return service().InsertQueueAct(batch_id, pick_queue_id, loc_id, mu_id, uid_id, allocated_qty, picked_qty, userId, pick_ticket_id, line_no, INV_DETAIL_ID);
        //}
        //根据库位代码查ID
        public DataTable QueryByLocId(string LocCode)
        {
            return service().QueryByLocId(LocCode);
        }
        //计划盘点查询
        public DataTable QueryPlanCheck(string checkCredence, string login_name, double UserId)
        {
            return service().QueryPlanCheck(checkCredence, login_name, UserId);
        }
        //更新计划盘点子表
        public bool UpdateCheckDetailStatus(double id, double User_id, double qty, string state)
        {
            return service().UpdateCheckDetailStatus(id, User_id, qty, state);
        }
        //计划盘点主表更新
        public bool UpdateCheckStatus(double id, double User_id, string state)
        {
            return service().UpdateChecStatus(id, User_id, state);
        }

        //查询仓库
        public DataTable QueryWareHouse(double id)
        {
            return service().QueryWareHouse(id);
        }
        //验证库位库存数量
        public bool CheckLoc(string LoginName, string LoginTime, string OldLoc, string partCode, int Count, out string Mess)
        {
            return service().CheckLoc(LoginName, LoginTime, OldLoc, partCode, Count, out Mess);
        }
        //得到零件
        public DataTable GetItem(string ItemCode)
        {
            return service().GetItem(ItemCode);
        }
        //新增循环盘点数据
        public bool InsertFreeCheck(double LocId, double ItemId, double qty, double userId)
        {
            return service().InsertFreeCheck(LocId, ItemId, qty, userId);
        }

        //包装箱查询
        public DataTable QueryPackege(string barcode, string itemCode)
        {
            return service().QueryPackege(barcode, itemCode);
        }

        //包装箱查询
        public DataTable QueryPackegeOn(string barcode, string itemCode)
        {
            return service().QueryPackegeOn(barcode, itemCode);
        }

        /// <summary>
        /// 查询包装箱内零件数量
        /// </summary>
        /// <param name="PickTickCode">拣货单号</param>
        /// <param name="PackgCode">包装箱代码</param>
        /// <param name="PackgeId">包装箱ID</param>
        /// <returns></returns>
        public int PackgeCount(string PickTickCode, string PackgCode, double PackgeId)
        {
            return service().PackgeCount(PickTickCode, PackgCode, PackgeId);
        }

        /// <summary>
        /// 根据拣货单号查询包装箱数量
        /// </summary>
        /// <param name="PickTickCode">拣货单号</param>
        /// <returns></returns>
        public int PackgeCountByPickTickCode(string PickTickCode)
        {
            return service().PackgeCountByPickTickCode(PickTickCode);
        }

        //更新包装箱
        public bool UpdatePackege(double id, double PackegeId, double qty, double OldQty, double ticketDetaiId, double userId, string partCode, string oldPackege, string pick_ticket_code, out double BianQty, out double oldQty1)
        {
            return service().UpdatePackege(id, PackegeId, qty, OldQty, ticketDetaiId, userId, partCode, oldPackege, pick_ticket_code, out BianQty, out oldQty1);
        }


        #region 核料
        /// <summary>
        /// 查询核料单据
        /// </summary>
        /// <param name="PickCode"></param>
        /// <param name="UserId"></param>
        /// <param name="Mesg"></param>
        /// <returns></returns>
        public DataTable LoadShipOrder(string PickCode, string UserId, out string Mesg)
        {
            return service().LoadShipOrder(PickCode, UserId, out Mesg);
        }

        //按条码查询包装箱
        public DataTable CheckPackge(string PackgCode)
        {
            return service().CheckPackge(PackgCode);
        }

        //保存包装箱
        public bool OutShipment(double PackgID, double UserId, double ItemId,
            double OutCount, bool isNew, out string Mesg, double WhseId, string WhseCode, string PICK_TICKET_CODE)
        {
            return service().OutShipment(PackgID, UserId, ItemId, OutCount,
                 WhseId, WhseCode, isNew, PICK_TICKET_CODE, out Mesg);
        }
        #endregion
        //拣货移库
        //public bool MovPickLoc(string LoginName, string LoginTime, string OldLoc, string NewLoc, string PartCode, int Count, out string Mess, out string ErrType)
        //{
        //    return service().MovPickLoc(LoginName, LoginTime, OldLoc, NewLoc, PartCode, Count, out Mess, out ErrType);
        //}

        //public bool MovPickLoc(string LoginName, string LoginTime, string OldLoc, string NewLoc, string PartCode, int Count, double wantCount, double vpaId, double BatchId, double vpqId, double muId, double uId, string userId, double pickId, double detailId, double queueId, string lineNo, out string Mess, out string ErrType, out double updateQty)
        //{
        //    return service().MovPickLoc(LoginName, LoginTime, OldLoc, NewLoc, PartCode, Count, wantCount, vpaId, BatchId, vpqId, muId, uId, userId, pickId, detailId, queueId, lineNo, out Mess, out ErrType, out updateQty);
        //}

        public bool Checked(string orderNumber, string userName, double userId, double batchId)
        {
            return service().Checked(orderNumber, userName, userId, batchId);
        }

        public bool MovePickLoc(string LoginName, string LoginTime, double vpaId, int Count, string NewLoc, string userId, out string Mess, out string ErrType, out double updateQty)
        {
            return service().MovePickLoc1(LoginName, LoginTime, vpaId, Count, NewLoc, userId, out Mess, out ErrType, out updateQty);
        }


        //获取批号 add by xhy 2014年9月25日
        public string GetLotByItemLoc(string itemCode, string locCode)
        {
            return service().GetLotByItemLoc(itemCode, locCode);
        }


        #region hzf 上架重新开发 2014-12-02 12:39:47
        //根据零件编码获取零件库位
        public string GetInfoByPartCode(string Item_Code, string User_ID)
        {
            return service().GetInfoByPartCode(Item_Code, User_ID);
        }
        //根据零件编码获取零件主库位
        public string GetInfoByPartCodeMloc(string Item_Code, string User_ID)
        {
            return service().GetInfoByPartCodeMloc(Item_Code, User_ID);
        }

        /// <summary>
        /// 上架操作
        /// </summary>
        /// <param name="Item_Code">零件编码</param>
        /// <param name="InCount">上架数量</param>
        /// <param name="Item_Loc">上架库位</param>
        /// <param name="IsLoc">是否是默认库位</param>
        /// <returns></returns>
        public bool SaveAddedDetail(string Item_Code, double InCount, string Item_Loc, string IsLoc, string User_ID, out string Msg)
        {
            return service().SaveAddedDetail(Item_Code, InCount, Item_Loc, IsLoc, User_ID, out Msg);
        }
        #endregion

        #region 计划移库 add by xhy 2015年6月24日 16:45:06
        /// <summary>
        /// 查询未完成的移库计划
        /// </summary>
        /// <returns></returns>
        public DataTable QueryMovePlan()
        {
            return service().QueryMovePlan();
        }

        /// <summary>
        /// 查询移库计划明细
        /// </summary>
        /// <returns></returns>
        public DataTable QueryMovePlanDetail(int detailId)
        {
            return service().QueryMovePlanDetail(detailId);
        }

        /// <summary>
        /// 根据移库计划单号查询移库计划明细
        /// </summary>
        /// <returns></returns>
        public DataTable QueryMovePlanDetailByPlanNo(string planNo)
        {
            return service().QueryMovePlanDetailByPlanNo(planNo);
        }

        /// <summary>
        /// 移库明细确认
        /// </summary>
        /// <returns></returns>
        public bool ConfirmPlanMove(int planId, int detailId, int stockId, int locId, int targetId, int moveQty, string LoginName, string LoginTime, out string Mess, out string ErrType, int userId)
        {
            return service().ConfirmPlanMove(planId, detailId, stockId, locId, targetId, moveQty, LoginName, LoginTime, userId, out Mess, out ErrType);
        }
        #endregion

        //保存包装箱
        public bool SaveOrderAutoPrintInfo(string OrderNo, string UserId)
        {
            return service().SaveOrderAutoPrintInfo(OrderNo, UserId);
        }

        #region mjy 合箱功能开发 2016-04-28
        public bool MergePackage(string srcPakcageCode, string targetPackgeCode, double UserID, out string Msg)
        {
            return service().MergePackage(srcPakcageCode, targetPackgeCode, UserID, out Msg);
        }
        #endregion

        #region mjy 入库同步接口 2016-05-04
        public string Get_OrderList(string date)
        {
            return service().Get_OrderList(date);
        }
        #endregion

        #region mjy 出库装箱数据同步接口 2016-05-04
        public string Get_PackingList(string date)
        {
            return service().Get_PackingList(date);
        }
        #endregion

        #region mjy 二维码数据同步接口 2016-05-10
        public string Get_QRCodeList(string date)
        {
            return service().Get_QRCodeList(date);
        }
        #endregion

        #region mjy 上架时判断入库库位的仓库是否是当前用户所对应仓库 2016-05-24
        public bool IsUserWhse(string LOC_CODE, string User_ID)
        {
            return service().IsUserWhse(LOC_CODE, User_ID);
        }
        #endregion

        #region 零件主库位查询 add by mjy 2016-07-12
        public DataTable GetMainLocByPartCode(string partCode, string userId)
        {
            return service().GetMainLocByPartCode(partCode, userId);
        }
        #endregion
    }
}