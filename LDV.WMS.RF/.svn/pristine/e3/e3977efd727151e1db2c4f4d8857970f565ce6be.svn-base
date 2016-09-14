using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;
using System.Data;
using System.Configuration;

namespace LDV.WMS.LED
{
    public class GDIImageOrder
    {
        //private static int count = 1;//总页数
        /// <summary>
        /// 字体 
        /// </summary>
        string ImageFontFamily =  "微软雅黑";
        int ImageHeight = 160;
        int ImageWidth = 320;
          /// <summary>
            /// 图片字体大小
          /// </summary>
        int ImageFontSize = 12;
        int yc = 10;
        int xc = 10;
        private static float left = 2;
        private static float top = 2;
        private static float textHeight = 22;
        private static float orderDateToPartCode = 100;
        private static float partCodeToType = orderDateToPartCode + 150;
        private static string orderQty = "0";
        private static string orderCount = "0";
        public static int page = 1;
        public string ip = "";
        /// <summary>
        /// 未完成数量
        /// </summary>
        PointF pfOrderQtyText = new PointF(left, top);
        /// <summary>
        /// 未完成数据值
        /// </summary>
        PointF pfOrderQtyNum = new PointF(left+95, top);
        /// <summary>
        /// 未完成条目数
        /// </summary>
        PointF pfOrderListText = new PointF(left + 160, top);
        /// <summary>
        /// 未完成条目数值
        /// </summary>
        PointF pfOrderListQty = new PointF(left+160+105, top);
        /// <summary>
        /// 订单日期
        /// </summary>
        PointF pfOrderDate = new PointF(left, textHeight + top);
        /// <summary>
        /// 零件号
        /// </summary>
        PointF pfPartCode = new PointF(left+orderDateToPartCode, textHeight + top);
        /// <summary>
        /// 状态
        /// </summary>
        PointF pfOrderType = new PointF(left+partCodeToType, textHeight + top);

        public void setOrderCount(DataTable orderList)
        {
            if (orderList == null)
                return;
            int qty = 0;
            for (int i = 0; i < orderList.Rows.Count; i++)
            {
                qty+=int.Parse(orderList.Rows[i]["qty"].ToString());

            }
            orderQty = qty.ToString();
            orderCount = orderList.Rows.Count.ToString();
        }
        public string getOrderValue(DataTable orderList,string name,int rowsCount)
        {
            string value= orderList.Rows[rowsCount][name].ToString();
          
            return value;
        }
        /// <summary>
        /// 绘制表格的方法
        /// </summary>
        public  void drawWang(DataTable orderList )
        {

            MemoryStream ms = new MemoryStream();
            //实例化Bitmap对象
            Bitmap objbitmap = new Bitmap(ImageWidth, ImageHeight, PixelFormat.Format24bppRgb);

            //实例化Graphics类
            Graphics g = Graphics.FromImage(objbitmap);
            Rectangle r = new Rectangle(0, 0, ImageWidth, ImageHeight);

            g.FillRectangle(Brushes.Black, r);//背景  

            #region 1  
           
          //  Color.Green;  绿色
          //  Color.Yellow; 黄色
            //画列名
            g.DrawString("未完成数量", new Font(ImageFontFamily, ImageFontSize), new SolidBrush(Color.Red), pfOrderQtyText);          
            g.DrawString("未完成条目数", new Font(ImageFontFamily, ImageFontSize), new SolidBrush(Color.Red), pfOrderListText);
            if (page == 1)
            {
                setOrderCount(orderList);
            }
            g.DrawString(orderQty, new Font(ImageFontFamily, ImageFontSize), new SolidBrush(Color.Red), pfOrderQtyNum);
            g.DrawString(orderCount, new Font(ImageFontFamily, ImageFontSize), new SolidBrush(Color.Red), pfOrderListQty);

            g.DrawString("订单日期", new Font(ImageFontFamily, ImageFontSize), new SolidBrush(Color.Red), pfOrderDate);
            g.DrawString("零件号", new Font(ImageFontFamily, ImageFontSize), new SolidBrush(Color.Red), pfPartCode);
            g.DrawString("状态", new Font(ImageFontFamily, ImageFontSize), new SolidBrush(Color.Red), pfOrderType);
            
            #region 实现内容分页
            int j = 1;
            for (int i = 0; i < 5 && (i + (page - 1) * 5) < orderList.Rows.Count; i++)
            {
                SolidBrush textColor;
                string orderType=getOrderValue(orderList, "type", i + (page - 1) * 5);
                if (orderType == "OP")
                {
                    textColor = new SolidBrush(Color.Yellow);
                    orderType = "待包装";
                }
                else
                {
                    textColor = new SolidBrush(Color.LawnGreen);
                    orderType = "待上架";
                }

                PointF pfOrder = new PointF(left, textHeight * (j + 1) + top);
                g.DrawString(getOrderValue(orderList, "bill_date", i + (page - 1) * 5), new Font(ImageFontFamily, ImageFontSize), textColor, pfOrder);

                PointF pfPart = new PointF(left + orderDateToPartCode, textHeight * (j + 1) + top);
                g.DrawString(getOrderValue(orderList, "item_code", i + (page - 1) * 5), new Font(ImageFontFamily, ImageFontSize), textColor, pfPart);

                PointF pfType = new PointF(left + partCodeToType, textHeight * (j + 1) + top);
                g.DrawString(orderType, new Font(ImageFontFamily, ImageFontSize), textColor, pfType);

                j++;
            }
            #endregion

            #endregion
            string strPath = ConfigurationManager.AppSettings["Path"].ToString(); 
            //System.Environment.CurrentDirectory.ToString();
            objbitmap.Save(strPath + "\\" + ip + ".bmp", ImageFormat.Bmp);         


            //释放资源 
            objbitmap.Dispose();
            objbitmap = null;
            g.Dispose();
            g = null;
            GC.Collect();
        }

