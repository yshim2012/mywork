using System;
using System.Collections.Generic;
using System.Linq;
using System.Text; 
using System.Collections;
using System.Threading;
using System.Configuration;
using System.Drawing;
using System.Drawing.Imaging;
using System.Data;

namespace LDV.WMS.LED
{
    class MainClass
    {
        private const int RETURN_ERROR_AERETYPE = 0xF7;//区域类型错误，在添加、删除图文区域文件时区域类型出错返回此类型错误。 
        private const int RETURN_ERROR_RA_SCREENNO = 0xF8;  //已经有该显示屏信息。如要重新设定请先DeleteScreen删除该显示屏再添加； 
        private const int RETURN_ERROR_NOFIND_AREAFILE = 0xF9; //没有找到有效的区域文件(图文区域)； 
        private const int RETURN_ERROR_NOFIND_AREA = 0xFA;  //没有找到有效的显示区域；可以使用AddScreenProgramBmpTextArea添加区域信息。 
        private const int RETURN_ERROR_NOFIND_PROGRAM = 0xFB;  //没有找到有效的显示屏节目；可以使用AddScreenProgram函数添加指定节目 
        private const int RETURN_ERROR_NOFIND_SCREENNO = 0xFC;  //系统内没有查找到该显示屏；可以使用AddScreen函数添加显示屏 
        private const int RETURN_ERROR_NOW_SENDING = 0xFD; //系统内正在向该显示屏通讯，请稍后再通讯；
        private const int RETURN_ERROR_OTHER = 0xFF; //其它错误； 
        private const int RETURN_NOERROR = 0; //没有错误 
        public static int  Page =1  ;
        public static string loadType = "0";
        private static Hashtable IpLoadType = new Hashtable();//保存LED屏是否加载

        private static bool IsBussey = false;//是否在操作LED屏（自然结束或后计数线程中断threadOpreatingLed时，将IsBussey置为false）
        private static bool IsSetSreen = false;//是否已经设置过屏参

        private string OperatingLedIp;//正在操作的LED屏IP
        private LEDParam OperatingLedParam;//正在操作的屏参
        private LedDTO OperatingLedDTO;//正在发送数据的屏

        private static Hashtable mapLedInfo = new Hashtable(); //保存屏参信息
        private static Hashtable mapData = new Hashtable();//保存所有屏的当前数据
        private static DataTable RcvDoc= new DataTable();
        private static DataTable PickDoc = new DataTable ();
        private Thread threadOpreatingLed;//正在操作LED屏的线程
        private Thread threadCount; //计数的线程
        private static string ledIP1 = ConfigurationManager.AppSettings["LedIP1"].ToString();
        private static string ledIP2 = ConfigurationManager.AppSettings["LedIP2"].ToString();
        private static string ledIP3 = ConfigurationManager.AppSettings["LedIP3"].ToString();
        private static string ledIP1IsOpen = ConfigurationManager.AppSettings["ledIP1IsOpen"].ToString();
        private static string ledIP2IsOpen = ConfigurationManager.AppSettings["ledIP2IsOpen"].ToString();
        private static string ledIP3IsOpen = ConfigurationManager.AppSettings["ledIP3IsOpen"].ToString();
        /// <summary>
        /// 加载屏参
        /// </summary>
        private void LoadAllScrean()
        {
            #region 加载新屏
            PrintOutMess("开始设置新增屏的屏参");
            if (ledIP1IsOpen == "1")
            {
                LEDParam led = new LEDParam();
                led.LedNo = 1;
                led.ScreenIp = ledIP1;
                led.Length = 320;
                led.Height = 160;
                SetLedScreen(led);
            }
            if (ledIP2IsOpen == "1")
            {
                LEDParam led2 = new LEDParam();
                led2.LedNo = 2;
                led2.ScreenIp = ledIP2;
                led2.Length = 320;
                led2.Height = 160;
                SetLedScreen(led2);               
            }
            if (ledIP3IsOpen == "1")
            {
                LEDParam led3 = new LEDParam();
                led3.LedNo = 3;
                led3.ScreenIp = ledIP3;
                led3.Length = 320;
                led3.Height = 160;
                SetLedScreen(led3);
               
            }

            PrintOutMess("结束设置新增屏的屏参");
            #endregion

        }

