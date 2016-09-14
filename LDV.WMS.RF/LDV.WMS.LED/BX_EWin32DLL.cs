using System;
using System.Runtime.InteropServices;

namespace LDV.WMS.LED
{
    class BX_EWin32DLL
    {

        #region LedDynamicArea

        /*-------------------------------------------------------------------------------
  过程名:    AddScreen
  向动态库中添加显示屏信息；该函数不与显示屏通讯。
  参数:
    nControlType:显示屏的控制器型号，目前该动态区域动态库只支持BX-5E1、BX-5E2、BX-5E3等BX-5E系列控制器。
    nScreenNo：显示屏屏号；该参数与LedshowTW 2013软件中"设置屏参"模块的"屏号"参数一致。
    nSendMode：通讯模式；目前动态库中支持0:串口通讯；2：网络通讯(只支持固定IP模式)；5：保存到文件等三种通讯模式。
    nWidth：显示屏宽度；单位：像素。
    nHeight：显示屏高度；单位：像素。
    nScreenType：显示屏类型；1：单基色；2：双基色。
    nPixelMode：点阵类型，只有显示屏类型为双基色时有效；1：R+G；2：G+R。
    pCom：通讯串口，只有在串口通讯时该参数有效；例："COM1"
    nBaud：通讯串口波特率，只有在串口通讯时该参数有效；目前只支持9600、57600两种波特率。
    pSocketIP：控制器的IP地址；只有在网络通讯(固定IP模式)模式下该参数有效，例："192.168.0.199"
    nSocketPort：控制器的端口地址；只有在网络通讯(固定IP模式)模式下该参数有效，例：5005
    pCommandDataFile：保存到文件方式时，命令保存命令文件名称。只有在保存到文件模式下该参数有效，例："curCommandData.dat"
  返回值:    详见返回状态代码定义。
-------------------------------------------------------------------------------*/
        [DllImport("LedDynamicArea.dll")]
        public static extern int AddScreen(int nControlType, int nScreenNo, int nSendMode, int nWidth, int nHeight,
              int nScreenType, int nPixelMode, string pCom, int nBaud, string pSocketIP, int nSocketPort,
              string pCommandDataFile);

        /*-------------------------------------------------------------------------------
          过程名:    AddScreenDynamicArea
          向动态库中指定显示屏添加动态区域；该函数不与显示屏通讯。
          参数:
            nScreenNo：显示屏屏号；该参数与AddScreen函数中的nScreenNo参数对应。
            nDYAreaID：动态区域编号；目前系统中最多5个动态区域；该值取值范围为0~4;
            nRunMode：动态区域运行模式：
                      0:动态区数据循环显示；
                      1:动态区数据显示完成后静止显示最后一页数据；
                      2:动态区数据循环显示，超过设定时间后数据仍未更新时不再显示；
                      3:动态区数据循环显示，超过设定时间后数据仍未更新时显示Logo信息,Logo 信息即为动态区域的最后一页信息
                      4:动态区数据顺序显示，显示完最后一页后就不再显示
            nTimeOut：动态区数据超时时间；单位：秒 
            nAllProRelate：节目关联标志；
                      1：所有节目都显示该动态区域；
                      0：在指定节目中显示该动态区域，如果动态区域要独立于节目显示，则下一个参数为空。
            pProRelateList：节目关联列表，用节目编号表示；节目编号间用","隔开,节目编号定义为LedshowTW 2013软件中"P***"中的"***"
            nPlayImmediately：动态区域是否立即播放0：该动态区域与异步节目一起播放；1：异步节目停止播放，仅播放该动态区域
            nAreaX：动态区域起始横坐标；单位：像素
            nAreaY：动态区域起始纵坐标；单位：像素
            nAreaWidth：动态区域宽度；单位：像素
            nAreaHeight：动态区域高度；单位：像素
            nAreaFMode：动态区域边框显示标志；0：纯色；1：花色；255：无边框
            nAreaFLine：动态区域边框类型, 纯色最大取值为FRAME_SINGLE_COLOR_COUNT；花色最大取值为：FRAME_MULI_COLOR_COUNT
            nAreaFColor：边框显示颜色；选择为纯色边框类型时该参数有效；
            nAreaFStunt：边框运行特技；
                      0：闪烁；1：顺时针转动；2：逆时针转动；3：闪烁加顺时针转动；
                      4:闪烁加逆时针转动；5：红绿交替闪烁；6：红绿交替转动；7：静止打出
            nAreaFRunSpeed：边框运行速度；
            nAreaFMoveStep：边框移动步长；该值取值范围：1~8；
          返回值:    详见返回状态代码定义。
        -------------------------------------------------------------------------------*/
        [DllImport("LedDynamicArea.dll")]
        public static extern int AddScreenDynamicArea(int nScreenNo, int nDYAreaID, int nRunMode,
            int nTimeOut, int nAllProRelate, string pProRelateList, int nPlayImmediately,
            int nAreaX, int nAreaY, int nAreaWidth, int nAreaHeight, int nAreaFMode, int nAreaFLine, int nAreaFColor,
            int nAreaFStunt, int nAreaFRunSpeed, int nAreaFMoveStep);

