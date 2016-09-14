using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IBatisNet.Common;
using Utility;
using DataMapper;
using IBatisNet.DataMapper;
using CodeBetter.Json;


namespace YTWMS.Business
{
    /// <summary>
    /// 排序类
    /// </summary>
    public class SortServices
    {
        /// <summary>
        /// 查询单号
        /// </summary>
        /// <param name="Acount">单号</param>
        /// <param name="Password">仓库</param>
        /// <returns></returns>
        public static DataTable GetSortPart(string sortNo, int warehouseId, ISqlMapper sqlMapper)
        {
            try
            {
                SqlParamSet sqlParam = new SqlParamSet();
                sqlParam.AddParam("WAREHOUSE_ID", warehouseId);
                sqlParam.AddParam("PULL_ORDER_NO", sortNo);
                sqlParam.AddParam("IS_DISABLE", "0");

                DataTable dt = PullPlan.QueryDataTable(sqlMapper,"SelectPullPlanDetailByNo", sqlParam.GetParams());
                return dt;
            }
            catch (Exception ex)
            {
                RunTimeLogger.Debug(DateTime.Now.ToString() + ":" + ex.Message);
                throw new Exception(ex.Message.ToString());
            }
        }

        /// <summary>
        /// 查询单号
        /// </summary>
        /// <param name="Acount">单号</param>
        /// <param name="Password">仓库</param>
        /// <returns></returns>
        public static DataTable GetSortPart(string sortNo, int warehouseId)
        {
            try
            {
                SqlParamSet sqlParam = new SqlParamSet();
                sqlParam.AddParam("WAREHOUSE_ID", warehouseId);
                sqlParam.AddParam("PULL_ORDER_NO", sortNo);
                sqlParam.AddParam("IS_DISABLE", "0");

                DataTable dt = PullPlan.QueryDataTable("SelectPullPlanDetailByNo", sqlParam.GetParams());
                return dt;
            }
            catch (Exception ex)
            {
                RunTimeLogger.Debug(DateTime.Now.ToString() + ":" + ex.Message);
                throw new Exception(ex.Message.ToString());
            }
        }

