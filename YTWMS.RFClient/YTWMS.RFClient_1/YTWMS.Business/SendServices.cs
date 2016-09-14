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
    public class SendServices
    {
        /// <summary>
        /// 退供应商
        /// </summary>
        /// <param name="supplierId"></param>
        /// <param name="userId"></param>
        /// <param name="warehouseId"></param>
        /// <param name="truckNo"></param>
        /// <param name="drver"></param>
        /// <param name="tel"></param>
        /// <param name="jsonBox"></param>
        /// <returns></returns>
        public static string BackSupplier(int supplierId, int userId, int warehouseId, string truckNo, string drver, string tel, string jsonBox)
        {
            try
            {
                List<WareHouse> houseList = new List<WareHouse>();
                List<Deliver> deliverList = new List<Deliver>();
                IList<Part> partList = new List<Part>();
                Deliver del;

                WareHouse h = new WareHouse() { TYPE = EnumParser.GetEnumFiledValue(WareHouseType.仓库).ToString() };
                houseList = h.QueryList("SelectByParam").ToList<WareHouse>();
                WareHouse house = houseList.FirstOrDefault(c => c.ID == warehouseId);

                LtUser loginuser = new LtUser() { ID = userId, House = house };

                Part pt = new Part() { WAREHOUSE_ID = warehouseId };
                partList = pt.QueryList("SelectByParam").ToList<Part>();

                List<BoxInfo> boxList = Converter.Deserialize<List<BoxInfo>>(jsonBox);

                StockServices Services = new StockServices();

                ISqlMapper sqlMapper = Sql_Mapper.Instance();
                sqlMapper.BeginTransaction();
                try
                {
                    #region 表头
                    OrderNum order = new OrderNum();
                    order.CREATE_TIME = DateTime.Now;
                    order.ORDER_CREATE_TIME = DateTime.Now;
                    order.CREATE_USER_ID = userId;
                    order.WAREHOUSE_ID = warehouseId;
                    order.ORDER_NO = WareHouseServices.GetSerialNo(house.WAREHOUSE_CODE, EnumParser.GetEnumFiledValue(OrderNo.退货到供应商单号).ToString());
                    order.ORDER_REMARK = string.Empty;

                    OrderBusiness business = new OrderBusiness();
                    business.CREATE_TIME = DateTime.Now;
                    business.CREATE_USER_ID = userId;
                    business.ORDER_DELIVER_TIME = DateTime.Now;
                    business.ORDER_TYPE = EnumParser.GetEnumFiledValue(OrderType.退货到供应商).ToString();
                    business.ORDER_STATE = EnumParser.GetEnumFiledValue(Is_Finish.完成).ToString();
                    business.PART_OWNER = EnumParser.GetEnumFiledValue(PartOwner.帐内).ToString();
                    business.SEND_LOC_ID = warehouseId;
                    business.RECEIVE_LOC_ID = supplierId;
                    business.USER_ID = userId;

                    int busInstorageId = busServices.SaveOrderBusiness(sqlMapper, order, business);
                    #endregion

                    foreach (BoxInfo box in boxList)
                    {
                        Part p = partList.FirstOrDefault(c => c.PART_CODE == box.PART_CODE && c.WAREHOUSE_ID == warehouseId);

                        SqlParamSet param = new SqlParamSet();
                        //param.AddParam("BATCH_NO", box.ss);
                        param.AddParam("BOX_NUMBER", box.BOX_CODE);
                        //param.AddParam("FURNACE_NO", box.FURNACE_NO);
                        //param.AddParam("PROJECT_ID", box.PROJECT_ID);
                        //param.AddParam("PROJECT_ITEM_ID", box.PROJECT_ITEM_ID);
                        param.AddParam("WAREHOUSE_ID", warehouseId);
                        param.AddParam("PART_ID", p.ID);
                        param.AddParam("UNIT", EnumParser.GetEnumFiledValue(MeasurementType.箱).ToString());

                        PartStock ps = PartStock.QueryObject(sqlMapper, "SelectBoxPartStock", param.GetParams());
                        if (ps == null)
                        {
                            sqlMapper.RollBackTransaction();
                            MessageInfo info = new MessageInfo();
                            info.ResultState = "Error";
                            info.Info = "库存不存在:" + box.BOX_CODE.ToString();
                            return Converter.Serialize(info);
                        }

                        del = new Deliver();
                        del.CREATE_TIME = DateTime.Now;
                        del.CREATE_USER_ID = userId;
                        del.PLAN_OUT_QTY = box.QTY;
                        del.REAL_OUT_QTY = box.QTY;
                        del.CUSTOMER_RECEIVE_QTY = box.QTY;
                        del.DELIVER_TYPE = EnumParser.GetEnumFiledValue(DELIVERTYPE.退货).ToString();
                        del.DELIVER_REMARK = string.Empty;
                        del.RECEIVE_STATE = EnumParser.GetEnumFiledValue(Is_Finish.完成).ToString();
                        del.OUT_TIME = DateTime.Now;
                        del.IS_DEAL = EnumParser.GetEnumFiledValue(IsDeal.否).ToString();
                        del.IS_DISABLE = EnumParser.GetEnumFiledValue(Is_Disable.有效).ToString();
                        del.WAREHOUSE_ID = warehouseId;
                        del.BATCH_PART_ID = ps.BATCH_PART_ID;
                        del.LOC_ID = ps.WAREHOUSE_LOCATION_ID;
                        del.ORDER_BUSINESS_ID = busInstorageId;

                        int index = (int)sqlMapper.Insert("Deliver.Insert", del);
                        if (index <= 0)
                        {
                            sqlMapper.RollBackTransaction();
                            MessageInfo info = new MessageInfo();
                            info.ResultState = "Error";
                            info.Info = "扣库失败:" + box.BOX_CODE;
                            return Converter.Serialize(info);
                        }
                        Services.StockOprateOut(sqlMapper, loginuser, business, del);
                    }

                    sqlMapper.CommitTransaction();
                    MessageInfo infoReturn = new MessageInfo();
                    infoReturn.ResultState = "Succes";
                    infoReturn.Info = "";
                    return Converter.Serialize(infoReturn);
                }
                catch (Exception ex)
                {
                    RunTimeLogger.Debug(DateTime.Now.ToString() + ":" + ex.Message);
                    sqlMapper.RollBackTransaction();
                    MessageInfo info = new MessageInfo();
                    info.ResultState = "Error";
                    info.Info = ex.Message;
                    return Converter.Serialize(info);
                }
            }
            catch (Exception ex)
            {
                RunTimeLogger.Debug(DateTime.Now.ToString() + ":" + ex.Message);
                MessageInfo infoReturn = new MessageInfo();
                infoReturn.ResultState = "Error";
                infoReturn.Info = ex.Message.ToString();
                return Converter.Serialize(infoReturn);
            }
        }


        /// <summary>
        /// 整箱拉动发货
        /// </summary>
        /// <param name="supplierId"></param>
        /// <param name="userId"></param>
        /// <param name="warehouseId"></param>
        /// <param name="truckNo"></param>
        /// <param name="drver"></param>
        /// <param name="tel"></param>
        /// <param name="jsonBox"></param>
        /// <returns></returns>
        public static string PullPackageSend(string planNO, int userId, int warehouseId, string truckNo, string drver, string tel, string jsonBox)
        {
            try
            {
                List<WareHouse> houseList = new List<WareHouse>();
                List<Deliver> deliverList = new List<Deliver>();
                IList<Part> partList = new List<Part>();
                Deliver del;

                WareHouse h = new WareHouse() { TYPE = EnumParser.GetEnumFiledValue(WareHouseType.仓库).ToString() };
                houseList = h.QueryList("SelectAll").ToList<WareHouse>();
                WareHouse house = houseList.FirstOrDefault(c => c.ID == warehouseId);

                LtUser loginuser = new LtUser() { ID = userId, House = house };

                Part pt = new Part() { WAREHOUSE_ID = warehouseId };
                partList = pt.QueryList("SelectByParam").ToList<Part>();

                List<BoxInfo> boxList = Converter.Deserialize<List<BoxInfo>>(jsonBox);

                StockServices Services = new StockServices();

                ISqlMapper sqlMapper = Sql_Mapper.Instance();
                sqlMapper.BeginTransaction();
                try
                {
                    #region 表头
                    OrderNum order = new OrderNum();
                    order.CREATE_TIME = DateTime.Now;
                    order.ORDER_CREATE_TIME = DateTime.Now;
                    order.CREATE_USER_ID = userId;
                    order.WAREHOUSE_ID = warehouseId;
                    order.DOCUMENT_NO = planNO;
                    order.ORDER_NO = WareHouseServices.GetSerialNo(house.WAREHOUSE_CODE, EnumParser.GetEnumFiledValue(OrderNo.发货单).ToString(),sqlMapper);
                    order.ORDER_REMARK = string.Empty;

                    OrderBusiness business = new OrderBusiness();
                    business.CREATE_TIME = DateTime.Now;
                    business.CREATE_USER_ID = userId;
                    business.ORDER_DELIVER_TIME = DateTime.Now;
                    business.ORDER_TYPE = EnumParser.GetEnumFiledValue(OrderType.发货单).ToString();
                    business.ORDER_STATE = EnumParser.GetEnumFiledValue(Is_Finish.完成).ToString();
                    business.PART_OWNER = EnumParser.GetEnumFiledValue(PartOwner.帐内).ToString();
                    business.SEND_LOC_ID = warehouseId;
                    business.ORDER_END_TIME = DateTime.Now;
                    business.RECEIVE_LOC_ID = 0;
                    business.USER_ID = userId;

                    DataTable dtPulll = SortServices.GetSortPart(planNO, warehouseId, sqlMapper);

                    if (dtPulll != null && dtPulll.Rows.Count > 0 && dtPulll.Rows[0]["PLAN_DELIVER_TIME"] != null)
                        business.PLAN_TIME = Convert.ToDateTime(dtPulll.Rows[0]["PLAN_DELIVER_TIME"]);

                    if (dtPulll != null && dtPulll.Rows.Count > 0 && dtPulll.Rows[0]["CUSTOMER_ID"] != null)
                        business.RECEIVE_LOC_ID = Convert.ToInt32(dtPulll.Rows[0]["CUSTOMER_ID"]);

                    int busInstorageId = busServices.SaveOrderBusiness(sqlMapper, order, business);
                    #endregion

                    foreach (BoxInfo box in boxList)
                    {
                        Part p = partList.FirstOrDefault(c => c.PART_CODE == box.PART_CODE && c.WAREHOUSE_ID == warehouseId);

                        SqlParamSet param = new SqlParamSet();
                        //param.AddParam("BATCH_NO", box.BATCH_NO);
                        param.AddParam("BOX_NUMBER", box.BOX_CODE);
                        //param.AddParam("FURNACE_NO", box.FURNACE_NO);
                        //param.AddParam("PROJECT_ID", box.PROJECT_ID);
                        param.AddParam("PROJECT_ITEM_ID", box.PROJECT_ITEM_ID);
                        param.AddParam("WAREHOUSE_ID", warehouseId);
                        param.AddParam("PART_ID", p.ID);
                        param.AddParam("UNIT", EnumParser.GetEnumFiledValue(MeasurementType.箱).ToString());

                        PartStock ps = PartStock.QueryObject(sqlMapper, "SelectBatchPartStock", param.GetParams());
                        if (ps == null)
                        {
                            sqlMapper.RollBackTransaction();
                            MessageInfo info = new MessageInfo();
                            info.ResultState = "Error";
                            info.Info = "库存不存在:" + box.BOX_CODE;
                            return Converter.Serialize(info);
                        }

                        del = new Deliver();
                        del.CREATE_TIME = DateTime.Now;
                        del.CREATE_USER_ID = userId;
                        del.PLAN_OUT_QTY = box.QTY;
                        del.REAL_OUT_QTY = box.QTY;
                        del.CUSTOMER_RECEIVE_QTY = box.QTY;
                        del.DELIVER_TYPE = EnumParser.GetEnumFiledValue(DELIVERTYPE.拉动).ToString();
                        del.DELIVER_REMARK = string.Empty;
                        del.RECEIVE_STATE = EnumParser.GetEnumFiledValue(Is_Finish.完成).ToString();
                        del.OUT_TIME = DateTime.Now;
                        del.IS_DEAL = EnumParser.GetEnumFiledValue(IsDeal.否).ToString();
                        del.IS_DISABLE = EnumParser.GetEnumFiledValue(Is_Disable.有效).ToString();
                        del.WAREHOUSE_ID = warehouseId;
                        del.BATCH_PART_ID = ps.BATCH_PART_ID;
                        del.LOC_ID = ps.WAREHOUSE_LOCATION_ID;
                        del.ORDER_BUSINESS_ID = busInstorageId;

                        DataRow[] dr = dtPulll.Select(" PART_ID=" + p.ID);
                        if (dr.Length > 0)
                            del.PLAN_DETAIL_ID = Convert.ToInt32(dr[0]["ID"]);

                        int index = (int)sqlMapper.Insert("Deliver.Insert", del);
                        if (index <= 0)
                        {
                            sqlMapper.RollBackTransaction();
                            MessageInfo info = new MessageInfo();
                            info.ResultState = "Error";
                            info.Info = "扣库失败:" + box.BOX_CODE;
                            return Converter.Serialize(info);
                        }
                        Services.StockOprateOut(sqlMapper, loginuser, business, del);
                    }

                    sqlMapper.CommitTransaction();
                    MessageInfo infoReturn = new MessageInfo();
                    infoReturn.ResultState = "Succes";
                    infoReturn.Info = "";
                    return Converter.Serialize(infoReturn);
                }
                catch (Exception ex)
                {
                    RunTimeLogger.Debug(DateTime.Now.ToString() + ":" + ex.Message);
                    sqlMapper.RollBackTransaction();
                    MessageInfo info = new MessageInfo();
                    info.ResultState = "Error";
                    info.Info = ex.Message;
                    return Converter.Serialize(info);
                }
            }
            catch (Exception ex)
            {
                RunTimeLogger.Debug(DateTime.Now.ToString() + ":" + ex.Message);
                MessageInfo infoReturn = new MessageInfo();
                infoReturn.ResultState = ex.Message.ToString();
                infoReturn.Info = string.Empty;
                return Converter.Serialize(infoReturn);
            }
        }

        /// <summary>
        /// 查询拉动单号
        /// </summary>
        /// <param name="Acount">单号</param>
        /// <param name="Password">仓库</param>
        /// <returns></returns>
        public static DataTable GetPullPlan(string orderNo, int warehouseId)
        {
            try
            {
                SqlParamSet sqlParam = new SqlParamSet();
                sqlParam.AddParam("WAREHOUSE_ID", warehouseId);
                sqlParam.AddParam("PULL_ORDER_NO", orderNo);
                sqlParam.AddParam("IS_DISABLE", "0");

                DataTable dt = PullPlan.QueryDataTable("SelectByParam", sqlParam.GetParams());
                return dt;
            }
            catch (Exception ex)
            {
                RunTimeLogger.Debug(DateTime.Now.ToString() + ":" + ex.Message);
                throw new Exception(ex.Message.ToString());
            }
        }

        /// <summary>
        /// 查询箱号库存
        /// </summary>
        /// <param name="Acount">单号</param>
        /// <param name="Password">仓库</param>
        /// <returns></returns>
        public static string CheckBoxStock(string boxNO,string partCode, int warehouseId)
        {
            try
            {
                IList<Part> partList = new List<Part>();
           
                Part pt = new Part() { WAREHOUSE_ID = warehouseId };
                partList = pt.QueryList("SelectByParam").ToList<Part>();

                Part p = partList.FirstOrDefault(c => c.PART_CODE == partCode && c.WAREHOUSE_ID == warehouseId);


                SqlParamSet param = new SqlParamSet();
                param.AddParam("BOX_NUMBER", boxNO);
                param.AddParam("WAREHOUSE_ID", warehouseId);
                param.AddParam("PART_ID", p.ID);
                param.AddParam("UNIT", EnumParser.GetEnumFiledValue(MeasurementType.箱).ToString());

                PartStock ps = PartStock.QueryObject("SelectBoxPartStock", param.GetParams());
                if (ps != null)
                {
                    MessageInfo info = new MessageInfo();
                    info.ResultState = "Error";
                    info.Info = "库存已存在:" + boxNO;
                    return Converter.Serialize(info);
                }
                else
                {
                    MessageInfo info = new MessageInfo();
                    info.ResultState = "Succes";
                    info.Info = "";
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