        /*-------------------------------------------------------------------------------
          过程名:    AddScreenDynamicAreaFile
          向动态库中指定显示屏的指定动态区域添加信息文件；该函数不与显示屏通讯。
          参数:
            nScreenNo：显示屏屏号；该参数与AddScreen函数中的nScreenNo参数对应。
            nDYAreaID：动态区域编号；该参数与AddScreenDynamicArea函数中的nDYAreaID参数对应
            pFileName：添加的信息文件名称；目前只支持txt(支持ANSI、UTF-8、Unicode等格式编码)、bmp的文件格式
            nShowSingle：文字信息是否单行显示；0：多行显示；1：单行显示；显示该参数只有szFileName为txt格式文档时才有效；
            pFontName：文字信息显示字体；该参数只有szFileName为txt格式文档时才有效；
            nFontSize：文字信息显示字体的字号；该参数只有szFileName为txt格式文档时才有效；
            nBold：文字信息是否粗体显示；0：正常；1：粗体显示；该参数只有szFileName为txt格式文档时才有效；
            nFontColor：文字信息显示颜色；该参数只有szFileName为txt格式文档时才有效；
            nStunt：动态区域信息运行特技；
                      00：随机显示 
                      01：静止显示
                      02：快速打出 
                      03：向左移动 
                      04：向左连移 
                      05：向上移动 
                      06：向上连移 
                      07：闪烁 
                      08：飘雪 
                      09：冒泡 
                      10：中间移出 
                      11：左右移入 
                      12：左右交叉移入 
                      13：上下交叉移入 
                      14：画卷闭合 
                      15：画卷打开 
                      16：向左拉伸 
                      17：向右拉伸 
                      18：向上拉伸 
                      19：向下拉伸 
                      20：向左镭射 
                      21：向右镭射 
                      22：向上镭射 
                      23：向下镭射 
                      24：左右交叉拉幕 
                      25：上下交叉拉幕 
                      26：分散左拉 
                      27：水平百页 
                      28：垂直百页 
                      29：向左拉幕 
                      30：向右拉幕 
                      31：向上拉幕 
                      32：向下拉幕 
                      33：左右闭合 
                      34：左右对开 
                      35：上下闭合 
                      36：上下对开 
                      37：向右移动 
                      38：向右连移 
                      39：向下移动 
                      40：向下连移
            nRunSpeed：动态区域信息运行速度
            nShowTime：动态区域信息显示时间；单位：10ms
          返回值:    详见返回状态代码定义。
        -------------------------------------------------------------------------------*/
        [DllImport("LedDynamicArea.dll")]
        public static extern int AddScreenDynamicAreaFile(int nScreenNo, int nDYAreaID,
            string pFileName, int nShowSingle, string pFontName, int nFontSize, int nBold, int nFontColor,
            int nStunt, int nRunSpeed, int nShowTime);
                         
        /*-------------------------------------------------------------------------------
          过程名:    DeleteScreen
          删除动态库中指定显示屏的所有信息；该函数不与显示屏通讯。
          参数:
            nScreenNo：显示屏屏号；该参数与AddScreen函数中的nScreenNo参数对应。
          返回值:    详见返回状态代码定义
        -------------------------------------------------------------------------------*/
        [DllImport("LedDynamicArea.dll")]
        public static extern int DeleteScreen(int nScreenNo);

        /*-------------------------------------------------------------------------------
          过程名:    DeleteScreenDynamicAreaFile
          删除动态库中指定显示屏指定的动态区域指定文件信息；该函数不与显示屏通讯。
          参数:
            nScreenNo：显示屏屏号；该参数与AddScreen函数中的nScreenNo参数对应。
            nDYAreaID：动态区域编号；该参数与AddScreenDynamicArea函数中的nDYAreaID参数对应
            nFileOrd：动态区域的指定文件的文件序号；该序号按照文件添加顺序，从0顺序递增，如删除中间的文件，后面的文件序号自动填充。
          返回值:    详见返回状态代码定义
        -------------------------------------------------------------------------------*/
        [DllImport("LedDynamicArea.dll")]
        public static extern int DeleteScreenDynamicAreaFile(int nScreenNo, int nDYAreaID, int nFileOrd);

