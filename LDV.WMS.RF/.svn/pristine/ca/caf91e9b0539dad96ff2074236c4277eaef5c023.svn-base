using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LDV.WMS.LED
{
    /// <summary>
    /// LED显示屏
    /// </summary>
    public class LedDTO
    {
        private string screenIp;
        /// <summary>
        /// IP
        /// </summary>
        public string ScreenIp
        {
            get { return screenIp; }
            set { screenIp = value; }
        }

        private string screenNo;
        /// <summary>
        /// 屏号
        /// </summary>
        public string ScreenNo
        {
            get { return screenNo; }
            set { screenNo = value; }
        }

        private string values;
        /// <summary>
        /// 显示的值
        /// </summary>
        public string Value
        {
            get { return values; }
            set { values = value; }
        }

        private string _Val1;
        /// <summary>
        /// 显示的值1
        /// </summary>
        public string Val1
        {
            get { return _Val1; }
            set { _Val1 = value; }
        }

        private string _Val2;
        /// <summary>
        /// 显示的值1
        /// </summary>
        public string Val2
        {
            get { return _Val2; }
            set { _Val2 = value; }
        }

        private string _Val3;
        /// <summary>
        /// 显示的值3
        /// </summary>
        public string Val3
        {
            get { return _Val3; }
            set { _Val3 = value; }
        }

        private string _Val4;
        /// <summary>
        /// 显示的值4
        /// </summary>
        public string Val4
        {
            get { return _Val4; }
            set { _Val4 = value; }
        }

        private string status;
        /// <summary>
        /// 状态
        /// </summary>
        public string Status
        {
            get { return status; }
            set { status = value; }
        }

        private string fontEn;
        /// <summary>
        /// 英文字体
        /// </summary>
        public string FontEn
        {
            get { return fontEn; }
            set { fontEn = value; }
        }

        private string fontZh;
        /// <summary>
        /// 中文字体
        /// </summary>
        public string FontZh
        {
            get { return fontZh; }
            set { fontZh = value; }
        }

        private string fontSize;
        /// <summary>
        /// 中文字体大小
        /// </summary>
        public int FontSize
        {
            get
            {
                if (string.IsNullOrEmpty(fontSize))
                    return 0;
                else
                    return int.Parse(fontSize);
            }
            set { fontSize = value.ToString(); }
        }

        private string fontEnSize;
        /// <summary>
        /// 英文字体大小
        /// </summary>
        public int FontEnSize
        {
            get
            {
                if (string.IsNullOrEmpty(fontEnSize))
                    return 0;
                else
                    return int.Parse(fontEnSize);
            }
            set { fontEnSize = value.ToString(); }
        }

        private string color;
        /// <summary>
        /// 颜色
        /// </summary>
        public int Color
        {
            get { return int.Parse(color); }
            set { color = value.ToString(); }
        }


        private string whid;
        /// <summary>
        /// 仓库ID
        /// </summary>
        public int WHID
        {
            get { return int.Parse(whid); }
            set { whid = value.ToString(); }
        }
    }
}