        /// <summary>
        /// Led 错误信息判断
        /// </summary>
        /// <param name="szfunctionName"></param>
        /// <param name="nResult"></param>
        /// <returns></returns>
        public string GetErrorMessage(string szfunctionName, int nResult)
        {
            string ErrorMess = string.Empty;
            string szResult = string.Empty;
            //DateTime dt = DateTime.Now;
            szResult = szfunctionName + "返回结果：";
            switch (nResult)
            {
                case RETURN_ERROR_AERETYPE:
                    ErrorMess += szResult + "区域类型错误，在添加、删除图文区域文件时区域类型出错返回此类型错误。\r\n";
                    break;
                case RETURN_ERROR_RA_SCREENNO:
                    ErrorMess += szResult + "已经有该显示屏信息。如要重新设定请先DeleteScreen删除该显示屏再添加\r\n";
                    break;
                case RETURN_ERROR_NOFIND_AREAFILE:
                    ErrorMess += szResult + "没有找到有效的区域文件(图文区域)\r\n";
                    break;
                case RETURN_ERROR_NOFIND_AREA:
                    ErrorMess += szResult + "没有找到有效的显示区域可以使用AddScreenProgramBmpTextArea添加区域信息。\r\n";
                    break;
                case RETURN_ERROR_NOFIND_PROGRAM:
                    ErrorMess += szResult + "没有找到有效的显示屏节目可以使用AddScreenProgram函数添加指定节目\r\n";
                    break;
                case RETURN_ERROR_NOFIND_SCREENNO:
                    ErrorMess += szResult + "系统内没有查找到该显示屏可以使用AddScreen函数添加显示屏\r\n";
                    break;
                case RETURN_ERROR_NOW_SENDING:
                    ErrorMess += szResult + "系统内正在向该显示屏通讯，请稍后再通讯\r\n";
                    break;
                case RETURN_ERROR_OTHER:
                    ErrorMess += szResult + "其它错误\r\n";
                    break;
                case RETURN_NOERROR:
                    ErrorMess += szResult + "函数执行/通讯成功\r\n";
                    break;
                case 0x01:
                    ErrorMess += szResult + "通讯错误\r\n";
                    break;
                case 0x02:
                    ErrorMess += szResult + "通讯错误\r\n";
                    break;
                case 0x03:
                    ErrorMess += szResult + "通讯错误\r\n";
                    break;
                case 0x04:
                    ErrorMess += szResult + "通讯错误\r\n";
                    break;
                case 0x05:
                    ErrorMess += szResult + "通讯错误\r\n";
                    break;
                case 0x06:
                    ErrorMess += szResult + "通讯错误\r\n";
                    break;
                case 0x07:
                    ErrorMess += szResult + "通讯错误\r\n";
                    break;
                case 0x08:
                    ErrorMess += szResult + "通讯错误\r\n";
                    break;
                case 0x09:
                    ErrorMess += szResult + "通讯错误\r\n";
                    break;
                case 0x0A:
                    ErrorMess += szResult + "通讯错误\r\n";
                    break;
                case 0x0B:
                    ErrorMess += szResult + "通讯错误\r\n";
                    break;
                case 0x0C:
                    ErrorMess += szResult + "通讯错误\r\n";
                    break;
                case 0x0D:
                    ErrorMess += szResult + "通讯错误\r\n";
                    break;
                case 0x0E:
                    ErrorMess += szResult + "通讯错误\r\n";
                    break;
                case 0x0F:
                    ErrorMess += szResult + "通讯错误\r\n";
                    break;
                case 0x10:
                    ErrorMess += szResult + "通讯错误\r\n";
                    break;
                case 0x11:
                    ErrorMess += szResult + "通讯错误\r\n";
                    break;
                case 0x12:
                    ErrorMess += szResult + "通讯错误\r\n";
                    break;
                case 0x13:
                    ErrorMess += szResult + "通讯错误\r\n";
                    break;
                case 0x14:
                    ErrorMess += szResult + "通讯错误\r\n";
                    break;
                case 0x15:
                    ErrorMess += szResult + "通讯错误\r\n";
                    break;
                case 0x16:
                    ErrorMess += szResult + "通讯错误\r\n";
                    break;
                case 0x17:
                    ErrorMess += szResult + "通讯错误\r\n";
                    break;
                case 0x18:
                    ErrorMess += szResult + "通讯错误\r\n";
                    break;
                case 0xFE:
                    ErrorMess += szResult + "通讯错误\r\n";
                    break;
            }

            return ErrorMess;

        }
        /// <summary>
        /// 输出信息
        /// </summary>
        /// <param name="Mess"></param>
        private void PrintOutMess(string Mess)
        {
            Console.WriteLine(DateTime.Now.ToString() + "\t" + Mess);
            RunTimeLogger.Debug(Mess);
        }
        /// <summary>
        /// 主方法
        /// </summary>
        public void RunExc()
        {
            try
            {
                LoadAllScrean(); //加载屏参
                 SendDataToLed();//发送数据
            }
            catch (Exception ex)
            {
                 PrintOutMess("RunExc()发生异常：" + ex.Message);
            }
        }
    
