using System;

namespace LDV.WMS.RF.DataMapper
{
	/// <summary>
	/// 
	/// </summary>
	[Serializable]
	public class VWmsRcvDoc : BaseEntity<VWmsRcvDoc>
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
		private string _DOC_CODE;
		/// <summary>
		///	
		/// </summary>
		public string DOC_CODE
		{
			get { return _DOC_CODE; }
			set { _DOC_CODE = value; }
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
		private Nullable<double> _COMPANY_ID;
		/// <summary>
		///	
		/// </summary>
		public Nullable<double> COMPANY_ID
		{
			get { return _COMPANY_ID; }
			set { _COMPANY_ID = value; }
		}
		private string _STATUS;
		/// <summary>
		///	
		/// </summary>
		public string STATUS
		{
			get { return _STATUS; }
			set { _STATUS = value; }
		}
		private Nullable<DateTime> _ETA_DATE;
		/// <summary>
		///	
		/// </summary>
		public Nullable<DateTime> ETA_DATE
		{
			get { return _ETA_DATE; }
			set { _ETA_DATE = value; }
		}
		private Nullable<float> _TOTAL_COST;
		/// <summary>
		///	
		/// </summary>
		public Nullable<float> TOTAL_COST
		{
			get { return _TOTAL_COST; }
			set { _TOTAL_COST = value; }
		}
		private Nullable<float> _TOTAL_WEIGHT;
		/// <summary>
		///	
		/// </summary>
		public Nullable<float> TOTAL_WEIGHT
		{
			get { return _TOTAL_WEIGHT; }
			set { _TOTAL_WEIGHT = value; }
		}
		private Nullable<float> _TOTAL_COLUMN;
		/// <summary>
		///	
		/// </summary>
		public Nullable<float> TOTAL_COLUMN
		{
			get { return _TOTAL_COLUMN; }
			set { _TOTAL_COLUMN = value; }
		}
		private Nullable<float> _TOTAL_PIECES;
		/// <summary>
		///	
		/// </summary>
		public Nullable<float> TOTAL_PIECES
		{
			get { return _TOTAL_PIECES; }
			set { _TOTAL_PIECES = value; }
		}
		private Nullable<double> _DAMAGED_PIECES;
		/// <summary>
		///	
		/// </summary>
		public Nullable<double> DAMAGED_PIECES
		{
			get { return _DAMAGED_PIECES; }
			set { _DAMAGED_PIECES = value; }
		}
		private Nullable<double> _SUPPLIE_ID;
		/// <summary>
		///	
		/// </summary>
		public Nullable<double> SUPPLIE_ID
		{
			get { return _SUPPLIE_ID; }
			set { _SUPPLIE_ID = value; }
		}
		private string _FROM_NAME;
		/// <summary>
		///	
		/// </summary>
		public string FROM_NAME
		{
			get { return _FROM_NAME; }
			set { _FROM_NAME = value; }
		}
		private string _FROM_ADDR1;
		/// <summary>
		///	
		/// </summary>
		public string FROM_ADDR1
		{
			get { return _FROM_ADDR1; }
			set { _FROM_ADDR1 = value; }
		}
		private string _FROM_ADDR2;
		/// <summary>
		///	
		/// </summary>
		public string FROM_ADDR2
		{
			get { return _FROM_ADDR2; }
			set { _FROM_ADDR2 = value; }
		}
		private string _FROM_ADDR3;
		/// <summary>
		///	
		/// </summary>
		public string FROM_ADDR3
		{
			get { return _FROM_ADDR3; }
			set { _FROM_ADDR3 = value; }
		}
		private string _FROM_CITY;
		/// <summary>
		///	
		/// </summary>
		public string FROM_CITY
		{
			get { return _FROM_CITY; }
			set { _FROM_CITY = value; }
		}
		private string _FROM_STATE;
		/// <summary>
		///	
		/// </summary>
		public string FROM_STATE
		{
			get { return _FROM_STATE; }
			set { _FROM_STATE = value; }
		}
		private string _FROM_ZIP;
		/// <summary>
		///	
		/// </summary>
		public string FROM_ZIP
		{
			get { return _FROM_ZIP; }
			set { _FROM_ZIP = value; }
		}
		private string _FROM_PHONE;
		/// <summary>
		///	
		/// </summary>
		public string FROM_PHONE
		{
			get { return _FROM_PHONE; }
			set { _FROM_PHONE = value; }
		}
		private string _FROM_CONTACT_PERSON;
		/// <summary>
		///	
		/// </summary>
		public string FROM_CONTACT_PERSON
		{
			get { return _FROM_CONTACT_PERSON; }
			set { _FROM_CONTACT_PERSON = value; }
		}
		private string _FROM_FAX;
		/// <summary>
		///	
		/// </summary>
		public string FROM_FAX
		{
			get { return _FROM_FAX; }
			set { _FROM_FAX = value; }
		}
		private string _COMMENTS;
		/// <summary>
		///	
		/// </summary>
		public string COMMENTS
		{
			get { return _COMMENTS; }
			set { _COMMENTS = value; }
		}
		private Nullable<DateTime> _BILL_DATE;
		/// <summary>
		///	
		/// </summary>
		public Nullable<DateTime> BILL_DATE
		{
			get { return _BILL_DATE; }
			set { _BILL_DATE = value; }
		}
		private Nullable<DateTime> _CANCEL_DATE;
		/// <summary>
		///	
		/// </summary>
		public Nullable<DateTime> CANCEL_DATE
		{
			get { return _CANCEL_DATE; }
			set { _CANCEL_DATE = value; }
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
		private string _RCV_TYPE;
		/// <summary>
		///	
		/// </summary>
		public string RCV_TYPE
		{
			get { return _RCV_TYPE; }
			set { _RCV_TYPE = value; }
		}
		private Nullable<double> _FROM_WHSE;
		/// <summary>
		///	
		/// </summary>
		public Nullable<double> FROM_WHSE
		{
			get { return _FROM_WHSE; }
			set { _FROM_WHSE = value; }
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
		private string _TRACKNO;
		/// <summary>
		///	
		/// </summary>
		public string TRACKNO
		{
			get { return _TRACKNO; }
			set { _TRACKNO = value; }
		}
		private string _VTRNR;
		/// <summary>
		///	
		/// </summary>
		public string VTRNR
		{
			get { return _VTRNR; }
			set { _VTRNR = value; }
		}
		private string _LIFERSHEIN;
		/// <summary>
		///	
		/// </summary>
		public string LIFERSHEIN
		{
			get { return _LIFERSHEIN; }
			set { _LIFERSHEIN = value; }
		}
		private string _GOODSTYPE;
		/// <summary>
		///	
		/// </summary>
		public string GOODSTYPE
		{
			get { return _GOODSTYPE; }
			set { _GOODSTYPE = value; }
		}
		private string _SENDER;
		/// <summary>
		///	
		/// </summary>
		public string SENDER
		{
			get { return _SENDER; }
			set { _SENDER = value; }
		}
		private Nullable<float> _PLAN_QTY;
		/// <summary>
		///	
		/// </summary>
		public Nullable<float> PLAN_QTY
		{
			get { return _PLAN_QTY; }
			set { _PLAN_QTY = value; }
		}
		private Nullable<DateTime> _LAST_MODIFIED;
		/// <summary>
		///	
		/// </summary>
		public Nullable<DateTime> LAST_MODIFIED
		{
			get { return _LAST_MODIFIED; }
			set { _LAST_MODIFIED = value; }
		}
		private string _CREATED_OPERATOR;
		/// <summary>
		///	
		/// </summary>
		public string CREATED_OPERATOR
		{
			get { return _CREATED_OPERATOR; }
			set { _CREATED_OPERATOR = value; }
		}
		private Nullable<double> _IS_QUICK;
		/// <summary>
		///	
		/// </summary>
		public Nullable<double> IS_QUICK
		{
			get { return _IS_QUICK; }
			set { _IS_QUICK = value; }
		}
		private Nullable<DateTime> _DELIVERY_DATE;
		/// <summary>
		///	
		/// </summary>
		public Nullable<DateTime> DELIVERY_DATE
		{
			get { return _DELIVERY_DATE; }
			set { _DELIVERY_DATE = value; }
		}
		private string _TIME_WINDOW;
		/// <summary>
		///	
		/// </summary>
		public string TIME_WINDOW
		{
			get { return _TIME_WINDOW; }
			set { _TIME_WINDOW = value; }
		}
		#endregion
		
		public override bool SelectKey()
        {
			return false;
        }
	}
}