        /*-------------------------------------------------------------------------------
         过程名:    SendDynamicAreaInfoCommand
         发送动态库中指定显示屏指定的动态区域信息到显示屏；该函数与显示屏通讯。
         参数:
           nScreenNo：显示屏屏号；该参数与AddScreen函数中的nScreenNo参数对应。
           nDYAreaID：动态区域编号；该参数与AddScreenDynamicArea函数中的nDYAreaID参数对应
         返回值:    详见返回状态代码定义
       -------------------------------------------------------------------------------*/
        [DllImport("LedDynamicArea.dll")]
        public static extern int SendDynamicAreaInfoCommand(int nScreenNo, int nDYAreaID);

        /*-------------------------------------------------------------------------------
          过程名:    SendDeleteDynamicAreasCommand
          删除动态库中指定显示屏指定的动态区域信息；同时向显示屏通讯删除指定的动态区域信息。该函数与显示屏通讯
          参数:
            nScreenNo：显示屏屏号；该参数与AddScreen函数中的nScreenNo参数对应。
            nDYAreaID：动态区域编号；该参数与AddScreenDynamicArea函数中的nDYAreaID参数对应
            pDYAreaIDList：动态区域编号列表；如果同时删除多个动态区域，动态区域编号间用","隔开。如"0,1"
          返回值:    详见返回状态代码定义
        -------------------------------------------------------------------------------*/
        [DllImport("LedDynamicArea.dll")]
        public static extern int SendDeleteDynamicAreasCommand(int nScreenNo, int nDelAllDYArea, string pDYAreaIDList);

        #endregion 

        #region BX_5E1

        ///*-------------------------------------------------------------------------------
        //  过程名:    AddScreen
        //  向动态库中添加显示屏信息；该函数不与显示屏通讯，只用于动态库中的指定显示屏参数信息配置。
        //  参数:
        //    nControlType    :显示屏的控制器型号；详见宏定义“控制器型号定义”
        //      CONTROLLER_BX-5AT=81
        //      CONTROLLER_BX-5A0=337;
        //      CONTROLLER_BX-5A1=593;
        //      CONTROLLER_BX-5A1_WiFi=1617;
        //      CONTROLLER_BX-5A=2385;
        //      CONTROLLER_BX-5A2=849;
        //      CONTROLLER_BX-5A2_RF=4945;
        //      CONTROLLER_BX-5A2_WiFi=1873;
        //      CONTROLLER_BX-5A3=1105;
        //      CONTROLLER_BX-5A4=1361;
        //      CONTROLLER_BX-5A4_RF=5457;
        //      CONTROLLER_BX-5A4_WiFi=2129;
        //      CONTROLLER_BX-5M1=82;
        //      CONTROLLER_BX-5M2=594;
        //      CONTROLLER_BX-5M3=850;
        //      CONTROLLER_BX-5M4=1106;
        //      CONTROLLER_BX-5UT=85;
        //      CONTROLLER_BX-5U0=341;
        //      CONTROLLER_BX-5U1=597;
        //      CONTROLLER_BX-5U2=853;
        //      CONTROLLER_BX-5U3=1109;
        //      CONTROLLER_BX-5U4=1365;
        //      CONTROLLER_BX-5E1=340;
        //      CONTROLLER_BX-5E2=596;
        //      CONTROLLER_BX-5E3=852;
        //      CONTROLLER_BX-5Q1=342;
        //      CONTROLLER_BX-5Q2=598;
        //      CONTROLLER_BX-5QS1=343;
        //      CONTROLLER_BX-5QS2=599;
        //      CONTROLLER_BX-5QS=855;
        //      CONTROLLER_BX-4T1=320;
        //      CONTROLLER_BX-4T2=576;
        //      CONTROLLER_BX-4T3=832;
        //      CONTROLLER_BX-4A1=321;
        //      CONTROLLER_BX-4A2=577;
        //      CONTROLLER_BX-4A3=833;
        //      CONTROLLER_BX-4AQ=4161;
        //      CONTROLLER_BX-4A=65;
        //      CONTROLLER_BX-4UT=1093;
        //      CONTROLLER_BX-4U0=69;
        //      CONTROLLER_BX-4U1=325;
        //      CONTROLLER_BX-4U2=581;
        //      CONTROLLER_BX-4U2X=1349;
        //      CONTROLLER_BX-4U3=837;
        //      CONTROLLER_BX-4M0=578;
        //      CONTROLLER_BX-4M1=322;
        //      CONTROLLER_BX-4M=66;
        //      CONTROLLER_BX-4MC=3138;
        //      CONTROLLER_BX-4C=67;
        //      CONTROLLER_BX-4E1=324;
        //      CONTROLLER_BX-4E=68;
        //      CONTROLLER_BX-4EL=2116;
        //      CONTROLLER_BX-3T=16;
        //      CONTROLLER_BX-3A1=33;
        //      CONTROLLER_BX-3A2=34;
        //      CONTROLLER_BX-3A=32;
        //      CONTROLLER_BX-3M=48;
        //              CONTROLLER_BX_5Q0+ = 4182;
        //              CONTROLLER_BX_5Q1+ = 4438;
        //              CONTROLLER_BX_5Q2+ = 4694;
        //              CONTROLLER_BX_5QS1+ = 4439;
        //              CONTROLLER_BX_5QS2+ = 4695;
        //              CONTROLLER_BX_5QS+ = 4951;
        //    nScreenNo       :显示屏屏号；该参数与LedshowTW 2013软件中"设置屏参"模块的"屏号"参数一致。
        //    nWidth          :显示屏宽度 16的整数倍；最小64；BX-5E系列最小为80
        //    nHeight         :显示屏高度 16的整数倍；最小16；
        //    nScreenType     :显示屏类型；1：单基色；2：双基色；
        //      3：双基色；注意：该显示屏类型只有BX-4MC支持；同时该型号控制器不支持其它显示屏类型。
        //      4：全彩色；注意：该显示屏类型只有BX-5Q系列支持；同时该型号控制器不支持其它显示屏类型。
        //      5：双基色灰度；注意：该显示屏类型只有BX-5QS支持；同时该型号控制器不支持其它显示屏类型。
        //    nPixelMode      :点阵类型；1：R+G；2：G+R；该参数只对双基色屏有效 ；默认为2；
        //    nDataDA         :数据极性；，0x00：数据低有效，0x01：数据高有效；默认为0；
        //    nDataOE         :OE极性；  0x00：OE 低有效；0x01：OE 高有效；默认为0；
        //    nRowOrder       :行序模式；0：正常；1：加1行；2：减1行；默认为0；
        //    nFreqPar        :扫描点频；0~6；默认为0；
        //    pCom            :串口名称；串口通讯模式时有效；例:COM1
        //    nBaud           :串口波特率：目前支持9600、57600；默认为57600；
        //    pSocketIP       :控制卡IP地址，网络通讯模式时有效；例:192.168.0.199；
        //      本动态库网络通讯模式时只支持固定IP模式，单机直连和网络服务器模式不支持。
        //    nSocketPort     :控制卡网络端口；网络通讯模式时有效；例：5005
        //    pWiFiIP         :控制器WiFi模式的IP地址信息；WiFi通讯模式时有效；例:192.168.100.1
        //    nWiFiPort       :控制卡WiFi端口；WiFi通讯模式时有效；例：5005
        //    pScreenStatusFile:用于保存查询到的显示屏状态参数保存的INI文件名；
        //      只有执行查询显示屏状态GetScreenStatus时，该参数才有效
        //  返回值            :详见返回状态代码定义。
        //-------------------------------------------------------------------------------*/
        //[DllImport("BX_IV.dll")]
        //public static extern int AddScreen(int nControlType, int nScreenNo,
        //int nWidth, int nHeight, int nScreenType, int nPixelMode, int nDataDA,
        //   int nDataOE, int nRowOrder, int nFreqPar, string pCom, int nBaud,
        //   string pSocketIP, int nSocketPort, string pWiFiIP, int nWiFiPort, string pScreenStatusFile); //添加屏显

