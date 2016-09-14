using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IBatisNet.DataMapper;
using System.Data;
using DataMapper;
using Utility;

namespace YTWMS.Business
{
   public  class StockServices
    {
        #region 自定义变量
        private PartStock stock;   ///零件库存
        #endregion

        #region 日志
        /// <summary>
        ///零件入库仓库操作日志
        /// </summary>
        private void PartInOprateHistory(ISqlMapper sqlMap, LtUser loginUser, ReceiveOrderItem item, OrderBusiness business, PartStock stock)
        {
            try
            {
                PartOprateHistory partHistory = new PartOprateHistory();
                partHistory.BATCH_PART_ID = item.BATCH_PART_ID;
                partHistory.PART_OWNER = business.PART_OWNER;
                switch (business.ORDER_TYPE)
                {
                    case "SupplierIn":    /// EnumParser.GetEnumFiledValue(OrderType.供应商送货入库).ToString()
                        partHistory.OPERATE_TYPE = EnumParser.GetEnumFiledValue(OperateType.入库).ToString();
                        break;
                }
                partHistory.ORIGINAL_LOCATION_ID = item.LOCATION_ID;
                partHistory.TARGET_LOCATION_ID = item.LOCATION_ID;
                partHistory.FORMER_STORAGE_QTY = stock.STOCK_QTY - item.REAL_IN_QTY;
                partHistory.AFTER_STORAGE_QTY = stock.STOCK_QTY;
                partHistory.OPERATE_QTY = item.REAL_IN_QTY;
                partHistory.OPERATE_USER_ID = loginUser.ID;
                partHistory.OPERATE_TIME = DateTime.Now;
                partHistory.ORDER_SOURCE_ID = business.ORDER_NUM_ID;
                partHistory.WAREHOUSE_ID = loginUser.House.ID;
                partHistory.CREATE_TIME = DateTime.Now;
                int icount = (int)sqlMap.Insert("PartOprateHistory.Insert", partHistory);
                if (icount <= 0)
                    throw new Exception("零件仓库日志保存错误！");
            }
            catch (Exception ex)
            {
                RunTimeLogger.Debug(DateTime.Now.ToString() + ":" + ex.Message);
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        ///零件拉动出库仓库操作日志
        /// </summary>
        private void PartOutOprateHistory(ISqlMapper sqlMap, LtUser loginUser, Deliver send, OrderBusiness business, PartStock stock)
        {
            try
            {
                PartOprateHistory partHistory = new PartOprateHistory();
                partHistory.BATCH_PART_ID = send.BATCH_PART_ID;
                partHistory.PART_OWNER = business.PART_OWNER;
                switch (business.ORDER_TYPE)
                {
                    case "PullProduce":
                        partHistory.OPERATE_TYPE = EnumParser.GetEnumFiledValue(OperateType.发货).ToString();
                        break;
                    case "ServicePull":
                        partHistory.OPERATE_TYPE = EnumParser.GetEnumFiledValue(OperateType.发货).ToString();
                        break;
                    case "FurnacePull":
                        partHistory.OPERATE_TYPE = EnumParser.GetEnumFiledValue(OperateType.发货).ToString();
                        break;
                    case "PartSend":
                        partHistory.OPERATE_TYPE = EnumParser.GetEnumFiledValue(OperateType.发货).ToString();
                        break;
                    case "BackSupplier":
                        partHistory.OPERATE_TYPE = EnumParser.GetEnumFiledValue(OperateType.发货).ToString();
                        break;
                    case "ServiceSend":
                        partHistory.OPERATE_TYPE = EnumParser.GetEnumFiledValue(OperateType.发货).ToString();
                        break;
                }
                partHistory.ORIGINAL_LOCATION_ID = stock.WAREHOUSE_LOCATION_ID;
                // partHistory.TARGET_LOCATION_ID = 1;     ///发货目的库位 无
                partHistory.FORMER_STORAGE_QTY = stock.STOCK_QTY + send.REAL_OUT_QTY;
                partHistory.AFTER_STORAGE_QTY = stock.STOCK_QTY;
                partHistory.OPERATE_QTY = send.REAL_OUT_QTY;
                partHistory.OPERATE_USER_ID = loginUser.ID;
                partHistory.OPERATE_TIME = DateTime.Now;
                partHistory.ORDER_SOURCE_ID = business.ORDER_NUM_ID;
                partHistory.WAREHOUSE_ID = loginUser.House.ID;
                partHistory.CREATE_TIME = DateTime.Now;
                int id = (int)sqlMap.Insert("PartOprateHistory.Insert", partHistory);
            }
            catch (Exception ex)
            {
                RunTimeLogger.Debug(DateTime.Now.ToString() + ":" + ex.Message);
                throw new Exception(ex.Message);
            }
        }
        #endregion 

        #region 收货
        /// <summary>
        /// 仓库入库操作
        /// </summary>
        /// <param name="sqlMap"></param>
        /// <param name="userId"></param>
        public void StockOprateIn(ISqlMapper sqlMap, ReceiveOrderItem rOrderItem, OrderBusiness business, LtUser loginUser)
        {
            try
            {
                int iCount = 0;
                stock = new PartStock();
                stock.BATCH_PART_ID = rOrderItem.BATCH_PART_ID;
                stock.WAREHOUSE_LOCATION_ID = rOrderItem.LOCATION_ID;
                //stock.QUALITY_STATE = EnumParser.GetEnumFiledValue(Qualitystate.合格).ToString();
                stock.PART_OWNER = business.PART_OWNER;
                stock.WAREHOUSE_ID = loginUser.House.ID;

                stock = (PartStock)sqlMap.QueryForObject("PartStock.SelectByParam", stock);
                if (stock == null)
                {
                    ///新增
                    stock = new PartStock();
                    stock.BATCH_PART_ID = rOrderItem.BATCH_PART_ID;
                    stock.WAREHOUSE_LOCATION_ID = rOrderItem.LOCATION_ID;
                    stock.PART_OWNER = business.PART_OWNER;
                    stock.WAREHOUSE_ID = loginUser.House.ID;
                    stock.STOCK_QTY = rOrderItem.REAL_IN_QTY;
                    stock.QUALITY_STATE = EnumParser.GetEnumFiledValue(Qualitystate.合格).ToString();
                    stock.FROZEN_STATE = EnumParser.GetEnumFiledValue(IsFrozen.否).ToString();
                    stock.CREATE_TIME = DateTime.Now;
                    stock.CREATE_USER_ID = loginUser.ID;

                    iCount = (int)sqlMap.Insert("PartStock.Insert", stock);
                    if (iCount <= 0)
                        throw new Exception("零件库存保存失败！");
                }
                else
                {
                    if (stock.FROZEN_STATE == EnumParser.GetEnumFiledValue(IsFrozen.是).ToString())
                        throw new Exception("零件库存已冻结！");

                    stock.STOCK_QTY = stock.STOCK_QTY + rOrderItem.REAL_IN_QTY;
                    stock.LAST_UPDATE = DateTime.Now;
                    stock.UPDATE_USER_ID = loginUser.ID;

                    iCount = (int)sqlMap.Update("PartStock.UpdateStorageQty", stock);
                    if (iCount <= 0)
                        throw new Exception("零件库存保存失败！");
                }
                //插入日志
                PartInOprateHistory(sqlMap, loginUser, rOrderItem, business, stock);
            }
            catch (Exception ex)
            {
                RunTimeLogger.Debug(DateTime.Now.ToString() + ":" + ex.Message);
                throw new Exception(ex.Message);
            }
        }
        #endregion 

        #region 发货
        /// <summary>
        /// 仓库出库操作
        /// </summary>
        /// <param name="sqlMap"></param>
        /// <param name="userId"></param>
        public void StockOprateOut(ISqlMapper sqlMap, LtUser loginUser, OrderBusiness business, Deliver send)
        {
            try
            {
                int iCount = 0;
                stock = new PartStock();
                stock.BATCH_PART_ID = send.BATCH_PART_ID;
                stock.WAREHOUSE_LOCATION_ID = send.LOC_ID;
                stock.PART_OWNER = business.PART_OWNER;
                stock.WAREHOUSE_ID = loginUser.House.ID;

                stock = (PartStock)sqlMap.QueryForObject("PartStock.SelectByParam", stock);
                if (stock == null)
                {
                    throw new Exception("零件库存不存在！");
                }
                else
                {
                    if (stock.FROZEN_STATE == EnumParser.GetEnumFiledValue(IsFrozen.是).ToString())
                        throw new Exception("零件库存已冻结！");

                    if (stock.STOCK_QTY < send.REAL_OUT_QTY)
                        throw new Exception("零件库存数量小于出库数量！");

                    stock.STOCK_QTY = stock.STOCK_QTY - send.REAL_OUT_QTY;
                    stock.LAST_UPDATE = DateTime.Now;
                    stock.UPDATE_USER_ID = loginUser.ID;

                    if (stock.STOCK_QTY <= 0)
                    {
                        iCount = (int)sqlMap.Delete("PartStock.deleteStock", stock);
                        if (iCount <= 0)
                            throw new Exception("零件库存保存失败！");
                    }
                    else
                    {
                        iCount = (int)sqlMap.Update("PartStock.UpdateStorageQty", stock);
                        if (iCount <= 0)
                            throw new Exception("零件库存保存失败！");
                    }
                }
                //插入日志
                PartOutOprateHistory(sqlMap, loginUser, send, business, stock);
            }
            catch (Exception ex)
            {
                RunTimeLogger.Debug(DateTime.Now.ToString() + ":" + ex.Message);
                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region 排序
        /// <summary>
        /// 仓库出库操作
        /// </summary>
        /// <param name="sqlMap"></param>
        /// <param name="userId"></param>
        public int StockOprateQueueOut(ISqlMapper sqlMap, OrderNum order, OrderBusiness business, Queue q)
        {
            try
            {
                int iCount = 0;
                stock = new PartStock();
                stock.BATCH_PART_ID = q.BATCH_PART_ID;
                stock.WAREHOUSE_LOCATION_ID = q.WAREHOUSE_LOCATION_ID;
                stock.PART_OWNER = business.PART_OWNER;
                stock.WAREHOUSE_ID = order.WAREHOUSE_ID;

                stock = (PartStock)sqlMap.QueryForObject("PartStock.SelectByParam", stock);
                if (stock == null)
                {
                    throw new Exception("零件库存不存在！");
                }
                else
                {
                    if (stock.FROZEN_STATE == EnumParser.GetEnumFiledValue(IsFrozen.是).ToString())
                    {
                        throw new Exception("零件库存已冻结！");
                    }

                    if (stock.STOCK_QTY < q.PLAN_QUEUE_QTY)
                    {
                        throw new Exception("零件库存数量小于出库数量！");
                    }

                    stock.STOCK_QTY = stock.STOCK_QTY - q.PLAN_QUEUE_QTY;
                    stock.LAST_UPDATE = DateTime.Now;
                    stock.UPDATE_USER_ID = order.CREATE_USER_ID;

                    if (stock.STOCK_QTY <= 0)
                    {
                        iCount = (int)sqlMap.Delete("PartStock.deleteStock", stock);
                        if (iCount <= 0)
                        {
                            throw new Exception("零件库存保存失败！");
                        }
                    }
                    else
                    {
                        iCount = (int)sqlMap.Update("PartStock.UpdateStorageQty", stock);
                        if (iCount <= 0)
                        {
                            throw new Exception("零件库存保存失败！");
                        }
                    }
                }
                //插入日志
                PartOutOprateHistory(sqlMap, order, q, business, stock);
                return 1;
            }
            catch (Exception ex)
            {
                RunTimeLogger.Debug(DateTime.Now.ToString() + ":" + ex.Message);
                throw new Exception(ex.Message);
            }
        }
        #endregion


        /// <summary>
       /// 查询仓库库存
       /// </summary>
       /// <param name="sqlMap"></param>
       /// <param name="sqlParam"></param>
       /// <returns></returns>
        public static DataTable GetStockTable(ISqlMapper sqlMap, SqlParamSet sqlParam)
        {
            try
            {
                return (DataTable)sqlMap.QueryForDataTable("PartStock.SelectBatchPartStock", sqlParam.GetParams(), "PartStock");
            }
            catch (Exception ex)
            {
                RunTimeLogger.Debug(DateTime.Now.ToString() + ":" + ex.Message);
                return null;
            }
        }


        /// <summary>
        ///零件拉动出库仓库操作日志
        /// </summary>
        private void PartOutOprateHistory(ISqlMapper sqlMap, OrderNum order, Queue Q, OrderBusiness business, PartStock stock)
        {
            try
            {
                PartOprateHistory partHistory = new PartOprateHistory();
                partHistory.BATCH_PART_ID = Q.BATCH_PART_ID;
                partHistory.PART_OWNER = business.PART_OWNER;
                switch (business.ORDER_TYPE)
                {
                    case "PullProduce":
                        partHistory.OPERATE_TYPE = EnumParser.GetEnumFiledValue(OperateType.发货).ToString();
                        break;
                    case "ServicePull":
                        partHistory.OPERATE_TYPE = EnumParser.GetEnumFiledValue(OperateType.发货).ToString();
                        break;
                    case "FurnacePull":
                        partHistory.OPERATE_TYPE = EnumParser.GetEnumFiledValue(OperateType.发货).ToString();
                        break;
                    case "PartSend":
                        partHistory.OPERATE_TYPE = EnumParser.GetEnumFiledValue(OperateType.发货).ToString();
                        break;
                    case "BackSupplier":
                        partHistory.OPERATE_TYPE = EnumParser.GetEnumFiledValue(OperateType.发货).ToString();
                        break;
                    case "ServiceSend":
                        partHistory.OPERATE_TYPE = EnumParser.GetEnumFiledValue(OperateType.发货).ToString();
                        break;
                    case "QueueSend":
                        partHistory.OPERATE_TYPE = EnumParser.GetEnumFiledValue(OperateType.发货).ToString();
                        break;
                        
                }
                partHistory.ORIGINAL_LOCATION_ID = stock.WAREHOUSE_LOCATION_ID;
                partHistory.FORMER_STORAGE_QTY = stock.STOCK_QTY + Q.PLAN_QUEUE_QTY;
                partHistory.AFTER_STORAGE_QTY = stock.STOCK_QTY;
                partHistory.OPERATE_QTY = Q.PLAN_QUEUE_QTY;
                partHistory.OPERATE_USER_ID = order.CREATE_USER_ID;
                partHistory.OPERATE_TIME = DateTime.Now;
                partHistory.ORDER_SOURCE_ID = business.ORDER_NUM_ID;
                partHistory.WAREHOUSE_ID = order.WAREHOUSE_ID;
                partHistory.CREATE_TIME = DateTime.Now;
                int id = (int)sqlMap.Insert("PartOprateHistory.Insert", partHistory);
            }
            catch (Exception ex)
            {
                RunTimeLogger.Debug(DateTime.Now.ToString() + ":" + ex.Message);
                throw new Exception(ex.Message);
            }
        }
    }
}
