using System;

namespace LDV.WMS.RF.DataMapper
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class LdvQrCode : BaseEntity<LdvQrCode>
    {
        #region properties
        private Nullable<double> _ID;
        /// <summary>
        ///	ID
        /// </summary>
        public Nullable<double> ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        private string _QRCODE;
        /// <summary>
        ///	二维码数据
        /// </summary>
        public string QRCODE
        {
            get { return _QRCODE; }
            set { _QRCODE = value; }
        }

        private Nullable<double> _REF_ID;
        /// <summary>
        ///
        /// </summary>
        public Nullable<double> REF_ID
        {
            get { return _REF_ID; }
            set { _REF_ID = value; }
        }

        private string _REF_TYPE;
        /// <summary>
        ///	
        /// </summary>
        public string REF_TYPE
        {
            get { return _REF_TYPE; }
            set { _REF_TYPE = value; }
        }

        private Nullable<DateTime> _CREATED_TIME;
        /// <summary>
        ///	创建时间
        /// </summary>
        public Nullable<DateTime> CREATED_TIME
        {
            get { return _CREATED_TIME; }
            set { _CREATED_TIME = value; }
        }

        private string _CREATED_BY;
        /// <summary>
        ///	创建人
        /// </summary>
        public string CREATED_BY
        {
            get { return _CREATED_BY; }
            set { _CREATED_BY = value; }
        }

        #endregion

        public override bool SelectKey()
        {
            return false;
        }
    }
}