        /// <summary>
        /// 排序确认
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public static string ConfirmQueue(string sortNo, int userId, int warehouseId, string strDock, string strDriver, string strTruck)
        {
            try
            {
                WareHouse house = new WareHouse { ID= warehouseId };
                house = WareHouseServices.GetWareHouseID(house);
                if (house == null)
                {
                    MessageInfo info = new MessageInfo();
                    info.ResultState = "Error";
                    info.Info = "获取仓库信息失败！";
                    return Converter.Serialize(info);
                }

                ISqlMapper sqlMapper = Sql_Mapper.Instance();
                sqlMapper.BeginTransaction();
                try
                {
                    StockServices service = new StockServices();
                    int partId = 0;
                    foreach (string str in sortNo.Split(',').ToArray()) 
                    {
                        OrderNum order = new OrderNum();
                        order.CREATE_TIME = DateTime.Now;
                        order.CREATE_USER_ID = userId;
                        order.ORDER_CREATE_TIME = DateTime.Now;
                        order.WAREHOUSE_ID = warehouseId;
                        order.ORDER_NO = WareHouseServices.GetSerialNo(house.WAREHOUSE_CODE, EnumParser.GetEnumFiledValue(OrderNo.发货单).ToString(),sqlMapper);
                        order.DOCUMENT_NO = string.Empty;

                        OrderBusiness business = new OrderBusiness();
                        business.CREATE_TIME = DateTime.Now;
                        business.CREATE_USER_ID = userId;
                        business.DRIVER_NAME = strDriver;
                        business.DOCK = strDock;
                        business.TRUCK_NO = strTruck;
                        business.ORDER_STATE = EnumParser.GetEnumFiledValue(Is_Finish.完成).ToString();
                        business.PART_OWNER = EnumParser.GetEnumFiledValue(PartOwner.帐内).ToString();
                        business.ORDER_TYPE = EnumParser.GetEnumFiledValue(OrderType.发货单).ToString();
                        business.USER_ID = userId;
                        business.SEND_LOC_ID = warehouseId;
                        //过滤排序完成的订单
                        DataTable dtSort = SortServices.GetSortPart(str, warehouseId, sqlMapper);
                        if (dtSort == null || dtSort.Rows.Count <= 0)
                            continue;

                        if (dtSort != null && dtSort.Rows.Count > 0 && dtSort.Rows[0]["PLAN_DELIVER_TIME"].ToString() != string.Empty)
                            business.PLAN_TIME = Convert.ToDateTime(dtSort.Rows[0]["PLAN_DELIVER_TIME"].ToString());
                        if (dtSort != null && dtSort.Rows.Count > 0 && dtSort.Rows[0]["PULL_ORDER_NO"].ToString() != string.Empty)
                            order.DOCUMENT_NO = dtSort.Rows[0]["PULL_ORDER_NO"].ToString();
                        if (dtSort != null && dtSort.Rows.Count > 0 && dtSort.Rows[0]["CUSTOMER_ID"].ToString() != string.Empty)
                            business.RECEIVE_LOC_ID = Convert.ToInt32(dtSort.Rows[0]["CUSTOMER_ID"].ToString());
                        int businessId = busServices.SaveOrderBusiness(sqlMapper, order, business);
                        foreach (DataRow dr in dtSort.Rows)
                        {
                            SqlParamSet sqlParam = new SqlParamSet();
                            sqlParam.AddParam("PART_ID", Convert.ToInt32(dr["PART_ID"].ToString()));
                            sqlParam.AddParam("SUPPLIER_ID", Convert.ToInt32(dr["SUPPLIER_ID"].ToString()));
                            sqlParam.AddParam("PROJECT_ID", Convert.ToInt32(dr["PROJECT_ID"].ToString()));
                            sqlParam.AddParam("WAREHOUSE_ID", warehouseId);
                            sqlParam.AddParam("UNIT", EnumParser.GetEnumFiledValue(MeasurementType.件).ToString());
                            sqlParam.AddParam("PROJECT_ITEM_ID", 0);// 不发送小项目
                            DataTable dt = StockServices.GetStockTable(sqlMapper, sqlParam);

                            if (dt == null || dt.Rows.Count <= 0)
                            {
                                sqlMapper.RollBackTransaction();
                                MessageInfo info = new MessageInfo();
                                info.ResultState = "Error";
                                info.Info = "零件库存不足!";
                                return Converter.Serialize(info);
                            }

                            Queue Q = new Queue();
                            Q.PART_ID = Convert.ToInt32(dr["PART_ID"].ToString());
                            Q.SUPPLIER_ID = Convert.ToInt32(dr["SUPPLIER_ID"].ToString());
                            Q.PROJECT_ID = Convert.ToInt32(dr["PROJECT_ID"].ToString());
                            Q.PROJECT_ITEM_ID = Convert.ToInt32(dr["PROJECT_ITEM_ID"].ToString());
                            Q.WAREHOUSE_ID = warehouseId;
                            Q.QUEUE_TIME = DateTime.Now;
                            Q.QUEUE_NO = dr["SEQNO"].ToString();
                            Q.PLAN_QUEUE_QTY = Convert.ToInt32(Convert.ToDecimal(dr["PULL_QTY"].ToString()));
                            Q.ORDER_SOURCE_ID = Convert.ToInt32(dr["ID"].ToString());
                            Q.IS_DISABLE = EnumParser.GetEnumFiledValue(Is_Disable.有效).ToString();
                            Q.BATCH_PART_ID = Convert.ToInt32(dt.Rows[0]["BATCH_PART_ID"].ToString());
                            Q.ORDER_BUSINESS_ID = businessId;
                            Q.WAREHOUSE_LOCATION_ID = Convert.ToInt32(dt.Rows[0]["WAREHOUSE_LOCATION_ID"].ToString());
                            Q.CREATE_TIME = DateTime.Now;
                            Q.CREATE_USER_ID = userId;

                            Deliver del = new Deliver();
                            del.CREATE_TIME = DateTime.Now;
                            del.CREATE_USER_ID = userId;
                            del.PLAN_OUT_QTY = Convert.ToInt32(Convert.ToDecimal(dr["PULL_QTY"].ToString()));
                            del.REAL_OUT_QTY = Convert.ToInt32(Convert.ToDecimal(dr["PULL_QTY"].ToString()));
                            del.CUSTOMER_RECEIVE_QTY = 0;
                            del.DELIVER_TYPE = EnumParser.GetEnumFiledValue(DELIVERTYPE.排序发货单).ToString();
                            del.DELIVER_REMARK = string.Empty;
                            del.RECEIVE_STATE = EnumParser.GetEnumFiledValue(Is_Finish.未完成).ToString();
                            del.OUT_TIME = DateTime.Now;
                            del.IS_DEAL = EnumParser.GetEnumFiledValue(IsDeal.否).ToString();
                            del.IS_DISABLE = EnumParser.GetEnumFiledValue(Is_Disable.有效).ToString();
                            del.WAREHOUSE_ID = warehouseId;
                            del.BATCH_PART_ID = Convert.ToInt32(dt.Rows[0]["BATCH_PART_ID"].ToString());
                            del.LOC_ID = Convert.ToInt32(dt.Rows[0]["BATCH_PART_ID"].ToString());
                            del.ORDER_BUSINESS_ID = businessId;
                            del.PLAN_DETAIL_ID = Convert.ToInt32(dr["ID"].ToString());

                            int delId = (int)del.Save(sqlMapper);
                            if (delId <= 0)
                            {
                                sqlMapper.RollBackTransaction();
                                MessageInfo info = new MessageInfo();
                                info.ResultState = "Error";
                                info.Info = "排序保存失败!";
                                return Converter.Serialize(info);
                            }
                            partId = (int)Q.Save(sqlMapper);
                            if (partId <= 0)
                            {
                                sqlMapper.RollBackTransaction();
                                MessageInfo info = new MessageInfo();
                                info.ResultState = "Error";
                                info.Info = "排序保存失败!";
                                return Converter.Serialize(info);
                            }

                            if (Q.PLAN_QUEUE_QTY > 0)
                            {
                                int i = service.StockOprateQueueOut(sqlMapper, order, business, Q);
                                if (i != 1)
                                {
                                    sqlMapper.RollBackTransaction();
                                    MessageInfo info = new MessageInfo();
                                    info.ResultState = "Error";
                                    info.Info = "保存库存日志失败!";
                                    return Converter.Serialize(info);
                                }
                            }
                        }
                    }

                    sqlMapper.CommitTransaction();
                    MessageInfo infoSucces = new MessageInfo();
                    infoSucces.ResultState = "Succes";
                    infoSucces.Info = "出库成功!";
                    return Converter.Serialize(infoSucces);
                }
                catch (Exception ex)
                {
                    sqlMapper.RollBackTransaction();
                    RunTimeLogger.Debug(DateTime.Now.ToString() + ":" + ex.Message);
                    MessageInfo info = new MessageInfo();
                    info.ResultState = "Error";
                    info.Info = ex.Message.ToString();
                    return Converter.Serialize(info);
                }
            }
            catch (Exception ex)
            {
                RunTimeLogger.Debug(DateTime.Now.ToString() + ":" + ex.Message);
                MessageInfo info = new MessageInfo();
                info.ResultState = "Error";
                info.Info = ex.Message.ToString();
                return Converter.Serialize(info);
            }
        }
    }
}
