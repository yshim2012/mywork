using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LDV.WMS.LED
{
    public class BX_E
    {
        private static int nScreenType = 2;



        #region LedDynamicArea


        private const int CONTROLLER_BX_5E1 = 0x0154;//BX_5E1

        private const int CONTROLLER_BX_5E1_INDEX = 0;

        private const int FRAME_SINGLE_COLOR_COUNT = 23; //纯色边框图片个数
        private const int FRAME_MULI_COLOR_COUNT = 47; //花色边框图片个数

        //------------------------------------------------------------------------------
        // 通讯模式
        private const int SEND_MODE_NETWORK = 2;//网络通讯
        //------------------------------------------------------------------------------
        //------------------------------------------------------------------------------
        // 动态区域运行模式
        private const int RUN_MODE_CYCLE_SHOW = 0; //动态区数据循环显示；
        private const int RUN_MODE_SHOW_LAST_PAGE = 1; //动态区数据显示完成后静止显示最后一页数据；
        private const int RUN_MODE_SHOW_CYCLE_WAITOUT_NOSHOW = 2; //动态区数据循环显示，超过设定时间后数据仍未更新时不再显示；
        private const int RUN_MODE_SHOW_ORDERPLAYED_NOSHOW = 4; //动态区数据顺序显示，显示完最后一页后就不再显示
        //------------------------------------------------------------------------------
        //==============================================================================
        // 返回状态代码定义
        private const int RETURN_ERROR_NOFIND_DYNAMIC_AREA = 0xE1; //没有找到有效的动态区域。
        private const int RETURN_ERROR_NOFIND_DYNAMIC_AREA_FILE_ORD = 0xE2; //在指定的动态区域没有找到指定的文件序号。
        private const int RETURN_ERROR_NOFIND_DYNAMIC_AREA_PAGE_ORD = 0xE3; //在指定的动态区域没有找到指定的页序号。
        private const int RETURN_ERROR_NOSUPPORT_FILETYPE = 0xE4; //不支持该文件类型。
        private const int RETURN_ERROR_RA_SCREENNO = 0xF8; //已经有该显示屏信息。如要重新设定请先DeleteScreen删除该显示屏再添加；
        private const int RETURN_ERROR_NOFIND_AREA = 0xFA; //没有找到有效的显示区域；可以使用AddScreenProgramBmpTextArea添加区域信息。
        private const int RETURN_ERROR_NOFIND_SCREENNO = 0xFC; //系统内没有查找到该显示屏；可以使用AddScreen函数添加显示屏
        private const int RETURN_ERROR_NOW_SENDING = 0xFD; //系统内正在向该显示屏通讯，请稍后再通讯；
        private const int RETURN_ERROR_OTHER = 0xFF; //其它错误；
        private const int RETURN_NOERROR = 0; //没有错误
        //==============================================================================

        private const int SCREEN_NO = 1;
        private const int SCREEN_WIDTH = 192;
        private const int SCREEN_HEIGHT = 96;
        private const int SCREEN_TYPE = 2;//显示屏类型：1、单基色2、双基色3、
        private const int SCREEN_TYPE_YZ = 2;//显示屏类型：1、单基色2、双基色3、
        private const int SCREEN_DATADA = 0;
        private const int SCREEN_DATAOE = 0;
        private const string SCREEN_COMM = "COM1";
        private const int SCREEN_BAUD = 57600;
        private const int SCREEN_ROWORDER = 0;
        private const int SCREEN_FREQPAR = 0;
        private const string SCREEN_SOCKETIP = "192.168.2.199";
        private const int SCREEN_SOCKETPORT = 5005;
        private bool m_bSendBusy = false;//此变量在数据更新中非常重要，请务必保留。
        private string FAddDynamicArea = "第二步-----添加动态区域";
        private string FAddDYAreaFile = "第三步-----动态区域文件属性";

        /// <summary>
        /// Led 错误信息判断
        /// </summary>
        /// <param name="szfunctionName"></param>
        /// <param name="nResult"></param>
        /// <returns></returns>
        public static string GetErrorMessage(string szfunctionName, int nResult)
        {
            string ErrorMess = string.Empty;
            string szResult = string.Empty;
            szResult = "-执行函数：" + szfunctionName + "---返回结果：";
            switch (nResult)
            {
                case RETURN_ERROR_NOFIND_DYNAMIC_AREA:
                    ErrorMess += szResult + "没有找到有效的动态区域。\r\n";
                    break;
                case RETURN_ERROR_NOFIND_DYNAMIC_AREA_FILE_ORD:
                    ErrorMess += szResult + "在指定的动态区域没有找到指定的文件序号。\r\n";
                    break;
                case RETURN_ERROR_NOFIND_DYNAMIC_AREA_PAGE_ORD:
                    ErrorMess += szResult + "在指定的动态区域没有找到指定的页序号。\r\n";
                    break;
                case RETURN_ERROR_NOSUPPORT_FILETYPE:
                    ErrorMess += szResult + "动态库不支持该文件类型。\r\n";
                    break;
                case RETURN_ERROR_RA_SCREENNO:
                    ErrorMess += szResult + "系统中已经有该显示屏信息。如要重新设定请先执行DeleteScreen函数删除该显示屏后再添加。\r\n";
                    break;
                case RETURN_ERROR_NOFIND_AREA:
                    ErrorMess += szResult + "系统中没有找到有效的动态区域；可以先执行AddScreenDynamicArea函数添加动态区域信息后再添加。\r\n";
                    break;
                case RETURN_ERROR_NOFIND_SCREENNO:
                    ErrorMess += szResult + "系统内没有查找到该显示屏；可以使用AddScreen函数添加该显示屏。\r\n";
                    break;
                case RETURN_ERROR_NOW_SENDING:
                    ErrorMess += szResult + "系统内正在向该显示屏通讯，请稍后再通讯。\r\n";
                    break;
                case RETURN_ERROR_OTHER:
                    ErrorMess += szResult + "其它错误。\r\n";
                    break;
                case RETURN_NOERROR:
                    ErrorMess += szResult + "函数执行成功。\r\n";
                    break;
            }

            return ErrorMess;

        }

        /// <summary>
        /// 向动态库中添加显示屏信息；该函数不与显示屏通讯，只用于动态库中的指定显示屏参数信息配置。
        /// </summary>
        /// <param name="led"></param>
        /// <returns></returns>
        ///  * CONTROLLER_BX_5E1--
             ///   *  led.LedNo-屏号
             ///   *  SEND_MODE_NETWORK
            ///    *  led.Length 长
             ///   *  led.Height, 宽
               ///    SCREEN_TYPE 2双色 1单色
              ///  * , 1, SCREEN_COMM, SCREEN_BAUD
             ///                  , 
              ///  * led.ScreenIp：IP地址
              ///  * , SCREEN_SOCKETPORT
        public static int AddScreen(LEDParam led)
        {
            int nReturn;
            nReturn = BX_EWin32DLL.AddScreen(CONTROLLER_BX_5E1, led.LedNo, SEND_MODE_NETWORK, led.Length, led.Height,
                SCREEN_TYPE, 1, SCREEN_COMM, SCREEN_BAUD
                            , led.ScreenIp, SCREEN_SOCKETPORT, "curCommandData.dat");

            return nReturn;
           
            
            
        }


        /// <summary>
        /// 删除动态库中指定显示屏的所有信息；该函数不与显示屏通讯。
        /// </summary>
        /// <param name="led"></param>
        /// <returns></returns>
        public static int DeleteScreen(LEDParam led)
        {
            int nReturn = BX_EWin32DLL.DeleteScreen((int)led.LedNo);
            return nReturn;
        }

        // <summary>
        //添加屏幕动态区域
        // </summary>
        // <param name="led"></param>
        // <returns></returns> LedNo屏号
        public static int AddScreenDynamicArea(LEDParam led)
        {
            int nReturn;
            nReturn = BX_EWin32DLL.AddScreenDynamicArea(led.LedNo, 0, RUN_MODE_CYCLE_SHOW
                      , 10, 1, "", 1
                      , 0, 0, led.Length, led.Height
                      , 255, 0, 255
                      , 1, 6, 1);

            return nReturn;
        }
        public static int AddScreenDynamicAreaFile(LEDParam led)
        {
            int nReturn = 1;
            string fileName = string.Empty;
            fileName = Application.StartupPath + "\\" + led.ScreenIp;
            nReturn = BX_EWin32DLL.AddScreenDynamicAreaFile(led.LedNo, 0, fileName + ".bmp", 0, "宋体", 12, 0, 255, 1, 30, 0);
            return nReturn;
        }
        ///// <summary>
        /////添加文件
        ///// </summary>
        ///// <param name="led"></param>
        ///// <returns></returns>
        //public static int AddScreenDynamicAreaFile(LEDParam led, int count)
        //{
        //    int nReturn = 1;
        //    string fileName = string.Empty;
        //    fileName = Application.StartupPath + "\\" + led.ScreenIp;

        //    if (led.ScreenIp == "192.168.41.170")
        //    {
        //        if (led.LedPicPage == 1)
        //        {
        //            nReturn = BX_EWin32DLL.AddScreenDynamicAreaFile(led.LedNo, 0, fileName + ".bmp", 0, "宋体", 12, 0, 255, 1, 30, 0);
        //        }
        //        else
        //        {
        //            nReturn = BX_EWin32DLL.AddScreenDynamicAreaFile(led.LedNo, 0, fileName + "-" + led.LedPicPage + ".bmp", 0, "宋体", 12, 0, 255, 1, 30, 0);
        //        }
        //    }
        //    else
        //    {
        //        if (count == 1)
        //        {
        //            nReturn = BX_EWin32DLL.AddScreenDynamicAreaFile(led.LedNo, 0, fileName + ".bmp", 0, "宋体", 12, 0, 255
        //                                                                   , 1, 30, 0);
        //        }
        //        else
        //        {
        //            for (int i = 1; i <= count; i++)
        //            {
        //                if (i == 1)
        //                {
        //                    nReturn = BX_EWin32DLL.AddScreenDynamicAreaFile(led.LedNo, 0, fileName + ".bmp", 0, "宋体", 12, 0, 255, 6, 63, 5);
        //                }
        //                else
        //                {
        //                    nReturn = BX_EWin32DLL.AddScreenDynamicAreaFile(led.LedNo, 0, fileName + "-1.bmp", 0, "宋体", 12, 0, 255, 6, 63, 5);
        //                }
        //            }
        //        }
        //    }
        //    return nReturn;
        //}


        /// <summary>
        ///更新动态区域
        /// </summary>
        /// <param name="led"></param>
        /// <returns></returns>
        public static int SendDynamicAreaInfoCommand(LEDParam led)
        {
            int nReturn;
            nReturn = BX_EWin32DLL.SendDynamicAreaInfoCommand(led.LedNo, 0);
            return nReturn;
        }
        #endregion


        #region BX_5E1

        //// 控制器通讯模式
        //private const int SEND_MODE_COMM = 0;
        //private const int SEND_MODE_NET = 2;

        ////------------------------------------------------------------------------------
        //// 控制器类型
        //private const int CONTROLLER_TYPE_5E1 = 340;
        //private const string SCREEN_COMM = "COM1";
        //private const int SCREEN_BAUD = 57600;
        //private const int SCREEN_ROWORDER = 0;
        //private const int SCREEN_FREQPAR = 0;

        ////通讯命令值
        //private const int SEND_CMD_PARAMETER = 41471;  //加载屏参数。
        //private const int SEND_CMD_SENDALLPROGRAM = 41456;  //发送所有节目信息。
        //private const int SEND_CMD_POWERON = 41727; //强制开机
        //private const int SEND_CMD_POWEROFF = 41726; //强制关机
        //private const int SEND_CMD_TIMERPOWERONOFF = 41725; //定时开关机
        //private const int SEND_CMD_CANCEL_TIMERPOWERONOFF = 41724; //取消定时开关机
        //private const int SEND_CMD_RESIVETIME = 41723; //校正时间。
        //private const int SEND_CMD_ADJUSTLIGHT = 41722; //亮度调整。

        ////==============================================================================
        //private const int SCREEN_NO = 1;
        //private const int SCREEN_TYPE = 1;//显示屏类型：1、单基色2、双基色3、
        //private const int SCREEN_SOCKETPORT = 5005;
        //private const string SCREEN_WIFIIP = "192.168.0.235";
        //private const int SCREEN_WIFIPORT = 5005;

        ///// <summary>
        ///// 向动态库中添加显示屏信息；该函数不与显示屏通讯，只用于动态库中的指定显示屏参数信息配置。
        ///// </summary>
        ///// <param name="led"></param>
        ///// <returns></returns>
        //public static int AddScreen(LEDParam led)
        //{
        //    int nReturn;
        //    nReturn = BX_EWin32DLL.AddScreen(CONTROLLER_TYPE_5E1, SCREEN_NO, led.Length, led.Height, SCREEN_TYPE, 1,
        //        led.DA, led.OE, SCREEN_ROWORDER, SCREEN_FREQPAR, SCREEN_COMM, SCREEN_BAUD, led.ScreenIp, SCREEN_SOCKETPORT,
        //        SCREEN_WIFIIP, SCREEN_WIFIPORT, "C:\\ScreenStatus.ini");


        //    int nReturn;
        //    nReturn = BX_EWin32DLL.AddScreen(CONTROLLER_BX_5E1, led.LedNo, SEND_MODE_NETWORK, led.Length, led.Height,
        //        SCREEN_TYPE_YZ, 2, SCREEN_COMM, SCREEN_BAUD
        //                    , led.ScreenIp, SCREEN_SOCKETPORT, "curCommandData.dat");

        //    return nReturn;
        //}

        ///// <summary>
        /////向动态库中指定显示屏添加节目；该函数不与显示屏通讯，只用于动态库中的指定显示屏节目信息配置。
        ///// </summary>
        ///// <param name="led"></param>
        ///// <returns></returns>
        //public static int AddScreenProgram()
        //{
        //    int nReturn;
        //    nReturn = BX_EWin32DLL.AddScreenProgram(SCREEN_NO, 0, 0, 65535, 5, 23, 2011, 11, 26, 1, 1, 1, 1, 1, 1, 1, 0, 0, 23, 59);

        //    return nReturn;
        //}

        ///// <summary>
        /////向动态库中指定显示屏的指定节目添加图文区域；该函数不与显示屏通讯，只用于动态库中的指定显示屏指定节目中的图文区域信息配置。
        ///// </summary>
        ///// <param name="led"></param>
        ///// <returns></returns>
        //public static int AddScreenProgramBmpTextArea(LEDParam led)
        //{
        //    int nReturn;
        //    nReturn = BX_EWin32DLL.AddScreenProgramBmpTextArea(SCREEN_NO, 0, 0, 0, led.Length, led.Height);

        //    return nReturn;
        //}


        ///// <summary>
        /////向动态库中指定显示屏的指定节目的指定图文区域添加文件；该函数不与显示屏通讯，只用于动态库中的指定显示屏指定节目中指定图文区域的文件信息配置。
        ///// </summary>
        ///// <param name="led"></param>
        ///// <returns></returns>
        //public static void AddScreenProgramAreaBmpTextFile(LEDParam led, int count)
        //{
        //    int nReturn;
        //    string fileName = string.Empty;
        //    fileName = Application.StartupPath + "\\1.bmp";
        //    if (count == 1)
        //    {
        //        nReturn = BX_EWin32DLL.AddScreenProgramAreaBmpTextFile(SCREEN_NO, 0, 0, fileName, 0, "宋体", 16, 0, 65535, 4, 30, 0);
        //        if (nReturn == 0)
        //        {
        //            Console.WriteLine(DateTime.Now.ToString() + "\t 添加图片到图文区：1.bmp 成功！");
        //            RunTimeLogger.Debug("添加图片到图文区：1.bmp 成功！");
        //        }
        //        else
        //        {
        //            Console.WriteLine(DateTime.Now.ToString() + "\t 添加图片到图文区：1.bmp 失败！");
        //            RunTimeLogger.Debug("添加图片到图文区：1.bmp 失败！");
        //        }

        //    }
        //    else
        //    {
        //        //BX_EUserDLL.userTranDynamicData(1, 0, 0, 0, 160, 128, 1, 2, 1, 1, 9, 0, "1.bmp", 0, "DynamicData1", 1);
        //        for (int i = 1; i <= count; i++)
        //        {
        //            if (i == 1)
        //            {
        //                nReturn = BX_EWin32DLL.AddScreenProgramAreaBmpTextFile(SCREEN_NO, 0, 0, fileName, 0, "宋体", 16, 0, 65535, 4, 30, 0);
        //                if (nReturn == 0)
        //                {
        //                    Console.WriteLine(DateTime.Now.ToString() + "\t 添加图片到图文区：1.bmp 成功！");
        //                    RunTimeLogger.Debug("添加图片到图文区：1.bmp 成功！");
        //                }
        //                else
        //                {
        //                    Console.WriteLine(DateTime.Now.ToString() + "\t 添加图片到图文区：1.bmp 失败！");
        //                    RunTimeLogger.Debug("添加图片到图文区：1.bmp 失败！");
        //                }
        //            }
        //            else
        //            {
        //                nReturn = BX_EWin32DLL.AddScreenProgramAreaBmpTextFile(SCREEN_NO, 0, 0, Application.StartupPath + "\\" + i.ToString() + ".bmp", 0, "宋体", 16, 0, 65535, 4, 30, 0);

        //                if (nReturn == 0)
        //                {
        //                    Console.WriteLine(DateTime.Now.ToString() + "\t 添加图片到图文区：" + i.ToString() + " .bmp 成功！");
        //                    RunTimeLogger.Debug("添加图片到图文区：" + i.ToString() + ".bmp 成功！");
        //                }
        //                else
        //                {
        //                    Console.WriteLine(DateTime.Now.ToString() + "\t 添加图片到图文区：" + i.ToString() + " .bmp 失败！");
        //                    RunTimeLogger.Debug("添加图片到图文区：" + i.ToString() + ".bmp 失败！");
        //                }
        //            }
        //        }
        //    }


        //    //int nReturn;
        //    ////添加文件到图文区
        //    //nReturn = BX_EWin32DLL.AddScreenProgramAreaBmpTextFile(SCREEN_NO, 0, 0, fileName, 0, "宋体", 16, 0, 65535, 4, 30, 0);

        //    //return nReturn;
        //}

        ///// <summary>
        /////通过指定的通讯模式，发送相应信息、命令到显示屏。该函数与显示屏进行通讯
        ///// </summary>
        ///// <param name="led"></param>
        ///// <returns></returns>
        //public static int SendScreenInfo()
        //{
        //    int nReturn;
        //    nReturn = BX_EWin32DLL.SendScreenInfo(SCREEN_NO, SEND_MODE_NET, SEND_CMD_SENDALLPROGRAM, 0);
        //    return nReturn;
        //}

        #endregion



        //#region BX_E
        ///// <summary>
        ///// 设置BX_E屏参
        ///// </summary>
        ///// <param name="led"></param>
        //public static int SetScreen(LEDParam led)
        //{
        //    int nReturn;
        //    BX_EUserDLL.userSetScreenParameter(1, led.Length, led.Height, nScreenType, 1, led.DA, led.OE, 0, 0, 0, "ParametetData1");
        //    nReturn = BX_EUserDLL.userSendTCPIPData(led.ScreenIp, 5005, 193, led.Length, led.Height, nScreenType, "ParametetData1");

        //    if (nReturn == 0)
        //    {
        //        PrintOutMess("设置BX_E屏参成功");
        //    }
        //    else
        //    {
        //        PrintOutMess("设置BX_E屏参失败");
        //    }

        //    return nReturn;
        //}

        ///// <summary>
        ///// 设置显示区域
        ///// </summary>
        //public static int SetShowArea(LEDParam led)
        //{
        //    int nreturn;
        //    BX_EUserDLL.userGetAllDataHead(1, 1, "SendAllDataHead1");
        //    BX_EUserDLL.userUnionAreaDataToFile("SendAllDataHead1", "SendAllData1", 1);

        //    BX_EUserDLL.userGetProgramHead(0, 1, 0, 10, 0x7F, 0, 0, 0, 23, 59, 59, "ProgramHead0");
        //    BX_EUserDLL.userUnionAreaDataToFile("ProgramHead0", "SendAllData1", 0);
        //    BX_EUserDLL.userSetDynamicAttrib(0, 0, led.Length, led.Height, nScreenType, 1, 0, 2, "", "SendDataDynamicAttrib1");
        //    BX_EUserDLL.userUnionAreaDataToFile("SendDataDynamicAttrib1", "SendAllData1", 0);

        //    BX_EUserDLL.userGetCurDataTime("CurTimeData1");
        //    BX_EUserDLL.userUnionAreaDataToFile("CurTimeData1", "SendAllData1", 0);

        //    nreturn = BX_EUserDLL.userSendTCPIPData(led.ScreenIp, 5005, 209, led.Length, led.Height, nScreenType, "SendAllData1");

        //    if (nreturn == 0)
        //        PrintOutMess("设置显示区域成功");
        //    else
        //        PrintOutMess("设置显示区域失败");

        //    return nreturn;
        //}

        //public static void SendData1(LEDParam led, string Title1, string Title2, string Font1, string Font2, int fontSize1, int fontSize2, int color1,
        //    int color2, int Stunt, int Runspeet, int ShowTime, int StaticStringLength1, int StaticStringLength2)
        //{
        //    int nreturn;
        //    BX_EUserDLL.userGetAllDataHead(1, 1, "SendAllDataHead1");
        //    BX_EUserDLL.userUnionAreaDataToFile("SendAllDataHead1", "SendAllData1", 1);

        //    BX_EUserDLL.userGetProgramHead(0, 2, 0, 10, 0x7F, 8, 0, 0, 20, 0, 0, "ProgramHead0");
        //    BX_EUserDLL.userUnionAreaDataToFile("ProgramHead0", "SendAllData1", 0);
        //    //第一行
        //    if (Title1.Length <= StaticStringLength1)
        //    {
        //        //静态显示
        //        BX_EUserDLL.userSetScreenTitle(0, 0, led.Length, led.Height / 2, nScreenType, 2, Font1, fontSize1, color1, 0, 0, 0, Title1, 1, 1, 1, "SendDataTitle1");
        //    }
        //    else
        //    {
        //        //特效显示 
        //        BX_EUserDLL.userSetScreenTitle(0, 0, led.Length, led.Height / 2, nScreenType, 2, Font1, fontSize1, color1, 0, 0, 0, Title1, Stunt, Runspeet, ShowTime, "SendDataTitle1");
        //    }

        //    BX_EUserDLL.userUnionAreaDataToFile("SendDataTitle1", "SendAllData1", 0);
        //    //第二行
        //    if (Title2.Length <= StaticStringLength2)
        //    {
        //        //静态显示
        //        BX_EUserDLL.userSetScreenTitle(0, led.Height / 2, led.Length, led.Height / 2, nScreenType, 2, Font2, fontSize2, color2, 0, 0, 0, Title2, 1, 1, 1, "SendDataTitle2");
        //    }
        //    else
        //    {
        //        //特效显示 
        //        BX_EUserDLL.userSetScreenTitle(0, led.Height / 2, led.Length, led.Height / 2, nScreenType, 2, Font2, fontSize2, color2, 0, 0, 0, Title2, Stunt, Runspeet, ShowTime, "SendDataTitle2");
        //    }
        //    BX_EUserDLL.userUnionAreaDataToFile("SendDataTitle2", "SendAllData1", 0);

        //    BX_EUserDLL.userGetCurDataTime("CurTimeData1");
        //    BX_EUserDLL.userUnionAreaDataToFile("CurTimeData1", "SendAllData1", 0);

        //    nreturn = BX_EUserDLL.userSendTCPIPData(led.ScreenIp, 5005, 209, led.Length, led.Height, nScreenType, "SendAllData1");

        //    if (nreturn == 0)
        //    {
        //        PrintOutMess("更新动态区域文本成功");
        //    }
        //    else
        //    {
        //        PrintOutMess("更新动态区域文本失败");
        //    }
        //}

        ///// <summary>
        ///// 更新动态区域图片
        ///// </summary>
        ///// <param name="led"></param>
        //public static void SendBmp(LEDParam led, int count)
        //{
        //    int nreturn;
        //    if (count == 1)
        //        BX_EUserDLL.userTranDynamicData(1, 0, 0, 0, led.Length, led.Height, nScreenType, 2, 1, 1, 2, 0, "1.bmp", 0, "DynamicData1", 1);
        //    else
        //    {
        //        //BX_EUserDLL.userTranDynamicData(1, 0, 0, 0, 160, 128, 1, 2, 1, 1, 9, 0, "1.bmp", 0, "DynamicData1", 1);
        //        for (int i = 1; i <= count; i++)
        //        {
        //            if (i == 1)
        //                BX_EUserDLL.userTranDynamicData(1, 0, 0, 0, led.Length, led.Height, nScreenType, 2, 1, 18, 2, 0, "1.bmp", 0, "DynamicData1", 1);
        //            else
        //                BX_EUserDLL.userTranDynamicData(1, 0, led.Length * i, 0, led.Length, led.Height, nScreenType, 2, 1, 18, 2, 0, i.ToString() + ".bmp", 0, "DynamicData1", 0);
        //        }
        //    }
        //    //nreturn = BX_EUserDLL.userSendTCPIPData(led.ScreenIp, 5005, 210, led.Length, led.Height, nScreenType, "DynamicData1");
        //    nreturn = BX_EUserDLL.userSendTCPIPData(led.ScreenIp, 5005, 210, led.Length, led.Height, nScreenType, "DynamicData1");

        //    if (nreturn == 0)
        //        PrintOutMess("更新动态区域图片成功");
        //    else
        //        PrintOutMess("更新动态区域图片失败");
        //}

        /// <summary>
        ///删除动态库中指定显示屏指定的动态区域指定文件信息；该函数不与显示屏通讯。
        /// </summary>
        /// <param name="led"></param>
        /// <returns></returns>
        public static int DeleteScreenDynamicAreaFile(LEDParam led)
        {
            int nReturn = 0;
            //for (int i = led.LedPicCount - 1; i >= 0; i--)
            //{
            //    nReturn = BX_EWin32DLL.DeleteScreenDynamicAreaFile(led.LedNo, 0, i);
            //}
            nReturn = BX_EWin32DLL.DeleteScreenDynamicAreaFile(led.LedNo, 0, 0);
            return nReturn;
        }


        ///// <summary>
        ///// 输出信息
        ///// </summary>
        ///// <param name="Mess"></param>
        //private static void PrintOutMess(string Mess)
        //{
        //    Console.WriteLine(Mess);
        //    RunTimeLogger.Debug(Mess + "\r\n");
        //}

        //#endregion
    }
}