        ///*-------------------------------------------------------------------------------
        //  过程名:    DeleteScreen
        //  删除指定显示屏信息，删除显示屏成功后会将该显示屏下所有节目信息从动态库中删除。
        //  该函数不与显示屏通讯，只用于动态库中的指定显示屏参数信息配置。
        //  参数:
        //    nScreenNo       :显示屏屏号；该参数与AddScreen函数中的nScreenNo参数对应。
        //  返回值            :详见返回状态代码定义。
        //-------------------------------------------------------------------------------}*/
        //[DllImport("BX_IV.dll")]
        //public static extern int DeleteScreen(int nScreenNo);//删除屏显
        ///*-------------------------------------------------------------------------------
        //  过程名:    SendScreenInfo
        //  通过指定的通讯模式，发送相应信息、命令到显示屏。该函数与显示屏进行通讯
        //  参数:
        //    nScreenNo       :显示屏屏号；该参数与AddScreen函数中的nScreenNo参数对应。
        //    nSendMode       :与显示屏的通讯模式；
        //      0:串口模式、BX-5A2&RF、BX-5A4&RF等控制器为RF串口无线模式;
        //      2:网络模式;
        //      4:WiFi模式
        //    nSendCmd        :通讯命令值
        //      SEND_CMD_PARAMETER =41471;  加载屏参数。
        //      SEND_CMD_SENDALLPROGRAM = 41456;  发送所有节目信息。
        //      SEND_CMD_POWERON =41727; 强制开机
        //      SEND_CMD_POWEROFF = 41726; 强制关机
        //      SEND_CMD_TIMERPOWERONOFF = 41725; 定时开关机
        //      SEND_CMD_CANCEL_TIMERPOWERONOFF = 41724; 取消定时开关机
        //      SEND_CMD_RESIVETIME = 41723; 校正时间。
        //      SEND_CMD_ADJUSTLIGHT = 41722; 亮度调整。
        //    nOtherParam1    :保留参数；0
        //  返回值            :详见返回状态代码定义。
        //-------------------------------------------------------------------------------*/
        //[DllImport("BX_IV.dll")]
        //public static extern int SendScreenInfo(int nScreenNo, int nSendMode, int nSendCmd, int nOtherParam1);//发送相应命令到显示屏。 

