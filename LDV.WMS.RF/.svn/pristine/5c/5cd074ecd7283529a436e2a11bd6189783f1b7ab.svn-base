using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using LDV.WMS.RF.DataMapper;
using LDV.WMS.RF.Utility;

namespace LDV.WMS.RF.Business
{
    public class PackegeService
    {
        /// <summary>
        /// 查询对像LIST
        /// </summary>
        /// <param name="param"></param>
        /// <returns>DataTable</returns>
        public static DataTable QueryPackege(string barcode, string ItemCode)
        {
            SqlParamSet param = new SqlParamSet();
            param.AddParam("PACKAGE_BARCODE", barcode);
            param.AddParam("ITEM_CODE", ItemCode);
            return LdvPackageItemRel.QueryDataTable("SelectPackege", param.GetParams());
        }
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="barcode"></param>
        /// <param name="ItemCode"></param>
        /// <returns></returns>
        public static DataTable QueryPackegeOn(string barcode, string ItemCode)
        {
            SqlParamSet param = new SqlParamSet();
            param.AddParam("PACKAGE_BARCODE", barcode);
            param.AddParam("ITEM_CODE", ItemCode);
            return LdvPackageItemRel.QueryDataTable("SelectPackegeOn", param.GetParams());
        }
        /// <summary>
        /// 查询包装箱内零件数量
        /// </summary>
        /// <param name="PickTickCode">拣货单号</param>
        /// <param name="PackgCode">包装箱号</param>
        /// <param name="PackgeId">不传填-1</param>
        /// <returns></returns>
        public static int PackgeCount(string PickTickCode, string PackgCode, double PackgeId)
        {
            try
            {
                SqlParamSet param = new SqlParamSet();
                param.AddParam("PICK_TICKET_CODE", PickTickCode);
                param.AddParam("PACKAGE_BARCODE", PackgCode);
                if (PackgeId != null && PackgeId > 0)
                {
                    param.AddParam("ID", PackgeId);
                }
                return LdvPackageBarcode.QueryDataTable("SelectByItemCount", param.GetParams()).Rows.Count;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        //根据出库单计算包装箱数
        public static int PackgeCountByPickTickCode(string PickTickCode)
        {
            try
            {
                SqlParamSet param = new SqlParamSet();
                param.AddParam("PICK_TICKET_CODE", PickTickCode);

                return LdvPackageBarcode.QueryDataTable("SelectBoxCountByPickTickCode", param.GetParams()).Rows.Count;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="barcode"></param>
        /// <param name="ItemCode"></param>
        /// <returns></returns>
        public static bool UpdatePackege(double id, double PackegeId, double qty, double OldQty, double ticketDetaiId, double userId, string PartCode, string OldPackege, string pick_ticket_code, out double BianQty, out double oldQty1)
        {
            bool flag = true;
            IBatisNet.DataMapper.ISqlMapper sqlMapper = Sql_Mapper.Instance();
            BianQty = 0;
            oldQty1 = 0;
            try
            {
                SqlParamSet sqlParam3 = new SqlParamSet();
                sqlParam3.AddParam("PACKEGE_ID", PackegeId);
                DataTable dt = LdvPackageItemRel.QueryDataTable("SelectPackegeOn", sqlParam3.GetParams());
                LdvPackageItemRel rel = LdvPackageItemRel.QueryObject("SelectByPackgeId", id);
                double jianQty = double.Parse(rel.QTY.ToString());
                if (qty == OldQty)
                {
                    SqlParamSet sqlParam = new SqlParamSet();
                    sqlParam.AddParam("ID", id);
                    sqlParam.AddParam("PACKAGE_BARCODE_ID", PackegeId);
                    sqlParam.AddParam("QTY", jianQty);
                    BianQty = qty - jianQty;
                    oldQty1 = OldQty - jianQty;
                    sqlParam.AddParam("LAST_MODIFY_DATE", DBDateTimeGenerator.GetDBDateTime());
                    int a = LdvPackageItemRel.Update("UpdateSection", sqlParam.GetParams());
                    if (a > 0)
                    {
                        flag = true;
                    }
                    else
                    {
                        flag = false;
                    }
                }
                else if (qty < OldQty)
                {
                    sqlMapper.BeginTransaction();
                    SqlParamSet sqlParam = new SqlParamSet();
                    sqlParam.AddParam("ID", id);
                    sqlParam.AddParam("PACKAGE_BARCODE_ID", null);
                    if (qty >= jianQty)
                    {
                        sqlParam.AddParam("QTY", 0);
                        BianQty = qty - jianQty;
                        oldQty1 = OldQty - jianQty;
                    }
                    else
                    {
                        sqlParam.AddParam("QTY", jianQty - qty);
                    }
                    sqlParam.AddParam("LAST_MODIFY_DATE", DBDateTimeGenerator.GetDBDateTime(sqlMapper));
                    int a = LdvPackageItemRel.Update(sqlMapper, "UpdateSection", sqlParam.GetParams());
                    SqlParamSet sqlParam1 = new SqlParamSet();
                    sqlParam1.AddParam("PACKAGE_BARCODE_ID", PackegeId);
                    sqlParam1.AddParam("ITEM_CODE", PartCode);
                    DataTable LdvPackage = LdvPackageItemRel.QueryDataTable(sqlMapper, "SelectPackegeOn", sqlParam1.GetParams());
                    if (LdvPackage.Rows.Count == 0)
                    {
                        LdvPackageItemRel itemRel = new LdvPackageItemRel();
                        itemRel.PACKAGE_BARCODE_ID = PackegeId;
                        itemRel.PICK_TICKET_DETAIL_ID = ticketDetaiId;
                        if (qty >= jianQty)
                            itemRel.QTY = jianQty;
                        else
                            itemRel.QTY = qty;
                        itemRel.CREATE_DATE = DBDateTimeGenerator.GetDBDateTime(sqlMapper);
                        itemRel.CREATE_USER_ID = userId;
                        itemRel.LAST_MODIFY_DATE = DBDateTimeGenerator.GetDBDateTime(sqlMapper);
                        itemRel.LAST_MODIFY_USER_ID = userId;
                        itemRel.Save(sqlMapper);
                        flag = true;
                    }
                    else if (LdvPackage.Rows.Count > 0)
                    {
                        double newqty = 0;
                        if (qty >= jianQty)
                        {
                            newqty = Convert.ToDouble(LdvPackage.Rows[0]["QTY"].ToString()) + jianQty;
                        }
                        else
                            newqty = Convert.ToDouble(LdvPackage.Rows[0]["QTY"].ToString()) + qty;
                        double newId = Convert.ToDouble(LdvPackage.Rows[0]["D_ID"].ToString());
                        SqlParamSet sqlParam2 = new SqlParamSet();
                        sqlParam2.AddParam("ID", newId);
                        sqlParam2.AddParam("PACKAGE_BARCODE_ID", null);
                        sqlParam2.AddParam("QTY", newqty);
                        sqlParam2.AddParam("LAST_MODIFY_DATE", DBDateTimeGenerator.GetDBDateTime(sqlMapper));
                        int aa = LdvPackageItemRel.Update(sqlMapper, "UpdateSection", sqlParam2.GetParams());
                        if (aa > 0)
                        {
                            flag = true;
                        }
                        else
                        {
                            flag = false;
                        }
                    }
                    sqlMapper.CommitTransaction();
                }

                if (dt.Rows.Count == 0)
                {
                    SqlParamSet sqlParam4 = new SqlParamSet();
                    sqlParam4.AddParam("PACKAGE_BARCODE", OldPackege);
                    DataTable dt1 = LdvPackageItemRel.QueryDataTable("SelectPackegeOn", sqlParam4.GetParams());
                    if (dt1.Rows.Count == 0)
                    {
                        DataTable dt2 = LdvPackageItemRel.QueryDataTable("SelectPackege", sqlParam4.GetParams());
                        string box_num = dt2.Rows[0]["BOX_NUM"].ToString();
                        SqlParamSet sqlParam5 = new SqlParamSet();
                        sqlParam5.AddParam("BOX_NUM", int.Parse(box_num));
                        sqlParam5.AddParam("ID", PackegeId);
                        LdvPackageBarcode.Update("UpdateSection", sqlParam5.GetParams());
                    }
                    else
                    {
                        SqlParamSet sqlParam5 = new SqlParamSet();
                        sqlParam5.AddParam("ID", PackegeId);
                        sqlParam5.AddParam("PICK_TICKET_CODE", pick_ticket_code);
                        LdvPackageBarcode.Update("UpdateBox", sqlParam5.GetParams());
                    }
                }
                else
                {
                    SqlParamSet sqlParam4 = new SqlParamSet();
                    sqlParam4.AddParam("PACKAGE_BARCODE", OldPackege);
                    DataTable dt1 = LdvPackageItemRel.QueryDataTable("SelectPackegeOn", sqlParam4.GetParams());
                    if (dt1.Rows.Count == 0)
                    {
                        DataTable dt2 = LdvPackageItemRel.QueryDataTable("SelectPackege", sqlParam4.GetParams());
                        string box_num = dt2.Rows[0]["BOX_NUM"].ToString();
                        SqlParamSet sqlParam5 = new SqlParamSet();
                        sqlParam5.AddParam("BOX_NUM", int.Parse(box_num));
                        sqlParam5.AddParam("PICK_TICKET_CODE", pick_ticket_code);
                        LdvPackageBarcode.Update("UpdateBox1", sqlParam5.GetParams());
                    }
                }
                SqlParamSet sqlParam6 = new SqlParamSet();
                sqlParam6.AddParam("ID", PackegeId);
                LdvPackageBarcode.Update("UpdateStatus", sqlParam6.GetParams());
                return flag;


            }
            catch (Exception ex)
            {
                sqlMapper.RollBackTransaction();
                BianQty = 0;
                oldQty1 = 0;
                return false;
                throw ex;
            }
        }

        /// <summary>
        /// 按包装箱号查询包装箱/核料
        /// </summary>
        /// <param name="PackgCode"></param>
        /// <returns></returns>
        public static DataTable CheckPackge(string PackgCode)
        {
            SqlParamSet sqlParam = new SqlParamSet();
            sqlParam.AddParam("PACKAGE_BARCODE", PackgCode);
            DataTable Result = LdvPackageBarcode.QueryDataTable("SelectPackgeByCode", sqlParam.GetParams());
            if (Result.Rows.Count < 1)
            {
                return null;
            }
            return Result;
        }

        /// <summary>
        /// 包装箱核料保存零件
        /// </summary>
        /// <param name="OrderMId"></param>
        /// <param name="OrderId"></param>
        /// <param name="PackgID"></param>
        /// <param name="UserId"></param>
        /// <param name="ItemId"></param>
        /// <param name="OutCount"></param>
        /// <param name="OutSum"></param>
        /// <returns></returns>
        public static bool OutShipment(double PackgID, double UserId, double ItemId,
            double OutCount, bool isNew, out string Mesg, double WhseId, string WhseCode, string PICK_TICKET_CODE)
        {
            //修改拣货单状态（主表最后出库时间，子表出库数量）
            //添加包装箱零件
            //修改零件库存
            IBatisNet.DataMapper.ISqlMapper sqlMapper = Sql_Mapper.Instance();
            sqlMapper.BeginTransaction();

            Mesg = string.Empty;
            try
            {

                //查询订单信息
                //SelectDetailByOrderCodeItemId
                SqlParamSet Dparm = new SqlParamSet();
                Dparm.AddParam("PICK_TICKET_CODE", PICK_TICKET_CODE);
                Dparm.AddParam("ITEM_ID", ItemId);
                DataTable DetailRow = VWmsPickTicketDetail.QueryDataTable(sqlMapper, "SelectDetailByOrderCodeItemId", Dparm.GetParams());
                if (DetailRow.Rows.Count < 1)
                {
                    Mesg = "该零件已出库，请返回订单选择界面刷新!";
                    return false;
                }
                string BATCH_ID = DetailRow.Rows[0]["BATCH_ID"].ToString();//操作单号
                //检查包装箱
                //SelectPackgeByCode
                Dparm = new SqlParamSet();
                Dparm.AddParam("ID", PackgID);
                DataTable Result = LdvPackageBarcode.QueryDataTable(sqlMapper, "SelectPackgeByID", Dparm.GetParams());
                if (Result.Rows.Count < 1)
                {
                    Mesg = "该包装箱不存在!";
                    sqlMapper.RollBackTransaction();
                    return false;
                }
                if (Result.Rows[0]["STATUS"].ToString().Equals("CL"))
                {
                    Mesg = "该包装箱已出库!";
                    sqlMapper.RollBackTransaction();
                    return false;
                }
                if ((Result.Select("PICK_TICKET_CODE IS NULL").Length + Result.Select("PICK_TICKET_CODE ='" + PICK_TICKET_CODE + "'").Length) < Result.Rows.Count)
                {
                    Mesg = PICK_TICKET_CODE + "已经被使用,请重新输入!";
                    sqlMapper.RollBackTransaction();
                    return false;
                }

                //构造MUid,Uid出库的零件数组
                System.Collections.Hashtable MuIdCount =
                    CeckDetailItem(DetailRow, out WhseCode, OutCount, PackgID, isNew, PICK_TICKET_CODE, out Mesg, UserId, ItemId, sqlMapper);




                //出库
                if (!SaveInvDetail(MuIdCount, ItemId, WhseId, WhseCode, out Mesg, PackgID, UserId, BATCH_ID, sqlMapper))
                {
                    //Mesg = "拣货库存记录不存在!";
                    sqlMapper.RollBackTransaction();
                    return false;
                }



                sqlMapper.CommitTransaction();
                //sqlMapper.RollBackTransaction();
                return true;

            }
            catch (Exception ex)
            {
                sqlMapper.RollBackTransaction();
                throw ex;
            }

        }


        /// <summary>
        /// 循环零件Detail数据组装
        /// </summary>
        /// <param name="DetailRow">零件详单数据</param>
        /// <param name="WhseCode">仓库代码</param>
        /// <param name="OutCount">出库数量</param>
        /// <param name="PackgID">包装箱ID</param>
        /// <param name="isNew">是否为新包装箱</param>
        /// <param name="PICK_TICKET_CODE">出库单号</param>
        /// <param name="Mesg">返回到客户端的提示错误信息</param>
        /// <param name="UserId">操作用户ID</param>
        /// <param name="ItemId">零件ID</param>
        /// <param name="sqlMapper">事务</param>
        /// <returns></returns>
        private static System.Collections.Hashtable CeckDetailItem(DataTable DetailRow, out string WhseCode, double OutCount, double PackgID, bool isNew,
            string PICK_TICKET_CODE, out string Mesg, double UserId, double ItemId,
            IBatisNet.DataMapper.ISqlMapper sqlMapper)
        {
            try
            {
                Mesg = string.Empty;
                WhseCode = string.Empty;
                double SumOutCount = 0;//当前总共出库数量
                System.Collections.Hashtable MuIdCount = new System.Collections.Hashtable();//MUID与数量之前的关系 
                foreach (DataRow var in DetailRow.Rows)//循环查询到的零件详单
                {
                    double OrderMId = double.Parse(var["TICK_ID"].ToString());
                    double OrderId = double.Parse(var["DETAIL_ID"].ToString());
                    double OrderQty = double.Parse(var["ORDER_QTY"].ToString());
                    double PICKED_QTY = double.Parse(var["PICKED_QTY"].ToString());
                    double OutSum = double.Parse(var["SHIP_QTY"].ToString());//已出的数量
                    double PQID = double.Parse(var["PQID"].ToString());

                    WhseCode = var["WHSE_NAME"].ToString();//重定向仓库代码
                    if (SumOutCount == OutCount)//累加出库数量等于
                    {
                        break;//停止循环
                    }

                    double CurOutCount = 0;//当前循环出库数量
                    VWmsPickTicket Tik = new VWmsPickTicket();

                    if ((OutCount - SumOutCount) + OutSum <= PICKED_QTY)//数量小于等于当前循环拣货数量
                    {
                        CurOutCount = OutCount - SumOutCount;
                    }
                    if ((OutCount - SumOutCount) + OutSum > PICKED_QTY)//数量大于当前循环拣货数量
                    {
                        CurOutCount = PICKED_QTY - OutSum;
                    }
                    Tik.ID = OrderMId;
                    if (CurOutCount + OutSum == OrderQty)//此次出库数量+已出库数量等于当前循环订单数量就标记此单已完成
                    {
                        Tik.STATUS = "PI";
                    }
                    Tik.SHIP_DATE = DBDateTimeGenerator.GetDBDateTime(sqlMapper);
                    Tik.LAST_MODIFIED = DBDateTimeGenerator.GetDBDateTime(sqlMapper);
                    Tik.Update(sqlMapper, "UpdateSection");

                    #region 修改订单信息、包装箱信息、包装箱记录
                    VWmsPickTicketDetail Tikd = new VWmsPickTicketDetail();
                    Tikd.ID = OrderId;
                    Tikd.SHIP_QTY = CurOutCount + OutSum;
                    Tikd.STATUS = "PI";
                    Tikd.LAST_MODIFIED = DBDateTimeGenerator.GetDBDateTime(sqlMapper);
                    Tikd.Update(sqlMapper, "UpdateSection");

                    LdvPackageBarcode BarD = new LdvPackageBarcode();
                    BarD.ID = PackgID;
                    BarD.LAST_MODIFY_DATE = DBDateTimeGenerator.GetDBDateTime(sqlMapper);
                    if (isNew)
                    {
                        BarD.STATUS = "NP";
                        BarD.Update(sqlMapper, "UpdateSection");

                        //更新包装箱数
                        SqlParamSet BarParm = new SqlParamSet();
                        BarParm.AddParam("ID", PackgID);
                        BarParm.AddParam("PICK_TICKET_CODE", PICK_TICKET_CODE);
                        LdvPackageBarcode.Update(sqlMapper, "UpdateBoxNum", BarParm.GetParams());
                    }

                    LdvPackageItemRel PRel = new LdvPackageItemRel();
                    PRel.PACKAGE_BARCODE_ID = PackgID;
                    PRel.PICK_TICKET_DETAIL_ID = OrderId;
                    PRel.QTY = CurOutCount;
                    PRel.CREATE_DATE = DBDateTimeGenerator.GetDBDateTime(sqlMapper);
                    PRel.CREATE_USER_ID = UserId;
                    PRel.LAST_MODIFY_DATE = DBDateTimeGenerator.GetDBDateTime(sqlMapper);
                    PRel.LAST_MODIFY_USER_ID = UserId;
                    PRel.Save(sqlMapper);//添加包装箱零件记录
                    #endregion

                    SqlParamSet sqlParam = new SqlParamSet();
                    sqlParam.AddParam("ITEM_ID", ItemId);
                    sqlParam.AddParam("PQID", PQID);
                    sqlParam.AddParam("LOC_CODE", WhseCode + "-F");
                    sqlParam.AddParam("PICK_TICKET_ID", OrderMId);
                    DataTable MuidList = VWmsInvDetail.QueryDataTable(sqlMapper, "SelectByUidMidQty", sqlParam.GetParams());//MID,UID数据组
                    //PickTickAct已出库数量与PqAct已捡数量要检查


                    if (MuidList.Rows.Count < 1)
                    {
                        Mesg = "拣货库存记录不存在!";
                        throw new Exception("拣货库存记录不存在!");
                    }
                    if (CurOutCount > double.Parse(MuidList.Compute("SUM(PICKED_QTY)", "PICKED_QTY NOT IS NULL").ToString()))
                    {
                        Mesg = "拣货库存记录出现异常!";
                        throw new Exception("拣货库存记录出现异常!");
                    }

                    double ActSum = 0;
                    foreach (DataRow VarMu in MuidList.Rows)//组装UID扣零件数量
                    {
                        //string MuKey = VarMu["MU_ID"].ToString() + "," + VarMu["UID_ID"].ToString();
                        double ActCount = 0;
                        double PT_QTY = VarMu["PT_QTY"] == DBNull.Value ? 0 : double.Parse(VarMu["PT_QTY"].ToString());
                        if (ActSum == CurOutCount)
                        {
                            break;
                        }
                        if (CurOutCount - ActSum > (double.Parse(VarMu["PICKED_QTY"].ToString()) - PT_QTY))
                        {
                            ActCount = double.Parse(VarMu["PICKED_QTY"].ToString()) - PT_QTY;
                            ActSum = ActSum + ActCount;
                        }
                        else
                        {
                            ActCount = CurOutCount - ActSum;
                            ActSum += ActCount;
                        }

                        if (ActCount > 0)
                        {
                            //组装HASHTABLE
                            BulidHashtable(MuIdCount, VarMu["MU_ID"].ToString(), VarMu["UID_ID"].ToString(), ActCount);

                            //写出库ACT记录
                            InsertPickTickAct(UserId.ToString(), OrderMId, var["LINE_NO"].ToString(), var["BATCH_ID"].ToString(),
                                double.Parse(VarMu["UID_ID"].ToString()), double.Parse(VarMu["MU_ID"].ToString()), ActCount,
                                double.Parse(VarMu["LOC_ID"].ToString()), sqlMapper);
                        }
                        SumOutCount += ActCount;
                    }
                    if (ActSum != CurOutCount)
                    {
                        Mesg = "写ACT记录数量异常!";
                        throw new Exception("记录数量异常!");
                    }
                }
                return MuIdCount;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        /// <summary>
        /// 库存出库
        /// </summary>
        /// <param name="MuIdCount">MUid,Uid组要扣的零件数组</param>
        /// <param name="ItemId">零件ID</param>
        /// <param name="WhseId">仓库ID</param>
        /// <param name="WhseCode">仓库代码</param>
        /// <param name="Mesg">返回到客户端的提示错误信息</param>
        /// <param name="PackgID">包装箱ID</param>
        /// <param name="UserId">操作用户ID</param>
        /// <param name="BATCH_ID">操作单号</param>
        /// <param name="sqlMapper">全局事务</param>
        /// <returns></returns>
        private static bool SaveInvDetail(System.Collections.Hashtable MuIdCount, double ItemId, double WhseId, string WhseCode, out string Mesg,
            double PackgID, double UserId, string BATCH_ID,
            IBatisNet.DataMapper.ISqlMapper sqlMapper)
        {
            try
            {
                Mesg = string.Empty;
                foreach (System.Collections.DictionaryEntry VarMuid in MuIdCount)
                {
                    string[] keystring = VarMuid.Key.ToString().Split(',');
                    string MuId = keystring[0];
                    string UidId = keystring[1];

                    //string MUkey = VarMuid["MU_ID"].ToString() + "," + VarMuid["UID_ID"].ToString();

                    SqlParamSet PsqlParam = new SqlParamSet();
                    PsqlParam.AddParam("MU_ID", MuId);
                    PsqlParam.AddParam("UID_ID", UidId);
                    PsqlParam.AddParam("LOC_CODE", WhseCode + "-F");
                    PsqlParam.AddParam("ITEM_ID", ItemId);
                    DataTable Qtytmp = VWmsInvDetail.QueryDataTable(sqlMapper, "SelectByShipOutQty", PsqlParam.GetParams());//查询零件库存
                    if (Qtytmp.Rows.Count < 1)
                    {
                        Mesg = "零件查询数据为空";
                        return false;
                    }
                    if (double.Parse(VarMuid.Value.ToString()) > double.Parse(Qtytmp.Compute("SUM(QTY)", "QTY NOT IS NULL").ToString()))
                    {
                        Mesg = "库存数量不足!";
                        return false;
                    }
                    if (!UpdateItemCount(PackgID, UserId, ItemId, double.Parse(VarMuid.Value.ToString()),
                        WhseId, WhseCode, sqlMapper, Qtytmp, BATCH_ID))
                    {
                        Mesg = "出库失败!请重试!";
                        return false;
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //更新库存数据New
        private static bool UpdateItemCount(double PackgID, double UserId, double ItemId, double OutCount,
            double WhseId, string WhseCode, IBatisNet.DataMapper.ISqlMapper sqlMapper, DataTable ItemQty, string BATCH_ID)
        {


            double CurrCount = 0;
            try
            {
                foreach (DataRow item in ItemQty.Rows)
                {



                    if (CurrCount >= OutCount)
                    {
                        return false;
                    }

                    //根据已出库的零件编号更新表INPUTAGE里的零件个数
                    UpdateQtyByItemId(item["ITEM_ID"].ToString(), OutCount, item["LOC_ID"].ToString());

                    if (double.Parse(item["QTY"].ToString()) == OutCount - CurrCount)//数量合适，直接修改库位
                    {
                        VWmsInvDetail InvDt = new VWmsInvDetail();
                        InvDt.ID = double.Parse(item["ID"].ToString());
                        InvDt.QTY = 0;
                        InvDt.Delete(sqlMapper);
                        //InvDt.Update(sqlMapper, "UpdateSection");//更新了了数量把有值的变为零
                        //写仓库日志记录
                        WriteWaerehouse(UserId, ItemId, double.Parse(item["QTY"].ToString()), WhseId, sqlMapper, item, BATCH_ID);
                        break;
                    }
                    else if (double.Parse(item["QTY"].ToString()) > OutCount - CurrCount)//零件库存 大于移动库存
                    {

                        VWmsInvDetail InvDt = new VWmsInvDetail();
                        InvDt.ID = double.Parse(item["ID"].ToString());
                        InvDt.QTY = float.Parse(item["QTY"].ToString()) - float.Parse((OutCount - CurrCount).ToString());
                        InvDt.Update(sqlMapper, "UpdateSection");
                        //写仓库日志记录
                        WriteWaerehouse(UserId, ItemId, OutCount - CurrCount, WhseId, sqlMapper, item, BATCH_ID);
                        return true;
                    }
                    else
                    {
                        VWmsInvDetail InvDt = new VWmsInvDetail();
                        InvDt.ID = double.Parse(item["ID"].ToString());
                        InvDt.QTY = 0;
                        //InvDt.Update(sqlMapper, "UpdateSection");
                        InvDt.Delete(sqlMapper);//更新了了数量把有值的变为零
                        CurrCount += double.Parse(item["QTY"].ToString());
                        //写仓库日志记录
                        WriteWaerehouse(UserId, ItemId, double.Parse(item["QTY"].ToString()), WhseId, sqlMapper, item, BATCH_ID);
                    }





                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }



        /// <summary>
        /// 更具出库时的零件编号更新表INPUTAGE里的数据
        /// </summary>
        /// <param name="itemID">零件编号</param>
        /// <param name="outCount">出库的数量</param>
        private static void UpdateQtyByItemId(string itemID, double outCount, string locID)
        {
            IBatisNet.DataMapper.ISqlMapper sqlMapper = Sql_Mapper.Instance();
            SqlParamSet PsqlParam1 = new SqlParamSet();
            PsqlParam1.AddParam("ITEM_ID", itemID); //零件编号
            // PsqlParam1.AddParam("LOC_ID", locID); //库位号
            //根据零件编号查询出所有的库存量
            DataTable tab = VWmsInvUid.QueryDataTable(sqlMapper, "SelectByItemID", PsqlParam1.GetParams());
            int notesOutCount = 0;
            if (tab.Rows.Count > 0)
            {
                foreach (DataRow item in tab.Rows)
                {
                    if (int.Parse(item["QTY"].ToString()) == (outCount - notesOutCount))
                    {
                        //直接修改数量变为零 
                        SqlParamSet PsqlParam = new SqlParamSet();
                        PsqlParam.AddParam("ID", item["ID"].ToString());
                        PsqlParam.AddParam("QTY", 0);
                        PsqlParam.AddParam("LAST_MODIFIED", DateTime.Now);
                        VWmsInvDetail.Update(sqlMapper, "UPDATEINPUTAGE", PsqlParam.GetParams());
                        //变为零了后直接删除
                        //VWmsInvDetail.Delete("Delete1", PsqlParam.GetParams())
                        return; //此零件的数量刚好出库完就不要在继续了。

                    }
                    else if (int.Parse(item["QTY"].ToString()) > (outCount - notesOutCount))
                    {
                        //减去出库的数量来更新
                        SqlParamSet PsqlParam = new SqlParamSet();
                        PsqlParam.AddParam("ID", item["ID"].ToString());
                        PsqlParam.AddParam("QTY", (int.Parse(item["QTY"].ToString()) - (outCount - notesOutCount)));
                        PsqlParam.AddParam("LAST_MODIFIED", DateTime.Now);
                        VWmsInvDetail.Update(sqlMapper, "UPDATEINPUTAGE", PsqlParam.GetParams());
                        return;//此零件的数量刚好出库完就不要在继续了。


                    }
                    else
                    {
                        //循环还是修改
                        if (notesOutCount >= outCount) return;
                        SqlParamSet PsqlParam = new SqlParamSet();
                        PsqlParam.AddParam("ID", item["ID"].ToString());
                        PsqlParam.AddParam("QTY", 0);
                        PsqlParam.AddParam("LAST_MODIFIED", DateTime.Now);
                        //记录除了多少个零件了
                        notesOutCount += int.Parse(item["QTY"].ToString());
                        VWmsInvDetail.Update(sqlMapper, "UPDATEINPUTAGE", PsqlParam.GetParams());
                        //变为零了后直接删除
                        //VWmsInvDetail.Delete("Delete1", PsqlParam.GetParams())




                    }



                }


            }




        }


        /// <summary>
        /// 组装Muid出库数量
        /// </summary>
        /// <param name="MuIdCount">MUid,Uid组要扣的零件数组</param>
        /// <param name="Mid">Mid</param>
        /// <param name="Uid"></param>
        /// <param name="Qty"></param>
        private static void BulidHashtable(System.Collections.Hashtable MuIdCount, string Mid, string Uid, double Qty)
        {
            if (MuIdCount.Contains(Mid + "," + Uid))
            {
                MuIdCount[Mid + "," + Uid] = double.Parse(MuIdCount[Mid + "," + Uid].ToString()) + Qty;
            }
            else
            {
                MuIdCount.Add(Mid + "," + Uid, Qty);
            }
        }
        /// <summary>
        /// 写仓库日志记录
        /// </summary>
        /// <param name="UserId"></param>
        /// <param name="ItemId"></param>
        /// <param name="OutCount"></param>
        /// <param name="WhseId"></param>
        /// <param name="sqlMapper"></param>
        /// <param name="item"></param>
        private static void WriteWaerehouse(double UserId, double ItemId, double OutCount, double WhseId,
            IBatisNet.DataMapper.ISqlMapper sqlMapper, DataRow item, string BATCH_ID)
        {
            VWmsInvTransaction Tran = new VWmsInvTransaction();
            Tran.TRANSACTION_CODE = "com.vtradex.wms.anji.outbound.QuickShip";
            Tran.WHSE_ID = WhseId;
            Tran.LOC_ID = double.Parse(item["LOC_ID"].ToString());
            Tran.T_LOC_ID = double.Parse(item["LOC_ID"].ToString());
            Tran.COMPANY_ID = 1;
            Tran.ITEM_ID = ItemId;
            Tran.LOT = item["LOT"].ToString();
            Tran.F_QTY = float.Parse(item["QTY"].ToString());
            Tran.T_QTY = float.Parse(item["QTY"].ToString()) - float.Parse(OutCount.ToString());
            Tran.F_MU_ID = double.Parse(item["MU_ID"].ToString());
            Tran.T_MU_ID = double.Parse(item["MU_ID"].ToString());
            Tran.F_STATUS = "V";
            Tran.T_STATUS = "V";
            Tran.F_ITEM_STATUS = "N";
            Tran.T_ITEM_STATUS = "N";
            Tran.DESCRIPTION = BATCH_ID;
            Tran.USER_ID = VPhrSecUsr.QueryDataTable(sqlMapper, "SelectById", UserId).Rows[0]["LOGIN_NAME"].ToString();
            Tran.CREATED_TIME = DBDateTimeGenerator.GetDBDateTime(sqlMapper);
            Tran.F_GOODSTYPE = "P";
            Tran.T_GOODSTYPE = "P";
            Tran.Save(sqlMapper);
        }

        /// <summary>
        /// 添加Act表记录_出库执行记录
        /// </summary>
        /// <param name="UserId"></param>
        /// <param name="sqlMapper"></param>
        private static void InsertPickTickAct(string UserId, double PickTickId, string LineNo, string BATCH_ID, double UidId, double MuId, double Qty,
            double LocId, IBatisNet.DataMapper.ISqlMapper sqlMapper)
        {
            //添加Act表记录 2012-8-20新增修改
            VWmsPickTicketAct VwmsPickeTicktAct = new VWmsPickTicketAct();
            VwmsPickeTicktAct.PICK_TICKET_ID = PickTickId;
            VwmsPickeTicktAct.LINE_NO = LineNo;
            VwmsPickeTicktAct.UID_ID = UidId;
            VwmsPickeTicktAct.MU_ID = MuId;
            VwmsPickeTicktAct.QTY = Qty;
            VwmsPickeTicktAct.USER_ID = UserId;
            VwmsPickeTicktAct.PICKED_TIME = DBDateTimeGenerator.GetDBDateTime(sqlMapper);
            VwmsPickeTicktAct.VEHICLE_NO = "1to1100";
            VwmsPickeTicktAct.LOAD_NO = BATCH_ID;
            VwmsPickeTicktAct.IS_FINAL_LOAD_NO = "1";
            VwmsPickeTicktAct.SHIP_TIME = DBDateTimeGenerator.GetDBDateTime(sqlMapper);
            VwmsPickeTicktAct.LAST_MODIFIED = DBDateTimeGenerator.GetDBDateTime(sqlMapper);
            VwmsPickeTicktAct.IS_DISABLED = "0";
            VwmsPickeTicktAct.LOC_ID = LocId;
            VwmsPickeTicktAct.RECEIVE_TIME = null;
            VwmsPickeTicktAct.Save(sqlMapper);
        }

        /// <summary>
        /// 保存订单自动打印信息
        /// </summary>
        /// <param name="OrderNo"></param>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public static bool SaveOrderAutoPrintInfo(string OrderNo, string UserId)
        {
            IBatisNet.DataMapper.ISqlMapper sqlMapper = Sql_Mapper.Instance();
            try
            {
                LdvOrderAutoPrint print = new LdvOrderAutoPrint();
                print.USER_ID = int.Parse(UserId);
                print.ORDER_NO = OrderNo;
                print.CREATE_DATE = DBDateTimeGenerator.GetDBDateTime(sqlMapper);
                print.Save(sqlMapper);
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        #region mjy 合箱功能开发 2016-04-28
        /// <summary>
        /// 合箱
        /// </summary>
        /// <param name="srcPakcageCode">原箱号</param>
        /// <param name="targetPackgeCode">目的箱号</param>
        /// <param name="UserID">用户ID</param>
        /// <param name="Msg">提示</param>
        /// <returns></returns>
        public static bool MergePackage(string srcPakcageCode, string targetPackgeCode, double UserID, out string Msg)
        {
            bool flag = true;
            IBatisNet.DataMapper.ISqlMapper sqlMapper = Sql_Mapper.Instance();
            try
            {
                SqlParamSet sqlParam1 = new SqlParamSet();
                sqlParam1.AddParam("PACKAGE_BARCODE", srcPakcageCode);
                DataTable dtOldPackage = LdvPackageItemRel.QueryDataTable("SelectPackegeOn", sqlParam1.GetParams());
                if (dtOldPackage.Rows.Count == 0)
                {
                    Msg = "原箱号无零件信息！";
                    flag = false;
                    return flag;
                }
                else
                {
                    string rowStatus = dtOldPackage.Rows[0]["STATUS"].ToString();
                    if (rowStatus == "CL")
                    {
                        Msg = "原箱号已发货,不能被调整";
                        flag = false;
                        return flag;
                    }
                }

                SqlParamSet sqlParam2 = new SqlParamSet();
                sqlParam2.AddParam("PACKAGE_BARCODE", targetPackgeCode);
                DataTable dtNewPackage = LdvPackageItemRel.QueryDataTable("SelectPackege", sqlParam2.GetParams());
                string rowNewStatus = string.Empty;
                if (dtNewPackage.Rows.Count == 0)
                {
                    Msg = "目的箱号" + targetPackgeCode + "不正确！";
                    flag = false;
                    return flag;
                }
                else
                {
                    rowNewStatus = dtNewPackage.Rows[0]["STATUS"].ToString();
                    if (rowNewStatus == "CL")
                    {
                        Msg = "目的箱号已发货,不能被调整";
                        flag = false;
                        return flag;
                    }
                }

                string oldCustomer = dtOldPackage.Rows[0]["PICK_TICKET_CODE"].ToString();
                string newCustomer = string.Empty;
                if (dtNewPackage.Rows[0]["PICK_TICKET_CODE"].ToString() != string.Empty)
                {
                    newCustomer = dtNewPackage.Rows[0]["PICK_TICKET_CODE"].ToString();
                }
                if (oldCustomer != newCustomer && newCustomer != string.Empty)
                {
                    Msg = "两箱订单不同,不能被调整！";
                    flag = false;
                    return flag;
                }

                sqlMapper.BeginTransaction();
                //update 原箱号下所有零件都移动到新箱号
                foreach (DataRow item in dtOldPackage.Rows)
                {
                    SqlParamSet sqlParam = new SqlParamSet();
                    sqlParam.AddParam("ID", item["D_ID"]);
                    sqlParam.AddParam("PACKAGE_BARCODE_ID", dtNewPackage.Rows[0]["PACKEGE_ID"]);
                    sqlParam.AddParam("LAST_MODIFY_DATE", DBDateTimeGenerator.GetDBDateTime(sqlMapper));
                    sqlParam.AddParam("LAST_MODIFY_USER_ID", UserID);
                    int a = LdvPackageItemRel.Update(sqlMapper, "UpdateSection", sqlParam.GetParams());
                    if (a > 0)
                    {
                        flag = true;
                    }
                    else
                    {
                        flag = false;
                    }
                }
                //如果目的箱号为未使用，更新目的箱号为已使用。
                if (rowNewStatus == "OP")
                {
                    SqlParamSet sqlParam6 = new SqlParamSet();
                    sqlParam6.AddParam("ID", dtNewPackage.Rows[0]["PACKEGE_ID"].ToString());
                    LdvPackageBarcode.Update(sqlMapper, "UpdateStatus", sqlParam6.GetParams());
                }
                sqlMapper.CommitTransaction();
                Msg = "合箱成功！";
                return flag;

            }
            catch (Exception ex)
            {
                sqlMapper.RollBackTransaction();
                Msg = "合箱失败！" + ex;
                return false;
                throw ex;
            }
        }
        #endregion
    }
}
