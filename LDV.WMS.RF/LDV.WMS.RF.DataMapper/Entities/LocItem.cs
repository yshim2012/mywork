using System;

namespace LDV.WMS.RF.DataMapper
{
    /// <summary>
    /// 程序中的库存
    /// </summary>
    [Serializable]
    public class LocItem : BaseEntity<LocItem>
    {
        #region Properties
        private Nullable<double> _ID;
        /// <summary>
        /// 库存ID
        /// </summary>
        public Nullable<double> ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        private string _LOC_CODE;
        /// <summary>
        /// 库位
        /// </summary>
        public string LOC_CODE
        {
            get { return _LOC_CODE; }
            set { _LOC_CODE = value; }
        }

        private Nullable<double> _UID_ID;
        /// <summary>
        /// 商品细分ID
        /// </summary>
        public Nullable<double> UID_ID
        {
            get { return _UID_ID; }
            set { _UID_ID = value; }
        }

        private string _ITEM_CODE;
        /// <summary>
        /// 零件编码
        /// </summary>
        public string ITEM_CODE
        {
            get { return _ITEM_CODE; }
            set { _ITEM_CODE = value; }
        }

        private Nullable<double> _QTY;
        /// <summary>
        /// 数量
        /// </summary>
        public Nullable<double> QTY
        {
            get { return _QTY; }
            set { _QTY = value; }
        }
        #endregion

        public override bool SelectKey()
        {
            return false;
        }
    }
}
