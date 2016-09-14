using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LDV.WMS.LED
{
    public class BX_EUserDLL
    {



        //#region BX_E
        ///// <summary>
        ///// 设置屏参
        ///// </summary>
        ///// <param name="nScreenNO">显示屏屏号；从1开始</param>
        ///// <param name="nWidth">显示屏的长度</param>
        ///// <param name="nHeight">显示屏的高度</param>
        ///// <param name="nScreenType">显示屏类型；1：单基色；2：双基色</param>
        ///// <param name="nMkType">点阵类型；1：R+G型；2：G+R型</param>
        ///// <param name="nDataDA">显示屏极性；0：负极性；1：正极性</param>
        ///// <param name="nDataOE">显示屏OE极性；0：负有效；1：正有效</param>
        ///// <param name="nDataStyle">0：正常; 1：镜像</param>
        ///// <param name="nDataSort">0 ：正常行顺序; 1：上移一行;  2：下移一行</param>
        ///// <param name="nFrequency">0：10MHz;1：6.6MHz; 2 ：5MHz; 3：2.5MHz;4：1.25MHz</param>
        ///// <param name="FileName">显示屏参数信息保存的文件名</param>
        ///// <returns></returns>
        //public static void userSetScreenParameter(int nScreenNO, int nWidth, int nHeight, int nScreenType, int nMkType, int nDataDA, int nDataOE, int nDataStyle, int nDataSort, int nFrequency, string FileName)
        //{
        //    unsafe
        //    {
        //        byte[] FileNameBytes = Encoding.Default.GetBytes(FileName);
        //        fixed (byte* pfilename = FileNameBytes)
        //        {
        //            BX_EWin32DLL.SetScreenParameter(nScreenNO, nWidth, nHeight, nScreenType, nMkType, nDataDA, nDataOE, nDataStyle, nDataSort, nFrequency, pfilename);
        //        }
        //    }
        //}

        ///// <summary>
        ///// TCP/IP模式下发送信息
        ///// </summary>
        ///// <param name="szTCPAddress">显示屏IP地址；格式如“192.168.0.235”</param>
        ///// <param name="nPort">显示屏端口信息</param>
        ///// <param name="nSendType">通讯数据类型；
        ///// 0xC1：设置显示屏参数
        ///// 0xC8：设置显示屏亮度
        ///// 0xD1：发送显示屏全部数据
        ///// 0xD2：更新显示屏动态区域数据
        ///// 0xC4：强制开、关机
        ///// 0xE6：修改IP地址信息
        ///// 0xCD：校正时间
        ///// </param>
        ///// <param name="nWidth">显示屏的长度</param>
        ///// <param name="nHeight">显示屏的高度</param>
        ///// <param name="nScreenType">显示屏类型；1：单基色；2：双基色</param>
        ///// <param name="szSendBufFile">显示屏数据、命令信息</param>
        ///// <returns>0：向显示屏发送信息成功；1：向显示屏发送信息失败</returns>
        //public static int userSendTCPIPData(string szTCPAddress, int nPort, int nSendType, int nWidth, int nHeight, int nScreenType, string szSendBufFile)
        //{
        //    int cs;
        //    unsafe
        //    {
        //        byte[] TCPAddressBytes = Encoding.Default.GetBytes(szTCPAddress);
        //        byte[] SendBufFileBytes = Encoding.Default.GetBytes(szSendBufFile);
        //        fixed (byte* pTCPAddress = TCPAddressBytes, pSendBufFile = SendBufFileBytes)
        //        {
        //            cs = BX_EWin32DLL.SendTCPIPData(pTCPAddress, nPort, nSendType, nWidth, nHeight, nScreenType, pSendBufFile);
        //        }
        //    }
        //    return cs;
        //}

        ///// <summary>
        ///// 串口模式下发送数据到串口
        ///// </summary>
        ///// <param name="nScreenNO">显示屏屏号；从1开始</param>
        ///// <param name="pCom">串口名称；例：“Com1”</param>
        ///// <param name="nBaud">串口波特率；9600；57600；</param>
        ///// <param name="nSendType">通讯数据类型
        ///// 0xC1：设置显示屏参数
        ///// 0xC8：设置显示屏亮度
        ///// 0xD1：发送显示屏全部数据
        ///// 0xD2：更新显示屏动态区域数据
        ///// 0xC4：强制开、关机
        ///// 0xCD：校正时间
        ///// </param>
        ///// <param name="nWidth">显示屏宽度；单位：dpi</param>
        ///// <param name="nHeight">显示屏高度；单位：dpi</param>
        ///// <param name="nScreenTpe">显示屏类型；1：单基色；2：双基色</param>
        ///// <param name="SendBufFile">数据信息文件名称</param>
        ///// <returns></returns>
        //public static int userSendDataToComm(int nScreenNO, string szCom, int nBaud, int nSendType, int nWidth, int nHeight, int nScreenTpe, string szSendBufFile)
        //{
        //    int nReturn;
        //    unsafe
        //    {
        //        byte[] SendBufFileBytes = Encoding.Default.GetBytes(szSendBufFile);
        //        byte[] ComBytes = Encoding.Default.GetBytes(szCom);
        //        fixed (byte* pSendBufFile = SendBufFileBytes, pCom = ComBytes)
        //        {
        //            nReturn = BX_EWin32DLL.SendDataToComm(nScreenNO, pCom, nBaud, nSendType, nWidth, nHeight, nScreenTpe, pSendBufFile);
        //        }
        //    }

        //    return nReturn;
        //}

        ///// <summary>
        ///// 得到显示屏数据的头信息，保存到文件pFileName中
        ///// </summary>
        ///// <param name="nScreenNO">显示屏屏号；从1开始</param>
        ///// <param name="nProgramCount">显示屏的节目个数</param>
        ///// <param name="FileName">显示屏头信息保存的文件名</param>
        //public static void userGetAllDataHead(int nScreenNO, int nProgramCount, string FileName)
        //{
        //    unsafe
        //    {
        //        byte[] FileNameBytes = Encoding.Default.GetBytes(FileName);
        //        fixed (byte* pfilename = FileNameBytes)
        //        {
        //            BX_EWin32DLL.GetAllDataHead(nScreenNO, nProgramCount, pfilename);
        //        }
        //    }
        //}

        ///// <summary>
        ///// 合并显示区域信息文件
        ///// </summary>
        ///// <param name="SourceFile">预合并信息文件名称</param>
        ///// <param name="UnionedFile">合并目标文件名称</param>
        ///// <param name="bDeleted">0：在原文件下添加合并信息文件；1：删除原文件信息，重新创建合并信息文件返回值：无</param>
        //public static void userUnionAreaDataToFile(string SourceFile, string UnionedFile, int bDeleted)
        //{
        //    unsafe
        //    {
        //        byte[] SourceFileBytes = Encoding.Default.GetBytes(SourceFile);
        //        byte[] UnionedFileBytes = Encoding.Default.GetBytes(UnionedFile);
        //        fixed (byte* psourcefile = SourceFileBytes, punionedfile = UnionedFileBytes)
        //        {
        //            BX_EWin32DLL.UnionAreaDataToFile(psourcefile, punionedfile, bDeleted);
        //        }
        //    }
        //}

        ///// <summary>
        ///// 取得显示屏当前节目的头信息，在添加显示区域信息前添加
        ///// </summary>
        ///// <param name="nProgramOrd">节目序号，从0开始计数</param>
        ///// <param name="nAreaCount">显示屏中区域的个数。在一个显示屏中的动态区域只可以放置一个。表盘、字幕可以放置多个，但是总共最多可以有8个区域</param>
        ///// <param name="nProgPlayMode">节目播放模式，0：定长播放；1：定时播放</param>
        ///// <param name="nProgPlayLength">节目定长播放时的播放长度；单位为秒；1~ 65535</param>
        ///// <param name="nProgWeekAttrib">节目定时播放时的星期播放属性，
        ///// 从周一到周日循环，对应该字节内的低位(bit0)到高位(bit6)。
        ///// 如果如果周一播放，则bit0=1，否则bit0=0；依次如果周日播放bit6=1，否则bit6=0</param>
        ///// <param name="nPlayHour">当天该节目开始播放的小时值</param>
        ///// <param name="nPlayMinute">当天该节目开始播放的分值</param>
        ///// <param name="nPlaySecond">当天该节目开始播放的秒值</param>
        ///// <param name="nStopHour">当天该节目结束播放的小时值</param>
        ///// <param name="nStopMintue">当天该节目结束播放的分值</param>
        ///// <param name="nStopSecond">当天该节目结束播放的秒值</param>
        ///// <param name="FileName">节目头信息保存的文件名称</param>
        //public static void userGetProgramHead(int nProgramOrd, int nAreaCount, int nProgPlayMode, int nProgPlayLength, int nProgWeekAttrib, int nPlayHour,
        //    int nPlayMinute, int nPlaySecond, int nStopHour, int nStopMintue, int nStopSecond, string FileName)
        //{
        //    unsafe
        //    {
        //        byte[] FileNameBytes = Encoding.Default.GetBytes(FileName);
        //        fixed (byte* pfilename = FileNameBytes)
        //        {
        //            BX_EWin32DLL.GetProgramHead(nProgramOrd, nAreaCount, nProgPlayMode, nProgPlayLength, nProgWeekAttrib, nPlayHour,
        //     nPlayMinute, nPlaySecond, nStopHour, nStopMintue, nStopSecond, pfilename);
        //        }
        //    }
        //}

        ///// <summary>
        ///// 设置动态区域显示属性
        ///// </summary>
        ///// <param name="nX">动态区域的横坐标</param>
        ///// <param name="nY">动态区域的纵坐标</param>
        ///// <param name="nWidth">动态区域的长度</param>
        ///// <param name="nHeight">动态区域的高度</param>
        ///// <param name="nScreenType">显示屏类型；1：单基色；2：双基色</param>
        ///// <param name="nMkType">点阵类型；1：R+G型；2：G+R型</param>
        ///// <param name="bShowExceptPic">是否显示异常处理图片；1：显示；0：不显示</param>
        ///// <param name="nExceptTime">异常判断时间间隔；单位：分钟</param>
        ///// <param name="ExceptPic">异常处理显示时的异常处理显示图片文件名</param>
        ///// <param name="FileName">动态区域位置属性信息保存的文件名</param>
        //public static void userSetDynamicAttrib(int nX, int nY, int nWidth, int nHeight, int nScreenType, int nMkType,
        //    int bShowExceptPic, int nExceptTime, string ExceptPic, string FileName)
        //{
        //    unsafe
        //    {
        //        byte[] ExceptPicBytes = Encoding.Default.GetBytes(ExceptPic);
        //        byte[] FileNameBytes = Encoding.Default.GetBytes(FileName);
        //        fixed (byte* pfilename = FileNameBytes, pExceptPic = ExceptPicBytes)
        //        {
        //            BX_EWin32DLL.SetDynamicAttrib(nX, nY, nWidth, nHeight, nScreenType, nMkType,
        //     bShowExceptPic, nExceptTime, pExceptPic, pfilename);
        //        }
        //    }
        //}

        ///// <summary>
        ///// 取得当前时间，在发送全部显示屏数据时添加完各个区域信息后，加上当前时间
        ///// </summary>
        ///// <param name="FileName">表示要发送当前时间数据保存的文件</param>
        //public static void userGetCurDataTime(string FileName)
        //{
        //    unsafe
        //    {
        //        byte[] FileNameBytes = Encoding.Default.GetBytes(FileName);
        //        fixed (byte* pfilename = FileNameBytes)
        //        {
        //            BX_EWin32DLL.GetCurDataTime(pfilename);
        //        }
        //    }
        //}

        ///// <summary>
        ///// 更新动态区域数据信息
        ///// </summary>
        ///// <param name="nScreenNO">显示屏屏号；从1开始</param>
        ///// <param name="nOrdArea">区域号：动态显示区域在显示屏中的区域号：	注意：在显示屏中添加区域是，首先添加动态区域</param>
        ///// <param name="nX">动态区域的横坐标</param>
        ///// <param name="nY">动态区域的纵坐标</param>
        ///// <param name="nWidth">动态区域的长度</param>
        ///// <param name="nHeight">动态区域的高度</param>
        ///// <param name="nScreenType">显示屏类型；1：单基色；2：双基色</param>
        ///// <param name="nMkType">点阵类型；1：R+G型；2：G+R型</param>
        ///// <param name="nPage">更新动态区域信息页码；(暂时无效)</param>
        ///// <param name="nStunt">动态区域显示信息特技方式；具体特技特征字见注2</param>
        ///// <param name="nRunSpeed">动态区域显示速度；0~15</param>
        ///// <param name="nShowTime">动态区域显示停留时间；0~255</param>
        ///// <param name="SourceName">预更新动态区域信息的文件名称；注：只支持Bmp类型文件</param>
        ///// <param name="nSourceType">预更新动态区域预转换的文件类型；0：bmp类型文件；1：rtf类型文本文件</param>
        ///// <param name="DataFileName">更新动态区域信息保存的文件名</param>
        ///// <param name="bDeleted">0：在原动态区域信息下添加动态信息；1：删除原动态区域信息，全部更新动态区域数据</param>
        //public static void userTranDynamicData(int nScreenNO, int nOrdArea, int nX, int nY, int nWidth, int nHeight, int nScreenType,
        //int nMkType, int nPage, int nStunt, int nRunSpeed, int nShowTime, string SourceName, int nSourceType,
        //string DataFileName, int bDeleted)
        //{
        //    unsafe
        //    {
        //        byte[] SourceNameBytes = Encoding.Default.GetBytes(SourceName);
        //        byte[] DataFileNameBytes = Encoding.Default.GetBytes(DataFileName);
        //        fixed (byte* psourcename = SourceNameBytes, pdatafilename = DataFileNameBytes)
        //        {
        //            BX_EWin32DLL.TranDynamicData(nScreenNO, nOrdArea, nX, nY, nWidth, nHeight, nScreenType, nMkType, nPage, nStunt, nRunSpeed, nShowTime, psourcename, nSourceType, pdatafilename, bDeleted);
        //        }
        //    }
        //}

        ///// <summary>
        ///// 更新txt文件到动态区域
        ///// </summary>
        ///// <param name="nOrdArea">区域号：动态显示区域在显示屏中的区域号</param>
        ///// <param name="nX">动态区域的横坐标</param>
        ///// <param name="nY">动态区域的纵坐标</param>
        ///// <param name="nWidth">动态区域的长度</param>
        ///// <param name="nHeight">动态区域的高度</param>
        ///// <param name="nScreenType">显示屏类型；1：单基色；2：双基色</param>
        ///// <param name="nMkType">点阵类型；1：R+G型；2：G+R型</param>
        ///// <param name="nStunt">动态区域显示信息特技方式；具体特技特征字见注2</param>
        ///// <param name="nRunSpeed">动态区域显示速度；0~15</param>
        ///// <param name="nShowTime">动态区域显示停留时间；0~255</param>
        ///// <param name="TxtFile">预更新动态区域信息的文本文件名</param>
        ///// <param name="FontName">预更新动态区域信息的字体名称</param>
        ///// <param name="FontSize">预更新动态区域信息的字体字号</param>
        ///// <param name="FontColor">预更新动态区域信息的字体颜色</param>
        ///// <param name="FontBold">预更新动态区域信息的字体是否为粗体；1:粗体</param>
        ///// <param name="DataFileName">更新动态区域信息保存的文件名</param>
        //public static void userTranDynamicTxtFile(int nOrdArea, int nX, int nY, int nWidth, int nHeight, int nScreenType,
        // int nMkType, int nStunt, int nRunSpeed, int nShowTime, string TxtFile, string FontName,
        // int FontSize, int FontColor, int FontBold, string DataFileName)
        //{
        //    unsafe
        //    {
        //        byte[] TxtFileBytes = Encoding.Default.GetBytes(TxtFile);
        //        byte[] FontNameBytes = Encoding.Default.GetBytes(FontName);
        //        byte[] DataFileNameBytes = Encoding.Default.GetBytes(DataFileName);
        //        fixed (byte* pTxtFile = TxtFileBytes, pFontName = FontNameBytes, pDataFileName = DataFileNameBytes)
        //        {
        //            BX_EWin32DLL.TranDynamicTxtFile(nOrdArea, nX, nY, nWidth, nHeight, nScreenType,
        //            nMkType, nStunt, nRunSpeed, nShowTime, pTxtFile, pFontName,
        //               FontSize, FontColor, FontBold, pDataFileName);
        //        }
        //    }
        //}

        ///// <summary>
        ///// 转换字幕区域显示信息
        ///// </summary>
        ///// <param name="nX">字幕区域的横坐标</param>
        ///// <param name="nY">字幕区域的纵坐标</param>
        ///// <param name="nWidth">字幕区域的长度</param>
        ///// <param name="nHeight">字幕区域的高度</param>
        ///// <param name="nScreenType">显示屏类型；1：单基色；2：双基色</param>
        ///// <param name="nMkType">点阵类型；1：R+G型；2：G+R型</param>
        ///// <param name="pFontName">字幕区域显示字体；支持Windows所有字体</param>
        ///// <param name="nFontSize">字幕区域显示字号</param>
        ///// <param name="nFontColor">字幕区域显示颜色; 1：红色；2：绿色；3：黄色</param>
        ///// <param name="bBold">粗体</param>
        ///// <param name="bItalic">斜体</param>
        ///// <param name="bUnderLine">下划线</param>
        ///// <param name="pTitle">字幕区域显示的字幕滚动信息</param>
        ///// <param name="nStunt">字幕区域显示特技；具体特技特征字见注1</param>
        ///// <param name="nRunSpeed">字幕区域信息运行速度</param>
        ///// <param name="nShowTime">字幕区域信息停留时间</param>
        ///// <param name="pFileName">字幕区域信息保存的文件名</param>
        //public static void userSetScreenTitle(int nX, int nY, int nWidth, int nHeight, int nScreenType, int nMkType, string FontName, int nFontSize, int nFontColor,
        //    int bBold, int bItalic, int bUnderLine, string Title, int nStunt, int nRunSpeed, int nShowTime, string FileName)
        //{
        //    unsafe
        //    {
        //        byte[] FontNameBytes = Encoding.Default.GetBytes(FontName);
        //        byte[] TitleBytes = Encoding.Default.GetBytes(Title);
        //        byte[] FileNameBytes = Encoding.Default.GetBytes(FileName);
        //        fixed (byte* pFontName = FontNameBytes, pTitle = TitleBytes, pFileName = FileNameBytes)
        //        {
        //            BX_EWin32DLL.SetScreenTitle(nX, nY, nWidth, nHeight, nScreenType, nMkType, pFontName, nFontSize, nFontColor, bBold, bItalic,
        //                bUnderLine, pTitle, nStunt, nRunSpeed, nShowTime, pFileName);
        //        }
        //    }
        //}

        //#endregion
    }
}
