using System;

namespace LDV.WMS.RF.DataMapper
{
	/// <summary>
	/// 
	/// </summary>
	[Serializable]
	public class LdvPackageBarcode : BaseEntity<LdvPackageBarcode>
	{
		#region properties
		
		
		private Nullable<double> _ID;
		/// <summary>
		///	
		/// </summary>
		public Nullable<double> ID
		{
			get { return _ID; }
			set { _ID = value; }
		}
		private string _PACKAGE_BARCODE;
		/// <summary>
		///	包装箱条码
		/// </summary>
		public string PACKAGE_BARCODE
		{
			get { return _PACKAGE_BARCODE; }
			set { _PACKAGE_BARCODE = value; }
		}
		private Nullable<DateTime> _CREATE_DATE;
		/// <summary>
		///	创建时间
		/// </summary>
		public Nullable<DateTime> CREATE_DATE
		{
			get { return _CREATE_DATE; }
			set { _CREATE_DATE = value; }
		}
		private Nullable<double> _CREATE_USER_ID;
		/// <summary>
		///	创建人
		/// </summary>
		public Nullable<double> CREATE_USER_ID
		{
			get { return _CREATE_USER_ID; }
			set { _CREATE_USER_ID = value; }
		}
        private string _STATUS;
        /// <summary>
        ///	状态
        /// </summary>
        public string STATUS
        {
            get { return _STATUS; }
            set { _STATUS = value; }
        }
        private Nullable<DateTime> _LAST_MODIFY_DATE;
        /// <summary>
        ///	最后修改时间
        /// </summary>
        public Nullable<DateTime> LAST_MODIFY_DATE
        {
            get { return _LAST_MODIFY_DATE; }
            set { _LAST_MODIFY_DATE = value; }
        }
        private int _BOX_NUM;

        public int BOX_NUM
        {
            get { return _BOX_NUM; }
            set { _BOX_NUM = value; }
        }
		#endregion
		
		public override bool SelectKey()
        {
			return false;
        }
	}
}