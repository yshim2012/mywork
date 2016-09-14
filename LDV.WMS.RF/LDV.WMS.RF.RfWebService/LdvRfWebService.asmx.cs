using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;
using LDV.WMS.RF.DataMapper;
using LDV.WMS.RF.Business;

namespace LDV.WMS.RF.RfWebService
{
    /// <summary>
    /// LdvRfWebService 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
    // [System.Web.Script.Services.ScriptService]
    public class LdvRfWebService : System.Web.Services.WebService
    {
        private string path = System.Configuration.ConfigurationManager.AppSettings["PathToClientFiles"].ToString();
        //版本
        [WebMethod]
        public string GetVersion()
        {
            string version = "1.0.0.0";
            try
            {
                XElement root = XElement.Load(path + "files.config.xml");
                var vs = from v in root.Descendants("Version") select v.Value;
                foreach (var v in vs)
                    version = v;

                return version;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //登入
        [WebMethod]
        public VPhrSecUsr Login(string LoginName, string pwd)
        {
            try
            {
                VPhrSecUsr logUser = VPhrSecUsrService.Login(LoginName, pwd);
                if (logUser != null)
                {
                    logUser.EXTEND_COLUMN_0 = DBDateTimeGenerator.GetDBDateTime().ToString("yyyy-MM-dd HH:mm:ss");

                    VPhrSecUsrService.UpdateUser(logUser);
                }

                return logUser;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [WebMethod]
        public DataTable GetUserAll()
        {
            try
            {
                return VPhrSecUsrService.GetUserAll();


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [WebMethod]
        public DataTable GetRcvDoc()
        {
            try
            {
                return RvcDoc.GetRvcDoc();


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [WebMethod]
        public DataTable GetPickDoc()
        {
            try
            {
                return RvcDoc.GetPickDoc();


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [WebMethod]
        public DataTable GetUserOrder(string orderNum)
        {
            try
            {
                return VPhrSecUsrService.GetUserOrder(orderNum);


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #region 收货操作
        //读取收货单
        [WebMethod]
        public DataTable LoadMainDocByStatus(string Status, string UserID)
        {
            try
            {
                return ReceivingService.LoadMainDocByStatus(Status, UserID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //包装完成操作
        [WebMethod]
        public bool UpdatePQStatusByClose(string Status, string ItemS, string DetailID, string DOCID, int count)
        {
            try
            {
                return ReceivingService.UpdatePQStatusByClose(Status, ItemS, DetailID, DOCID, count);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        //读取收货单
        [WebMethod]
        public DataTable LoadMainDoc(string OrderNumber, double UserId)
        {
            try
            {
                return ReceivingService.LoadMainDoc(OrderNumber, UserId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        //保存子表
        [WebMethod]
        public bool SaveOrderDetail(string ID, string ITEM_ID, float InCount, float ACTUAL_QTY, float EXPECTED_QTY, float oldap_qty,
            string LocID, double WhseID, string LotDate, bool ISLOC, double SUPPLIER_ID, double User_ID, string RID, out string OutMsg)
        {
            try
            {
                //if (LotDate == string.Empty)
                //{
                //    throw new Exception("收货时间为空!");
                //}
                return ReceivingService.SaveOrderDetail(ID, ITEM_ID, InCount, ACTUAL_QTY, EXPECTED_QTY, oldap_qty, LocID, WhseID, LotDate, ISLOC, SUPPLIER_ID, User_ID, RID, out OutMsg);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //---------------------------------------huzhenfei  2014-07-11 14:32:58-----------------------------
        //读取预收货单
        [WebMethod]
        public DataTable LoadMainDocRV(string OrderNumber, double UserId)
        {
            try
            {
                return ReceivingService.LoadMainDocRV(OrderNumber, UserId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //保存预收货
        [WebMethod]
        public bool SaveAllReceivingRV(string ID, string ITEM_ID, float InCount, float ACTUAL_QTY, float EXPECTED_QTY,
            string LocID, double WhseID, string LotDate, bool ISLOC, double SUPPLIER_ID, double User_ID, string RID, out string OutMsg)
        {
            try
            {
                //if (LotDate == string.Empty)
                //{
                //    throw new Exception("收货时间为空!");
                //}
                return ReceivingService.SaveAllReceivingRV(ID, ITEM_ID, InCount, ACTUAL_QTY, EXPECTED_QTY, LocID, WhseID, LotDate, ISLOC, SUPPLIER_ID, User_ID, RID, out OutMsg);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //保存包装
        [WebMethod]
        public bool SaveAllReceivingPQ(string ID, string ITEM_ID, float InCount, float ACTUAL_QTY, float EXPECTED_QTY,
            string LocID, double WhseID, string LotDate, bool ISLOC, double SUPPLIER_ID, double User_ID, string RID, out string OutMsg)
        {
            try
            {
                //if (LotDate == string.Empty)
                //{
                //    throw new Exception("收货时间为空!");
                //}
                return ReceivingService.SaveAllReceivingPQ(ID, ITEM_ID, InCount, ACTUAL_QTY, EXPECTED_QTY, LocID, WhseID, LotDate, ISLOC, SUPPLIER_ID, User_ID, RID, out OutMsg);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // 查询订单信息
        [WebMethod]
        public DataTable SelectReceivingStatus(string Number_ID)
        {
            try
            {

                return ReceivingService.SelectReceivingStatus(Number_ID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //-------------------------------------------------------------------------------------------------
        //修改主表
        [WebMethod]
        public bool SaveOrderMain(string Row)
        {
            try
            {
                return ReceivingService.SaveOrderMain(Row, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion


        #region 用户操作
        //更新用户当前操作和状态
        [WebMethod]
        public bool UpdateUserState(double Userid, string CurrOrder, string OpState)
        {
            try
            {
                return VPhrSecUsrService.UpdateUserState(Userid, CurrOrder, OpState);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        //检查用户是否异地登陆
        [WebMethod]
        public bool IsUserLoginOtherDevice(string LoginName, string LoginTime)
        {
            try
            {
                return VPhrSecUsrService.IsUserLoginOtherDevice(LoginName, LoginTime);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //修改密码
        [WebMethod]
        public bool UpdatePwd(double UserId, string NewPwd, out string Mess)
        {
            Mess = string.Empty;
            try
            {
                VPhrSecUsrService.UpdatePwd(UserId, NewPwd);
                Mess = "密码修改成功";
            }
            catch (Exception ex)
            {
                Mess = "密码修改失败：" + ex.Message;
                return false;
            }

            return true;
        }

        #endregion


        //查询空库位
        [WebMethod]
        public DataTable SelectNullLoc(string locCode, double userId)
        {
            try
            {
                return BaseLocationService.QueryDataTableByParam(locCode, userId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //初始查询拣货订单
        [WebMethod]
        public DataTable SelectOrder(string loginName, double userId)
        {
            try
            {
                return PickTicketService.QueryDataTableByParam(loginName, userId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //初始查询拣货订单
        [WebMethod]
        public DataTable SelectOrderBoxList(string orderlist, double userId, string boxNolist)
        {
            try
            {
                return PickTicketService.SelectOrderBoxList(userId, orderlist, boxNolist);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //查询箱号拣货订单
        [WebMethod]
        public DataTable SelectOrderBoxInfo(string loginName, double userId, string boxNum)
        {
            return PickTicketService.SelectOrderBoxInfo(userId, loginName, boxNum);
        }

        //查询拣货订单
        [WebMethod]
        public DataTable SelectOrderBy(string orderCode, string loginName, double userId)
        {
            try
            {
                return PickTicketService.QueryDataTableByParam(orderCode, loginName, userId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //拣货更新拣货数量
        [WebMethod]
        public int UpdateQty(double id, double qty)
        {
            return PickQueueService.UpdateQty(id, qty);
        }



        #region 库存查询
        //查询库存
        [WebMethod]
        public LocItem[] QueryLocItem(string LoginName, string LoginTime, string LocCode, string PartCode)
        {
            try
            {
                if (VPhrSecUsrService.IsUserLoginOtherDevice(LoginName, LoginTime))
                {
                    IList<LocItem> list = VWmsInvDetailService.QueryVWmsInvDetail(LocCode, PartCode);
                    return list.ToArray<LocItem>();
                }
                else
                    return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //查询库存，带仓库
        [WebMethod]
        public DataTable QueryPartQty(string LOC_CODE, string ITEM_CODE, string UserId)
        {
            try
            {
                if (LOC_CODE == string.Empty && ITEM_CODE == string.Empty)
                {
                    throw new Exception("库位跟零件只有一个为空!");
                }
                else
                {
                    return VWmsInvDetailService.QueryPartQty(LOC_CODE, ITEM_CODE, UserId);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        //修改订单子表状态
        //[WebMethod]
        //public bool UpdatePickDetailStatus(double id,double allowQty,double pickedQty,string status)
        //{
        //    try
        //    {
        //        int rowCount= PickTickDetailService.UpdateStatus(id,allowQty,pickedQty,status);
        //        if (rowCount > 0)
        //            return true;
        //        else
        //            return false;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //修改拣货子表状态
        //[WebMethod]
        //public bool UpdatePickQueueStatus(double id,double count)
        //{
        //    try
        //    {
        //        int rowCount = PickQueueService.UpdateStatus(id,count);
        //        if (rowCount > 0)
        //            return true;
        //        else
        //            return false;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        [WebMethod]
        //根据ID查PICK_TICKET_DETAIL表
        public DataTable QueryDetailById(double id)
        {
            return PickTickDetailService.QueryDataTableByParam(id);
        }

        //修改拣货执行情况状态
        [WebMethod]
        public bool UpdatePickQueueActStatus(double id)
        {
            try
            {
                int rowCount = PickQueueActService.UpdateStatus(id);
                if (rowCount > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //修改拣货执行情况状态
        [WebMethod]
        public bool UpdatePickBatchStatus(double id)
        {
            try
            {
                int rowCount = PickBatchService.UpdateBatchStatus(id);
                if (rowCount > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #region 库内移位
        //库内移位  ErrType
        //["SUCCESS:库内移位成功", "NOITEM:库位中没有此商品", "ERRQTY:录入的数量不对", "ERRNEWLOC:新库位被设为其它商品的主库位", 
        //"NONEWLOC:新库位不存在"]
        [WebMethod]
        public bool MovLoc(string LoginName, string LoginTime, string OldLoc, string NewLoc, string PartCode, int Count, out string Mess, out string ErrType)
        {
            Mess = string.Empty;
            ErrType = string.Empty;
            try
            {
                if (VPhrSecUsrService.IsUserLoginOtherDevice(LoginName, LoginTime))
                {
                    //    //库存查询
                    DataTable litem = VWmsInvDetailService.QueryVWmsInvDetailForDataTable(OldLoc, PartCode);
                    if (litem.Rows.Count < 1)
                    {
                        Mess = "库位:" + OldLoc + "中没有" + PartCode;
                        ErrType = "NOITEM";
                        return false;
                    }
                    double ItemCount = 0;
                    try
                    {
                        ItemCount = double.Parse(litem.Compute("SUM(QTY)", "QTY NOT IS NULL").ToString()) -
                            double.Parse(litem.Compute("SUM(PLAN_PICK_QTY)", "QTY NOT IS NULL").ToString());
                    }
                    catch (Exception ex)
                    {
                        Mess = "计划拣货数量异常!";
                        ErrType = "ERRQTY";
                        return false;
                    }


                    if (ItemCount < Count)
                    {
                        Mess = "录入的数量大于库存数量";
                        ErrType = "ERRQTY";
                        return false;
                    }
                    if (ItemCount < 1)
                    {
                        Mess = "录入的数量小于1";
                        ErrType = "ERRQTY";
                        return false;
                    }

                    //主库位查询
                    DataTable dtMainLoc = BaseLocationService.QueryMainLoc(NewLoc);
                    if (dtMainLoc == null || dtMainLoc.Rows.Count < 1)
                    {
                        Mess = "新库位不存在";
                        ErrType = "NONEWLOC";
                        return false;
                    }

                    if (dtMainLoc.Rows[0]["ITEM_CODE"] != null && dtMainLoc.Rows[0]["ITEM_CODE"].ToString() != string.Empty
                        && dtMainLoc.Rows[0]["ITEM_CODE"].ToString() != PartCode)
                    {
                        Mess = "新库位被设为其它商品的主库位";
                        ErrType = "ERRNEWLOC";
                        return false;
                    }
                    //移零件
                    try
                    {
                        BaseLocationService.MoveItem(Count, litem, double.Parse(dtMainLoc.Rows[0]["ID"].ToString()), LoginName);
                        ErrType = "CHENGGONG";
                        Mess = "移库成功!";
                        return true;
                    }
                    catch (Exception ex)
                    {
                        Mess = "移库失败!";
                        ErrType = "ERRMOVE";
                        return false;
                    }

                    //if (dtMainLoc.Rows[0]["ITEM_CODE"].ToString() == PartCode)//新库位是零件的主库位,直接改数量
                    //{
                    //    BaseLocationService.MoveItem(Count, litem, double.Parse(dtMainLoc.Rows[0]["ID"].ToString()));
                    //}

                    //库内移位

                }
                else
                {
                    Mess = "此帐号在异地登入，无法操作！";
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //库内移位  ErrType 
        //["SUCCESS:库内移位成功", "NOITEM:库位中没有此商品", "ERRQTY:录入的数量不对", "ERRNEWLOC:新库位被设为其它商品的主库位", 
        //"NONEWLOC:新库位不存在"]
        //-New add by xhy 带批号
        [WebMethod]
        public bool MovLocWithLot(string LoginName, string LoginTime, string OldLoc, string NewLoc, string PartCode, int Count, string lotNo, out string Mess, out string ErrType)
        {
            Mess = string.Empty;
            ErrType = string.Empty;
            try
            {
                if (VPhrSecUsrService.IsUserLoginOtherDevice(LoginName, LoginTime))
                {
                    //    //库存查询
                    DataTable litem = VWmsInvDetailService.QueryVWmsInvDetailForDataTable(OldLoc, PartCode, lotNo);
                    if (litem.Rows.Count < 1)
                    {
                        Mess = "库位:" + OldLoc + "中没有" + PartCode;
                        ErrType = "NOITEM";
                        return false;
                    }
                    double ItemCount = 0;
                    try
                    {
                        ItemCount = double.Parse(litem.Compute("SUM(QTY)", "QTY NOT IS NULL").ToString()) -
                            double.Parse(litem.Compute("SUM(PLAN_PICK_QTY)", "QTY NOT IS NULL").ToString());
                    }
                    catch (Exception ex)
                    {
                        Mess = "计划拣货数量异常!";
                        ErrType = "ERRQTY";
                        return false;
                    }


                    if (ItemCount < Count)
                    {
                        Mess = "录入的数量大于库存数量";
                        ErrType = "ERRQTY";
                        return false;
                    }
                    if (ItemCount < 1)
                    {
                        Mess = "录入的数量小于1";
                        ErrType = "ERRQTY";
                        return false;
                    }

                    //主库位查询
                    DataTable dtMainLoc = BaseLocationService.QueryMainLoc(NewLoc);
                    if (dtMainLoc == null || dtMainLoc.Rows.Count < 1)
                    {
                        Mess = "新库位不存在";
                        ErrType = "NONEWLOC";
                        return false;
                    }

                    if (dtMainLoc.Rows[0]["ITEM_CODE"] != null && dtMainLoc.Rows[0]["ITEM_CODE"].ToString() != string.Empty
                        && dtMainLoc.Rows[0]["ITEM_CODE"].ToString() != PartCode)
                    {
                        Mess = "新库位被设为其它商品的主库位";
                        ErrType = "ERRNEWLOC";
                        return false;
                    }
                    //移零件
                    try
                    {
                        BaseLocationService.MoveItem(Count, litem, double.Parse(dtMainLoc.Rows[0]["ID"].ToString()), LoginName);
                        ErrType = "CHENGGONG";
                        Mess = "移库成功!";
                        return true;
                    }
                    catch (Exception ex)
                    {
                        Mess = "移库失败!";
                        ErrType = "ERRMOVE";
                        return false;
                    }

                    //if (dtMainLoc.Rows[0]["ITEM_CODE"].ToString() == PartCode)//新库位是零件的主库位,直接改数量
                    //{
                    //    BaseLocationService.MoveItem(Count, litem, double.Parse(dtMainLoc.Rows[0]["ID"].ToString()));
                    //}

                    //库内移位

                }
                else
                {
                    Mess = "此帐号在异地登入，无法操作！";
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [WebMethod]
        public bool MovePickLoc1(string LoginName, string LoginTime, double vpaId, int Count, string NewLoc, string userId, out string Mess, out string ErrType, out double updateQty)
        {
            Mess = string.Empty;
            ErrType = string.Empty;
            double wantQty = 0;
            try
            {
                if (VPhrSecUsrService.IsUserLoginOtherDevice(LoginName, LoginTime))
                {

                    DataTable dt = PickTicketService.QueryDataTableByParam(vpaId);
                    if (dt.Rows.Count > 0)
                    {
                        DataRow dtRow = dt.Rows[0];
                        double muId = double.Parse(dtRow["MU_ID"].ToString());
                        double uId = double.Parse(dtRow["UID_ID"].ToString());
                        string OldLoc = dtRow["LOC_CODE"].ToString();
                        string PartCode = dtRow["ITEM_CODE"].ToString();
                        wantQty = double.Parse(dtRow["ALLOCATED_QTY"].ToString());

                        //库存查询
                        DataTable litem = VWmsInvDetailService.QueryVWmsInvDetailForDataTable1(OldLoc, PartCode, muId, uId);
                        if (litem.Rows.Count < 1)
                        {
                            Mess = OldLoc + "中没有" + PartCode;
                            ErrType = "NOITEM";
                            updateQty = wantQty;
                            return false;
                        }
                        double ItemCount = double.Parse(litem.Compute("SUM(QTY)", "QTY NOT IS NULL").ToString());


                        if (ItemCount < Count)
                        {
                            Mess = "录入的数量大于库存数量";
                            ErrType = "ERRQTY";
                            updateQty = wantQty;
                            return false;
                        }

                        DataTable dtMainLoc = BaseLocationService.QueryMainLoc(NewLoc);
                        if (dtMainLoc.Rows.Count > 0)
                        {
                            bool Pick = BaseLocationService.Pick(Count, dtRow, userId, litem, dtMainLoc.Rows[0]["ID"].ToString(), LoginName);

                            if (Pick == true)
                            {
                                ErrType = "CHENGGONG";
                                Mess = "拣货成功!";
                                updateQty = wantQty - Count;
                                return true;
                            }
                            else
                            {
                                ErrType = "SHIBAI";
                                Mess = "服务器无法处理请求!";
                                updateQty = wantQty;
                                return false;
                            }
                        }
                        else
                        {
                            ErrType = "SHIBAI";
                            Mess = "查不到发货区的库位!";
                            updateQty = wantQty;
                            return false;
                        }
                    }
                    else
                    {
                        ErrType = "SHIBAI";
                        Mess = "无此拣货任务!";
                        updateQty = wantQty;
                        return false;
                    }
                }
                else
                {
                    ErrType = "SHIBAI";
                    Mess = "此帐号在异地登入，无法操作！";
                    updateQty = wantQty;
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            ErrType = "SHIBAI";
            Mess = "服务器无法处理请求!";
            updateQty = wantQty;
            return false;
        }

        //[WebMethod]
        //public bool MovPickLoc(string LoginName, string LoginTime, string OldLoc, string NewLoc, string PartCode, int Count,double wantCount,double vpaId,double BatchId,double vpqId,double muId,double uId,string userId,double pickId,double detailId,double queueId,string lineNo, out string Mess, out string ErrType,out double updateQty)
        //{
        //    Mess = string.Empty;
        //    ErrType = string.Empty;
        //    try
        //    {
        //        if (VPhrSecUsrService.IsUserLoginOtherDevice(LoginName, LoginTime))
        //        {
        //            //    //库存查询
        //            DataTable litem = VWmsInvDetailService.QueryVWmsInvDetailForDataTable(OldLoc, PartCode, muId, uId);
        //            if (litem.Rows.Count < 1)
        //            {
        //                Mess = OldLoc + "中没有" + PartCode;
        //                ErrType = "NOITEM";
        //                updateQty = 0;
        //                return false;
        //            }
        //            double ItemCount = double.Parse(litem.Compute("SUM(QTY)", "QTY NOT IS NULL").ToString());


        //            if (ItemCount < Count)
        //            {
        //                Mess = "录入的数量大于库存数量";
        //                ErrType = "ERRQTY";
        //                updateQty = 0;
        //                return false;
        //            }

        //            //主库位查询
        //            DataTable dtMainLoc = BaseLocationService.QueryMainLoc(NewLoc);
        //            //if (dtMainLoc == null || dtMainLoc.Rows.Count < 1)
        //            //{
        //            //    Mess = "默认发货库位不存在";
        //            //    ErrType = "NONEWLOC";
        //            //    updateQty = 0;
        //            //    return false;
        //            //}

        //            //if (dtMainLoc.Rows[0]["ITEM_CODE"] != null && dtMainLoc.Rows[0]["ITEM_CODE"].ToString() != string.Empty
        //            //    && dtMainLoc.Rows[0]["ITEM_CODE"].ToString() != PartCode)
        //            //{
        //            //    Mess = "默认发货库位被设为其它商品的主库位";
        //            //    ErrType = "ERRNEWLOC";
        //            //    updateQty = 0;
        //            //    return false;
        //            //}
        //            //移零件
        //            try
        //            {
        //                string inDlistid= BaseLocationService.MovePickItemRdID(Count, litem, double.Parse(dtMainLoc.Rows[0]["ID"].ToString()), LoginName);
        //                ErrType = "CHENGGONG";
        //                Mess = "拣货成功!";
        //                int UpdateQty=0;
        //                if (ErrType == "CHENGGONG")
        //                {
        //                    DataTable dtLoc = BaseLocationService.QueryByLocId(OldLoc);
        //                    double loc_id = double.Parse(dtLoc.Select("LOC_CODE='" + OldLoc + "'")[0]["LOC_ID"].ToString());
        //                    if (Count == wantCount)
        //                    {
        //                        UpdateQty = int.Parse(wantCount.ToString()) - Count;

        //                        //PickQueueService.UpdateQty(vpaId, UpdateQty);
        //                        bool a = PickQueueActService.InsertQueueAct(BatchId, vpqId, loc_id, muId, uId, wantCount, Count, userId, pickId, lineNo,inDlistid);
        //                        DataTable detailDt = QueryDetailById(detailId);
        //                        double pickQty = Convert.ToDouble(detailDt.Rows[0]["PICKED_QTY"].ToString());
        //                        double order_plan_qty = Convert.ToDouble(detailDt.Rows[0]["ORDER_PLAN_QTY"].ToString());
        //                        PickQueueService.UpdateActQty(vpaId, pickQty + Count);
        //                        if (pickQty + Count == order_plan_qty)
        //                        {
        //                            UpdatePickDetailStatus(detailId, pickQty + Count, pickQty + Count, "BL");
        //                            UpdatePickQueueStatus(queueId, pickQty + Count);
        //                        }
        //                        else
        //                        {
        //                            UpdatePickDetailStatus(detailId, pickQty + Count, pickQty + Count, "BL");
        //                            PickQueueService.UpdateQueueQty(queueId,pickQty + Count);
        //                        }

        //                    }
        //                    else if (Count < wantCount)
        //                    {
        //                        UpdateQty = int.Parse(wantCount.ToString()) - Count;
        //                        if (Count.ToString().Trim() != string.Empty)
        //                        {
        //                            bool a = PickQueueActService.InsertQueueAct(BatchId, vpqId, loc_id, muId, uId, wantCount, Count, userId, pickId, lineNo, inDlistid);
        //                        }

        //                       // PickQueueService.UpdateQty(vpaId, UpdateQty);
        //                        DataTable detailDt = QueryDetailById(detailId);
        //                        double pickQty = Convert.ToDouble(detailDt.Rows[0]["PICKED_QTY"].ToString());
        //                        if (pickQty.ToString().Trim() == string.Empty)
        //                        {
        //                            UpdatePickDetailStatus(detailId, Count, Count, "BL");
        //                            PickQueueService.UpdateQueueQty(queueId, Count);
        //                            PickQueueService.UpdateActQty(vpaId, Count);
        //                        }
        //                        else
        //                        {
        //                            double aa = Convert.ToDouble(Count.ToString()) + pickQty;
        //                            UpdatePickDetailStatus(detailId, aa, aa, "BL");
        //                            PickQueueService.UpdateQueueQty(queueId, aa);
        //                            PickQueueService.UpdateActQty(vpaId, aa);
        //                        }
        //                    }
        //                }
        //                updateQty = UpdateQty;
        //                return true;
        //            }
        //            catch (Exception ex)
        //            {
        //                Mess = "移库失败!";
        //                ErrType = "ERRMOVE";
        //                updateQty = 0;
        //                return false;
        //            }
        //            //if (dtMainLoc.Rows[0]["ITEM_CODE"].ToString() == PartCode)//新库位是零件的主库位,直接改数量
        //            //{
        //            //    BaseLocationService.MoveItem(Count, litem, double.Parse(dtMainLoc.Rows[0]["ID"].ToString()));
        //            //}

        //            //库内移位

        //        }
        //        else
        //        {
        //            Mess = "此帐号在异地登入，无法操作！";
        //            updateQty = 0;
        //            return false;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        #endregion


        [WebMethod]
        public bool Checked(string orderNumber, string userName, double userId, double batchId)
        {
            try
            {
                ArrayList list3 = new ArrayList();
                DataTable dt = SelectOrderBy(orderNumber, userName, userId);
                foreach (DataRow item in dt.Rows)
                {
                    string a = item["VPQ_ID"].ToString().Trim();
                    if (item["ORDER_QTY"].ToString() != item["PICK_QTY"].ToString() || item["VPQ_ID"].ToString().Trim() == string.Empty)
                    {
                        list3.Add(1);
                    }
                }
                UpdatePickBatchStatus(Convert.ToDouble(batchId));
                UpdateUserState(double.Parse(userId.ToString()), "", "");
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        [WebMethod]
        public bool UpdateStatus(string OrderNumber)
        {
            int rowCount = PickTicketService.UpdateStatus(OrderNumber);
            if (rowCount > 0)
                return true;
            else
                return false;
        }


        //[WebMethod]
        //public bool InsertQueueAct(double batch_id, double pick_queue_id, double loc_id, double mu_id, double uid_id, double allocated_qty, double picked_qty, string userId,double pick_ticket_id,string line_no,string INV_DETAIL_ID)
        //{
        //    try
        //    {
        //        bool a = PickQueueActService.InsertQueueAct(batch_id, pick_queue_id, loc_id, mu_id, uid_id, allocated_qty, picked_qty, userId,pick_ticket_id,line_no,INV_DETAIL_ID);
        //        return a;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        //根据库位代码查ID
        [WebMethod]
        public DataTable QueryByLocId(string LocCode)
        {
            return BaseLocationService.QueryByLocId(LocCode);
        }

        //计划盘点查询
        [WebMethod]
        public DataTable QueryPlanCheck(string checkCredence, string login_name, double UserId)
        {
            return PlanCheckDetailService.QueryDataTableByParam(checkCredence, login_name, UserId);
        }


        //更新计划盘点子表
        [WebMethod]
        public bool UpdateCheckDetailStatus(double id, double User_id, double qty, string state)
        {
            int a = PlanCheckDetailService.UpdateStatus(id, User_id, qty, state);
            if (a > 0)
                return true;
            else
                return false;
        }


        [WebMethod]
        //更新计划盘点主表
        public bool UpdateChecStatus(double id, double User_id, string state)
        {
            int a = PlanCheckService.UpdateStatus(id, User_id, state);
            if (a > 0)
                return true;
            else
                return false;
        }

        [WebMethod]
        //查询仓库
        public DataTable QueryWareHouse(double id)
        {
            return WareHouseService.QueryDataTableByParam(id);
        }

        [WebMethod]
        //查询零件
        public DataTable GetItem(string ItemCode)
        {
            return ItemService.QueryDataTableByParam(ItemCode);
        }

        [WebMethod]
        //新增循环盘点数据
        public bool InsertFreeCheck(double LocId, double ItemId, double qty, double userId)
        {
            return FreeDomCheckService.InsertFreeCheck(LocId, ItemId, qty, userId);
        }

        [WebMethod]
        public bool CheckLoc(string LoginName, string LoginTime, string OldLoc, string partCode, int Count, out string Mess)
        {
            Mess = string.Empty;
            try
            {
                if (VPhrSecUsrService.IsUserLoginOtherDevice(LoginName, LoginTime))
                {
                    //    //库存查询
                    DataTable litem = VWmsInvDetailService.QueryVWmsInvDetailForDataTable(OldLoc, partCode);
                    if (litem.Rows.Count < 1)
                    {
                        Mess = "库位" + OldLoc + "中没有此商品" + partCode;
                        return false;
                    }
                    double ItemCount = double.Parse(litem.Compute("SUM(QTY)", "QTY NOT IS NULL").ToString());
                    if (ItemCount < Count)
                    {
                        Mess = "录入的数量大于库存数量";
                        return false;
                    }
                    return true;
                }
                else
                {
                    Mess = "此帐号在异地登入，无法操作";
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #region 核料
        [WebMethod]
        //查询核料列表
        public DataTable LoadShipOrder(string PickCode, string UserId, out string Mesg)
        {
            try
            {
                return ShipmentsCheckService.LoadShipOrder(PickCode, UserId, out Mesg);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [WebMethod]
        //查询包装箱
        public DataTable CheckPackge(string PackgCode)
        {
            try
            {
                return PackegeService.CheckPackge(PackgCode);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [WebMethod]
        //查询包装箱内零件数量
        public int PackgeCount(string PickTickCode, string PackgCode, double PackgeId)
        {
            return PackegeService.PackgeCount(PickTickCode, PackgCode, PackgeId);
        }

        [WebMethod]
        //根据出库单查询包装箱数量
        public int PackgeCountByPickTickCode(string PickTickCode)
        {
            return PackegeService.PackgeCountByPickTickCode(PickTickCode);
        }

        [WebMethod]
        //保存包装箱
        public bool OutShipment(double PackgID, double UserId, double ItemId,
            double OutCount, double WhseId, string WhseCode, bool isNew, string PICK_TICKET_CODE, out string Mesg)
        {
            try
            {
                return PackegeService.OutShipment(PackgID, UserId, ItemId, OutCount, isNew, out Mesg,
                    WhseId, WhseCode, PICK_TICKET_CODE);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        #region 包装箱调整
        //查询包装箱
        [WebMethod]
        public DataTable QueryPackege(string barcode, string ItemCode)
        {
            return PackegeService.QueryPackege(barcode, ItemCode);
        }
        //查询
        [WebMethod]
        public DataTable QueryPackegeOn(string barcode, string ItemCode)
        {
            return PackegeService.QueryPackegeOn(barcode, ItemCode);
        }

        //修改
        [WebMethod]
        public bool UpdatePackege(double id, double PackegeId, double qty, double OldQty, double ticketDetaiId, double userId, string partCode, string oldPackege, string pick_ticket_code, out double BianQty, out double OldQty1)
        {
            return PackegeService.UpdatePackege(id, PackegeId, qty, OldQty, ticketDetaiId, userId, partCode, oldPackege, pick_ticket_code, out BianQty, out OldQty1);
        }
        #endregion

        //查询订单信息
        [WebMethod]
        public DataTable SelectOrderPartInfo(int UserID, string item_code)
        {
            return ReceivingService.SelectOrderPartInfo(UserID, item_code);
        }


        /// <summary>
        /// 根据订单编号下载文件
        /// </summary>
        /// <param name="packageNo">订单编号</param>
        /// <returns></returns>
        [WebMethod]
        public byte[] GetFile(string packageNo)
        {
            return ReceivingService.GetFile(packageNo);
        }


        /// <summary>
        /// 根据物料编码/原库位 获取批号；
        /// add by xhy 2014年9月25日
        /// </summary>
        /// <param name="itemCode"></param>
        /// <param name="locCode"></param>
        /// <returns></returns>
        [WebMethod]
        public string GetLotByItemLoc(string itemCode, string locCode)
        {
            return BaseLocationService.GetLotByItemLoc(itemCode, locCode);
        }

        #region hzf 上架重新开发 2014-12-02 12:39:47
        /// <summary>
        /// 根据零件编码获取零件库位
        /// </summary>
        /// <param name="Item_Code">零件编码</param>
        /// <param name="User_ID">用户ID</param>
        /// <returns></returns>
        [WebMethod]
        public string GetInfoByPartCode(string Item_Code, string User_ID)
        {
            return ReceivingService.GetInfoByPartCode(Item_Code, User_ID);
        }

        /// <summary>
        /// 根据零件编码获取零件主库位
        /// </summary>
        /// <param name="Item_Code">零件编码</param>
        /// <param name="User_ID">用户ID</param>
        /// <returns></returns>
        [WebMethod]
        public string GetInfoByPartCodeMloc(string Item_Code, string User_ID)
        {
            return ReceivingService.GetInfoByPartCodeMloc(Item_Code, User_ID);
        }
        /// <summary>
        /// 上架处理方法
        /// </summary>
        /// <param name="Item_Code"></param>
        /// <param name="User_ID"></param>
        /// <returns></returns>
        [WebMethod]
        //public string GetInfoByPartCode(string Item_Code, string User_ID)
        public bool SaveAddedDetail(string Item_Code, double InCount, string Item_Loc, string IsLoc, string User_ID, out string Msg)
        {
            return ReceivingService.SaveAddedDetail(Item_Code, InCount, Item_Loc, IsLoc, User_ID, out Msg);
        }

        #endregion

        #region 计划移库 add by xhy 2015年6月24日 15:38:38
        /// <summary>
        /// 查询未完成的移库计划
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        public DataTable QueryMovePlan()
        {
            return PlanMoveServices.QueryMovePlan();
        }

        /// <summary>
        /// 查询移库计划明细
        /// </summary>
        /// <param name="detailId"></param>
        /// <returns></returns>
        [WebMethod]
        public DataTable QueryMovePlanDetail(int detailId)
        {
            return PlanMoveServices.QueryMovePlanDetail(detailId);
        }

        /// <summary>
        /// 根据计划单号查询移库计划明细列表
        /// </summary>
        /// <param name="detailId"></param>
        /// <returns></returns>
        [WebMethod]
        public DataTable QueryMovePlanDetailByPlanNo(string PlanNO)
        {
            return PlanMoveServices.QueryMovePlanDetailByPlanNo(PlanNO);
        }

        /// <summary>
        /// 计划移库数确认
        /// </summary>
        /// <param name="planId"></param>
        /// <param name="detailId"></param>
        /// <param name="stockId"></param>
        /// <param name="locId"></param>
        /// <param name="targetId"></param>
        /// <param name="moveQty"></param>
        /// <param name="LoginName"></param>
        /// <param name="LoginTime"></param>
        /// <param name="Mess"></param>
        /// <param name="ErrType"></param>
        /// <returns></returns>
        [WebMethod]
        public bool ConfirmPlanMove(int planId, int detailId, int stockId, int locId, int targetId, int moveQty, string LoginName, string LoginTime, int userId, out string Mess, out string ErrType)
        {
            Mess = string.Empty;
            ErrType = string.Empty;
            try
            {
                if (VPhrSecUsrService.IsUserLoginOtherDevice(LoginName, LoginTime))
                {
                    ////库存查询
                    DataTable litem = VWmsInvDetailService.QueryVWmsInvDetailByInvId(stockId);

                    ////主库位查询
                    //DataTable dtMainLoc = BaseLocationService.QueryMainLoc(NewLoc);
                    //if (dtMainLoc == null || dtMainLoc.Rows.Count < 1)
                    //{
                    //    Mess = "新库位不存在";
                    //    ErrType = "NONEWLOC";
                    //    return false;
                    //}

                    //if (dtMainLoc.Rows[0]["ITEM_CODE"] != null && dtMainLoc.Rows[0]["ITEM_CODE"].ToString() != string.Empty
                    //    && dtMainLoc.Rows[0]["ITEM_CODE"].ToString() != PartCode)
                    //{
                    //    Mess = "新库位被设为其它商品的主库位";
                    //    ErrType = "ERRNEWLOC";
                    //    return false;
                    //}
                    //移零件
                    try
                    {
                        PlanMoveServices.ConfirmMovePlanDetail(LoginName, userId, planId, detailId, locId, targetId, moveQty, litem);
                        ErrType = "CHENGGONG";
                        Mess = "移库成功!";
                        return true;
                    }
                    catch (Exception ex)
                    {
                        Mess = "移库失败!";
                        ErrType = "ERRMOVE";
                        return false;
                    }
                }
                else
                {
                    Mess = "此帐号在异地登入，无法操作！";
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion


        [WebMethod]
        public bool SaveOrderAutoPrintInfo(string OrderNo, string UserId)
        {
            try
            {
                return PackegeService.SaveOrderAutoPrintInfo(OrderNo, UserId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        #region 根据零件编码获取主库位
        /// <summary>
        /// 根据零件编码获取主库位
        /// </summary>
        /// <param name="Item_Code">零件编码</param>
        /// <returns></returns>
        [WebMethod]
        public string GetMlocByPartCode(string Item_Code)
        {
            return ReceivingService.GetMlocByPartCode(Item_Code);
        }
        #endregion

        #region mjy 合箱功能开发 2016-04-28
        [WebMethod]
        public bool MergePackage(string srcPakcageCode, string targetPackgeCode, double UserID, out string Msg)
        {
            return PackegeService.MergePackage(srcPakcageCode, targetPackgeCode, UserID, out Msg);
        }
        #endregion

        #region mjy 入库数据同步接口 2016-05-04
        [WebMethod]
        public string Get_OrderList(string date)
        {
            return GetListService.Get_OrderList(date);
        }
        #endregion

        #region mjy 出库装箱数据同步接口 2016-05-04
        [WebMethod]
        public string Get_PackingList(string date)
        {
            return GetListService.Get_PackingList(date);
        }
        #endregion

        #region mjy 二维码数据同步接口 2016-05-12
        [WebMethod]
        public string Get_QRCodeList(string date)
        {
            return GetListService.Get_QRCodeList(date);
        }
        #endregion

        #region mjy 2016-05-24
        /// <summary>
        /// 上架时判断入库库位的仓库是否是当前用户所对应仓库
        /// </summary>
        /// <param name="LOC_CODE">入库库位代码</param>
        /// <param name="User_ID">用户ID</param>
        /// <returns></returns>
        [WebMethod]
        public bool IsUserWhse(string LOC_CODE, string User_ID)
        {
            return ReceivingService.IsUserWhse(LOC_CODE, User_ID);
        }

        #endregion

        #region mjy 2016-07-12
        //查询零件主库位
        [WebMethod]
        public DataTable GetMainLocByPartCode(string partCode, string userId)
        {
            try
            {
                return BaseLocationService.GetMainLocByPartCode(partCode, userId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

    }
}
