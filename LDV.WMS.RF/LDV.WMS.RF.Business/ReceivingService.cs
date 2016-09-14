using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using LDV.WMS.RF.DataMapper;
using LDV.WMS.RF.Utility;
using System.IO;
using System.Configuration;


namespace LDV.WMS.RF.Business
{
    /// <summary>
    /// 拣货操作类
    /// </summary>
    public class ReceivingService
    {
        /// <summary>
        /// 读取所有预收货单信息
        /// </summary>
        /// <param name="OrderNumber"></param>
        /// <returns></returns>
        public static DataTable LoadMainDocByStatus(string Status, string UserID)
        {

            SqlParamSet sqlParam = new SqlParamSet();
            sqlParam.AddParam("ID", UserID);
            try
            {
                DataTable Result = new DataTable();
                if (Status == "RV")
                {
                    Result = VWmsRcvDoc.QueryDataTable("SelectDocByStatusRV", sqlParam.GetParams());
                }
                if (Status == "PQ")
                {
                    Result = VWmsRcvDoc.QueryDataTable("SelectDocByStatusPQ", sqlParam.GetParams());
                }
                if (Status == "AP")
                {
                    Result = VWmsRcvDoc.QueryDataTable("SelectDocByStatusAP", sqlParam.GetParams());
                }
                if (Status == "DOC_CODE")
                {   //获取需要上架的订单号
                    Result = VWmsRcvDoc.QueryDataTable("SelectOrderPartInfoGroupByOrder", sqlParam.GetParams());
                }
                if (Status.Contains("ITEM"))
                {  //获取单一零件信息
                    // sqlParam.AddParam("ITEM_CODE",Status.Split('_')[1]);
                    Result = VWmsRcvDoc.QueryDataTable("SelectDocByStatusAP", sqlParam.GetParams());
                }
                return Result;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 读取收货单信息
        /// </summary>
        /// <param name="OrderNumber"></param>
        /// <returns></returns>
        public static DataTable LoadMainDoc(string OrderNumber, double UserId)
        {
            SqlParamSet sqlParam = new SqlParamSet();
            sqlParam.AddParam("DOC_CODE", OrderNumber);
            sqlParam.AddParam("ID", UserId);
            try
            {
                DataTable Result = VWmsRcvDoc.QueryDataTable("SelectDocByOrderNumber", sqlParam.GetParams());
                //foreach (DataRow item in Result.Rows)
                //{
                //    if (item["STATUS"].ToString() == "CL")
                //    {
                //        Result.TableName = "OrderCL";
                //        break;
                //    }
                //if (double.Parse(item["USER_ID"].ToString()) != UserId && double.Parse(item["USER_ID"].ToString()) > 0)
                //{
                //    Result.TableName ="#"+ item["FIRST_NAME"].ToString() + item["LAST_NAME"].ToString();
                //    break;
                //}
                //    else
                //    {
                //        Result.TableName = "OrderList";
                //    }
                //}

                if (Result.Select("STATUS ='CL'").Length == Result.Rows.Count)
                {
                    Result.TableName = "OrderCL";
                    return Result;
                }
                //----------huzhenfei 2014-07-17 13:20:10------------
                //PQ
                if (Result.Select("EXTEND_COLUMN_2='PQ'").Length == Result.Rows.Count || Result.Select("EXTEND_COLUMN_2<>'OP'").Length == Result.Rows.Count)
                {
                    Result.TableName = "OrderPQ";
                    return Result;
                }
                //RV
                if (Result.Select("EXTEND_COLUMN_2='RV'").Length == Result.Rows.Count)
                {
                    Result.TableName = "OrderRV";
                    return Result;
                }
                //---------------------------------------------------
                if (Result.Select("USER_ID<>" + UserId + " and USER_ID>0 ").Length > 0)
                {
                    Result.TableName = "#" + Result.Select("USER_ID<>" + UserId + " AND USER_ID>0 ")[0]["FIRST_NAME"].ToString() +
                        Result.Select("USER_ID<>" + UserId + " AND USER_ID>0 ")[0]["LAST_NAME"].ToString();
                    return Result;
                }
                else
                {
                    Result.TableName = "OrderList";
                    return Result;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 读取预收货信息（包装用）
        /// </summary>
        /// <param name="OrderNumber"></param>
        /// <returns></returns>
        public static DataTable LoadMainDocRV(string OrderNumber, double UserId)
        {
            SqlParamSet sqlParam = new SqlParamSet();
            sqlParam.AddParam("DOC_CODE", OrderNumber);
            sqlParam.AddParam("ID", UserId);
            try
            {
                DataTable Result = VWmsRcvDoc.QueryDataTable("SelectDocByOrderNumberas", sqlParam.GetParams());

                return Result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //收货保存子表
        /// <summary>
        /// 收货保存子表
        /// </summary>
        /// <param name="ID">收货子表ID</param>
        /// <param name="ACTUAL_QTY">收货数量</param>
        /// <param name="EXPECTED_QTY">预计收货数量</param>
        /// <param name="LocID">库位ID</param>
        /// <param name="WhseID">仓库ID</param>
        /// <param name="LotDate">入库时间</param>
        ///  <param name="UserId">用户ID（关联仓库）</param>
        /// <returns></returns>
        public static bool SaveOrderDetail(string ID, string ITEM_ID, float InCount, float ACTUAL_QTY, float EXPECTED_QTY, float oldap_qty,
            string _LocID, double WhseID, string LotDate, bool ISLOC, double SUPPLIER_ID, double User_ID, string RID, out string OutMsg)
        {
            IBatisNet.DataMapper.ISqlMapper sqlMapper = Sql_Mapper.Instance();
            sqlMapper.BeginTransaction();
            bool flag;
            double LocID;
            try
            {
                //判断当前零件是否并发上架
                SqlParamSet bfssdt = new SqlParamSet();
                bfssdt.AddParam("ID", ID);
                DataTable bfdt = VWmsRcvDocDetail.QueryDataTable(sqlMapper, "SelectByParam", bfssdt.GetParams());
                if (Convert.ToInt32(bfdt.Rows[0]["ACTUAL_QTY"]) != Convert.ToInt32(oldap_qty))
                {
                    OutMsg = "More";
                    return flag = false;
                }
                else
                {

                    #region 正常流程
                    DataTable CheckLoc = VWmsBaseLocation.QueryDataTable(sqlMapper, "SelectCheckLocById", _LocID);
                    if (CheckLoc.Rows.Count < 1)
                    {
                        throw new Exception("该库位不存在!");
                    }
                    LocID = double.Parse(CheckLoc.Rows[0]["LOC_ID"].ToString());



                    if (ISLOC)
                    {
                        //检查库位是否可用                    

                        if ((CheckLoc.Rows[0]["ITEM_ID"] != DBNull.Value || CheckLoc.Rows[0]["ITEM_ID"].ToString() != string.Empty)
                            && !CheckLoc.Rows[0]["ITEM_ID"].ToString().Equals(ITEM_ID))
                        {
                            throw new Exception("该库位是其他零件的主库位!");
                        }
                    }
                    //获取当前detail的数据判断是否已经包装完成
                    SqlParamSet ssdt = new SqlParamSet();
                    ssdt.AddParam("ID", ID);
                    DataTable detaildt = VWmsRcvDocDetail.QueryDataTable(sqlMapper, "SelectStatusById", ssdt.GetParams());

                    VWmsRcvDocDetail Detail = new VWmsRcvDocDetail();
                    Detail.ID = double.Parse(ID);
                    Detail.ACTUAL_QTY = ACTUAL_QTY;
                    //完成包装后 才能进行上架完成
                    if (ACTUAL_QTY == EXPECTED_QTY)
                    {
                        if (detaildt.Rows[0]["EXTEND_COLUMN_2"].ToString() == "PQ")
                        {
                            Detail.EXTEND_COLUMN_2 = "AP";


                            //更改时同时更改所有相同零件的状态
                            //  if (Detail.Update(sqlMapper, "UpdateStatus") > 0)
                            //更改当前零件的状态
                            if (Detail.Update(sqlMapper, "UpdateStatusByDetailID") > 0)
                            {
                                flag = true;
                            }
                            else
                            {
                                throw new Exception("包装失败!没有找到该零件或数据错误!");
                            }
                        }
                    }

                    Detail.LAST_MODIFIED = DBDateTimeGenerator.GetDBDateTime(sqlMapper);//修改收货状态
                    Detail.RECEIVEDATE = Detail.LAST_MODIFIED;

                    LotDate = Detail.LAST_MODIFIED.Value.ToString("yyyy-MM");

                    if (Detail.Update(sqlMapper, "UpdateSection") > 0)
                    {
                        flag = true;
                    }
                    else
                    {
                        throw new Exception("收货失败!没有找到该零件或数据错误!");
                    }



                    //修改库存
                    string INV_ID = string.Empty;  //记录 INV_DETAIL_ID(INPUTAGE)

                    SqlParamSet Parm = new SqlParamSet();
                    Parm.AddParam("ITEM_ID", ITEM_ID);
                    Parm.AddParam("LOT", LotDate);
                    Parm.AddParam("LOC_ID", LocID);
                    DataTable IsNanItem = VWmsInvUid.QueryDataTable(sqlMapper, "SelectIsItemById", Parm.GetParams());
                    if (IsNanItem.Rows.Count == 1)
                    {
                        INV_ID = IsNanItem.Rows[0]["INV_ID"].ToString();
                        //已存在此批次此库位零件,直接改数量
                        VWmsInvDetail UpDetail = new VWmsInvDetail();
                        UpDetail.ID = double.Parse(IsNanItem.Rows[0]["D_ID"].ToString());
                        UpDetail.QTY = float.Parse(IsNanItem.Rows[0]["QTY"].ToString()) + InCount;
                        if (UpDetail.Update(sqlMapper, "UpdateSection") > 0)
                        {
                            flag = true;
                        }
                        else
                        {
                            throw new Exception("收货失败!修改已有库位库存数量失败!");
                        }
                        //同时更改PQ-
                        flag = UpdateCountPQMinus(sqlMapper, InCount, double.Parse(IsNanItem.Rows[0]["MU_ID"].ToString()),
                            double.Parse(IsNanItem.Rows[0]["LOC_ID"].ToString()), double.Parse(IsNanItem.Rows[0]["U_ID"].ToString()));



                        VWmsRcvDocAct Ract = new VWmsRcvDocAct();
                        Ract.DOC_DETAIL_ID = Detail.ID;
                        Ract.UID_ID = double.Parse(IsNanItem.Rows[0]["U_ID"].ToString());//UpDetail.UID_ID;
                        Ract.QTY_RECEIVED = InCount;
                        Ract.QTY_DAMAGED = 0;
                        Ract.LP_ID = double.Parse(IsNanItem.Rows[0]["MU_ID"].ToString());
                        Ract.LOC_ID = LocID;
                        Ract.USER_ID = VPhrSecUsr.QueryDataTable(sqlMapper, "SelectById", User_ID).Rows[0]["LOGIN_NAME"].ToString();
                        Ract.CREATED_TIME = DBDateTimeGenerator.GetDBDateTime(sqlMapper);
                        Ract.IS_DISABLED = 0;
                        Ract.NORMAL_QTY = 0;
                        Ract.STATUS = "CL";
                        Ract.IS_PRINT = 0;
                        Ract.Save(sqlMapper);

                        //写仓库日志记录
                        VWmsInvTransaction Tran = new VWmsInvTransaction();
                        Tran.TRANSACTION_CODE = "com.vtradex.wms.inbound.Receiving";
                        Tran.WHSE_ID = WhseID;
                        Tran.LOC_ID = LocID;
                        Tran.T_LOC_ID = LocID;
                        Tran.COMPANY_ID = 1;
                        Tran.ITEM_ID = double.Parse(ITEM_ID);
                        Tran.LOT = LotDate;
                        Tran.F_QTY = float.Parse(IsNanItem.Rows[0]["QTY"].ToString());
                        Tran.T_QTY = float.Parse(IsNanItem.Rows[0]["QTY"].ToString()) + InCount;
                        Tran.F_MU_ID = double.Parse(IsNanItem.Rows[0]["MU_ID"].ToString()); ;
                        Tran.T_MU_ID = double.Parse(IsNanItem.Rows[0]["MU_ID"].ToString());
                        Tran.F_STATUS = "V";
                        Tran.T_STATUS = "V";
                        Tran.F_ITEM_STATUS = "N";
                        Tran.T_ITEM_STATUS = "N";
                        Tran.DESCRIPTION = "10";
                        Tran.USER_ID = VPhrSecUsr.QueryDataTable(sqlMapper, "SelectById", User_ID).Rows[0]["LOGIN_NAME"].ToString();
                        Tran.CREATED_TIME = DBDateTimeGenerator.GetDBDateTime(sqlMapper);
                        Tran.F_GOODSTYPE = "P";
                        Tran.T_GOODSTYPE = "P";
                        Tran.Save(sqlMapper);
                    }
                    else
                    {
                        Parm = new SqlParamSet();
                        Parm.AddParam("ITEM_ID", ITEM_ID);
                        Parm.AddParam("LOT", LotDate);
                        Parm.AddParam("LOC_ID", LocID);
                        IsNanItem.Clear();
                        IsNanItem = VWmsInvUid.QueryDataTable(sqlMapper, "SelectIsItemById", Parm.GetParams());
                        #region
                        if (IsNanItem.Rows.Count > 1)
                        {
                            //有批次，没库位(新建库位关系,在新建库位下加零件)
                            VWmsInvMu Mu = new VWmsInvMu();
                            Mu.LP = "S" + ITEM_ID + SUPPLIER_ID.ToString();
                            Mu.WHSE_ID = WhseID;
                            Mu.CREATED_TIME = DBDateTimeGenerator.GetDBDateTime(sqlMapper);
                            Mu.LAST_MODIFIED = DBDateTimeGenerator.GetDBDateTime(sqlMapper);
                            Mu.COMPANY_ID = 0;
                            Mu.WIDTH = 0;
                            Mu.HEIGHT = 0;
                            Mu.LENGTH = 0;
                            Mu.PACK_CODE = "";
                            Mu.IS_DISABLED = 0;
                            Mu.PACKAGE_TYPE = "";
                            Mu.ITEM_ID = 0;
                            Mu.Save(sqlMapper);//新建可移动单元

                            VWmsInvDetail Sda = new VWmsInvDetail();
                            Sda.LOC_ID = LocID;
                            Sda.MU_ID = Mu.ID;
                            Sda.UID_ID = double.Parse(IsNanItem.Rows[0]["U_ID"].ToString());
                            Sda.STATUS = "V";
                            Sda.ITEM_STATUS = "N";
                            Sda.QTY = InCount;
                            Sda.VERSION_TRANSACTION = 0;
                            Sda.PLAN_PICK_QTY = 0;
                            Sda.Save(sqlMapper);//新建零件    
                            //Sda.ID
                            INV_ID = Sda.ID.ToString();

                            VWmsRcvDocAct Ract = new VWmsRcvDocAct();
                            Ract.DOC_DETAIL_ID = Detail.ID;
                            Ract.UID_ID = Sda.UID_ID;
                            Ract.QTY_RECEIVED = InCount;
                            Ract.QTY_DAMAGED = 0;
                            Ract.LP_ID = Mu.ID;
                            Ract.LOC_ID = LocID;
                            Ract.USER_ID = VPhrSecUsr.QueryDataTable(sqlMapper, "SelectById", User_ID).Rows[0]["LOGIN_NAME"].ToString();
                            Ract.CREATED_TIME = DBDateTimeGenerator.GetDBDateTime(sqlMapper);
                            Ract.IS_DISABLED = 0;
                            Ract.NORMAL_QTY = 0;
                            Ract.STATUS = "CL";
                            Ract.Save(sqlMapper);


                            VWmsInvTransaction Tran = new VWmsInvTransaction();
                            Tran.TRANSACTION_CODE = "com.vtradex.wms.inbound.Receiving";
                            Tran.WHSE_ID = WhseID;
                            Tran.LOC_ID = LocID;
                            Tran.T_LOC_ID = LocID;
                            Tran.COMPANY_ID = 1;
                            Tran.ITEM_ID = double.Parse(ITEM_ID);
                            Tran.LOT = LotDate;
                            Tran.F_QTY = 0;
                            Tran.T_QTY = InCount;
                            Tran.F_MU_ID = Mu.ID; ;
                            Tran.T_MU_ID = Mu.ID;
                            Tran.F_STATUS = "V";
                            Tran.T_STATUS = "V";
                            Tran.F_ITEM_STATUS = "N";
                            Tran.T_ITEM_STATUS = "N";
                            Tran.DESCRIPTION = "10";
                            Tran.USER_ID = VPhrSecUsr.QueryDataTable(sqlMapper, "SelectById", User_ID).Rows[0]["LOGIN_NAME"].ToString();
                            Tran.CREATED_TIME = DBDateTimeGenerator.GetDBDateTime(sqlMapper);
                            Tran.F_GOODSTYPE = "P";
                            Tran.T_GOODSTYPE = "P";
                            Tran.Save(sqlMapper);
                        }
                        else//没批次
                        {
                            //新建批次
                            //新建可移动单元
                            //新建商品细分及明细

                            VWmsInvUid Uid = new VWmsInvUid();
                            Uid.WHSE_ID = WhseID;
                            Uid.ITEM_ID = double.Parse(ITEM_ID);
                            Uid.LOT = LotDate;
                            Uid.XDATE = null;
                            Uid.SERIAL = "S" + ITEM_ID + SUPPLIER_ID.ToString();
                            Uid.EXTEND_COLUMN_0 = "";
                            Uid.EXTEND_COLUMN_1 = "";
                            Uid.EXTEND_COLUMN_2 = "";
                            Uid.EXTEND_COLUMN_3 = "";
                            Uid.EXTEND_COLUMN_4 = "";
                            Uid.EXTEND_DATE_0 = DBDateTimeGenerator.GetDBDateTime(sqlMapper);
                            Uid.EXTEND_DATE_1 = DBDateTimeGenerator.GetDBDateTime(sqlMapper);
                            Uid.GOODSTYPE = "P";
                            Uid.TRACKNO = "000000";
                            Uid.SUPPLIER_ID = SUPPLIER_ID;
                            Uid.VERSION = "";
                            Uid.JISHOU = 0;
                            Uid.Save(sqlMapper);//新建批次

                            VWmsInvMu Mu = new VWmsInvMu();
                            Mu.LP = "S" + ITEM_ID + SUPPLIER_ID.ToString();
                            Mu.WHSE_ID = WhseID;
                            Mu.CREATED_TIME = DBDateTimeGenerator.GetDBDateTime(sqlMapper);
                            Mu.LAST_MODIFIED = DBDateTimeGenerator.GetDBDateTime(sqlMapper);
                            Mu.COMPANY_ID = 0;
                            Mu.WIDTH = 0;
                            Mu.HEIGHT = 0;
                            Mu.LENGTH = 0;
                            Mu.PACK_CODE = "";
                            Mu.IS_DISABLED = 0;
                            Mu.PACKAGE_TYPE = "";
                            Mu.ITEM_ID = 0;
                            Mu.Save(sqlMapper);//新建可移动单元                        
                            VWmsInvDetail Sda = new VWmsInvDetail();
                            Sda.LOC_ID = LocID;
                            Sda.MU_ID = Mu.ID;
                            Sda.UID_ID = Uid.ID;
                            Sda.STATUS = "V";
                            Sda.ITEM_STATUS = "N";
                            Sda.QTY = InCount;
                            Sda.VERSION_TRANSACTION = 0;
                            Sda.PLAN_PICK_QTY = 0;
                            Sda.Save(sqlMapper);//新建零件
                            INV_ID = Sda.ID.ToString();

                            VWmsRcvDocAct Ract = new VWmsRcvDocAct();
                            Ract.DOC_DETAIL_ID = Detail.ID;
                            Ract.UID_ID = Sda.UID_ID;
                            Ract.QTY_RECEIVED = InCount;
                            Ract.QTY_DAMAGED = 0;
                            Ract.LP_ID = Mu.ID;
                            Ract.LOC_ID = LocID;
                            Ract.USER_ID = VPhrSecUsr.QueryDataTable(sqlMapper, "SelectById", User_ID).Rows[0]["LOGIN_NAME"].ToString();
                            Ract.CREATED_TIME = DBDateTimeGenerator.GetDBDateTime(sqlMapper);
                            Ract.IS_DISABLED = 0;
                            Ract.NORMAL_QTY = 0;
                            Ract.STATUS = "CL";
                            Ract.Save(sqlMapper);

                            VWmsInvTransaction Tran = new VWmsInvTransaction();
                            Tran.TRANSACTION_CODE = "com.vtradex.wms.inbound.Receiving";
                            Tran.WHSE_ID = WhseID;
                            Tran.LOC_ID = LocID;
                            Tran.T_LOC_ID = LocID;
                            Tran.COMPANY_ID = 1;
                            Tran.ITEM_ID = double.Parse(ITEM_ID);
                            Tran.LOT = LotDate;
                            Tran.F_QTY = 0;
                            Tran.T_QTY = InCount;
                            Tran.F_MU_ID = Mu.ID; ;
                            Tran.T_MU_ID = Mu.ID;
                            Tran.F_STATUS = "V";
                            Tran.T_STATUS = "V";
                            Tran.F_ITEM_STATUS = "N";
                            Tran.T_ITEM_STATUS = "N";
                            Tran.DESCRIPTION = "10";
                            Tran.USER_ID = VPhrSecUsr.QueryDataTable(sqlMapper, "SelectById", User_ID).Rows[0]["LOGIN_NAME"].ToString();
                            Tran.CREATED_TIME = DBDateTimeGenerator.GetDBDateTime(sqlMapper);
                            Tran.F_GOODSTYPE = "P";
                            Tran.T_GOODSTYPE = "P";
                            Tran.Save(sqlMapper);
                        }
                        #endregion
                    }



                    #region  //插入库龄表
                    SqlParamSet IA = new SqlParamSet();
                    IA.AddParam("INV_DETAIL_ID", INV_ID);
                    IA.AddParam("INPUT_DATE", Detail.LAST_MODIFIED);
                    IA.AddParam("ITEM_ID", ITEM_ID);
                    IA.AddParam("SUPPLIER_ID", SUPPLIER_ID);
                    IA.AddParam("QTY", InCount);
                    IA.AddParam("LOC_ID", LocID);
                    //  IA.AddParam("LAST_MODIFIED", Detail.LAST_MODIFIED);
                    IA.AddParam("CREATE_TIME", Detail.LAST_MODIFIED);
                    IA.AddParam("CREATE_USER", User_ID);
                    //   IA.AddParam("MODIFIED_USER", User_ID);
                    VWmsRcvDoc.QueryDataTable(sqlMapper, "SelInsertInToInPutAge", IA.GetParams());
                    #endregion


                    //判断上架是否完成
                    SqlParamSet parms = new SqlParamSet();
                    parms.AddParam("RID", RID);
                    OutMsg = "Empty";
                    if (int.Parse(VWmsRcvDoc.QueryDataTable(sqlMapper, "SelectByApCount", parms.GetParams()).Rows[0][0].ToString()) == 0)
                    {
                        if (SaveOrderMain(RID, sqlMapper))
                        {
                            OutMsg = "OK";
                        }
                        else
                        {
                            OutMsg = "Catch";
                        }
                    }
                    sqlMapper.CommitTransaction();
                    return flag;
                    #endregion
                }
            }
            catch (Exception ex)
            {
                sqlMapper.RollBackTransaction();
                throw ex;
            }
        }

        /// <summary>
        /// 修改所有收货主表状态
        /// </summary>
        /// <param name="RowList"></param>
        /// <returns></returns>
        public static bool SaveOrderMain(string RowList, IBatisNet.DataMapper.ISqlMapper sqlMapper)
        {
            try
            {
                VWmsRcvDoc doc = new VWmsRcvDoc();
                doc.ID = double.Parse(RowList);
                doc.STATUS = "CL";
                doc.LAST_MODIFIED = DBDateTimeGenerator.GetDBDateTime(sqlMapper);
                doc.Update(sqlMapper, "UpdateSection");
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        //保存预收货
        /// <summary>
        /// 保存预收货
        /// </summary>
        /// <param name="ID">预收货子表ID</param>
        /// <param name="ACTUAL_QTY">收货数量</param>
        /// <param name="EXPECTED_QTY">预计收货数量</param>
        /// <param name="LocID">收货状态Status</param>
        /// <param name="WhseID">仓库ID</param>
        /// <param name="LotDate">入库时间</param>
        ///  <param name="UserId">用户ID（关联仓库）</param>
        /// <returns></returns>
        /// 
        public static bool SaveAllReceivingRV(string ID, string ITEM_ID, float InCount, float ACTUAL_QTY, float EXPECTED_QTY,
            string _LocID, double WhseID, string LotDate, bool ISLOC, double SUPPLIER_ID, double User_ID, string RID, out string OutMsg)
        {
            IBatisNet.DataMapper.ISqlMapper sqlMapper = Sql_Mapper.Instance();
            sqlMapper.BeginTransaction();
            bool flag;
            double LocID;
            string Status;
            try
            {
                //状态为RV预收货
                Status = "RV";

                #region 库位
                DataTable CheckLoc = VWmsBaseLocation.QueryDataTable(sqlMapper, "SelectCheckLocById", _LocID);
                if (CheckLoc.Rows.Count < 1)
                {
                    throw new Exception("该库位不存在!");
                }
                LocID = double.Parse(CheckLoc.Rows[0]["LOC_ID"].ToString());

                if (ISLOC)
                {
                    //检查库位是否可用                    

                    if ((CheckLoc.Rows[0]["ITEM_ID"] != DBNull.Value || CheckLoc.Rows[0]["ITEM_ID"].ToString() != string.Empty)
                        && !CheckLoc.Rows[0]["ITEM_ID"].ToString().Equals(ITEM_ID))
                    {
                        throw new Exception("该库位是其他零件的主库位!");
                    }
                }
                #endregion

                VWmsRcvDocDetail Detail = new VWmsRcvDocDetail();
                Detail.ID = double.Parse(ID);
                Detail.ACTUAL_QTY = 0;
                Detail.EXTEND_COLUMN_2 = Status; //预收货时只收一次就更改状态    
                Detail.LAST_MODIFIED = DBDateTimeGenerator.GetDBDateTime(sqlMapper);//修改收货状态
                Detail.RECEIVEDATE = Detail.LAST_MODIFIED;
                LotDate = Detail.LAST_MODIFIED.Value.ToString("yyyy-MM");

                if (Detail.Update(sqlMapper, "UpdateSection") > 0)
                {
                    flag = true;
                }
                else
                {
                    throw new Exception("预收货失败!没有找到该零件或数据错误!");
                }

                //订单下同一零件预收货一次更新所有零件状态
                VWmsRcvDocDetail DetailRV = new VWmsRcvDocDetail();
                DetailRV.ID = double.Parse(ID);
                DetailRV.EXTEND_COLUMN_2 = Status; //预收货时只收一次就更改全部零件状态    

                if (DetailRV.Update(sqlMapper, "UpdateStatus") > 0)
                {
                    flag = true;
                }
                else
                {
                    throw new Exception("预收货失败!没有找到该零件或数据错误!");
                }


                //修改库存
                string INV_ID = string.Empty;  //记录 INV_DETAIL_ID(INPUTAGE)

                SqlParamSet Parm = new SqlParamSet();
                Parm.AddParam("ITEM_ID", ITEM_ID);
                Parm.AddParam("LOT", LotDate);
                Parm.AddParam("LOC_ID", LocID);
                DataTable IsNanItem = VWmsInvUid.QueryDataTable(sqlMapper, "SelectIsItemById", Parm.GetParams());
                if (IsNanItem.Rows.Count == 1)
                {
                    INV_ID = IsNanItem.Rows[0]["INV_ID"].ToString();
                    //已存在此批次此库位零件,直接改数量   RV+
                    VWmsInvDetail UpDetail = new VWmsInvDetail();
                    UpDetail.ID = double.Parse(IsNanItem.Rows[0]["D_ID"].ToString());
                    UpDetail.QTY = float.Parse(IsNanItem.Rows[0]["QTY"].ToString()) + InCount;
                    if (UpDetail.Update(sqlMapper, "UpdateSection") > 0)
                    {
                        flag = true;
                    }
                    else
                    {
                        throw new Exception("预收货失败!修改已有库位库存数量失败!");
                    }

                    //更新detail明细表中de RV_qty 


                    //预收货的明细
                    //VWmsRcvDocAct Ract = new VWmsRcvDocAct();
                    VWmsRcvDocRv rv = new VWmsRcvDocRv();
                    rv.DOC_DETAIL_ID = Detail.ID;
                    rv.UID_ID = double.Parse(IsNanItem.Rows[0]["U_ID"].ToString());//UpDetail.UID_ID;
                    rv.QTY_RECEIVED = InCount;
                    rv.QTY_DAMAGED = 0;
                    rv.LP_ID = double.Parse(IsNanItem.Rows[0]["MU_ID"].ToString());
                    rv.LOC_ID = LocID;
                    rv.USER_ID = VPhrSecUsr.QueryDataTable(sqlMapper, "SelectById", User_ID).Rows[0]["LOGIN_NAME"].ToString();
                    rv.CREATED_TIME = DBDateTimeGenerator.GetDBDateTime(sqlMapper);
                    rv.IS_DISABLED = 0;
                    rv.NORMAL_QTY = 0;
                    rv.STATUS = "CL";
                    rv.IS_PRINT = 0;
                    rv.Save(sqlMapper);

                    //写仓库日志记录
                    VWmsInvTransaction Tran = new VWmsInvTransaction();
                    Tran.TRANSACTION_CODE = "com.vtradex.wms.inbound.Receiving";
                    Tran.WHSE_ID = WhseID;
                    Tran.LOC_ID = LocID;
                    Tran.T_LOC_ID = LocID;
                    Tran.COMPANY_ID = 1;
                    Tran.ITEM_ID = double.Parse(ITEM_ID);
                    Tran.LOT = LotDate;
                    Tran.F_QTY = float.Parse(IsNanItem.Rows[0]["QTY"].ToString());
                    Tran.T_QTY = float.Parse(IsNanItem.Rows[0]["QTY"].ToString()) + InCount;
                    Tran.F_MU_ID = double.Parse(IsNanItem.Rows[0]["MU_ID"].ToString()); ;
                    Tran.T_MU_ID = double.Parse(IsNanItem.Rows[0]["MU_ID"].ToString());
                    Tran.F_STATUS = "V";
                    Tran.T_STATUS = "V";
                    Tran.F_ITEM_STATUS = "N";
                    Tran.T_ITEM_STATUS = "N";
                    Tran.DESCRIPTION = "10";
                    Tran.USER_ID = VPhrSecUsr.QueryDataTable(sqlMapper, "SelectById", User_ID).Rows[0]["LOGIN_NAME"].ToString();
                    Tran.CREATED_TIME = DBDateTimeGenerator.GetDBDateTime(sqlMapper);
                    Tran.F_GOODSTYPE = "P";
                    Tran.T_GOODSTYPE = "P";
                    Tran.Save(sqlMapper);
                }
                else
                {
                    Parm = new SqlParamSet();
                    Parm.AddParam("ITEM_ID", ITEM_ID);
                    Parm.AddParam("LOT", LotDate);
                    Parm.AddParam("LOC_ID", LocID);
                    IsNanItem.Clear();
                    IsNanItem = VWmsInvUid.QueryDataTable(sqlMapper, "SelectIsItemById", Parm.GetParams());
                    #region
                    if (IsNanItem.Rows.Count > 1)
                    {
                        //有批次，没库位(新建库位关系,在新建库位下加零件)
                        VWmsInvMu Mu = new VWmsInvMu();
                        Mu.LP = "S" + ITEM_ID + SUPPLIER_ID.ToString();
                        Mu.WHSE_ID = WhseID;
                        Mu.CREATED_TIME = DBDateTimeGenerator.GetDBDateTime(sqlMapper);
                        Mu.LAST_MODIFIED = DBDateTimeGenerator.GetDBDateTime(sqlMapper);
                        Mu.COMPANY_ID = 0;
                        Mu.WIDTH = 0;
                        Mu.HEIGHT = 0;
                        Mu.LENGTH = 0;
                        Mu.PACK_CODE = "";
                        Mu.IS_DISABLED = 0;
                        Mu.PACKAGE_TYPE = "";
                        Mu.ITEM_ID = 0;
                        Mu.Save(sqlMapper);//新建可移动单元

                        VWmsInvDetail Sda = new VWmsInvDetail();
                        Sda.LOC_ID = LocID;
                        Sda.MU_ID = Mu.ID;
                        Sda.UID_ID = double.Parse(IsNanItem.Rows[0]["U_ID"].ToString());
                        Sda.STATUS = "V";
                        Sda.ITEM_STATUS = "N";
                        Sda.QTY = InCount;
                        Sda.VERSION_TRANSACTION = 0;
                        Sda.PLAN_PICK_QTY = 0;
                        Sda.Save(sqlMapper);//新建零件    
                        //Sda.ID
                        INV_ID = Sda.ID.ToString();

                        //VWmsRcvDocAct Ract = new VWmsRcvDocAct();
                        VWmsRcvDocRv Ract = new VWmsRcvDocRv();
                        Ract.DOC_DETAIL_ID = Detail.ID;
                        Ract.UID_ID = Sda.UID_ID;
                        Ract.QTY_RECEIVED = InCount;
                        Ract.QTY_DAMAGED = 0;
                        Ract.LP_ID = Mu.ID;
                        Ract.LOC_ID = LocID;
                        Ract.USER_ID = VPhrSecUsr.QueryDataTable(sqlMapper, "SelectById", User_ID).Rows[0]["LOGIN_NAME"].ToString();
                        Ract.CREATED_TIME = DBDateTimeGenerator.GetDBDateTime(sqlMapper);
                        Ract.IS_DISABLED = 0;
                        Ract.NORMAL_QTY = 0;
                        Ract.STATUS = "CL";
                        Ract.Save(sqlMapper);


                        VWmsInvTransaction Tran = new VWmsInvTransaction();
                        Tran.TRANSACTION_CODE = "com.vtradex.wms.inbound.Receiving";
                        Tran.WHSE_ID = WhseID;
                        Tran.LOC_ID = LocID;
                        Tran.T_LOC_ID = LocID;
                        Tran.COMPANY_ID = 1;
                        Tran.ITEM_ID = double.Parse(ITEM_ID);
                        Tran.LOT = LotDate;
                        Tran.F_QTY = 0;
                        Tran.T_QTY = InCount;
                        Tran.F_MU_ID = Mu.ID; ;
                        Tran.T_MU_ID = Mu.ID;
                        Tran.F_STATUS = "V";
                        Tran.T_STATUS = "V";
                        Tran.F_ITEM_STATUS = "N";
                        Tran.T_ITEM_STATUS = "N";
                        Tran.DESCRIPTION = "10";
                        Tran.USER_ID = VPhrSecUsr.QueryDataTable(sqlMapper, "SelectById", User_ID).Rows[0]["LOGIN_NAME"].ToString();
                        Tran.CREATED_TIME = DBDateTimeGenerator.GetDBDateTime(sqlMapper);
                        Tran.F_GOODSTYPE = "P";
                        Tran.T_GOODSTYPE = "P";
                        Tran.Save(sqlMapper);
                    }
                    else//没批次
                    {
                        //新建批次
                        //新建可移动单元
                        //新建商品细分及明细

                        VWmsInvUid Uid = new VWmsInvUid();
                        Uid.WHSE_ID = WhseID;
                        Uid.ITEM_ID = double.Parse(ITEM_ID);
                        Uid.LOT = LotDate;
                        Uid.XDATE = null;
                        Uid.SERIAL = "S" + ITEM_ID + SUPPLIER_ID.ToString();
                        Uid.EXTEND_COLUMN_0 = "";
                        Uid.EXTEND_COLUMN_1 = "";
                        Uid.EXTEND_COLUMN_2 = "";
                        Uid.EXTEND_COLUMN_3 = "";
                        Uid.EXTEND_COLUMN_4 = "";
                        Uid.EXTEND_DATE_0 = DBDateTimeGenerator.GetDBDateTime(sqlMapper);
                        Uid.EXTEND_DATE_1 = DBDateTimeGenerator.GetDBDateTime(sqlMapper);
                        Uid.GOODSTYPE = "P";
                        Uid.TRACKNO = "000000";
                        Uid.SUPPLIER_ID = SUPPLIER_ID;
                        Uid.VERSION = "";
                        Uid.JISHOU = 0;
                        Uid.Save(sqlMapper);//新建批次

                        VWmsInvMu Mu = new VWmsInvMu();
                        Mu.LP = "S" + ITEM_ID + SUPPLIER_ID.ToString();
                        Mu.WHSE_ID = WhseID;
                        Mu.CREATED_TIME = DBDateTimeGenerator.GetDBDateTime(sqlMapper);
                        Mu.LAST_MODIFIED = DBDateTimeGenerator.GetDBDateTime(sqlMapper);
                        Mu.COMPANY_ID = 0;
                        Mu.WIDTH = 0;
                        Mu.HEIGHT = 0;
                        Mu.LENGTH = 0;
                        Mu.PACK_CODE = "";
                        Mu.IS_DISABLED = 0;
                        Mu.PACKAGE_TYPE = "";
                        Mu.ITEM_ID = 0;
                        Mu.Save(sqlMapper);//新建可移动单元                        
                        VWmsInvDetail Sda = new VWmsInvDetail();
                        Sda.LOC_ID = LocID;
                        Sda.MU_ID = Mu.ID;
                        Sda.UID_ID = Uid.ID;
                        Sda.STATUS = "V";
                        Sda.ITEM_STATUS = "N";
                        Sda.QTY = InCount;
                        Sda.VERSION_TRANSACTION = 0;
                        Sda.PLAN_PICK_QTY = 0;
                        Sda.Save(sqlMapper);//新建零件
                        INV_ID = Sda.ID.ToString();

                        // VWmsRcvDocAct Ract = new VWmsRcvDocAct();
                        VWmsRcvDocRv Ract = new VWmsRcvDocRv();
                        Ract.DOC_DETAIL_ID = Detail.ID;
                        Ract.UID_ID = Sda.UID_ID;
                        Ract.QTY_RECEIVED = InCount;
                        Ract.QTY_DAMAGED = 0;
                        Ract.LP_ID = Mu.ID;
                        Ract.LOC_ID = LocID;
                        Ract.USER_ID = VPhrSecUsr.QueryDataTable(sqlMapper, "SelectById", User_ID).Rows[0]["LOGIN_NAME"].ToString();
                        Ract.CREATED_TIME = DBDateTimeGenerator.GetDBDateTime(sqlMapper);
                        Ract.IS_DISABLED = 0;
                        Ract.NORMAL_QTY = 0;
                        Ract.STATUS = "CL";
                        Ract.Save(sqlMapper);

                        VWmsInvTransaction Tran = new VWmsInvTransaction();
                        Tran.TRANSACTION_CODE = "com.vtradex.wms.inbound.Receiving";
                        Tran.WHSE_ID = WhseID;
                        Tran.LOC_ID = LocID;
                        Tran.T_LOC_ID = LocID;
                        Tran.COMPANY_ID = 1;
                        Tran.ITEM_ID = double.Parse(ITEM_ID);
                        Tran.LOT = LotDate;
                        Tran.F_QTY = 0;
                        Tran.T_QTY = InCount;
                        Tran.F_MU_ID = Mu.ID; ;
                        Tran.T_MU_ID = Mu.ID;
                        Tran.F_STATUS = "V";
                        Tran.T_STATUS = "V";
                        Tran.F_ITEM_STATUS = "N";
                        Tran.T_ITEM_STATUS = "N";
                        Tran.DESCRIPTION = "10";
                        Tran.USER_ID = VPhrSecUsr.QueryDataTable(sqlMapper, "SelectById", User_ID).Rows[0]["LOGIN_NAME"].ToString();
                        Tran.CREATED_TIME = DBDateTimeGenerator.GetDBDateTime(sqlMapper);
                        Tran.F_GOODSTYPE = "P";
                        Tran.T_GOODSTYPE = "P";
                        Tran.Save(sqlMapper);
                    }
                    #endregion
                }

                SqlParamSet parms = new SqlParamSet();
                parms.AddParam("RID", RID);
                OutMsg = "Empty";



                sqlMapper.CommitTransaction();
                return flag;
            }
            catch (Exception ex)
            {
                sqlMapper.RollBackTransaction();
                throw ex;
            }
        }


        //保存包装
        /// <summary>
        /// 保存包装
        /// </summary>
        /// <param name="ID">包装子表ID</param>
        /// <param name="ACTUAL_QTY">收货数量</param>
        /// <param name="EXPECTED_QTY">预计收货数量</param>
        /// <param name="LocID">收货状态Status</param>
        /// <param name="WhseID">仓库ID</param>
        /// <param name="LotDate">入库时间</param>
        ///  <param name="UserId">用户ID（关联仓库）</param>
        /// <returns></returns>
        /// 
        public static bool SaveAllReceivingPQ(string ID, string ITEM_ID, float InCount, float ACTUAL_QTY, float EXPECTED_QTY,
            string _LocID, double WhseID, string LotDate, bool ISLOC, double SUPPLIER_ID, double User_ID, string RID, out string OutMsg)
        {
            IBatisNet.DataMapper.ISqlMapper sqlMapper = Sql_Mapper.Instance();

            bool flag;
            double LocID;
            string DS;
            DataTable deadt = new DataTable();
            string user_id = VPhrSecUsr.QueryDataTable("SelectById", User_ID).Rows[0]["LOGIN_NAME"].ToString();
            try
            {

                #region 库位
                DataTable CheckLoc = VWmsBaseLocation.QueryDataTable("SelectCheckLocById", _LocID);
                if (CheckLoc.Rows.Count < 1)
                {
                    throw new Exception("该库位不存在!");
                }
                LocID = double.Parse(CheckLoc.Rows[0]["LOC_ID"].ToString());

                if (ISLOC)
                {
                    //检查库位是否可用                    

                    if ((CheckLoc.Rows[0]["ITEM_ID"] != DBNull.Value || CheckLoc.Rows[0]["ITEM_ID"].ToString() != string.Empty)
                        && !CheckLoc.Rows[0]["ITEM_ID"].ToString().Equals(ITEM_ID))
                    {
                        throw new Exception("该库位是其他零件的主库位!");
                    }
                }


                //查询是否有批次
                SqlParamSet Parm = new SqlParamSet();
                Parm.AddParam("ITEM_ID", ITEM_ID);
                Parm.AddParam("LOT", LotDate);
                Parm.AddParam("LOC_ID", LocID);
                Parm.AddParam("WHSE_ID", WhseID);
                DataTable IsNanItem = VWmsInvUid.QueryDataTable("SelectIsItemById", Parm.GetParams());

                //根据ID获取零件明细（上架数量) SelectById
                SqlParamSet dss = new SqlParamSet();
                dss.AddParam("ID", ID);
                // DataTable detaildt = VWmsRcvDocDetail.QueryDataTable(sqlMapper, "SelectAPSumById", dss.GetParams()); 
                DataTable detaildt = VWmsRcvDocDetail.QueryDataTable(sqlMapper, "SelectByParam", dss.GetParams());

                #endregion






                sqlMapper.BeginTransaction();
                VWmsRcvDocDetail Detail = new VWmsRcvDocDetail();
                Detail.ID = double.Parse(ID);

                Detail.PQ_QTY = ACTUAL_QTY;

                float APsum = float.Parse(detaildt.Rows[0]["ACTUAL_QTY"].ToString());
                //float PQsum = 0;
                //if (detaildt.Rows[0]["PQ_QTY"] != null)
                //{
                //    if (detaildt.Rows[0]["PQ_QTY"].ToString() != string.Empty)
                //    {
                //        PQsum = float.Parse(detaildt.Rows[0]["PQ_QTY"].ToString());
                //    }
                //}
                //判断EXTEND_COLUMN_2状态 

                Detail.LAST_MODIFIED = DBDateTimeGenerator.GetDBDateTime(sqlMapper);//修改收货状态
                Detail.RECEIVEDATE = Detail.LAST_MODIFIED;
                LotDate = Detail.LAST_MODIFIED.Value.ToString("yyyy-MM");

                float expectedQty = float.Parse(detaildt.Rows[0]["EXPECTED_QTY"].ToString());
                string EXTEND_COLUMN_2 = detaildt.Rows[0]["EXTEND_COLUMN_2"].ToString();
                if (expectedQty == ACTUAL_QTY)
                {
                    if (EXTEND_COLUMN_2 != null && EXTEND_COLUMN_2 == "OP")
                    {
                        Detail.EXTEND_COLUMN_2 = "PQ";
                    }
                    else
                        Detail.EXTEND_COLUMN_2 = EXTEND_COLUMN_2;
                }
                DS = Detail.EXTEND_COLUMN_2;
                if (Detail.Update(sqlMapper, "UpdateSection") > 0)
                {
                    flag = true;
                }
                else
                {
                    throw new Exception("包装失败!没有找到该零件或数据错误!");
                }
                //修改库存
                string INV_ID = string.Empty;  //记录 INV_DETAIL_ID(INPUTAGE)


                if (IsNanItem.Rows.Count == 1)
                {
                    INV_ID = IsNanItem.Rows[0]["INV_ID"].ToString();
                    //已存在此批次此库位零件,直接改数量 PQ+
                    VWmsInvDetail UpDetail = new VWmsInvDetail();
                    UpDetail.ID = double.Parse(IsNanItem.Rows[0]["D_ID"].ToString());
                    UpDetail.QTY = float.Parse(IsNanItem.Rows[0]["QTY"].ToString()) + InCount;
                    if (UpDetail.Update(sqlMapper, "UpdateSection") > 0)
                    {
                        flag = true;
                    }
                    else
                    {
                        throw new Exception("包装失败!修改已有库位库存数量失败!");
                    }
                    //同时更改PV-
                    // flag = UpdateCountRVMinus(sqlMapper, InCount, double.Parse(ID));

                    //包装的明细
                    //VWmsRcvDocAct Ract = new VWmsRcvDocAct();
                    VWmsRcvDocPQ rv = new VWmsRcvDocPQ();
                    rv.DOC_DETAIL_ID = Detail.ID;
                    rv.UID_ID = double.Parse(IsNanItem.Rows[0]["U_ID"].ToString());//UpDetail.UID_ID;
                    rv.QTY_RECEIVED = InCount;
                    rv.QTY_DAMAGED = 0;
                    rv.LP_ID = double.Parse(IsNanItem.Rows[0]["MU_ID"].ToString());
                    rv.LOC_ID = LocID;
                    rv.USER_ID = User_ID.ToString();
                    rv.CREATED_TIME = DBDateTimeGenerator.GetDBDateTime(sqlMapper);
                    rv.IS_DISABLED = 0;
                    rv.NORMAL_QTY = 0;
                    rv.STATUS = "CL";
                    rv.IS_PRINT = 0;
                    rv.Save(sqlMapper);

                    //写仓库日志记录
                    VWmsInvTransaction Tran = new VWmsInvTransaction();
                    Tran.TRANSACTION_CODE = "com.vtradex.wms.inbound.Receiving";
                    Tran.WHSE_ID = WhseID;
                    Tran.LOC_ID = LocID;
                    Tran.T_LOC_ID = LocID;
                    Tran.COMPANY_ID = 1;
                    Tran.ITEM_ID = double.Parse(ITEM_ID);
                    Tran.LOT = LotDate;
                    Tran.F_QTY = float.Parse(IsNanItem.Rows[0]["QTY"].ToString());
                    Tran.T_QTY = float.Parse(IsNanItem.Rows[0]["QTY"].ToString()) + InCount;
                    Tran.F_MU_ID = double.Parse(IsNanItem.Rows[0]["MU_ID"].ToString()); ;
                    Tran.T_MU_ID = double.Parse(IsNanItem.Rows[0]["MU_ID"].ToString());
                    Tran.F_STATUS = "V";
                    Tran.T_STATUS = "V";
                    Tran.F_ITEM_STATUS = "N";
                    Tran.T_ITEM_STATUS = "N";
                    Tran.DESCRIPTION = "10";
                    //Tran.USER_ID = VPhrSecUsr.QueryDataTable(sqlMapper, "SelectById", User_ID).Rows[0]["LOGIN_NAME"].ToString();
                    Tran.USER_ID = user_id;
                    Tran.CREATED_TIME = DBDateTimeGenerator.GetDBDateTime(sqlMapper);
                    Tran.F_GOODSTYPE = "P";
                    Tran.T_GOODSTYPE = "P";
                    Tran.Save(sqlMapper);
                }
                else
                {
                    Parm = new SqlParamSet();
                    Parm.AddParam("ITEM_ID", ITEM_ID);
                    Parm.AddParam("LOT", LotDate);
                    Parm.AddParam("LOC_ID", LocID);
                    IsNanItem.Clear();
                    IsNanItem = VWmsInvUid.QueryDataTable(sqlMapper, "SelectIsItemById", Parm.GetParams());
                    #region
                    if (IsNanItem.Rows.Count > 0)
                    {
                        //有批次，没库位(新建库位关系,在新建库位下加零件)
                        VWmsInvMu Mu = new VWmsInvMu();
                        Mu.LP = "S" + ITEM_ID + SUPPLIER_ID.ToString();
                        Mu.WHSE_ID = WhseID;
                        Mu.CREATED_TIME = DBDateTimeGenerator.GetDBDateTime(sqlMapper);
                        Mu.LAST_MODIFIED = DBDateTimeGenerator.GetDBDateTime(sqlMapper);
                        Mu.COMPANY_ID = 0;
                        Mu.WIDTH = 0;
                        Mu.HEIGHT = 0;
                        Mu.LENGTH = 0;
                        Mu.PACK_CODE = "";
                        Mu.IS_DISABLED = 0;
                        Mu.PACKAGE_TYPE = "";
                        Mu.ITEM_ID = 0;
                        Mu.Save(sqlMapper);//新建可移动单元

                        VWmsInvDetail Sda = new VWmsInvDetail();
                        Sda.LOC_ID = LocID;
                        Sda.MU_ID = Mu.ID;
                        Sda.UID_ID = double.Parse(IsNanItem.Rows[0]["U_ID"].ToString());
                        Sda.STATUS = "V";
                        Sda.ITEM_STATUS = "N";
                        Sda.QTY = InCount;
                        Sda.VERSION_TRANSACTION = 0;
                        Sda.PLAN_PICK_QTY = 0;
                        Sda.Save(sqlMapper);//新建零件    
                        //Sda.ID
                        INV_ID = Sda.ID.ToString();

                        //VWmsRcvDocAct Ract = new VWmsRcvDocAct();
                        VWmsRcvDocPQ Ract = new VWmsRcvDocPQ();
                        Ract.DOC_DETAIL_ID = Detail.ID;
                        Ract.UID_ID = Sda.UID_ID;
                        Ract.QTY_RECEIVED = InCount;
                        Ract.QTY_DAMAGED = 0;
                        Ract.LP_ID = Mu.ID;
                        Ract.LOC_ID = LocID;
                        Ract.USER_ID = User_ID.ToString();
                        Ract.CREATED_TIME = DBDateTimeGenerator.GetDBDateTime(sqlMapper);
                        Ract.IS_DISABLED = 0;
                        Ract.NORMAL_QTY = 0;
                        Ract.STATUS = "CL";
                        Ract.Save(sqlMapper);


                        VWmsInvTransaction Tran = new VWmsInvTransaction();
                        Tran.TRANSACTION_CODE = "com.vtradex.wms.inbound.Receiving";
                        Tran.WHSE_ID = WhseID;
                        Tran.LOC_ID = LocID;
                        Tran.T_LOC_ID = LocID;
                        Tran.COMPANY_ID = 1;
                        Tran.ITEM_ID = double.Parse(ITEM_ID);
                        Tran.LOT = LotDate;
                        Tran.F_QTY = 0;
                        Tran.T_QTY = InCount;
                        Tran.F_MU_ID = Mu.ID; ;
                        Tran.T_MU_ID = Mu.ID;
                        Tran.F_STATUS = "V";
                        Tran.T_STATUS = "V";
                        Tran.F_ITEM_STATUS = "N";
                        Tran.T_ITEM_STATUS = "N";
                        Tran.DESCRIPTION = "10";
                        //Tran.USER_ID = VPhrSecUsr.QueryDataTable(sqlMapper, "SelectById", User_ID).Rows[0]["LOGIN_NAME"].ToString();
                        Tran.USER_ID = user_id;
                        Tran.CREATED_TIME = DBDateTimeGenerator.GetDBDateTime(sqlMapper);
                        Tran.F_GOODSTYPE = "P";
                        Tran.T_GOODSTYPE = "P";
                        Tran.Save(sqlMapper);
                    }
                    else//没批次
                    {
                        //新建批次
                        //新建可移动单元
                        //新建商品细分及明细

                        VWmsInvUid Uid = new VWmsInvUid();
                        Uid.WHSE_ID = WhseID;
                        Uid.ITEM_ID = double.Parse(ITEM_ID);
                        Uid.LOT = LotDate;
                        Uid.XDATE = null;
                        Uid.SERIAL = "S" + ITEM_ID + SUPPLIER_ID.ToString();
                        Uid.EXTEND_COLUMN_0 = "";
                        Uid.EXTEND_COLUMN_1 = "";
                        Uid.EXTEND_COLUMN_2 = "";
                        Uid.EXTEND_COLUMN_3 = "";
                        Uid.EXTEND_COLUMN_4 = "";
                        Uid.EXTEND_DATE_0 = DBDateTimeGenerator.GetDBDateTime(sqlMapper);
                        Uid.EXTEND_DATE_1 = DBDateTimeGenerator.GetDBDateTime(sqlMapper);
                        Uid.GOODSTYPE = "P";
                        Uid.TRACKNO = "000000";
                        Uid.SUPPLIER_ID = SUPPLIER_ID;
                        Uid.VERSION = "";
                        Uid.JISHOU = 0;
                        Uid.Save(sqlMapper);//新建批次

                        VWmsInvMu Mu = new VWmsInvMu();
                        Mu.LP = "S" + ITEM_ID + SUPPLIER_ID.ToString();
                        Mu.WHSE_ID = WhseID;
                        Mu.CREATED_TIME = DBDateTimeGenerator.GetDBDateTime(sqlMapper);
                        Mu.LAST_MODIFIED = DBDateTimeGenerator.GetDBDateTime(sqlMapper);
                        Mu.COMPANY_ID = 0;
                        Mu.WIDTH = 0;
                        Mu.HEIGHT = 0;
                        Mu.LENGTH = 0;
                        Mu.PACK_CODE = "";
                        Mu.IS_DISABLED = 0;
                        Mu.PACKAGE_TYPE = "";
                        Mu.ITEM_ID = 0;
                        Mu.Save(sqlMapper);//新建可移动单元                        
                        VWmsInvDetail Sda = new VWmsInvDetail();
                        Sda.LOC_ID = LocID;
                        Sda.MU_ID = Mu.ID;
                        Sda.UID_ID = Uid.ID;
                        Sda.STATUS = "V";
                        Sda.ITEM_STATUS = "N";
                        Sda.QTY = InCount;
                        Sda.VERSION_TRANSACTION = 0;
                        Sda.PLAN_PICK_QTY = 0;
                        Sda.Save(sqlMapper);//新建零件
                        INV_ID = Sda.ID.ToString();

                        // VWmsRcvDocAct Ract = new VWmsRcvDocAct();
                        VWmsRcvDocPQ Ract = new VWmsRcvDocPQ();
                        Ract.DOC_DETAIL_ID = Detail.ID;
                        Ract.UID_ID = Sda.UID_ID;
                        Ract.QTY_RECEIVED = InCount;
                        Ract.QTY_DAMAGED = 0;
                        Ract.LP_ID = Mu.ID;
                        Ract.LOC_ID = LocID;
                        Ract.USER_ID = User_ID.ToString();
                        Ract.CREATED_TIME = DBDateTimeGenerator.GetDBDateTime(sqlMapper);
                        Ract.IS_DISABLED = 0;
                        Ract.NORMAL_QTY = 0;
                        Ract.STATUS = "CL";
                        Ract.Save(sqlMapper);

                        VWmsInvTransaction Tran = new VWmsInvTransaction();
                        Tran.TRANSACTION_CODE = "com.vtradex.wms.inbound.Receiving";
                        Tran.WHSE_ID = WhseID;
                        Tran.LOC_ID = LocID;
                        Tran.T_LOC_ID = LocID;
                        Tran.COMPANY_ID = 1;
                        Tran.ITEM_ID = double.Parse(ITEM_ID);
                        Tran.LOT = LotDate;
                        Tran.F_QTY = 0;
                        Tran.T_QTY = InCount;
                        Tran.F_MU_ID = Mu.ID;
                        Tran.T_MU_ID = Mu.ID;
                        Tran.F_STATUS = "V";
                        Tran.T_STATUS = "V";
                        Tran.F_ITEM_STATUS = "N";
                        Tran.T_ITEM_STATUS = "N";
                        Tran.DESCRIPTION = "10";
                        //Tran.USER_ID = VPhrSecUsr.QueryDataTable(sqlMapper, "SelectById", User_ID).Rows[0]["LOGIN_NAME"].ToString();
                        Tran.USER_ID = user_id;
                        Tran.CREATED_TIME = DBDateTimeGenerator.GetDBDateTime(sqlMapper);
                        Tran.F_GOODSTYPE = "P";
                        Tran.T_GOODSTYPE = "P";
                        Tran.Save(sqlMapper);
                    }
                    #endregion
                }


                SqlParamSet parms = new SqlParamSet();
                parms.AddParam("RID", RID);
                parms.AddParam("ITEM_ID", ITEM_ID);
                OutMsg = "Empty";
                if (int.Parse(VWmsRcvDoc.QueryDataTable(sqlMapper, "SelectByPQCount", parms.GetParams()).Rows[0][0].ToString()) == 0)
                {
                    if (DS == "AP" || DS == "PQ")
                    {
                        if (SelectPartSum(sqlMapper, ID).Rows.Count == 0)
                        {
                            OutMsg = "OK";
                        }
                    }
                }
                sqlMapper.CommitTransaction();
                return flag;
            }
            catch (Exception ex)
            {
                sqlMapper.RollBackTransaction();
                throw ex;
            }
        }


        /// <summary>
        /// 查询订单信息
        /// </summary>
        public static DataTable SelectReceivingStatus(string Number_ID)
        {
            DataTable dt = new DataTable();
            SqlParamSet ss = new SqlParamSet();
            ss.AddParam("Number_ID", Number_ID);
            dt = VWmsRcvDocRv.QueryDataTable("SelectReceivingStatus", ss.GetParams());
            return dt;
        }

        /// <summary>
        /// 查询重复零件的个数
        /// </summary>
        public static DataTable SelectPartCount(IBatisNet.DataMapper.ISqlMapper sql, string ID)
        {
            DataTable dt = new DataTable();
            SqlParamSet ss = new SqlParamSet();
            ss.AddParam("ID", ID);
            dt = VWmsRcvDocRv.QueryDataTable(sql, "SelectPartCount", ss.GetParams());
            return dt;
        }
        /// <summary>
        /// 查询重复零件是否已经包装完成
        /// </summary>
        public static DataTable SelectPartSum(IBatisNet.DataMapper.ISqlMapper sql, string ID)
        {
            DataTable dt = new DataTable();
            SqlParamSet ss = new SqlParamSet();
            ss.AddParam("ID", ID);
            dt = VWmsRcvDocRv.QueryDataTable(sql, "SelectPartSum", ss.GetParams());
            return dt;
        }



        /// <summary>
        ///减少预收货库存
        /// </summary>
        public static bool UpdateCountRVMinus(IBatisNet.DataMapper.ISqlMapper sqlMapper, float Count, double ID)
        {
            bool flag = false;
            VWmsInvDetail UpDetailRV = new VWmsInvDetail();
            UpDetailRV.QTY = Count;
            UpDetailRV.ID = ID;
            if (UpDetailRV.Update(sqlMapper, "UpdateCountRVMinus") > 0)
            {
                flag = true;
            }
            else
            {
                throw new Exception("修改预收货库位库存数量失败!");
            }
            return flag;
        }
        /// <summary>
        ///减少包装库存
        /// </summary>
        public static bool UpdateCountPQMinus(IBatisNet.DataMapper.ISqlMapper sqlMapper, float Count, double MU_ID, double LOC_ID, double UID_ID)
        {
            bool flag = false;
            VWmsInvDetail UpDetailRV = new VWmsInvDetail();
            UpDetailRV.QTY = Count;
            UpDetailRV.MU_ID = MU_ID;
            UpDetailRV.LOC_ID = LOC_ID;
            UpDetailRV.UID_ID = UID_ID;
            if (UpDetailRV.Update(sqlMapper, "UpdateCountPQMinusByLOCUID") > 0)
            {
                flag = true;
            }
            else
            {
                throw new Exception("修改包装库位库存数量失败!");
            }
            return flag;

        }

        /// <summary>
        ///包装完成后更改包装状态
        /// </summary>
        public static bool UpdatePQStatusByClose(string Status, string ItemS, string DetailID, string DOCID, int count)
        {
            bool flag = false;
            IBatisNet.DataMapper.ISqlMapper sqlMapper = Sql_Mapper.Instance();
            sqlMapper.BeginTransaction();
            try
            {
                //Detail
                VWmsRcvDocDetail Detail = new VWmsRcvDocDetail();
                Detail.ID = double.Parse(DetailID);
                Detail.EXTEND_COLUMN_2 = Status; //包装时确认关闭后才会包装
                if (Detail.Update(sqlMapper, "UpdateStatus") > 0)
                {
                    flag = true;
                }
                else
                {
                    throw new Exception("包装关闭失败!");
                }

                //DOC
                if (ItemS != "NOT")
                {
                    if (SaveOrderMain(DOCID, sqlMapper))
                    {
                        flag = true;
                    }
                    else
                    {
                        throw new Exception("更新订单状态失败!");
                    }
                }

                sqlMapper.CommitTransaction();
                return flag;
            }
            catch (Exception ex)
            {
                sqlMapper.RollBackTransaction();
                throw ex;
            }

        }

        /// <summary>
        /// 查询订单零件信息
        /// </summary>
        /// <returns></returns>
        public static DataTable SelectOrderPartInfo(int UserID, string Item_Code)
        {

            VWmsRcvDocRv vwrd = new VWmsRcvDocRv();
            SqlParamSet ss = new SqlParamSet();
            ss.AddParam("ID", UserID);
            if (Item_Code != string.Empty)
            {
                ss.AddParam("ITEM_CODE", Item_Code);
            }
            DataTable dt = VWmsRcvDocRv.QueryDataTable("SelectOrderPartInfo", ss.GetParams());
            return dt;
        }


        /// <summary>
        /// 根据订单打包图片并下载
        /// </summary>
        /// <param name="packageNo"></param>
        /// <returns></returns>
        public static byte[] GetFile(string packageNo)
        {
            packageNo = "20140903";
            List<string> filelist = new List<string>();
            string file1 = @"D:\workspace\LDV.Viewer\LDV.Viewer\LDV.Viewer\imags\QQ截图20140902110624.png";
            string file2 = @"D:\workspace\LDV.Viewer\LDV.Viewer\LDV.Viewer\imags\QQ截图20140902110631.png";
            string file3 = @"D:\workspace\LDV.Viewer\LDV.Viewer\LDV.Viewer\imags\QQ截图20140902110643.png";
            string file4 = @"D:\workspace\LDV.Viewer\LDV.Viewer\LDV.Viewer\imags\QQ截图20140902110649.png";
            filelist.Add(file1);
            filelist.Add(file2);
            filelist.Add(file3);
            filelist.Add(file4);

            string strpath = ConfigurationManager.AppSettings["TmpPath"].ToString();

            string zipName = strpath + "\\" + packageNo + ".zip";

            if (filelist.Count <= 0)
                return null;

            ZipHelp.Zip(filelist, zipName, "");

            FileStream fs = null;
            fs = File.Open(zipName, FileMode.Open, FileAccess.Read, FileShare.Read);
            byte[] filebytes = new byte[fs.Length];
            fs.Read(filebytes, 0, (int)fs.Length);
            fs.Close();
            fs = null;
            return filebytes;
        }




        #region 上架重新开发  hzf 2014-12-02


        public static string GetInfoByPartCodeMloc(string Item_Code, string User_ID)
        {
            string info = string.Empty;
            string locType = "";
            string IsDLoc = ConfigurationManager.AppSettings["IsDefaultLoc"].ToString();
            string DLoc = ConfigurationManager.AppSettings["DefaultLoc"].ToString();
            if (IsDLoc == "1" && DLoc.Length > 0)
            {
                info = DLoc;
            }
            else
            {


                SqlParamSet ss = new SqlParamSet();
                ss.AddParam("ITEM_CODE", Item_Code);
                ss.AddParam("ID", User_ID);
                DataTable dt = VWmsRcvDocRv.QueryDataTable("SelectOrderPartInfo", ss.GetParams());
                if (dt.Rows.Count != 0)
                {

                    info = dt.Rows[0]["LOC_CODE"].ToString();
                    locType = dt.Rows[0]["LOC_TYPE"].ToString();
                }
                else
                {
                    info = "NotFoundIItem";
                }
            }
            return info;
        }
        /// <summary>
        /// 根据零件Code获取零件是否存在 并获取零件推荐库位
        /// </summary>
        /// <param name="PartCode">零件单号</param>
        /// <returns></returns>
        public static string GetInfoByPartCode(string Item_Code, string User_ID)
        {
            string info = string.Empty;
            string locType = "";
            string IsDLoc = ConfigurationManager.AppSettings["IsDefaultLoc"].ToString();
            string DLoc = ConfigurationManager.AppSettings["DefaultLoc"].ToString();
            if (IsDLoc == "1" && DLoc.Length > 0)
            {
                info = DLoc;
            }
            else
            {


                SqlParamSet ss = new SqlParamSet();
                ss.AddParam("ITEM_CODE", Item_Code);
                ss.AddParam("ID", User_ID);
                DataTable dt = VWmsRcvDocRv.QueryDataTable("SelectOrderPartInfo", ss.GetParams());
                if (dt.Rows.Count != 0)
                {

                    info = dt.Rows[0]["LOC_CODE"].ToString();
                    locType = dt.Rows[0]["LOC_TYPE"].ToString();
                }
                else
                {
                    info = "NotFoundIItem";
                }
            }
            if (locType == "HI")
            {
                DataTable dtR = VWmsInvDetailService.QueryPartSupplierLoc(Item_Code);
                if (dtR == null || dtR.Rows.Count == 0)
                {
                    return info;
                }

                if (dtR != null && dtR.Rows.Count > 1)
                {
                    for (int i = 0; i < dtR.Rows.Count; i++)
                    {
                        if (info != dtR.Rows[i]["LOC_CODE"].ToString())
                        {
                            return dtR.Rows[i]["LOC_CODE"].ToString();
                        }
                    }
                }
                else if (dtR != null && dtR.Rows.Count == 1 && info != dtR.Rows[0]["LOC_CODE"].ToString())
                {
                    return dtR.Rows[0]["LOC_CODE"].ToString();
                }
                else
                {
                    int leftnum = 2;
                    int endnum = 4;
                    if (info.Length < 8)
                    {
                        leftnum = 1;
                        endnum = 3;
                    }
                    string loc = info.Substring(0, info.Length - leftnum);
                    string locNo = info.Substring(info.Length - 4, 2);
                    string locStartNo = info.Substring(0, endnum);

                    int Hno = Int32.Parse(locNo);
                    int i = Hno;
                    int j = Hno;
                    do
                    {
                        string leftNullLoc = locStartNo + i.ToString().PadLeft(2, '0').ToString();
                        string rightNullLoc = locStartNo + j.ToString().PadLeft(2, '0').ToString();
                        if (i == j)
                        {
                            DataTable dt = BaseLocationService.QueryDataTableByParam(leftNullLoc, double.Parse(User_ID));
                            if (dt != null && dt.Rows.Count > 0)
                            {
                                return dt.Rows[0]["LOC_CODE"].ToString();

                            }
                        }
                        else
                        {
                            if (i > 0)
                            {
                                DataTable dt = BaseLocationService.QueryDataTableByParam(leftNullLoc, double.Parse(User_ID));
                                if (dt != null && dt.Rows.Count > 0)
                                {
                                    return dt.Rows[0]["LOC_CODE"].ToString();

                                }
                            }
                            if (j < 50)
                            {
                                DataTable dt = BaseLocationService.QueryDataTableByParam(rightNullLoc, double.Parse(User_ID));
                                if (dt != null && dt.Rows.Count > 0)
                                {
                                    return dt.Rows[0]["LOC_CODE"].ToString();

                                }
                            }
                        }
                        i -= 2;
                        j += 2;
                    }
                    while (i < 1 && j > 50);
                    i = Hno;
                    j = Hno;
                    do
                    {
                        if (i == j)
                        {
                            i--;
                            j++;
                        }
                        string leftNullLoc = locStartNo + i.ToString().PadLeft(2, '0').ToString();
                        string rightNullLoc = locStartNo + j.ToString().PadLeft(2, '0').ToString();
                        if (i > 0)
                        {
                            DataTable dt = BaseLocationService.QueryDataTableByParam(leftNullLoc, double.Parse(User_ID));
                            if (dt != null && dt.Rows.Count > 0)
                            {
                                info = dt.Rows[0]["LOC_CODE"].ToString();
                                break;
                            }
                        }
                        if (j < 50)
                        {
                            DataTable dt = BaseLocationService.QueryDataTableByParam(rightNullLoc, double.Parse(User_ID));
                            if (dt != null && dt.Rows.Count > 0)
                            {
                                info = dt.Rows[0]["LOC_CODE"].ToString();
                                break;
                            }
                        }

                        i -= 2;
                        j += 2;

                    }
                    while (i < 1 && j > 50);

                }
            }
            return info;
        }

        /// <summary>
        /// 上架操作
        /// </summary>
        /// <param name="Item_Code">零件编码</param>
        /// <param name="InCount">上架数量</param>
        /// <param name="Item_Loc">上架库位</param>
        /// <param name="IsLoc">是否是默认库位</param>
        /// <returns></returns>
        public static bool SaveAddedDetail(string Item_Code, double InCount, string Item_Loc, string IsLoc, string User_ID, out string Msg)
        {
            bool flag = false;
            Msg = string.Empty;
            DataTable OrderList = LoadMainDocByStatus("AP", User_ID); //上架零件汇总表
            DataTable OrderInfoList = SelectOrderPartInfo(int.Parse(User_ID), Item_Code); // 上架零件明细表

            CheckAddedInfo(Item_Code, InCount, Item_Loc, IsLoc, OrderList);

            IBatisNet.DataMapper.ISqlMapper sqlMapper = Sql_Mapper.Instance();
            sqlMapper.BeginTransaction();

            try
            {
                AddedDetailOpre(sqlMapper, OrderList, OrderInfoList, Item_Code, int.Parse(InCount.ToString()), Item_Loc, IsLoc, User_ID);
                flag = true;
                sqlMapper.CommitTransaction();

                return flag;
            }
            catch (Exception ex)
            {
                flag = false;

                sqlMapper.RollBackTransaction();

                throw ex;
            }


            return flag;
        }

        /// <summary>
        /// 上架判断数据是否正常
        /// </summary>
        public static string CheckAddedInfo(string Item_Code, double InCount, string Item_Loc, string IsLoc, DataTable OrderList)
        {
            string Msg = string.Empty;

            #region 判断库位是否是正常库位

            DataTable Locdt = BaseLocationService.QueryByLocId(Item_Loc);
            if (Locdt.Rows.Count > 0)
            {
                if (Locdt.Rows[0]["TYPE"].ToString() != "RV")
                {
                    throw new Exception("该入库库位只能是正常库位!");
                }
                //库位存在多零件,查询当前零件是否属于该库位
                //if ((Locdt.Rows[0]["ITEM_ID"] != DBNull.Value || Locdt.Rows[0]["ITEM_ID"].ToString() != string.Empty))
                //{
                //    DataRow[] dr = Locdt.Select("item_code='" + Item_Code + "'");
                //    if (dr.Length == 0)
                //    {
                //        throw new Exception("该库位是其他零件的主库位!");
                //    }
                //}

                //if ((Locdt.Rows[0]["ITEM_ID"] != DBNull.Value || Locdt.Rows[0]["ITEM_ID"].ToString() != string.Empty)
                //       && !Locdt.Rows[0]["item_code"].ToString().Equals(Item_Code))
                //{
                // throw new Exception("该库位是其他零件的主库位!");
                //}
            }
            else
            {
                throw new Exception("该库位不存在!");
            }
            #endregion

            #region 判断上架数量是否正常
            DataRow[] tr = OrderList.Select("ITEM_CODE='" + Item_Code + "'");
            if (tr.Length == 1)
            {
                DataRow TempRow = OrderList.NewRow();
                TempRow.ItemArray = tr[0].ItemArray;
                if (int.Parse(TempRow["ACTUAL_QTY"].ToString()) + InCount > int.Parse(TempRow["PQQTY"].ToString()))
                {
                    throw new Exception("该零件上架数量大于计划数!已上架:" + TempRow["ACTUAL_QTY"].ToString() + ",计划数量:" + TempRow["PQQTY"].ToString() + "!");
                }
            }
            else
            {
                throw new Exception("该零件不存在!");
            }
            #endregion

            #region //
            #endregion

            return Msg;
        }

        /// <summary>
        /// 循环扣除上架数据
        /// </summary>
        public static string AddedDetailOpre(IBatisNet.DataMapper.ISqlMapper sqlMapper, DataTable OrderList, DataTable OrderInfoList, string Item_Code, int InCount, string Item_Loc, string IsLoc, string User_ID)
        {
            string Status = string.Empty;
            double LocID; //库位ID
            DataTable CheckLoc = VWmsBaseLocation.QueryDataTable(sqlMapper, "SelectCheckLocById", Item_Loc);
            LocID = double.Parse(CheckLoc.Rows[0]["LOC_ID"].ToString());

            for (int i = 0; i < OrderInfoList.Rows.Count; i++)
            {
                //InCount   LocID     User_ID   ISLOC
                string ID = OrderInfoList.Rows[i]["DID"].ToString();
                string ITEM_ID = OrderInfoList.Rows[i]["ITEM_ID"].ToString();
                double ACTUAL_QTY = double.Parse(OrderInfoList.Rows[i]["ACTUAL_QTY"].ToString());
                double EXPECTED_QTY = double.Parse(OrderInfoList.Rows[i]["PQQTY"].ToString());
                double WhseID = double.Parse(OrderInfoList.Rows[i]["WHSE_ID"].ToString());
                string LotDate = OrderInfoList.Rows[i]["RECEIVEDATE"].ToString();
                double SUPPLIER_ID = double.Parse(OrderInfoList.Rows[i]["supplier_ID"].ToString());
                string RID = OrderInfoList.Rows[i]["RID"].ToString();

                if (InCount != 0)
                {
                    //if (InCount < (int.Parse(OrderInfoList.Rows[i]["PQQTY"].ToString()) - int.Parse(OrderInfoList.Rows[i]["ACTUAL_QTY"].ToString())))
                    //{
                    //   Status= AddedDetailOpreItem(sqlMapper, ID, ITEM_ID, float.Parse(InCount.ToString()), float.Parse(ACTUAL_QTY.ToString()), float.Parse(EXPECTED_QTY.ToString()), LocID, WhseID, LotDate, SUPPLIER_ID, double.Parse(User_ID), RID);
                    //    InCount = 0;
                    //}
                    if (InCount <= (int.Parse(OrderInfoList.Rows[i]["PQQTY"].ToString()) - int.Parse(OrderInfoList.Rows[i]["ACTUAL_QTY"].ToString())))
                    {
                        Status = AddedDetailOpreItem(sqlMapper, ID, ITEM_ID, float.Parse(InCount.ToString()), float.Parse(ACTUAL_QTY.ToString()), float.Parse(EXPECTED_QTY.ToString()), LocID, WhseID, LotDate, SUPPLIER_ID, double.Parse(User_ID), RID);
                        InCount = 0;
                    }
                    if (InCount > (int.Parse(OrderInfoList.Rows[i]["PQQTY"].ToString()) - int.Parse(OrderInfoList.Rows[i]["ACTUAL_QTY"].ToString())))
                    {

                        Status = AddedDetailOpreItem(sqlMapper, ID, ITEM_ID, float.Parse((int.Parse(OrderInfoList.Rows[i]["PQQTY"].ToString()) - int.Parse(OrderInfoList.Rows[i]["ACTUAL_QTY"].ToString())).ToString()), float.Parse(ACTUAL_QTY.ToString()), float.Parse(EXPECTED_QTY.ToString()), LocID, WhseID, LotDate, SUPPLIER_ID, double.Parse(User_ID), RID);

                        InCount -= int.Parse(OrderInfoList.Rows[i]["PQQTY"].ToString()) - int.Parse(OrderInfoList.Rows[i]["ACTUAL_QTY"].ToString());
                    }
                }
            }


            return Status;
        }

        /// <summary>
        /// 上架数据操作方法
        /// </summary>
        /// <param name="ID">收货子表ID</param>
        /// <param name="ITEM_ID">零件ID</param>
        /// <param name="InCount">上架数量</param>
        /// <param name="ACTUAL_QTY">已上架数量</param>
        /// <param name="EXPECTED_QTY">包装数量</param>
        /// <param name="LocID">库位ID</param>
        /// <param name="WhseID">仓库ID</param>
        /// <param name="LotDate">收货时间</param>
        /// <param name="ISLOC">是否是推荐库位</param>
        /// <param name="SUPPLIER_ID">供应商ID</param>
        /// <param name="User_ID">操作用户ID</param>
        /// <param name="RID">收货主表ID</param>
        /// <param name="OutMsg"></param>
        /// <returns></returns>
        public static string AddedDetailOpreItem(IBatisNet.DataMapper.ISqlMapper sqlMapper, string ID, string ITEM_ID, float InCount, float ACTUAL_QTY, float EXPECTED_QTY,
            double LocID, double WhseID, string LotDate, double SUPPLIER_ID, double User_ID, string RID)
        {
            bool flag = false;
            string OutMsg = string.Empty;

            #region 循环扣除上架数量
            //获取当前detail的数据判断是否已经包装完成
            SqlParamSet ssdt = new SqlParamSet();
            ssdt.AddParam("ID", ID);
            DataTable detaildt = VWmsRcvDocDetail.QueryDataTable(sqlMapper, "SelectStatusById", ssdt.GetParams());

            VWmsRcvDocDetail Detail = new VWmsRcvDocDetail();
            Detail.ID = double.Parse(ID);
            Detail.ACTUAL_QTY = ACTUAL_QTY + InCount;
            //完成包装后 才能进行上架完成
            if (Detail.ACTUAL_QTY == EXPECTED_QTY)
            {
                if (detaildt != null && detaildt.Rows.Count > 0)
                {

                    if (Detail.ACTUAL_QTY == float.Parse(detaildt.Rows[0]["EXPECTED_QTY"].ToString()))
                    {
                        Detail.EXTEND_COLUMN_2 = "AP";


                        //更改时同时更改所有相同零件的状态
                        //  if (Detail.Update(sqlMapper, "UpdateStatus") > 0)
                        //更改当前零件的状态
                        if (Detail.Update(sqlMapper, "UpdateStatusByDetailID") > 0)
                        {
                            flag = true;
                        }
                        else
                        {
                            throw new Exception("包装失败!没有找到该零件或数据错误!");
                        }
                    }
                    else if (detaildt.Rows[0]["EXTEND_COLUMN_2"].ToString() == "OP" && float.Parse(detaildt.Rows[0]["EXPECTED_QTY"].ToString()) == float.Parse(detaildt.Rows[0]["PQ_QTY"].ToString()))
                    {
                        Detail.EXTEND_COLUMN_2 = "PQ";


                        //更改时同时更改所有相同零件的状态
                        //  if (Detail.Update(sqlMapper, "UpdateStatus") > 0)
                        //更改当前零件的状态
                        if (Detail.Update(sqlMapper, "UpdateStatusByDetailID") > 0)
                        {
                            flag = true;
                        }
                        else
                        {
                            throw new Exception("包装失败!没有找到该零件或数据错误!");
                        }
                    }

                }
            }

            //Detail.LAST_MODIFIED = DBDateTimeGenerator.GetDBDateTime(sqlMapper);//修改收货状态(注释by mjy 2016-05-31)
            //Detail.RECEIVEDATE = Detail.LAST_MODIFIED;//(注释by mjy 2016-05-31)
            Detail.RECEIVEDATE = DBDateTimeGenerator.GetDBDateTime(sqlMapper);//(修改by mjy 2016-05-31)

            //LotDate = Detail.LAST_MODIFIED.Value.ToString("yyyy-MM");//(注释by mjy 2016-05-31)
            LotDate = Detail.RECEIVEDATE.Value.ToString("yyyy-MM");//(修改by mjy 2016-05-31)

            if (Detail.Update(sqlMapper, "UpdateSection") > 0)
            {
                flag = true;
            }
            else
            {
                throw new Exception("收货失败!没有找到该零件或数据错误!");
            }


            #region 同时更改PQ-
            //flag = UpdateCountPQMinus(sqlMapper, InCount, double.Parse(IsNanItem.Rows[0]["MU_ID"].ToString()),
            //            double.Parse(IsNanItem.Rows[0]["LOC_ID"].ToString()), double.Parse(IsNanItem.Rows[0]["U_ID"].ToString()));
            SqlParamSet spInvDetail = new SqlParamSet();
            spInvDetail.AddParam("ID", ID);
            DataTable dtInvDetail = VWmsInvDetail.QueryDataTable(sqlMapper, "SelectByDocDetailId", spInvDetail.GetParams());

            float DetailCount = InCount;  //更新仓库剩余数量
            for (int i = 0; i < dtInvDetail.Rows.Count; i++)
            {
                if (DetailCount == 0)
                    break;
                VWmsInvDetail UpDetailRV = new VWmsInvDetail();
                if (double.Parse(dtInvDetail.Rows[i]["qty"].ToString()) >= DetailCount)
                {
                    UpDetailRV.QTY = DetailCount;
                    DetailCount = 0;
                }
                else
                {
                    UpDetailRV.QTY = float.Parse(dtInvDetail.Rows[i]["qty"].ToString());
                    DetailCount -= float.Parse(dtInvDetail.Rows[i]["qty"].ToString());
                }
                UpDetailRV.ID = double.Parse(dtInvDetail.Rows[i]["ID"].ToString());

                if (UpDetailRV.Update(sqlMapper, "UpdateCountPQone") > 0)
                {
                    flag = true;
                }
                else
                {
                    throw new Exception("修改包装库位库存数量失败!!");
                }
            }


            #endregion

            #region 修改库存
            string INV_ID = string.Empty;  //记录 INV_DETAIL_ID(INPUTAGE)

            SqlParamSet Parm = new SqlParamSet();
            Parm.AddParam("ITEM_ID", ITEM_ID);
            Parm.AddParam("LOT", LotDate);
            Parm.AddParam("LOC_ID", LocID);
            DataTable IsNanItem = VWmsInvUid.QueryDataTable(sqlMapper, "SelectIsItemById", Parm.GetParams());
            if (IsNanItem.Rows.Count == 1)
            {
                INV_ID = IsNanItem.Rows[0]["INV_ID"].ToString();
                //已存在此批次此库位零件,直接改数量
                VWmsInvDetail UpDetail = new VWmsInvDetail();
                UpDetail.ID = double.Parse(IsNanItem.Rows[0]["D_ID"].ToString());
                UpDetail.QTY = float.Parse(IsNanItem.Rows[0]["QTY"].ToString()) + InCount;
                if (UpDetail.Update(sqlMapper, "UpdateSection") > 0)
                {
                    flag = true;
                }
                else
                {
                    throw new Exception("收货失败!修改已有库位库存数量失败!");
                }

                VWmsRcvDocAct Ract = new VWmsRcvDocAct();
                Ract.DOC_DETAIL_ID = Detail.ID;
                Ract.UID_ID = double.Parse(IsNanItem.Rows[0]["U_ID"].ToString());//UpDetail.UID_ID;
                Ract.QTY_RECEIVED = InCount;
                Ract.QTY_DAMAGED = 0;
                Ract.LP_ID = double.Parse(IsNanItem.Rows[0]["MU_ID"].ToString());
                Ract.LOC_ID = LocID;
                Ract.USER_ID = VPhrSecUsr.QueryDataTable(sqlMapper, "SelectById", User_ID).Rows[0]["LOGIN_NAME"].ToString();
                Ract.CREATED_TIME = DBDateTimeGenerator.GetDBDateTime(sqlMapper);
                Ract.IS_DISABLED = 0;
                Ract.NORMAL_QTY = 0;
                Ract.STATUS = "CL";
                Ract.IS_PRINT = 0;
                Ract.Save(sqlMapper);

                //写仓库日志记录
                VWmsInvTransaction Tran = new VWmsInvTransaction();
                Tran.TRANSACTION_CODE = "com.vtradex.wms.inbound.Receiving";
                Tran.WHSE_ID = WhseID;
                Tran.LOC_ID = LocID;
                Tran.T_LOC_ID = LocID;
                Tran.COMPANY_ID = 1;
                Tran.ITEM_ID = double.Parse(ITEM_ID);
                Tran.LOT = LotDate;
                Tran.F_QTY = float.Parse(IsNanItem.Rows[0]["QTY"].ToString());
                Tran.T_QTY = float.Parse(IsNanItem.Rows[0]["QTY"].ToString()) + InCount;
                Tran.F_MU_ID = double.Parse(IsNanItem.Rows[0]["MU_ID"].ToString()); ;
                Tran.T_MU_ID = double.Parse(IsNanItem.Rows[0]["MU_ID"].ToString());
                Tran.F_STATUS = "V";
                Tran.T_STATUS = "V";
                Tran.F_ITEM_STATUS = "N";
                Tran.T_ITEM_STATUS = "N";
                Tran.DESCRIPTION = "10";
                Tran.USER_ID = VPhrSecUsr.QueryDataTable(sqlMapper, "SelectById", User_ID).Rows[0]["LOGIN_NAME"].ToString();
                Tran.CREATED_TIME = DBDateTimeGenerator.GetDBDateTime(sqlMapper);
                Tran.F_GOODSTYPE = "P";
                Tran.T_GOODSTYPE = "P";
                Tran.Save(sqlMapper);
            }
            else
            {
                Parm = new SqlParamSet();
                Parm.AddParam("ITEM_ID", ITEM_ID);
                Parm.AddParam("LOT", LotDate);
                Parm.AddParam("LOC_ID", LocID);
                IsNanItem.Clear();
                IsNanItem = VWmsInvUid.QueryDataTable(sqlMapper, "SelectIsItemById", Parm.GetParams());
                #region
                if (IsNanItem.Rows.Count > 1)
                {
                    //有批次，没库位(新建库位关系,在新建库位下加零件)
                    VWmsInvMu Mu = new VWmsInvMu();
                    Mu.LP = "S" + ITEM_ID + SUPPLIER_ID.ToString();
                    Mu.WHSE_ID = WhseID;
                    Mu.CREATED_TIME = DBDateTimeGenerator.GetDBDateTime(sqlMapper);
                    Mu.LAST_MODIFIED = DBDateTimeGenerator.GetDBDateTime(sqlMapper);
                    Mu.COMPANY_ID = 0;
                    Mu.WIDTH = 0;
                    Mu.HEIGHT = 0;
                    Mu.LENGTH = 0;
                    Mu.PACK_CODE = "";
                    Mu.IS_DISABLED = 0;
                    Mu.PACKAGE_TYPE = "";
                    Mu.ITEM_ID = 0;
                    Mu.Save(sqlMapper);//新建可移动单元

                    VWmsInvDetail Sda = new VWmsInvDetail();
                    Sda.LOC_ID = LocID;
                    Sda.MU_ID = Mu.ID;
                    Sda.UID_ID = double.Parse(IsNanItem.Rows[0]["U_ID"].ToString());
                    Sda.STATUS = "V";
                    Sda.ITEM_STATUS = "N";
                    Sda.QTY = InCount;
                    Sda.VERSION_TRANSACTION = 0;
                    Sda.PLAN_PICK_QTY = 0;
                    Sda.Save(sqlMapper);//新建零件    
                    //Sda.ID
                    INV_ID = Sda.ID.ToString();

                    VWmsRcvDocAct Ract = new VWmsRcvDocAct();
                    Ract.DOC_DETAIL_ID = Detail.ID;
                    Ract.UID_ID = Sda.UID_ID;
                    Ract.QTY_RECEIVED = InCount;
                    Ract.QTY_DAMAGED = 0;
                    Ract.LP_ID = Mu.ID;
                    Ract.LOC_ID = LocID;
                    Ract.USER_ID = VPhrSecUsr.QueryDataTable(sqlMapper, "SelectById", User_ID).Rows[0]["LOGIN_NAME"].ToString();
                    Ract.CREATED_TIME = DBDateTimeGenerator.GetDBDateTime(sqlMapper);
                    Ract.IS_DISABLED = 0;
                    Ract.NORMAL_QTY = 0;
                    Ract.STATUS = "CL";
                    Ract.Save(sqlMapper);


                    VWmsInvTransaction Tran = new VWmsInvTransaction();
                    Tran.TRANSACTION_CODE = "com.vtradex.wms.inbound.Receiving";
                    Tran.WHSE_ID = WhseID;
                    Tran.LOC_ID = LocID;
                    Tran.T_LOC_ID = LocID;
                    Tran.COMPANY_ID = 1;
                    Tran.ITEM_ID = double.Parse(ITEM_ID);
                    Tran.LOT = LotDate;
                    Tran.F_QTY = 0;
                    Tran.T_QTY = InCount;
                    Tran.F_MU_ID = Mu.ID; ;
                    Tran.T_MU_ID = Mu.ID;
                    Tran.F_STATUS = "V";
                    Tran.T_STATUS = "V";
                    Tran.F_ITEM_STATUS = "N";
                    Tran.T_ITEM_STATUS = "N";
                    Tran.DESCRIPTION = "10";
                    Tran.USER_ID = VPhrSecUsr.QueryDataTable(sqlMapper, "SelectById", User_ID).Rows[0]["LOGIN_NAME"].ToString();
                    Tran.CREATED_TIME = DBDateTimeGenerator.GetDBDateTime(sqlMapper);
                    Tran.F_GOODSTYPE = "P";
                    Tran.T_GOODSTYPE = "P";
                    Tran.Save(sqlMapper);
                }
                else//没批次
                {
                    //新建批次
                    //新建可移动单元
                    //新建商品细分及明细

                    VWmsInvUid Uid = new VWmsInvUid();
                    Uid.WHSE_ID = WhseID;
                    Uid.ITEM_ID = double.Parse(ITEM_ID);
                    Uid.LOT = LotDate;
                    Uid.XDATE = null;
                    Uid.SERIAL = "S" + ITEM_ID + SUPPLIER_ID.ToString();
                    Uid.EXTEND_COLUMN_0 = "";
                    Uid.EXTEND_COLUMN_1 = "";
                    Uid.EXTEND_COLUMN_2 = "";
                    Uid.EXTEND_COLUMN_3 = "";
                    Uid.EXTEND_COLUMN_4 = "";
                    Uid.EXTEND_DATE_0 = DBDateTimeGenerator.GetDBDateTime(sqlMapper);
                    Uid.EXTEND_DATE_1 = DBDateTimeGenerator.GetDBDateTime(sqlMapper);
                    Uid.GOODSTYPE = "P";
                    Uid.TRACKNO = "000000";
                    Uid.SUPPLIER_ID = SUPPLIER_ID;
                    Uid.VERSION = "";
                    Uid.JISHOU = 0;
                    Uid.Save(sqlMapper);//新建批次

                    VWmsInvMu Mu = new VWmsInvMu();
                    Mu.LP = "S" + ITEM_ID + SUPPLIER_ID.ToString();
                    Mu.WHSE_ID = WhseID;
                    Mu.CREATED_TIME = DBDateTimeGenerator.GetDBDateTime(sqlMapper);
                    Mu.LAST_MODIFIED = DBDateTimeGenerator.GetDBDateTime(sqlMapper);
                    Mu.COMPANY_ID = 0;
                    Mu.WIDTH = 0;
                    Mu.HEIGHT = 0;
                    Mu.LENGTH = 0;
                    Mu.PACK_CODE = "";
                    Mu.IS_DISABLED = 0;
                    Mu.PACKAGE_TYPE = "";
                    Mu.ITEM_ID = 0;
                    Mu.Save(sqlMapper);//新建可移动单元                        
                    VWmsInvDetail Sda = new VWmsInvDetail();
                    Sda.LOC_ID = LocID;
                    Sda.MU_ID = Mu.ID;
                    Sda.UID_ID = Uid.ID;
                    Sda.STATUS = "V";
                    Sda.ITEM_STATUS = "N";
                    Sda.QTY = InCount;
                    Sda.VERSION_TRANSACTION = 0;
                    Sda.PLAN_PICK_QTY = 0;
                    Sda.Save(sqlMapper);//新建零件
                    INV_ID = Sda.ID.ToString();

                    VWmsRcvDocAct Ract = new VWmsRcvDocAct();
                    Ract.DOC_DETAIL_ID = Detail.ID;
                    Ract.UID_ID = Sda.UID_ID;
                    Ract.QTY_RECEIVED = InCount;
                    Ract.QTY_DAMAGED = 0;
                    Ract.LP_ID = Mu.ID;
                    Ract.LOC_ID = LocID;
                    Ract.USER_ID = VPhrSecUsr.QueryDataTable(sqlMapper, "SelectById", User_ID).Rows[0]["LOGIN_NAME"].ToString();
                    Ract.CREATED_TIME = DBDateTimeGenerator.GetDBDateTime(sqlMapper);
                    Ract.IS_DISABLED = 0;
                    Ract.NORMAL_QTY = 0;
                    Ract.STATUS = "CL";
                    Ract.Save(sqlMapper);

                    VWmsInvTransaction Tran = new VWmsInvTransaction();
                    Tran.TRANSACTION_CODE = "com.vtradex.wms.inbound.Receiving";
                    Tran.WHSE_ID = WhseID;
                    Tran.LOC_ID = LocID;
                    Tran.T_LOC_ID = LocID;
                    Tran.COMPANY_ID = 1;
                    Tran.ITEM_ID = double.Parse(ITEM_ID);
                    Tran.LOT = LotDate;
                    Tran.F_QTY = 0;
                    Tran.T_QTY = InCount;
                    Tran.F_MU_ID = Mu.ID; ;
                    Tran.T_MU_ID = Mu.ID;
                    Tran.F_STATUS = "V";
                    Tran.T_STATUS = "V";
                    Tran.F_ITEM_STATUS = "N";
                    Tran.T_ITEM_STATUS = "N";
                    Tran.DESCRIPTION = "10";
                    Tran.USER_ID = VPhrSecUsr.QueryDataTable(sqlMapper, "SelectById", User_ID).Rows[0]["LOGIN_NAME"].ToString();
                    Tran.CREATED_TIME = DBDateTimeGenerator.GetDBDateTime(sqlMapper);
                    Tran.F_GOODSTYPE = "P";
                    Tran.T_GOODSTYPE = "P";
                    Tran.Save(sqlMapper);
                }
                #endregion
            }
            #endregion

            #region  //插入库龄表
            SqlParamSet IA = new SqlParamSet();
            IA.AddParam("INV_DETAIL_ID", INV_ID);
            //IA.AddParam("INPUT_DATE", Detail.LAST_MODIFIED);//(注释by mjy 2016-05-31)
            IA.AddParam("INPUT_DATE", Detail.RECEIVEDATE);//(修改by mjy 2016-05-31)
            IA.AddParam("ITEM_ID", ITEM_ID);
            IA.AddParam("SUPPLIER_ID", SUPPLIER_ID);
            IA.AddParam("QTY", InCount);
            IA.AddParam("LOC_ID", LocID);
            //  IA.AddParam("LAST_MODIFIED", Detail.LAST_MODIFIED);
            //IA.AddParam("CREATE_TIME", Detail.LAST_MODIFIED);//(注释by mjy 2016-05-31)
            IA.AddParam("CREATE_TIME", Detail.RECEIVEDATE);//(修改by mjy 2016-05-31)
            IA.AddParam("CREATE_USER", User_ID);
            //   IA.AddParam("MODIFIED_USER", User_ID);
            VWmsRcvDoc.QueryDataTable(sqlMapper, "SelInsertInToInPutAge", IA.GetParams());
            #endregion


            //判断上架是否完成
            SqlParamSet parms = new SqlParamSet();
            parms.AddParam("RID", RID);
            OutMsg = "Empty";
            if (int.Parse(VWmsRcvDoc.QueryDataTable(sqlMapper, "SelectByApCount", parms.GetParams()).Rows[0][0].ToString()) == 0)
            {
                if (SaveOrderMain(RID, sqlMapper))
                {
                    OutMsg = "OK";
                }
                else
                {
                    OutMsg = "Catch";
                }
            }
            #endregion

            return OutMsg;
        }
        #endregion

        #region 获取零件主库位
        public static string GetMlocByPartCode(string Item_Code)
        {
            string info = "NotFoundIItem";
            SqlParamSet ss = new SqlParamSet();
            ss.AddParam("ITEM_CODE", Item_Code);
            DataTable dt = VWmsItem.QueryDataTable("SelectPartInfoByCode", ss.GetParams());
            if (dt.Rows.Count != 0)
            {
                info = dt.Rows[0]["LOC_CODE"].ToString();
            }
            return info;
        }
        #endregion


        /// <summary>
        /// 上架时判断入库库位的仓库是否是当前用户所对应仓库
        /// </summary>
        /// <param name="LOC_CODE">入库库位代码</param>
        /// <param name="User_ID">用户ID</param>
        /// <returns></returns>
        public static bool IsUserWhse(string LOC_CODE, string User_ID)
        {
            SqlParamSet sqlParam = new SqlParamSet();
            sqlParam.AddParam("LOC_CODE", LOC_CODE);
            sqlParam.AddParam("USER_ID", User_ID);

            DataTable dt = VWmsBaseLocation.QueryDataTable("SelectIsUserWhse", sqlParam.GetParams());
            if (dt != null && dt.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