        /// <summary>
        /// 发送数据
        /// </summary>
        private void SendDataToLed()
        {
            try
            {
                PrintOutMess("开始发送数据");

                //threadOpreatingLed = new Thread(new ThreadStart(send));
                if (Page == 1)
                {
                    if (ledIP1IsOpen == "1")
                    {
                        RcvDoc = CC.Singleton().service().getRvcDoc();
                        GDIImageOrder.page = 1;
                    }
                    if (ledIP2IsOpen == "1" || ledIP3IsOpen == "1")
                    {
                        PickDoc = CC.Singleton().service().GetPickDoc();
                        GDIImageThree.page = 1;
                    }
                    
                }

                if (RcvDoc.Rows.Count > 0)
                {
                    if (ledIP1IsOpen == "1")
                    {
                        if ((GDIImageOrder.page - 1) * 5 >= RcvDoc.Rows.Count)
                        {
                            GDIImageOrder.page = 1;
                        }
                        GDIImageOrder gt = new GDIImageOrder();
                        gt.ip = ledIP1;
                        gt.drawWang(RcvDoc);
                        GDIImageOrder.page++;
                    }
                }
                else
                {
                    GDIImageOrder gt = new GDIImageOrder();
                    gt.ip = ledIP1;
                    gt.drawWang();
                }
                if (PickDoc.Rows.Count > 0)
                {
                    if (ledIP2IsOpen == "1" || ledIP3IsOpen == "1")
                    {
                        if ((GDIImageThree.page - 1) * 5 >= PickDoc.Rows.Count)
                        {
                            GDIImageThree.page = 1;
                        }
                        GDIImageThree gt = new GDIImageThree();
                        gt.ip = ledIP2;
                        gt.ip2 = ledIP3;
                        gt.drawWang(PickDoc);
                        GDIImageThree.page++;
                    }
                }
                else
                {
                    GDIImageThree gt = new GDIImageThree();
                    gt.ip = ledIP2;
                    gt.ip2 = ledIP3;
                    gt.drawWang();
                }
                if (ledIP1IsOpen == "1")
                {
                   // PrintOutMess(ledIP1);
                    PrintOutMess(GetErrorMessage("DeleteScreenDynamicAreaFile", BX_E.DeleteScreenDynamicAreaFile((LEDParam)mapLedInfo[ledIP1])));

                    PrintOutMess(BX_E.GetErrorMessage("AddScreenProgramAreaBmpTextFile", BX_E.AddScreenDynamicAreaFile(((LEDParam)mapLedInfo[ledIP1]))));

                    PrintOutMess(GetErrorMessage("SendScreenInfo", BX_E.SendDynamicAreaInfoCommand((LEDParam)mapLedInfo[ledIP1])));
                }
                if (ledIP2IsOpen == "1")
                {
                    //PrintOutMess(ledIP2);
                    PrintOutMess(GetErrorMessage("DeleteScreenDynamicAreaFile", BX_E.DeleteScreenDynamicAreaFile((LEDParam)mapLedInfo[ledIP2])));

                    PrintOutMess(BX_E.GetErrorMessage("AddScreenProgramAreaBmpTextFile", BX_E.AddScreenDynamicAreaFile(((LEDParam)mapLedInfo[ledIP2]))));

                    PrintOutMess(GetErrorMessage("SendScreenInfo", BX_E.SendDynamicAreaInfoCommand((LEDParam)mapLedInfo[ledIP2])));
                }
                if (ledIP3IsOpen == "1")
                {
                   // PrintOutMess("删除" + ledIP3);
                    PrintOutMess(GetErrorMessage("DeleteScreenDynamicAreaFile", BX_E.DeleteScreenDynamicAreaFile((LEDParam)mapLedInfo[ledIP3])));
                   // PrintOutMess("添加" + ledIP3);
                    PrintOutMess(BX_E.GetErrorMessage("AddScreenProgramAreaBmpTextFile", BX_E.AddScreenDynamicAreaFile(((LEDParam)mapLedInfo[ledIP3]))));
                   // PrintOutMess("发送" + ledIP3);
                    PrintOutMess(GetErrorMessage("SendScreenInfo", BX_E.SendDynamicAreaInfoCommand((LEDParam)mapLedInfo[ledIP3])));
                }


               PrintOutMess("结束发送数据");
            }
            catch (Exception ex)
            {
                PrintOutMess("SendDataToLed()发生异常：" + ex.Message);
            }
        }