        ///*-------------------------------------------------------------------------------
        //  过程名:    AddScreenProgram
        //  向动态库中指定显示屏添加节目；该函数不与显示屏通讯，只用于动态库中的指定显示屏节目信息配置。
        //  参数:
        //    nScreenNo       :显示屏屏号；该参数与AddScreen函数中的nScreenNo参数对应。
        //    nProgramType    :节目类型；0正常节目。
        //    nPlayLength     :0:表示自动顺序播放；否则表示节目播放的长度；范围1~65535；单位秒
        //    nStartYear      :节目的生命周期；开始播放时间年份。如果为无限制播放的话该参数值为65535；如2010
        //    nStartMonth     :节目的生命周期；开始播放时间月份。如11
        //    nStartDay       :节目的生命周期；开始播放时间日期。如26
        //    nEndYear        :节目的生命周期；结束播放时间年份。如2011
        //    nEndMonth       :节目的生命周期；结束播放时间月份。如11
        //    nEndDay         :节目的生命周期；结束播放时间日期。如26
        //    nMonPlay        :节目在生命周期内星期一是否播放;0：不播放;1：播放.
        //    nTuesPlay       :节目在生命周期内星期二是否播放;0：不播放;1：播放.
        //    nWedPlay        :节目在生命周期内星期二是否播放;0：不播放;1：播放.
        //    nThursPlay      :节目在生命周期内星期二是否播放;0：不播放;1：播放.
        //    bFriPlay        :节目在生命周期内星期二是否播放;0：不播放;1：播放.
        //    nSatPlay        :节目在生命周期内星期二是否播放;0：不播放;1：播放.
        //    nSunPlay        :节目在生命周期内星期二是否播放;0：不播放;1：播放.
        //    nStartHour      :节目在当天开始播放时间小时。如8
        //    nStartMinute    :节目在当天开始播放时间分钟。如0
        //    nEndHour        :节目在当天结束播放时间小时。如18
        //    nEndMinute      :节目在当天结束播放时间分钟。如0
        //  返回值            :详见返回状态代码定义。
        //-------------------------------------------------------------------------------*/
        //[DllImport("BX_IV.dll")]
        //public static extern int AddScreenProgram(int nScreenNo, int nProgramType, int nPlayLength,
        //    int nStartYear, int nStartMonth, int nStartDay, int nEndYear, int nEndMonth, int nEndDay,
        //    int nMonPlay, int nTuesPlay, int nWedPlay, int nThursPlay, int bFriPlay, int nSatPlay, int nSunPlay,
        //    int nStartHour, int nStartMinute, int nEndHour, int nEndMinute); //向指定显示屏添加节目； 

        ///*-------------------------------------------------------------------------------
        //  过程名:    DeleteScreenProgram
        //  删除指定显示屏指定节目，删除节目成功后会将该节目下所有区域信息删除。
        //  该函数不与显示屏通讯，只用于动态库中的指定显示屏指定节目信息配置。
        //  参数:
        //    nScreenNo       :显示屏屏号；该参数与AddScreen函数中的nScreenNo参数对应。
        //    nProgramOrd     :节目序号；该序号按照节目添加顺序，从0顺序递增，如删除中间的节目，后面的节目序号自动填充。
        //  返回值            :详见返回状态代码定义。
        //-------------------------------------------------------------------------------*/
        //[DllImport("BX_IV.dll")]
        //public static extern int DeleteScreenProgram(int nScreenNo, int nProgramOrd); //删除节目

        ///*-------------------------------------------------------------------------------
        //  过程名:    DeleteScreenProgramArea
        //  删除指定显示屏指定节目的指定区域，删除区域成功后会将该区域下所有信息删除。
        //  该函数不与显示屏通讯，只用于动态库中指定显示屏指定节目中指定的区域信息配置。
        //  参数:
        //    nScreenNo       :显示屏屏号；该参数与AddScreen函数中的nScreenNo参数对应。
        //    nProgramOrd     :节目序号；该序号按照节目添加顺序，从0顺序递增，如删除中间的节目，后面的节目序号自动填充。
        //    nAreaOrd        :区域序号；该序号按照区域添加顺序，从0顺序递增，如删除中间的区域，后面的区域序号自动填充。
        //  返回值            :详见返回状态代码定义。
        //-------------------------------------------------------------------------------*/
        //[DllImport("BX_IV.dll")]
        //public static extern int DeleteScreenProgramArea(int nScreenNo, int nProgramOrd, int nAreaOrd);//删除区域

