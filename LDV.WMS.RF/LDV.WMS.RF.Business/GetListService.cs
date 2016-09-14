using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using LDV.WMS.RF.DataMapper;
using LDV.WMS.RF.Utility;

namespace LDV.WMS.RF.Business
{
    public class GetListService
    {
        #region 入库数据同步接口
        public static string Get_OrderList(string date)
        {
            string jsonStr = string.Empty;

            //查询主表数据
            SqlParamSet para = new SqlParamSet();
            para.AddParam("DATE", date);
            var dtRcvDoc = VWmsRcvDoc.QueryDataTable("SelectOrder", para.GetParams());
            var orderList = GetOrder(dtRcvDoc);

            //查询子表数据
            SqlParamSet para1 = new SqlParamSet();
            para1.AddParam("DATE", date);
            var dtRcvdocItem = VWmsRcvDocAct.QueryDataTable("SelectOrderItem", para1.GetParams());
            var orderItemList = GetOrderItem(dtRcvdocItem);

            //序列化JSON
            RcvDocJson jsonList = new RcvDocJson();
            jsonList.orderList = orderList;
            jsonList.orderlistentry = orderItemList;
            jsonStr = JsonSerializationHandler.Serialize<RcvDocJson>(jsonList);

            return jsonStr;
        }
        #endregion

        #region 出库装箱数据同步接口
        public static string Get_PackingList(string date)
        {
            string jsonStr = string.Empty;

            //查询主表数据
            SqlParamSet para = new SqlParamSet();
            para.AddParam("DATE", date);
            var dtPickTicket = VWmsPickTicket.QueryDataTable("SelectPackOrder", para.GetParams());
            var packOrderList = GetPackOrder(dtPickTicket);

            //查询子表数据
            SqlParamSet para1 = new SqlParamSet();
            para1.AddParam("DATE", date);
            var dtPickTicketItem = VWmsPickTicketAct.QueryDataTable("SelectPackOrderItem", para1.GetParams());
            var packOrderItemList = GetPackOrderItem(dtPickTicketItem);

            //序列化JSON
            PickTicketJson jsonList = new PickTicketJson();
            jsonList.packingList = packOrderList;
            jsonList.packinglistentry = packOrderItemList;
            jsonStr = JsonSerializationHandler.Serialize<PickTicketJson>(jsonList);

            return jsonStr;
        }
        #endregion

        #region 入库数据转换
        private static List<OrderJson> GetOrder(DataTable dtRcvDoc)
        {
            List<OrderJson> orderList = new List<OrderJson>();

            for (int i = 0; i < dtRcvDoc.Rows.Count; i++)
            {
                OrderJson order = new OrderJson();
                order.id = dtRcvDoc.Rows[i]["id"].ToString();
                order.orderno = dtRcvDoc.Rows[i]["orderno"].ToString();
                order.supplierno = dtRcvDoc.Rows[i]["supplierno"].ToString();
                order.supplierIname = dtRcvDoc.Rows[i]["supplierIname"].ToString();
                order.orderdate = dtRcvDoc.Rows[i]["orderdate"].ToString();
                order.date = dtRcvDoc.Rows[i]["date"].ToString();
                orderList.Add(order);
            }
            return orderList;
        }

        private static List<OrderItemJson> GetOrderItem(DataTable dtRcvdocItem)
        {
            List<OrderItemJson> orderItemList = new List<OrderItemJson>();
            for (int i = 0; i < dtRcvdocItem.Rows.Count; i++)
            {
                OrderItemJson order = new OrderItemJson();
                order.id = dtRcvdocItem.Rows[i]["id"].ToString();
                order.ids = dtRcvdocItem.Rows[i]["ids"].ToString();
                order.Itemno = dtRcvdocItem.Rows[i]["Itemno"].ToString();
                order.itemname = dtRcvdocItem.Rows[i]["itemname"].ToString();
                order.qty = dtRcvdocItem.Rows[i]["qty"].ToString();
                order.mpq = dtRcvdocItem.Rows[i]["mpq"].ToString();
                orderItemList.Add(order);
            }
            return orderItemList;
        }
        #endregion

        #region 出库数据转换
        private static List<PackOrderJson> GetPackOrder(DataTable dtPickTicket)
        {
            List<PackOrderJson> orderList = new List<PackOrderJson>();

            for (int i = 0; i < dtPickTicket.Rows.Count; i++)
            {
                PackOrderJson order = new PackOrderJson();
                order.id = dtPickTicket.Rows[i]["id"].ToString();
                order.packingno = dtPickTicket.Rows[i]["packingno"].ToString();
                order.customerno = dtPickTicket.Rows[i]["customerno"].ToString();
                order.customername = dtPickTicket.Rows[i]["customername"].ToString();
                order.date = dtPickTicket.Rows[i]["date"].ToString();
                orderList.Add(order);
            }
            return orderList;
        }

        private static List<PackOrderItemJson> GetPackOrderItem(DataTable dtPickTicketItem)
        {
            List<PackOrderItemJson> orderItemList = new List<PackOrderItemJson>();

            for (int i = 0; i < dtPickTicketItem.Rows.Count; i++)
            {
                PackOrderItemJson orderItem = new PackOrderItemJson();
                orderItem.id = dtPickTicketItem.Rows[i]["id"].ToString();
                orderItem.ids = dtPickTicketItem.Rows[i]["ids"].ToString();
                orderItem.boxno = dtPickTicketItem.Rows[i]["boxno"].ToString();
                orderItem.boxlineno = dtPickTicketItem.Rows[i]["boxlineno"].ToString();
                orderItem.Itemid = dtPickTicketItem.Rows[i]["Itemid"].ToString();
                orderItem.itemname = dtPickTicketItem.Rows[i]["itemname"].ToString();
                orderItem.qty = dtPickTicketItem.Rows[i]["qty"].ToString();
                orderItem.checkuser = dtPickTicketItem.Rows[i]["checkuser"].ToString();
                orderItemList.Add(orderItem);
            }
            return orderItemList;
        }
        #endregion

        #region 二维码数据同步接口
        public static string Get_QRCodeList(string date)
        {
            string jsonStr = string.Empty;
            //查询数据
            SqlParamSet para = new SqlParamSet();
            para.AddParam("DATE", date);
            var dtQrCode = LdvQrCode.QueryDataTable("SelectQRCode", para.GetParams());
            var qrCodeList = GetQRCode(dtQrCode);

            //序列化JSON
            QrCodeJson jsonList = new QrCodeJson();
            jsonList.qrcodeList = qrCodeList;
            jsonStr = JsonSerializationHandler.Serialize<QrCodeJson>(jsonList);
            return jsonStr;
        }

        #endregion

        #region 二维码数据转换
        private static List<QrOrderJson> GetQRCode(DataTable dtQrCode)
        {
            List<QrOrderJson> qrCodeList = new List<QrOrderJson>();

            for (int i = 0; i < dtQrCode.Rows.Count; i++)
            {
                QrOrderJson order = new QrOrderJson();
                order.qrcode = dtQrCode.Rows[i]["qrcode"].ToString();
                qrCodeList.Add(order);
            }
            return qrCodeList;
        }
        #endregion

    }
}