        private void send()
        {
            threadCount = new Thread(new ThreadStart(Count));
            threadCount.Start();

           
            int screenHeight = ((LEDParam)mapLedInfo[OperatingLedDTO.ScreenIp]).Height;
            int screenWidth = ((LEDParam)mapLedInfo[OperatingLedDTO.ScreenIp]).Length;
            Color color = Color.Red;
            switch (OperatingLedDTO.Color)
            {
                case 1:
                    color = Color.Red;
                    break;
                case 2:
                    color = Color.LimeGreen;
                    break;
                case 3:
                    color = Color.Yellow;
                    break;
            }
            int count = 0;

           // DrawBMP(OperatingLedDTO.ScreenIp, screenHeight, screenWidth, OperatingLedDTO.Val1, OperatingLedDTO.Val2, OperatingLedDTO.Val3, OperatingLedDTO.Val4, OperatingLedDTO.FontEn, OperatingLedDTO.FontZh, OperatingLedDTO.FontEnSize, OperatingLedDTO.FontSize, color, out count);
        }
      

        /// <summary>
        /// 设置屏参
        /// </summary>
        /// <param name="led"></param>
        private void SetScreen()
        {
            try
            {
                threadCount = new Thread(new ThreadStart(Count));
                threadCount.Start();//启动计数线程
                //Thread.Sleep(10000000);
                PrintOutMess("开始执行BX_E.SetScreen(OperatingLedParam)");

                int nR = 0;
                int nSR = 0;

                if (!mapLedInfo.Contains(OperatingLedParam.ScreenIp))
                {
                    PrintOutMess(GetErrorMessage("DeleteScreen", BX_E.DeleteScreen(OperatingLedParam)));

                    nR = BX_E.AddScreen(OperatingLedParam);
                    PrintOutMess(GetErrorMessage("AddScreen", nR));

                    if (nR == 0)
                    {
                        //添加图文区域
                        nSR = BX_E.AddScreenDynamicArea(OperatingLedParam);
                        PrintOutMess(BX_E.GetErrorMessage("AddScreenDynamicArea", nSR));
                    }
                  //  loadType = "1";
                }
               


                PrintOutMess("结束执行BX_E.SetScreen(OperatingLedParam)");
                threadCount.Abort();//终止计数线程

                if (nR == 0 && nSR == 0)
                {
                    //加载成功的屏
                    if (mapLedInfo.Contains(OperatingLedParam.ScreenIp))
                        mapLedInfo[OperatingLedParam.ScreenIp] = OperatingLedParam;
                    else
                        mapLedInfo.Add(OperatingLedParam.ScreenIp, OperatingLedParam);

                    if (mapData.Contains(OperatingLedParam.ScreenIp))
                        mapData.Remove(OperatingLedParam.ScreenIp);
                }

                IsBussey = false;
            }
            catch (Exception ex)
            {
                PrintOutMess("SetScreen(LEDParam led)发生异常：" + ex.Message);
            }
        }
        private void SetLedScreen(LEDParam led)
        {
            PrintOutMess(led.ScreenIp);

            OperatingLedIp = led.ScreenIp;
            OperatingLedParam = led;
            IsBussey = true;
            threadOpreatingLed = new Thread(new ThreadStart(SetScreen));
            PrintOutMess("SetScreen:threadOpreatingLed.Start();");
            threadOpreatingLed.Start();
            while (true)
            {
                Thread.Sleep(50);
                if (IsBussey == false)
                    break;
            }
        }
        /// <summary>
        /// 计数线程
        /// </summary>
        private void Count()
        {
            int i = 0;
            int ErrKardTime = int.Parse(ConfigurationManager.AppSettings["ErrKardTime"].ToString());

            while (true)
            {
                Thread.Sleep(1000);
                i++;
                PrintOutMess(i.ToString() + "秒");

                if (i > ErrKardTime * 10)
                {
                    try
                    {

                        if (mapLedInfo.ContainsKey(OperatingLedIp))
                            mapLedInfo.Remove(OperatingLedIp);

                        if (mapData.ContainsKey(OperatingLedIp))
                            mapData.Remove(OperatingLedIp);

                        PrintOutMess(OperatingLedIp + "：已卡死，请维修");

                        threadOpreatingLed.Abort();
                    }
                    catch (Exception ex)
                    {
                        PrintOutMess("Count()方法异常：" + ex.Message);
                    }

                    IsBussey = false;
                    break;
                }
            }
        }
    }
}