        ///*-------------------------------------------------------------------------------
        //  过程名:    AddScreenProgramBmpTextArea:
        //  向动态库中指定显示屏的指定节目添加图文区域；该函数不与显示屏通讯，只用于动态库中的指定显示屏指定节目中的图文区域信息配置。
        //  参数:
        //    nScreenNo       :显示屏屏号；该参数与AddScreen函数中的nScreenNo参数对应。
        //    nProgramOrd     :节目序号；该序号按照节目添加顺序，从0顺序递增，如删除中间的节目，后面的节目序号自动填充。
        //    nX              :区域的横坐标；显示屏的左上角的横坐标为0；最小值为0
        //    nY              :区域的纵坐标；显示屏的左上角的纵坐标为0；最小值为0
        //    nWidth          :区域的宽度；最大值不大于显示屏宽度-nX
        //    nHeight         :区域的高度；最大值不大于显示屏高度-nY
        //  返回值            :详见返回状态代码定义。
        //-------------------------------------------------------------------------------*/
        //[DllImport("BX_IV.dll")]
        //public static extern int AddScreenProgramBmpTextArea(int nScreenNo, int nProgramOrd, int nX, int nY,
        //    int nWidth, int nHeight);//向指定显示屏指定节目添加图文区；

        ///*-------------------------------------------------------------------------------
        //  过程名:    AddScreenProgramAreaBmpTextFile
        //  向动态库中指定显示屏的指定节目的指定图文区域添加文件；
        //      该函数不与显示屏通讯，只用于动态库中的指定显示屏指定节目中指定图文区域的文件信息配置。
        //  参数:
        //    nScreenNo       :显示屏屏号；该参数与AddScreen函数中的nScreenNo参数对应。
        //    nProgramOrd     :节目序号；该序号按照节目添加顺序，从0顺序递增，如删除中间的节目，后面的节目序号自动填充。
        //    nAreaOrd        :区域序号；该序号按照区域添加顺序，从0顺序递增，如删除中间的区域，后面的区域序号自动填充。
        //    pFileName       :文件名称  支持.bmp,jpg,jpeg,rtf,txt等文件类型。
        //    nShowSingle     :单、多行显示；1：单行显示；0：多行显示；该参数只有在pFileName为txt类型文件时该参数才有效。
        //    pFontName       :字体名称；支持当前操作系统已经安装的矢量字库；该参数只有pFileName为txt类型文件时该参数才有效。
        //    nFontSize       :字体字号；支持当前操作系统的字号；该参数只有pFileName为txt类型文件时该参数才有效。
        //    nBold           :字体粗体；支持1：粗体；0：正常；该参数只有pFileName为txt类型文件时该参数才有效。
        //    nFontColor      :字体颜色；该参数只有pFileName为txt类型文件时该参数才有效。
        //    nStunt          :显示特技。
        //      0x00:随机显示
        //      0x01:静态
        //      0x02:快速打出
        //      0x03:向左移动
        //      0x04:向左连移
        //      0x05:向上移动            3T类型控制卡无此特技
        //      0x06:向上连移            3T类型控制卡无此特技
        //      0x07:闪烁                3T类型控制卡无此特技
        //      0x08:飘雪
        //      0x09:冒泡
        //      0x0A:中间移出
        //      0x0B:左右移入
        //      0x0C:左右交叉移入
        //      0x0D:上下交叉移入
        //      0x0E:画卷闭合
        //      0x0F:画卷打开
        //      0x10:向左拉伸
        //      0x11:向右拉伸
        //      0x12:向上拉伸
        //      0x13:向下拉伸            3T类型控制卡无此特技
        //      0x14:向左镭射
        //      0x15:向右镭射
        //      0x16:向上镭射
        //      0x17:向下镭射
        //      0x18:左右交叉拉幕
        //      0x19:上下交叉拉幕
        //      0x1A:分散左拉
        //      0x1B:水平百页            3T、3A、4A、3A1、3A2、4A1、4A2、4A3、4AQ类型控制卡无此特技
        //      0x1C:垂直百页            3T、3A、4A、3A1、3A2、4A1、4A2、4A3、4AQ、3M、4M、4M1、4MC类型控制卡无此特技
        //      0x1D:向左拉幕            3T、3A、4A类型控制卡无此特技
        //      0x1E:向右拉幕            3T、3A、4A类型控制卡无此特技
        //      0x1F:向上拉幕            3T、3A、4A类型控制卡无此特技
        //      0x20:向下拉幕            3T、3A、4A类型控制卡无此特技
        //      0x21:左右闭合            3T类型控制卡无此特技
        //      0x22:左右对开            3T类型控制卡无此特技
        //      0x23:上下闭合            3T类型控制卡无此特技
        //      0x24:上下对开            3T类型控制卡无此特技
        //      0x25:向右连移
        //      0x26:向右连移
        //      0x27:向下移动            3T类型控制卡无此特技
        //      0x28:向下连移            3T类型控制卡无此特技
        //    nRunSpeed       :运行速度；0~63；值越大运行速度越慢。
        //    nShowTime       :停留时间；0~65525；单位0.5秒

