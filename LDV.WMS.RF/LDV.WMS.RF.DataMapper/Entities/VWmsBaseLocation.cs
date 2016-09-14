using System;

namespace LDV.WMS.RF.DataMapper
{
	/// <summary>
	/// 
	/// </summary>
	[Serializable]
	public class VWmsBaseLocation : BaseEntity<VWmsBaseLocation>
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
		private string _LOC_CODE;
		/// <summary>
		///	
		/// </summary>
		public string LOC_CODE
		{
			get { return _LOC_CODE; }
			set { _LOC_CODE = value; }
		}
		private Nullable<double> _ZONE_ID;
		/// <summary>
		///	
		/// </summary>
		public Nullable<double> ZONE_ID
		{
			get { return _ZONE_ID; }
			set { _ZONE_ID = value; }
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
		private string _AISLE;
		/// <summary>
		///	
		/// </summary>
		public string AISLE
		{
			get { return _AISLE; }
			set { _AISLE = value; }
		}
		private string _BAY;
		/// <summary>
		///	
		/// </summary>
		public string BAY
		{
			get { return _BAY; }
			set { _BAY = value; }
		}
		private string _SHELF_LEVEL;
		/// <summary>
		///	
		/// </summary>
		public string SHELF_LEVEL
		{
			get { return _SHELF_LEVEL; }
			set { _SHELF_LEVEL = value; }
		}
		private string _SLOT;
		/// <summary>
		///	
		/// </summary>
		public string SLOT
		{
			get { return _SLOT; }
			set { _SLOT = value; }
		}
		private string _TYPE;
		/// <summary>
		///	
		/// </summary>
		public string TYPE
		{
			get { return _TYPE; }
			set { _TYPE = value; }
		}
		private Nullable<double> _IS_FROZON;
		/// <summary>
		///	
		/// </summary>
		public Nullable<double> IS_FROZON
		{
			get { return _IS_FROZON; }
			set { _IS_FROZON = value; }
		}
		private Nullable<double> _IS_DISABLED;
		/// <summary>
		///	
		/// </summary>
		public Nullable<double> IS_DISABLED
		{
			get { return _IS_DISABLED; }
			set { _IS_DISABLED = value; }
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
		private Nullable<DateTime> _LAST_MODIFIED;
		/// <summary>
		///	
		/// </summary>
		public Nullable<DateTime> LAST_MODIFIED
		{
			get { return _LAST_MODIFIED; }
			set { _LAST_MODIFIED = value; }
		}
		private string _EXTEND_COLUMN_0;
		/// <summary>
		///	
		/// </summary>
		public string EXTEND_COLUMN_0
		{
			get { return _EXTEND_COLUMN_0; }
			set { _EXTEND_COLUMN_0 = value; }
		}
		private string _EXTEND_COLUMN_1;
		/// <summary>
		///	
		/// </summary>
		public string EXTEND_COLUMN_1
		{
			get { return _EXTEND_COLUMN_1; }
			set { _EXTEND_COLUMN_1 = value; }
		}
		private string _EXTEND_COLUMN_2;
		/// <summary>
		///	
		/// </summary>
		public string EXTEND_COLUMN_2
		{
			get { return _EXTEND_COLUMN_2; }
			set { _EXTEND_COLUMN_2 = value; }
		}
		private string _EXTEND_COLUMN_3;
		/// <summary>
		///	
		/// </summary>
		public string EXTEND_COLUMN_3
		{
			get { return _EXTEND_COLUMN_3; }
			set { _EXTEND_COLUMN_3 = value; }
		}
		private string _EXTEND_COLUMN_4;
		/// <summary>
		///	
		/// </summary>
		public string EXTEND_COLUMN_4
		{
			get { return _EXTEND_COLUMN_4; }
			set { _EXTEND_COLUMN_4 = value; }
		}
		private Nullable<double> _MIN_BOX_QUANTITY;
		/// <summary>
		///	
		/// </summary>
		public Nullable<double> MIN_BOX_QUANTITY
		{
			get { return _MIN_BOX_QUANTITY; }
			set { _MIN_BOX_QUANTITY = value; }
		}
		private Nullable<double> _MAX_BOX_QUANTITY;
		/// <summary>
		///	
		/// </summary>
		public Nullable<double> MAX_BOX_QUANTITY
		{
			get { return _MAX_BOX_QUANTITY; }
			set { _MAX_BOX_QUANTITY = value; }
		}
		private Nullable<double> _IS_FLOOR;
		/// <summary>
		///	
		/// </summary>
		public Nullable<double> IS_FLOOR
		{
			get { return _IS_FLOOR; }
			set { _IS_FLOOR = value; }
		}
		private string _LOC_TYPE;
		/// <summary>
		///	
		/// </summary>
		public string LOC_TYPE
		{
			get { return _LOC_TYPE; }
			set { _LOC_TYPE = value; }
		}
		#endregion
		
		public override bool SelectKey()
        {
			return false;
        }
	}
}