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
    public class GDIImageThree
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
        private static float orderToPlanCount = 120;
        private static float PlanCountToPickCount = orderToPlanCount + 70;
        private static float PickCountToEndCount = PlanCountToPickCount + 65;
        private static string orderQty = "0";
        private static string orderCount = "0";
        public static int page = 1;
        public string ip = "";
        public string ip2 = "";

        /// <summary>
        /// 未完成订单数
        /// </summary>
        PointF pfOrderCount = new PointF(left, top);
        /// <summary>
        /// 未完成订单数
        /// </summary>
        PointF pfOrderCountQty = new PointF(left+105, top);
        /// <summary>
        /// 未完成条数
        /// </summary>
        PointF pfOrderList = new PointF(left + 160, top);
        /// <summary>
        /// 未完成条数
        /// </summary>
        PointF pfOrderListQty = new PointF(left+160+85, top);
        /// <summary>
        /// 订单号
        /// </summary>
        PointF pfOrderNum = new PointF(left, textHeight + top);
        /// <summary>
        /// 条目数
        /// </summary>
        PointF pfOrderPlanCount = new PointF(left+orderToPlanCount, textHeight + top);
        /// <summary>
        /// 拣货数
        /// </summary>
        PointF pfOrderPickCount = new PointF(left+PlanCountToPickCount, textHeight + top);
        /// <summary>
        /// 核料数
        /// </summary>
        PointF pfOrderPickEndCount = new PointF(left+PickCountToEndCount, textHeight + top);
        public void setOrderCount(DataTable orderList)
        {
            if (orderList == null)
                return;
            int qty = 0;
            for (int i = 0; i < orderList.Rows.Count; i++)
            {
                qty += (int.Parse(orderList.Rows[i]["pp"].ToString()) - int.Parse(orderList.Rows[i]["ed"].ToString()));

            }
            orderQty = qty.ToString();
            orderCount = orderList.Rows.Count.ToString();
        }
        public string getOrderValue(DataTable orderList, string name, int rowsCount)
        {
            string value = orderList.Rows[rowsCount][name].ToString();

            return value;
        }
        /// <summary>
        /// 绘制表格的方法
        /// </summary>
        public void drawWang(DataTable orderList)
        {


            MemoryStream ms = new MemoryStream();
            //实例化Bitmap对象
            Bitmap objbitmap = new Bitmap(ImageWidth, ImageHeight, PixelFormat.Format24bppRgb);

            //实例化Graphics类
            Graphics g = Graphics.FromImage(objbitmap);
            Rectangle r = new Rectangle(0, 0, ImageWidth, ImageHeight);

            g.FillRectangle(Brushes.Black, r);//背景  

            #region 1  
           
          //  Color.Green;  红色
          //  Color.Yellow; 黄色
            //画列名
            g.DrawString("未完成订单数", new Font(ImageFontFamily, ImageFontSize), new SolidBrush(Color.Red), pfOrderCount);           
            g.DrawString("未完成条数", new Font(ImageFontFamily, ImageFontSize), new SolidBrush(Color.Red), pfOrderList);
           
            if (page == 1)
            {
                setOrderCount(orderList);
            }
            g.DrawString(orderCount, new Font(ImageFontFamily, ImageFontSize), new SolidBrush(Color.Red), pfOrderCountQty);
            g.DrawString(orderQty, new Font(ImageFontFamily, ImageFontSize), new SolidBrush(Color.Red), pfOrderListQty);

            g.DrawString("订单号", new Font(ImageFontFamily, ImageFontSize), new SolidBrush(Color.Red), pfOrderNum);
            g.DrawString("条目数", new Font(ImageFontFamily, ImageFontSize), new SolidBrush(Color.Red), pfOrderPlanCount);
            g.DrawString("拣货条", new Font(ImageFontFamily, ImageFontSize), new SolidBrush(Color.Red), pfOrderPickCount);
            g.DrawString("核料条", new Font(ImageFontFamily, ImageFontSize), new SolidBrush(Color.Red), pfOrderPickEndCount);
            
            #region 实现内容分页
            int j = 1;
            for (int i = 0; i < 5 && (i + (page - 1) * 5) < orderList.Rows.Count; i++)
            {
                SolidBrush textColor;
                string planCount =  getOrderValue(orderList, "pp", i + (page - 1) * 5);
                string pickCount =  getOrderValue(orderList, "pt", i + (page - 1) * 5);
                if (planCount == pickCount)
                {
                    textColor = new SolidBrush(Color.LawnGreen);
                }
                else
                {
                    textColor = new SolidBrush(Color.Yellow);
                }

                PointF pfOrder = new PointF(left, textHeight*(j+1) + top);
                g.DrawString(getOrderValue(orderList, "pickCode", i + (page - 1) * 5), new Font(ImageFontFamily, ImageFontSize), textColor, pfOrder);

                PointF pfOrderPlan = new PointF(left + orderToPlanCount, textHeight * (j + 1) + top);
                g.DrawString(getOrderValue(orderList, "pp", i + (page - 1) * 5), new Font(ImageFontFamily, ImageFontSize), textColor, pfOrderPlan);

                PointF pfOrderPick = new PointF(left + PlanCountToPickCount, textHeight * (j + 1) + top);
                g.DrawString(getOrderValue(orderList, "pt", i + (page - 1) * 5), new Font(ImageFontFamily, ImageFontSize), textColor, pfOrderPick);

                PointF pfOrderEnd = new PointF(left + PickCountToEndCount, textHeight * (j + 1) + top);
                g.DrawString(getOrderValue(orderList, "ed", i + (page - 1) * 5), new Font(ImageFontFamily, ImageFontSize), textColor, pfOrderEnd);

                j++;
            }
            #endregion

            #endregion
            string strPath = ConfigurationManager.AppSettings["Path"].ToString(); 
            //System.Environment.CurrentDirectory.ToString();
            objbitmap.Save(strPath + "\\" + ip + ".bmp", ImageFormat.Bmp);
            objbitmap.Save(strPath + "\\" + ip2 + ".bmp", ImageFormat.Bmp);


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

            //  Color.Green;  红色
            //  Color.Yellow; 黄色
            //画列名
            g.DrawString("未完成订单数", new Font(ImageFontFamily, ImageFontSize), new SolidBrush(Color.Red), pfOrderCount);
            g.DrawString("未完成条数", new Font(ImageFontFamily, ImageFontSize), new SolidBrush(Color.Red), pfOrderList);

            g.DrawString("0", new Font(ImageFontFamily, ImageFontSize), new SolidBrush(Color.Red), pfOrderCountQty);
            g.DrawString("0", new Font(ImageFontFamily, ImageFontSize), new SolidBrush(Color.Red), pfOrderListQty);

            g.DrawString("订单号", new Font(ImageFontFamily, ImageFontSize), new SolidBrush(Color.Red), pfOrderNum);
            g.DrawString("条目数", new Font(ImageFontFamily, ImageFontSize), new SolidBrush(Color.Red), pfOrderPlanCount);
            g.DrawString("拣货条", new Font(ImageFontFamily, ImageFontSize), new SolidBrush(Color.Red), pfOrderPickCount);
            g.DrawString("核料条", new Font(ImageFontFamily, ImageFontSize), new SolidBrush(Color.Red), pfOrderPickEndCount);


            #endregion
            string strPath = ConfigurationManager.AppSettings["Path"].ToString();
            //System.Environment.CurrentDirectory.ToString();
            objbitmap.Save(strPath + "\\" + ip + ".bmp", ImageFormat.Bmp);
            objbitmap.Save(strPath + "\\" + ip2 + ".bmp", ImageFormat.Bmp);


            //释放资源 
            objbitmap.Dispose();
            objbitmap = null;
            g.Dispose();
            g = null;
            GC.Collect();
        }
    }
}