        //  返回值:           :详见返回状态代码定义。
        //-------------------------------------------------------------------------------*/
        //[DllImport("BX_IV.dll")]
        //public static extern int AddScreenProgramAreaBmpTextFile(int nScreenNo, int nProgramOrd, int nAreaOrd,
        //string pFileName, int nShowSingle, string pFontName, int nFontSize, int nBold, int nFontColor,
        //    int nStunt, int nRunSpeed, int nShowTime); //向指定显示屏指定节目指定区域添加文件

        ///*-------------------------------------------------------------------------------
        //  过程名:    DeleteScreenProgramAreaBmpTextFile
        //  删除指定显示屏指定节目指定图文区域的指定文件，删除文件成功后会将该文件信息删除。
        //  该函数不与显示屏通讯，只用于动态库中的指定显示屏指定节目指定区域中的指定文件信息配置。
        //  参数:
        //    nScreenNo       :显示屏屏号；该参数与AddScreen函数中的nScreenNo参数对应。
        //    nProgramOrd     :节目序号；该序号按照节目添加顺序，从0顺序递增，如删除中间的节目，后面的节目序号自动填充。
        //    nAreaOrd        :区域序号；该序号按照区域添加顺序，从0顺序递增，如删除中间的区域，后面的区域序号自动填充。
        //    nFileOrd        :文件序号；该序号按照文件添加顺序，从0顺序递增，如删除中间的文件，后面的文件序号自动填充。
        //  返回值            :详见返回状态代码定义。
        //-------------------------------------------------------------------------------*/
        //[DllImport("BX_IV.dll")]
        //public static extern int DeleteScreenProgramAreaBmpTextFile(int nScreenNo, int nProgramOrd, int nAreaOrd, int nFileOrd); //删除指定显示屏指定节目指定图文区域的指定文件，删除文件成功后会将该文件信息删除



        #endregion 


        //#region BX_E

        //[DllImport("BxEDLL.dll", CallingConvention = CallingConvention.StdCall)]
        //public unsafe static extern int SetScreenParameter(int nScreenNO, int nWidth, int nHeight, int nScreenType, int nMkType, int nDataDA, int nDataOE, int nDataStyle, int nDataSort, int nFrequency, byte* pFileName);

        //[DllImport("BxEDLL.dll", CallingConvention = CallingConvention.StdCall)]
        //public unsafe static extern int SetScreenState(int nScreenNO, int bScreenState, byte* pFileName);

        //[DllImport("BxEDLL.dll", CallingConvention = CallingConvention.StdCall)]
        //public unsafe static extern int SetScreenLight(int nScreenNO, int nScreenLightValue, byte* pFileName);

        //[DllImport("BxEDLL.dll", CallingConvention = CallingConvention.StdCall)]
        //public unsafe static extern int SetScreenTitle(int nX, int nY, int nWidth, int nHeight, int nScreenType, int nMkType,
        //byte* pFontName, int nFontSize, int nFontColor, int bBold, int bItalic, int bUnderLine, byte* pTitle,
        //int nStunt, int nRunSpeed, int nShowTime, byte* pFileName);

        //[DllImport("BxEDLL.dll", CallingConvention = CallingConvention.StdCall)]
        //public unsafe static extern int SetScreenDial(int nX, int nY, int nWidth, int nHeight, int nAllDotRadius, int n369DotRadius, int nHourPointerWidth,
        //    int nMinutePointerWidth, int nAllDotColor, int n369DotColor, int nHourPointerColor, int nMinutePointerColor, int nSecondPointerColor, byte* pFileName);

        //[DllImport("BxEDLL.dll", CallingConvention = CallingConvention.StdCall)]
        //public unsafe static extern int SetDynamicAttrib(int nX, int nY, int nWidth, int nHeight, int nScreenType, int nMkType,
        //    int bShowExceptPic, int nExceptTime, byte* pExceptPic, byte* pFileName);

        //[DllImport("BxEDLL.dll", CallingConvention = CallingConvention.StdCall)]
        //public unsafe static extern int TranDynamicData(int nScreenNO, int nOrdArea, int nX, int nY, int nWidth, int nHeight, int nScreenType,
        //int nMkType, int nPage, int nStunt, int nRunSpeed, int nShowTime, byte* pSourceName, int nSourceType,
        //byte* pDataFileName, int bDeleted);