        /// <summary>
        /// 绘制表格的方法
        /// </summary>
        public void drawWang()
        {

            MemoryStream ms = new MemoryStream();
            //实例化Bitmap对象
            Bitmap objbitmap = new Bitmap(ImageWidth, ImageHeight, PixelFormat.Format24bppRgb);

            //实例化Graphics类
            Graphics g = Graphics.FromImage(objbitmap);
            Rectangle r = new Rectangle(0, 0, ImageWidth, ImageHeight);

            g.FillRectangle(Brushes.Black, r);//背景  

            #region 1

            //  Color.Green;  绿色
            //  Color.Yellow; 黄色
            //画列名
            g.DrawString("未完成数量", new Font(ImageFontFamily, ImageFontSize), new SolidBrush(Color.Red), pfOrderQtyText);
            g.DrawString("未完成条目数", new Font(ImageFontFamily, ImageFontSize), new SolidBrush(Color.Red), pfOrderListText);
           
            g.DrawString("0", new Font(ImageFontFamily, ImageFontSize), new SolidBrush(Color.Red), pfOrderQtyNum);
            g.DrawString("0", new Font(ImageFontFamily, ImageFontSize), new SolidBrush(Color.Red), pfOrderListQty);

            g.DrawString("订单日期", new Font(ImageFontFamily, ImageFontSize), new SolidBrush(Color.Red), pfOrderDate);
            g.DrawString("零件号", new Font(ImageFontFamily, ImageFontSize), new SolidBrush(Color.Red), pfPartCode);
            g.DrawString("状态", new Font(ImageFontFamily, ImageFontSize), new SolidBrush(Color.Red), pfOrderType);
          

            #endregion
            string strPath = ConfigurationManager.AppSettings["Path"].ToString();
            //System.Environment.CurrentDirectory.ToString();
            objbitmap.Save(strPath + "\\" + ip + ".bmp", ImageFormat.Bmp);


            //释放资源 
            objbitmap.Dispose();
            objbitmap = null;
            g.Dispose();
            g = null;
            GC.Collect();
        }

    }
}
