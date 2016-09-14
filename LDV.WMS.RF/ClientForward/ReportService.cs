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

        //�õ��汾
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
        //����
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

        //�޸�����
        public bool UpdatePwd(double UserId, string NewPwd, out string Mess)
        {
            return service().UpdatePwd(UserId, NewPwd, out Mess);
        }

        //�տ�λ
        public DataTable SelectNullLoc(string locCode, double userId)
        {
            return service().SelectNullLoc(locCode, userId);
        }

        #region �ջ�

        /// <summary>
        /// ��װ��ɲ���
        /// </summary>
        public bool UpdatePQStatusByClose(string Status, string ItemS, string DetailID, string DOCID, int count)
        {
            return service().UpdatePQStatusByClose(Status, ItemS, DetailID, DOCID, count);
        }
        /// <summary>
        /// ��ȡ�ջ�����Ϣ
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
        /// �����ջ����
        /// </summary>
        /// <param name="ID">�ջ����ӱ�ID</param>
        /// <param name="ACTUAL_QTY">�˴��ջ�����</param>
        /// <param name="OLD_ACTUAL_QTY">ԭ���ջ�����</param>
        /// <returns></returns>
        public bool SaveOrderDetail(string ID, string ITEM_ID, float InCount, float ACTUAL_QTY, float EXPECTED_QTY, float oldap_qty,
            string LocID, double WhseID, string LotDate, bool ISLOC, double SUPPLIER_ID, double User_ID, string RID, out string OutMsg)
        {
            return service().SaveOrderDetail(ID, ITEM_ID, InCount, ACTUAL_QTY, EXPECTED_QTY, oldap_qty, LocID, WhseID, LotDate, ISLOC, SUPPLIER_ID, User_ID, RID, out OutMsg);
        }
        /// <summary>
        /// ��ѯ���������Ϣ
        /// </summary>
        /// <returns></returns>
        public DataTable SelectOrderPartInfo(int UserID, string item_code)
        {
            return service().SelectOrderPartInfo(UserID, item_code);
        }
        //-----------------huzhenfei 2014-07-14 10:54:18----------------------------------------------
        /// <summary>
        /// ��ȡԤ�ջ�����Ϣ
        /// </summary>
        /// <param name="OrderNumber"></param>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public DataTable LoadMainDocRV(string OrderNumber, double UserId)
        {
            return service().LoadMainDocRV(OrderNumber, UserId);
        }
        /// <summary>
        /// ����Ԥ�ջ����
        /// </summary>
        /// <param name="ID">�ջ����ӱ�ID</param>
        /// <param name="ACTUAL_QTY">�˴��ջ�����</param>
        /// <param name="OLD_ACTUAL_QTY">ԭ���ջ�����</param>
        /// <returns></returns>
        public bool SaveAllReceivingRV(string ID, string ITEM_ID, float InCount, float ACTUAL_QTY, float EXPECTED_QTY,
            string LocID, double WhseID, string LotDate, bool ISLOC, double SUPPLIER_ID, double User_ID, string RID, out string OutMsg)
        {
            return service().SaveAllReceivingRV(ID, ITEM_ID, InCount, ACTUAL_QTY, EXPECTED_QTY, LocID, WhseID, LotDate, ISLOC, SUPPLIER_ID, User_ID, RID, out OutMsg);
        }

        /// <summary>
        /// �����װ���
        /// </summary>
        /// <param name="ID">�ջ����ӱ�ID</param>
        /// <param name="ACTUAL_QTY">�˴��ջ�����</param>
        /// <param name="OLD_ACTUAL_QTY">ԭ���ջ�����</param>
        /// <returns></returns>
        public bool SaveAllReceivingPQ(string ID, string ITEM_ID, float InCount, float ACTUAL_QTY, float EXPECTED_QTY,
            string LocID, double WhseID, string LotDate, bool ISLOC, double SUPPLIER_ID, double User_ID, string RID, out string OutMsg)
        {
            return service().SaveAllReceivingPQ(ID, ITEM_ID, InCount, ACTUAL_QTY, EXPECTED_QTY, LocID, WhseID, LotDate, ISLOC, SUPPLIER_ID, User_ID, RID, out OutMsg);
        }
        //-----------------------------------------------------------------------------------------------
        /// <summary>
        /// ��ѯ������Ϣ
        /// </summary>
        public DataTable SelectReceivingStatus(string Number_ID)
        {
            return service().SelectReceivingStatus(Number_ID);
        }
        /// <summary>
        /// �޸��ջ�����״̬
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
        /// �޸��û���½״̬����ǰ��������
        /// </summary>
        /// <param name="Userid">�û�ID</param>
        /// <param name="CurrOrder">��������</param>
        /// <param name="OpState">��������</param>
        /// <returns></returns>
        public bool UpdateUserState(double Userid, string CurrOrder, string OpState)
        {
            return service().UpdateUserState(Userid, CurrOrder, OpState);
        }


        /// <summary>
        /// ����û��Ƿ���ص�½
        /// </summary>
        /// <param name="LoginName"></param>
        /// <param name="LoginTime"></param>
        /// <returns></returns>
        public bool IsUserLoginOtherDevice(string LoginName, string LoginTime)
        {
            return service().IsUserLoginOtherDevice(LoginName, LoginTime);
        }

        //��ʼ��ѯ����
        public DataTable SelectOrder(string loginName, double user_id)
        {
            return service().SelectOrder(loginName, user_id);
        }

        //��ʼ��ѯ�������
        public DataTable SelectOrderBoxList(string orderlist, double user_id, string boxNo)
        {
            return service().SelectOrderBoxList(orderlist, user_id, boxNo);
        }

        //��ѯ��Ŷ���
        public DataTable SelectOrderBoxInfo(string loginName, double user_id, string boxNolist)
        {
            return service().SelectOrderBoxInfo(loginName, user_id, boxNolist);
        }

        //���ݶ����Ų�ѯ
        public DataTable SelectOrder(string orderCode, string loginName, double user_id)
        {
            return service().SelectOrderBy(orderCode, loginName, user_id);
        }
        //�޸Ķ���״̬
        public bool UpdateStatus(string OrderNumber)
        {
            return service().UpdateStatus(OrderNumber);
        }

        /// <summary>
        /// ����������룬��λ���룬�ֿ��ѯ���:�����ѯ
        /// </summary>
        /// <param name="LOC_CODE"></param>
        /// <param name="ITEM_CODE"></param>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public DataTable QueryPartQty(string LOC_CODE, string ITEM_CODE, string UserId)
        {
            return service().QueryPartQty(LOC_CODE, ITEM_CODE, UserId);
        }
        ////�޸Ķ����ӱ�״̬
        //public bool UpdatePickDetailStatus(double id,double allowQty,double pickedQty,string status)
        //{
        //    return service().UpdatePickDetailStatus(id,allowQty,pickedQty,status);
        //}

        //����ID��PICK_TICKET_DETAIL��
        public DataTable QueryDetailById(double id)
        {
            return service().QueryDetailById(id);
        }
        ////�޸ļ�����ӱ�״̬
        //public bool UpdatePickQueueStatus(double id,double count)
        //{
        //    return service().UpdatePickQueueStatus(id,count);
        //}
        //�޸ļ����ִ�����״̬ 
        public bool UpdatePickQueueActStatus(double id)
        {
            return service().UpdatePickQueueActStatus(id);
        }
        //
        public int UpdateQty(double id, double qty)
        {
            return service().UpdateQty(id, qty);
        }
        //�޸ļ����״̬
        public bool UpdatePickBatchStatus(double id)
        {
            return service().UpdatePickBatchStatus(id);
        }

        //������λ
        public bool MovLoc(string LoginName, string LoginTime, string OldLoc, string NewLoc, string PartCode, int Count, out string Mess, out string ErrType)
        {
            return service().MovLoc(LoginName, LoginTime, OldLoc, NewLoc, PartCode, Count, out Mess, out ErrType);
        }

        //������λ-new ����
        public bool MovLocWithLot(string LoginName, string LoginTime, string OldLoc, string NewLoc, string PartCode, int Count, string lot, out string Mess, out string ErrType)
        {
            return service().MovLocWithLot(LoginName, LoginTime, OldLoc, NewLoc, PartCode, Count, lot, out Mess, out ErrType);
        }

        ////�������ִ�������
        //public bool InsertQueueAct(double batch_id, double pick_queue_id, double loc_id, double mu_id, double uid_id, double allocated_qty, double picked_qty, string userId, double pick_ticket_id, string line_no, string INV_DETAIL_ID)
        //{
        //    return service().InsertQueueAct(batch_id, pick_queue_id, loc_id, mu_id, uid_id, allocated_qty, picked_qty, userId, pick_ticket_id, line_no, INV_DETAIL_ID);
        //}
        //���ݿ�λ�����ID
        public DataTable QueryByLocId(string LocCode)
        {
            return service().QueryByLocId(LocCode);
        }
        //�ƻ��̵��ѯ
        public DataTable QueryPlanCheck(string checkCredence, string login_name, double UserId)
        {
            return service().QueryPlanCheck(checkCredence, login_name, UserId);
        }
        //���¼ƻ��̵��ӱ�
        public bool UpdateCheckDetailStatus(double id, double User_id, double qty, string state)
        {
            return service().UpdateCheckDetailStatus(id, User_id, qty, state);
        }
        //�ƻ��̵��������
        public bool UpdateCheckStatus(double id, double User_id, string state)
        {
            return service().UpdateChecStatus(id, User_id, state);
        }

        //��ѯ�ֿ�
        public DataTable QueryWareHouse(double id)
        {
            return service().QueryWareHouse(id);
        }
        //��֤��λ�������
        public bool CheckLoc(string LoginName, string LoginTime, string OldLoc, string partCode, int Count, out string Mess)
        {
            return service().CheckLoc(LoginName, LoginTime, OldLoc, partCode, Count, out Mess);
        }
        //�õ����
        public DataTable GetItem(string ItemCode)
        {
            return service().GetItem(ItemCode);
        }
        //����ѭ���̵�����
        public bool InsertFreeCheck(double LocId, double ItemId, double qty, double userId)
        {
            return service().InsertFreeCheck(LocId, ItemId, qty, userId);
        }

        //��װ���ѯ
        public DataTable QueryPackege(string barcode, string itemCode)
        {
            return service().QueryPackege(barcode, itemCode);
        }

        //��װ���ѯ
        public DataTable QueryPackegeOn(string barcode, string itemCode)
        {
            return service().QueryPackegeOn(barcode, itemCode);
        }

        /// <summary>
        /// ��ѯ��װ�����������
        /// </summary>
        /// <param name="PickTickCode">�������</param>
        /// <param name="PackgCode">��װ�����</param>
        /// <param name="PackgeId">��װ��ID</param>
        /// <returns></returns>
        public int PackgeCount(string PickTickCode, string PackgCode, double PackgeId)
        {
            return service().PackgeCount(PickTickCode, PackgCode, PackgeId);
        }

        /// <summary>
        /// ���ݼ�����Ų�ѯ��װ������
        /// </summary>
        /// <param name="PickTickCode">�������</param>
        /// <returns></returns>
        public int PackgeCountByPickTickCode(string PickTickCode)
        {
            return service().PackgeCountByPickTickCode(PickTickCode);
        }

        //���°�װ��
        public bool UpdatePackege(double id, double PackegeId, double qty, double OldQty, double ticketDetaiId, double userId, string partCode, string oldPackege, string pick_ticket_code, out double BianQty, out double oldQty1)
        {
            return service().UpdatePackege(id, PackegeId, qty, OldQty, ticketDetaiId, userId, partCode, oldPackege, pick_ticket_code, out BianQty, out oldQty1);
        }


        #region ����
        /// <summary>
        /// ��ѯ���ϵ���
        /// </summary>
        /// <param name="PickCode"></param>
        /// <param name="UserId"></param>
        /// <param name="Mesg"></param>
        /// <returns></returns>
        public DataTable LoadShipOrder(string PickCode, string UserId, out string Mesg)
        {
            return service().LoadShipOrder(PickCode, UserId, out Mesg);
        }

        //�������ѯ��װ��
        public DataTable CheckPackge(string PackgCode)
        {
            return service().CheckPackge(PackgCode);
        }

        //�����װ��
        public bool OutShipment(double PackgID, double UserId, double ItemId,
            double OutCount, bool isNew, out string Mesg, double WhseId, string WhseCode, string PICK_TICKET_CODE)
        {
            return service().OutShipment(PackgID, UserId, ItemId, OutCount,
                 WhseId, WhseCode, isNew, PICK_TICKET_CODE, out Mesg);
        }
        #endregion
        //����ƿ�
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


        //��ȡ���� add by xhy 2014��9��25��
        public string GetLotByItemLoc(string itemCode, string locCode)
        {
            return service().GetLotByItemLoc(itemCode, locCode);
        }


        #region hzf �ϼ����¿��� 2014-12-02 12:39:47
        //������������ȡ�����λ
        public string GetInfoByPartCode(string Item_Code, string User_ID)
        {
            return service().GetInfoByPartCode(Item_Code, User_ID);
        }
        //������������ȡ�������λ
        public string GetInfoByPartCodeMloc(string Item_Code, string User_ID)
        {
            return service().GetInfoByPartCodeMloc(Item_Code, User_ID);
        }

        /// <summary>
        /// �ϼܲ���
        /// </summary>
        /// <param name="Item_Code">�������</param>
        /// <param name="InCount">�ϼ�����</param>
        /// <param name="Item_Loc">�ϼܿ�λ</param>
        /// <param name="IsLoc">�Ƿ���Ĭ�Ͽ�λ</param>
        /// <returns></returns>
        public bool SaveAddedDetail(string Item_Code, double InCount, string Item_Loc, string IsLoc, string User_ID, out string Msg)
        {
            return service().SaveAddedDetail(Item_Code, InCount, Item_Loc, IsLoc, User_ID, out Msg);
        }
        #endregion

        #region �ƻ��ƿ� add by xhy 2015��6��24�� 16:45:06
        /// <summary>
        /// ��ѯδ��ɵ��ƿ�ƻ�
        /// </summary>
        /// <returns></returns>
        public DataTable QueryMovePlan()
        {
            return service().QueryMovePlan();
        }

        /// <summary>
        /// ��ѯ�ƿ�ƻ���ϸ
        /// </summary>
        /// <returns></returns>
        public DataTable QueryMovePlanDetail(int detailId)
        {
            return service().QueryMovePlanDetail(detailId);
        }

        /// <summary>
        /// �����ƿ�ƻ����Ų�ѯ�ƿ�ƻ���ϸ
        /// </summary>
        /// <returns></returns>
        public DataTable QueryMovePlanDetailByPlanNo(string planNo)
        {
            return service().QueryMovePlanDetailByPlanNo(planNo);
        }

        /// <summary>
        /// �ƿ���ϸȷ��
        /// </summary>
        /// <returns></returns>
        public bool ConfirmPlanMove(int planId, int detailId, int stockId, int locId, int targetId, int moveQty, string LoginName, string LoginTime, out string Mess, out string ErrType, int userId)
        {
            return service().ConfirmPlanMove(planId, detailId, stockId, locId, targetId, moveQty, LoginName, LoginTime, userId, out Mess, out ErrType);
        }
        #endregion

        //�����װ��
        public bool SaveOrderAutoPrintInfo(string OrderNo, string UserId)
        {
            return service().SaveOrderAutoPrintInfo(OrderNo, UserId);
        }

        #region mjy ���书�ܿ��� 2016-04-28
        public bool MergePackage(string srcPakcageCode, string targetPackgeCode, double UserID, out string Msg)
        {
            return service().MergePackage(srcPakcageCode, targetPackgeCode, UserID, out Msg);
        }
        #endregion

        #region mjy ���ͬ���ӿ� 2016-05-04
        public string Get_OrderList(string date)
        {
            return service().Get_OrderList(date);
        }
        #endregion

        #region mjy ����װ������ͬ���ӿ� 2016-05-04
        public string Get_PackingList(string date)
        {
            return service().Get_PackingList(date);
        }
        #endregion

        #region mjy ��ά������ͬ���ӿ� 2016-05-10
        public string Get_QRCodeList(string date)
        {
            return service().Get_QRCodeList(date);
        }
        #endregion

        #region mjy �ϼ�ʱ�ж�����λ�Ĳֿ��Ƿ��ǵ�ǰ�û�����Ӧ�ֿ� 2016-05-24
        public bool IsUserWhse(string LOC_CODE, string User_ID)
        {
            return service().IsUserWhse(LOC_CODE, User_ID);
        }
        #endregion

        #region �������λ��ѯ add by mjy 2016-07-12
        public DataTable GetMainLocByPartCode(string partCode, string userId)
        {
            return service().GetMainLocByPartCode(partCode, userId);
        }
        #endregion
    }
}