        //[DllImport("BxEDLL.dll", CallingConvention = CallingConvention.StdCall)]
        //public unsafe static extern int TranDynamicTxtFile(int nOrdArea, int nX, int nY, int nWidth, int nHeight, int nScreenType,
        //int nMkType, int nStunt, int nRunSpeed, int nShowTime, byte* pTxtFile, byte* pFontName,
        //int FontSize, int FontColor, int FontBold, byte* pDataFileName);

        //[DllImport("BxEDLL.dll", CallingConvention = CallingConvention.StdCall)]
        //public unsafe static extern int GetAllDataHead(int nScreenNO, int nProgramCount, byte* pFileName);

        //[DllImport("BxEDLL.dll", CallingConvention = CallingConvention.StdCall)]
        //public unsafe static extern int GetProgramHead(int nProgramOrd, int nAreaCount, int nProgPlayMode, int nProgPlayLength, int nProgWeekAttrib, int nPlayHour, int nPlayMinute, int nPlaySecond,
        //int nStopHour, int nStopMintue, int nStopSecond, byte* pFileName);


        //[DllImport("BxEDLL.dll", CallingConvention = CallingConvention.StdCall)]
        //public unsafe static extern int GetCurDataTime(byte* pFileName);

        //[DllImport("BxEDLL.dll", CallingConvention = CallingConvention.StdCall)]
        //public unsafe static extern int UnionAreaDataToFile(byte* pSourceFile, byte* pUnionedFile, int bDeleted);

        //[DllImport("BxEDLL.dll", CallingConvention = CallingConvention.StdCall)]
        //public unsafe static extern int SendDataToComm(int nScreenNO, byte* pCom, int nBaud, int nSendType, int nWidth, int nHeight, int nScreenTpe, byte* pSendBufFile);

        //[DllImport("BxEDLL.dll", CallingConvention = CallingConvention.StdCall)]
        //public unsafe static extern int SendTCPIPData(byte* pTCPAddress, int nPort, int nSendType, int nWidth, int nHeight, int nScreenType, byte* pSendBufFile);

        //[DllImport("BxEDLL.dll", CallingConvention = CallingConvention.StdCall)]
        //public unsafe static extern int SetScreenBmpText(int nX, int nY, int nWidth, int nHeight, int nScreenType, int nMkType, byte* pSourceFile, int nSourceType, int nStunt,
        //    int nRunSpeed, int nShowTime, byte* pFileName, int bDeleted);

        //[DllImport("BxEDLL.dll", CallingConvention = CallingConvention.StdCall)]
        //public unsafe static extern int ResiveCurTime(int nScreenNO, int nYear, int nMonth, int nDay, int nHour, int nMinute, int nSecond, byte* pFileName);

        //[DllImport("BxEDLL.dll", CallingConvention = CallingConvention.StdCall)]
        //public unsafe static extern int TranDynamicString(int nOrdArea, int nX, int nY, int nWidth, int nHeight, int nScreenType, int nMkType, int nStunt,
        //    int nRunSpeed, int nShowTime, byte* DynamicString, byte* FontName, int FontSize, int FontColor, int FontBold, byte* pDataFileName);

        //[DllImport("BxEDLL.dll", CallingConvention = CallingConvention.StdCall)]
        //public unsafe static extern int SetScreenDateTime(int nX, int nY, int nWidth, int nHeight, byte* pFontName, int nFontSize, int bBold, byte* pStaticText,
        //    int nStaticColor, int bTimeDiff, int nHourDiff, int nMinuteDiff, int nYearStyle, int nYearColor, int nWeekStyle, int nWeekColor, int nTimeStyle,
        //    int nTimeColor, int bShowMuli, byte* pFileName);

        //[DllImport("BxEDLL.dll", CallingConvention = CallingConvention.StdCall)]
        //public unsafe static extern int SetScreenTimer(int nX, int nY, int nWidth, int nHeight, byte* pFontName, int nFontSize, int bBold, byte* pStaticText, int nStaticColor,
        //    int nTargYear, int nTargMonth, int nTargDay, int nTargHour, int nTargMinute, int nTargSecond, int nTimerColor, int bShowDay, int bShowHour, int bShowMinute,
        //    int bShowSecond, byte* pFileName);

        //[DllImport("BxEDLL.dll", CallingConvention = CallingConvention.StdCall)]
        //public unsafe static extern int SetScreenTimerONOFF(int nScreenNo, int nONHour1, int nONMinute1, int nOFFHour1, int nOFFMinute1, int nONHour2, int nONMinute2,
        //    int nOFFHour2, int nOFFMinute2, int nONHour3, int nONMinute3, int nOFFHour3, int nOFFMinute3, byte* pFileName);

        //[DllImport("BxEDLL.dll", CallingConvention = CallingConvention.StdCall)]
        //public unsafe static extern int ModIPAddressAttrib(byte* pNewIPAddress, int nNewPort, byte* pFileName);

        //#endregion 
    }
}
