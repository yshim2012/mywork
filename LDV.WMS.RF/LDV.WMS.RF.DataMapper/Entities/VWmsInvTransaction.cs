using System;

namespace LDV.WMS.RF.DataMapper
{
	/// <summary>
	/// 
	/// </summary>
	[Serializable]
	public class VWmsInvTransaction : BaseEntity<VWmsInvTransaction>
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
		private string _TRANSACTION_CODE;
		/// <summary>
		///	
		/// </summary>
		public string TRANSACTION_CODE
		{
			get { return _TRANSACTION_CODE; }
			set { _TRANSACTION_CODE = value; }
		}
		private Nullable<double> _WHSE_ID;
		/// <summary>
		///	
		/// </summary>
		public Nullable<double> WHSE_ID
		{
			get { return _WHSE_ID; }
			set { _WHSE_ID = value; }
		}
		private Nullable<double> _LOC_ID;
		/// <summary>
		///	
		/// </summary>
		public Nullable<double> LOC_ID
		{
			get { return _LOC_ID; }
			set { _LOC_ID = value; }
		}
		private Nullable<double> _COMPANY_ID;
		/// <summary>
		///	
		/// </summary>
		public Nullable<double> COMPANY_ID
		{
			get { return _COMPANY_ID; }
			set { _COMPANY_ID = value; }
		}
		private Nullable<double> _ITEM_ID;
		/// <summary>
		///	
		/// </summary>
		public Nullable<double> ITEM_ID
		{
			get { return _ITEM_ID; }
			set { _ITEM_ID = value; }
		}
		private string _LOT;
		/// <summary>
		///	
		/// </summary>
		public string LOT
		{
			get { return _LOT; }
			set { _LOT = value; }
		}
		private string _SERIAL;
		/// <summary>
		///	
		/// </summary>
		public string SERIAL
		{
			get { return _SERIAL; }
			set { _SERIAL = value; }
		}
		private Nullable<DateTime> _XDATE;
		/// <summary>
		///	
		/// </summary>
		public Nullable<DateTime> XDATE
		{
			get { return _XDATE; }
			set { _XDATE = value; }
		}
		private Nullable<float> _F_QTY;
		/// <summary>
		///	
		/// </summary>
		public Nullable<float> F_QTY
		{
			get { return _F_QTY; }
			set { _F_QTY = value; }
		}
		private Nullable<float> _T_QTY;
		/// <summary>
		///	
		/// </summary>
		public Nullable<float> T_QTY
		{
			get { return _T_QTY; }
			set { _T_QTY = value; }
		}
		private Nullable<double> _F_MU_ID;
		/// <summary>
		///	
		/// </summary>
		public Nullable<double> F_MU_ID
		{
			get { return _F_MU_ID; }
			set { _F_MU_ID = value; }
		}
		private Nullable<double> _T_MU_ID;
		/// <summary>
		///	
		/// </summary>
		public Nullable<double> T_MU_ID
		{
			get { return _T_MU_ID; }
			set { _T_MU_ID = value; }
		}
		private string _F_STATUS;
		/// <summary>
		///	
		/// </summary>
		public string F_STATUS
		{
			get { return _F_STATUS; }
			set { _F_STATUS = value; }
		}
		private string _T_STATUS;
		/// <summary>
		///	
		/// </summary>
		public string T_STATUS
		{
			get { return _T_STATUS; }
			set { _T_STATUS = value; }
		}
		private string _F_ITEM_STATUS;
		/// <summary>
		///	
		/// </summary>
		public string F_ITEM_STATUS
		{
			get { return _F_ITEM_STATUS; }
			set { _F_ITEM_STATUS = value; }
		}
		private string _T_ITEM_STATUS;
		/// <summary>
		///	
		/// </summary>
		public string T_ITEM_STATUS
		{
			get { return _T_ITEM_STATUS; }
			set { _T_ITEM_STATUS = value; }
		}
		private string _REASON_CODE;
		/// <summary>
		///	
		/// </summary>
		public string REASON_CODE
		{
			get { return _REASON_CODE; }
			set { _REASON_CODE = value; }
		}
		private string _RELATED_DOC_TYPE;
		/// <summary>
		///	
		/// </summary>
		public string RELATED_DOC_TYPE
		{
			get { return _RELATED_DOC_TYPE; }
			set { _RELATED_DOC_TYPE = value; }
		}
		private string _RELATED_DOC_NO;
		/// <summary>
		///	
		/// </summary>
		public string RELATED_DOC_NO
		{
			get { return _RELATED_DOC_NO; }
			set { _RELATED_DOC_NO = value; }
		}
		private string _DESCRIPTION;
		/// <summary>
		///	
		/// </summary>
		public string DESCRIPTION
		{
			get { return _DESCRIPTION; }
			set { _DESCRIPTION = value; }
		}
		private string _USER_ID;
		/// <summary>
		///	
		/// </summary>
		public string USER_ID
		{
			get { return _USER_ID; }
			set { _USER_ID = value; }
		}
		private Nullable<DateTime> _CREATED_TIME;
		/// <summary>
		///	
		/// </summary>
		public Nullable<DateTime> CREATED_TIME
		{
			get { return _CREATED_TIME; }
			set { _CREATED_TIME = value; }
		}
		private Nullable<double> _T_LOC_ID;
		/// <summary>
		///	
		/// </summary>
		public Nullable<double> T_LOC_ID
		{
			get { return _T_LOC_ID; }
			set { _T_LOC_ID = value; }
		}
		private Nullable<DateTime> _F_RECEIVED_TIME;
		/// <summary>
		///	
		/// </summary>
		public Nullable<DateTime> F_RECEIVED_TIME
		{
			get { return _F_RECEIVED_TIME; }
			set { _F_RECEIVED_TIME = value; }
		}
		private Nullable<DateTime> _T_RECEIVED_TIME;
		/// <summary>
		///	
		/// </summary>
		public Nullable<DateTime> T_RECEIVED_TIME
		{
			get { return _T_RECEIVED_TIME; }
			set { _T_RECEIVED_TIME = value; }
		}
		private string _F_GOODSTYPE;
		/// <summary>
		///	
		/// </summary>
		public string F_GOODSTYPE
		{
			get { return _F_GOODSTYPE; }
			set { _F_GOODSTYPE = value; }
		}
		private string _T_GOODSTYPE;
		/// <summary>
		///	
		/// </summary>
		public string T_GOODSTYPE
		{
			get { return _T_GOODSTYPE; }
			set { _T_GOODSTYPE = value; }
		}
		private string _LX_CODE;
		/// <summary>
		///	
		/// </summary>
		public string LX_CODE
		{
			get { return _LX_CODE; }
			set { _LX_CODE = value; }
		}
		private Nullable<double> _SUPPLIER_ID;
		/// <summary>
		///	
		/// </summary>
		public Nullable<double> SUPPLIER_ID
		{
			get { return _SUPPLIER_ID; }
			set { _SUPPLIER_ID = value; }
		}
		#endregion
		
		public override bool SelectKey()
        {
			return false;
        }
	}
}