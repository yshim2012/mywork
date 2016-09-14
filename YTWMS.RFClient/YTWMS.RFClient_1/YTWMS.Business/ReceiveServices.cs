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
    public class ReceiveServices
    {
        /// <summary>
        /// 检查箱号信息
        /// </summary>
        /// <param name="warehouseId"></param>
        /// <param name="strJson"></param>
        /// <returns></returns>
        public static string CheckBoxInfo(int warehouseId, string strJson)
        {
            try
            {
                BoxInfo box = Converter.Deserialize<BoxInfo>(strJson);

                ISqlMapper sqlMapper = Sql_Mapper.Instance();
                Part p = new Part()
                {
                    PART_CODE = box.PART_CODE,
                    WAREHOUSE_ID = warehouseId,
                    IS_DISABLE = EnumParser.GetEnumFiledValue(Is_Disable.有效).ToString()
                };

                p= p.QueryObject(sqlMapper, "SelectByParam");
                if (p == null)
                {
                    MessageInfo info = new MessageInfo();
                    info.ResultState = "Error";
                    info.Info = "零件编号不存在";
                    return Converter.Serialize(info);
                }

                BatchPart bp = new BatchPart()
                {
                    PART_ID = p.ID,
                    UNIT = EnumParser.GetEnumFiledValue(MeasurementType.箱).ToString(),
                    //PROJECT_ID = box.PROJECT_ID,
                    //PROJECT_ITEM_ID = box.PROJECT_ITEM_ID,
                    WAREHOUSE_ID = warehouseId,
                    //BATCH_NO = box.BATCH_NO,
                    //FURNACE_NO = box.FURNACE_NO,
                    BOX_NUMBER = box.BOX_CODE
                };
                bp = bp.QueryObject(sqlMapper, "SelectByParam");

                if (bp != null)
                {
                    PartStock ps = new PartStock() { BATCH_PART_ID = bp.ID, WAREHOUSE_ID = warehouseId };

                    ps = ps.QueryObject(sqlMapper, "SelectPartStock");
                    if (ps != null)
                    {
                        MessageInfo info = new MessageInfo();
                        info.ResultState = "Error";
                        info.Info = "当前箱号库存已存在!";
                        return Converter.Serialize(info);
                    }
                    else
                    {
                        MessageInfo info = new MessageInfo();
                        info.ResultState = "Succes";
                        info.Info = "该箱号为二次收货";
                        return Converter.Serialize(info);
                    }
                }

                MessageInfo infoReturn = new MessageInfo();
                infoReturn.ResultState = "Succes";
                infoReturn.Info = "";
                return Converter.Serialize(infoReturn);
            }
            catch (Exception ex)
            {
                RunTimeLogger.Debug(DateTime.Now.ToString() + ":" + ex.Message);
                MessageInfo infoReturn = new MessageInfo();
                infoReturn.ResultState = "Error";
                infoReturn.Info = ex.Message;
                return Converter.Serialize(infoReturn);
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static string PackageReceive( string documentNo,int userId, string strJson, int warehouseId)
        {
            try
            {
                #region 变量
                ReceiveOrderItem roi;
                IList<Part> partList = new List<Part>();
                List<PartLoc> locList = new List<PartLoc>();
                List<WareHouse> houseList = new List<WareHouse>();
                List<BoxInfo> boxList = Converter.Deserialize<List<BoxInfo>>(strJson);
                IList<ReceiveCheckOrderItem> rcoiList = new List<ReceiveCheckOrderItem>();

                WareHouse h = new WareHouse() { TYPE = EnumParser.GetEnumFiledValue(WareHouseType.仓库).ToString() };
                houseList = h.QueryList("SelectByParam").ToList<WareHouse>();
                
                Part pt = new Part() {WAREHOUSE_ID=warehouseId };
                partList = pt.QueryList("SelectByParam").ToList<Part>();

                PartLoc pl = new PartLoc() { WAREHOUSE_ID=warehouseId };
                locList = pl.QueryList("SelectByParam").ToList<PartLoc>();

                WareHouse house = houseList.FirstOrDefault(c => c.ID == warehouseId);
                #endregion

                ISqlMapper sqlMapper = Sql_Mapper.Instance();
                sqlMapper.BeginTransaction();
                try
                {
                    #region boxLIst
                    foreach (BoxInfo box in boxList)
                    {
                        Part p = partList.FirstOrDefault(c => c.PART_CODE == box.PART_CODE && c.WAREHOUSE_ID == warehouseId);

                        if (p == null)
                        {
                            sqlMapper.RollBackTransaction();
                            MessageInfo info = new MessageInfo();
                            info.ResultState = "Error";
                            info.Info = "零件号:" + box.PART_CODE + "不存在!" ;
                            return Converter.Serialize(info);
                        }

                        BatchPart bp = new BatchPart()
                        {
                            PART_ID = p.ID,
                            //SUPPLIER_ID = p.SUPPLIER_ID,
                            UNIT = EnumParser.GetEnumFiledValue(MeasurementType.箱).ToString(),
                            //PROJECT_ID = box.PROJECT_ID,
                            //PROJECT_ITEM_ID = box.PROJECT_ITEM_ID,
                            WAREHOUSE_ID = warehouseId,
                            //BATCH_NO = box.BATCH_NO,
                            //FURNACE_NO = box.FURNACE_NO,
                            BOX_NUMBER = box.BOX_CODE
                        };
                        bp = bp.QueryObject(sqlMapper, "SelectByParam");
                        if (bp == null)
                        {
                            bp = new BatchPart();
                            bp.PART_ID = p.ID;
                            bp.SUPPLIER_ID = p.SUPPLIER_ID;
                            bp.UNIT = EnumParser.GetEnumFiledValue(MeasurementType.箱).ToString();
                            bp.PROJECT_ID = box.PROJECT_ID;
                            bp.PROJECT_ITEM_ID = box.PROJECT_ITEM_ID;
                            bp.WAREHOUSE_ID = warehouseId;
                            bp.BATCH_NO = box.BATCH_NO;
                            bp.FURNACE_NO = box.FURNACE_NO;
                            bp.BOX_NUMBER = box.BOX_CODE;
                            bp.CREATE_TIME = DateTime.Now;
                            bp.CREATE_USER_ID = userId;
                            bp.ID = (int)bp.Save(sqlMapper);
                        }
                        else
                        {
                            PartStock ps = new PartStock() { BATCH_PART_ID = bp.ID,
                            WAREHOUSE_ID=warehouseId};

                            ps = ps.QueryObject(sqlMapper, "SelectPartStock");
                            if (ps != null)
                            {
                                sqlMapper.RollBackTransaction();
                                MessageInfo info = new MessageInfo();
                                info.ResultState = "Error";
                                info.Info = "箱号已存在:" + box.BOX_CODE;
                                return Converter.Serialize(info);
                            }
                        }
                        ReceiveCheckOrderItem rcoi = new ReceiveCheckOrderItem()
                        {
                            BATCH_PART_ID = bp.ID,
                            PLAN_QTY = box.QTY,
                            OUT_QTY = box.QTY,
                            STATUS = EnumParser.GetEnumFiledValue(Is_Finish.完成).ToString(),
                            ORDER_SOURCE_ID = 0,
                            DETAIL_TYPE = EnumParser.GetEnumFiledValue(In_Order_Type.供应商送货入库).ToString(),
                            OUT_LOC = string.Empty,
                            CREATE_TIME = DateTime.Now,
                            CREATE_USER_ID = userId,
                            CHECK_QTY=box.QTY,
                            PART_ID = p.ID
                        };
                        rcoiList.Add(rcoi);
                    }
                    #endregion

                    #region 收货单
                    OrderNum OM = new OrderNum();
                    OM.DOCUMENT_NO = documentNo;
                    OM.ORDER_CREATE_TIME = DateTime.Now;
                    OM.CREATE_TIME = DateTime.Now;
                    OM.CREATE_USER_ID = userId;
                    OM.WAREHOUSE_ID = warehouseId;
                    OM.ORDER_NO = WareHouseServices.GetSerialNo(house.WAREHOUSE_CODE, EnumParser.GetEnumFiledValue(OrderNo.收货单号).ToString());

                    OrderBusiness business = new OrderBusiness();
                    business.CREATE_TIME = DateTime.Now;
                    business.ORDER_END_TIME = DateTime.Now;
                    business.CREATE_USER_ID = userId;
                    business.DRIVER_NAME = string.Empty;
                    business.DOCK = string.Empty;
                    business.TRUCK_NO = string.Empty;
                    business.ORDER_STATE = EnumParser.GetEnumFiledValue(Is_Finish.完成).ToString();
                    business.PART_OWNER = EnumParser.GetEnumFiledValue(PartOwner.帐内).ToString();
                    business.ORDER_TYPE = EnumParser.GetEnumFiledValue(OrderType.供应商送货收货).ToString();
                    business.USER_ID = userId;
                    #endregion

                    #region 入库单
                    OrderNum omInstorage = new OrderNum();
                    omInstorage.DOCUMENT_NO = documentNo;
                    omInstorage.ORDER_CREATE_TIME = DateTime.Now;
                    omInstorage.CREATE_TIME = DateTime.Now;
                    omInstorage.CREATE_USER_ID = userId;
                    omInstorage.WAREHOUSE_ID = warehouseId;
                    omInstorage.ORDER_NO = WareHouseServices.GetSerialNo(house.WAREHOUSE_CODE, EnumParser.GetEnumFiledValue(OrderNo.入库单号).ToString());

                    OrderBusiness busInstorage = new OrderBusiness();
                    busInstorage.CREATE_TIME = DateTime.Now;
                    busInstorage.CREATE_USER_ID = userId;
                    busInstorage.DRIVER_NAME = string.Empty;
                    busInstorage.ORDER_END_TIME = DateTime.Now;
                    busInstorage.DOCK = string.Empty;
                    busInstorage.TRUCK_NO = string.Empty;
                    busInstorage.ORDER_STATE = EnumParser.GetEnumFiledValue(Is_Finish.完成).ToString();
                    busInstorage.PART_OWNER = EnumParser.GetEnumFiledValue(PartOwner.帐内).ToString();
                    busInstorage.ORDER_TYPE = EnumParser.GetEnumFiledValue(OrderType.供应商送货入库).ToString();
                    busInstorage.USER_ID = userId;
                    #endregion

                    int busReceiveId = busServices.SaveOrderBusiness(sqlMapper, OM, business);

                    int busInstorageId = busServices.SaveOrderBusiness(sqlMapper, omInstorage, busInstorage);

                    foreach (ReceiveCheckOrderItem rcoi in rcoiList)
                    {
                        rcoi.ORDER_SOURCE_ID = 0;
                        rcoi.ORDER_BUSINESS_ID = busReceiveId;
                        int checkId = (int)rcoi.Save(sqlMapper);

                        PartLoc loc = locList.FirstOrDefault(c => c.PART_ID == rcoi.PART_ID && c.WAREHOUSE_ID == warehouseId
                            && c.LOC_TYPE == EnumParser.GetEnumFiledValue(LocType.正常库位).ToString());

                        if (loc == null)
                        {
                            sqlMapper.RollBackTransaction();
                            MessageInfo info = new MessageInfo();
                            info.ResultState = "Error";
                            info.Info = "零件库位错误！";
                            return Converter.Serialize(info);
                        }


                        roi = new ReceiveOrderItem();
                        roi.ORDER_BUSINESS_ID = busInstorageId;
                        roi.PLAN_IN_QTY = rcoi.CHECK_QTY;
                        roi.REAL_IN_QTY = rcoi.CHECK_QTY;
                        roi.TYPE = EnumParser.GetEnumFiledValue(OrderType.供应商送货入库).ToString();
                        roi.BATCH_PART_ID = rcoi.BATCH_PART_ID;
                        roi.RECOMMEND_LOC_ID = loc.LOC_ID;
                        roi.LOCATION_ID = loc.LOC_ID;
                        roi.ORDER_SOURCE_ID = checkId;
                        roi.STATE = EnumParser.GetEnumFiledValue(IsInStorage.已入库).ToString();
                        roi.CREATE_TIME = DateTime.Now;
                        roi.CREATE_USER_ID = userId;
                        roi.ORDER_SOURCE_ID = checkId;

                        int index = (int)roi.Save(sqlMapper);
                        if (index <= 0)
                        {
                            sqlMapper.RollBackTransaction();
                            MessageInfo info = new MessageInfo();
                            info.ResultState = "Error";
                            info.Info = "库存保存失败！";
                            return Converter.Serialize(info);
                        }
                        LtUser loginuser = new LtUser() { ID = userId, House = house };

                        StockServices Stock = new StockServices();
                        Stock.StockOprateIn(sqlMapper, roi, busInstorage, loginuser);
                    }

                    sqlMapper.CommitTransaction();

                    MessageInfo infoStr = new MessageInfo();
                    infoStr.ResultState = "Succes";
                    infoStr.Info = string.Empty;
                    return Converter.Serialize(infoStr);
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
                MessageInfo info = new MessageInfo();
                info.ResultState = "Error";
                info.Info = ex.Message;
                return Converter.Serialize(info);
            }
        }

    }
}
