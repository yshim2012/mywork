using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LDV.WMS.LED
{
    /// <summary>
    /// LED设计参数
    /// </summary>
    public class LEDParam
    {
        private string id;
        /// <summary>
        /// id
        /// </summary>
        public int ID
        {
            get { return int.Parse(id); }
            set { id = value.ToString(); }
        }

        private string screenIp;
        /// <summary>
        /// IP地址
        /// </summary>
        public string ScreenIp
        {
            get { return screenIp; }
            set { screenIp = value; }
        }

        private string length;
        /// <summary>
        /// 宽
        /// </summary>
        public int Length
        {
            get { return int.Parse(length); }
            set { length = value.ToString(); }
        }

        private string highth;
        /// <summary>
        /// 高
        /// </summary>
        public int Height
        {
            get { return int.Parse(highth); }
            set { highth = value.ToString(); }
        }

        private string oe;
        /// <summary>
        /// OE极性：0低有效 1高有效
        /// </summary>
        public int OE
        {
            get { return int.Parse(oe); }
            set { oe = value.ToString(); }
        }

        private string da;
        /// <summary>
        /// 数据极性：0负有效   1正有效
        /// </summary>
        public int DA
        {
            get { return int.Parse(da); }
            set { da = value.ToString(); }
        }



        //private string cardType;
        ///// <summary>
        ///// 卡型：BX_E    BX_5E1
        ///// </summary>
        //public string CardType
        //{
        //    get { return cardType; }
        //    set { cardType = value; }
        //}


        private string version;
        /// <summary>
        /// 屏幕类型
        /// </summary>
        public string Version
        {
            get { return version; }
            set { version = value; }
        }

        private int ledNo;
        /// <summary>
        /// 屏号
        /// </summary>
        public int LedNo
        {
            get { return ledNo; }
            set { ledNo = value; }
        }
        private int _WAREHOUSE_ID;
        /// <summary>
        /// 仓库ID
        /// </summary>
        public int WAREHOUSE_ID
        {
            get { return _WAREHOUSE_ID; }
            set { _WAREHOUSE_ID = value; }
        }

        private string _BERTH_CODE;
        /// <summary>
        /// 泊位代码
        /// </summary>
        public string BERTH_CODE
        {
            get { return _BERTH_CODE; }
            set { _BERTH_CODE = value; }
        }


        private int ledPicCount;
        /// <summary>
        ///  页数
        /// </summary>
        public int LedPicCount
        {
            get { return ledPicCount; }
            set { ledPicCount = value; }
        }

        private int ledPicPage;
        /// <summary>
        ///  页数(排队屏)
        /// </summary>
        public int LedPicPage
        {
            get { return ledPicPage; }
            set { ledPicPage = value; }
        }

        private int count;
        /// <summary>
        ///  总页数（排队屏）
        /// </summary>
        public int Count
        {
            get { return count; }
            set { count = value; }
        }
    }
}
