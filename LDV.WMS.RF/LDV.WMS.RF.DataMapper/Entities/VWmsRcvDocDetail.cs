using System;

namespace LDV.WMS.RF.DataMapper
{
	/// <summary>
	/// 
	/// </summary>
	[Serializable]
	public class VWmsRcvDocDetail : BaseEntity<VWmsRcvDocDetail>
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
		private Nullable<double> _RCV_DOC_ID;
		/// <summary>
		///	
		/// </summary>
		public Nullable<double> RCV_DOC_ID
		{
			get { return _RCV_DOC_ID; }
			set { _RCV_DOC_ID = value; }
		}
		private string _LINE_NO;
		/// <summary>
		///	
		/// </summary>
		public string LINE_NO
		{
			get { return _LINE_NO; }
			set { _LINE_NO = value; }
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
		private Nullable<float> _EXPECTED_QTY;
		/// <summary>
		///	
		/// </summary>
		public Nullable<float> EXPECTED_QTY
		{
			get { return _EXPECTED_QTY; }
			set { _EXPECTED_QTY = value; }
		}
		private Nullable<float> _ACTUAL_QTY;
		/// <summary>
		///	
		/// </summary>
		public Nullable<float> ACTUAL_QTY
		{
			get { return _ACTUAL_QTY; }
			set { _ACTUAL_QTY = value; }
		}
		private Nullable<float> _DMG_QTY;
		/// <summary>
		///	
		/// </summary>
		public Nullable<float> DMG_QTY
		{
			get { return _DMG_QTY; }
			set { _DMG_QTY = value; }
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
		private string _CAUSE;
		/// <summary>
		///	
		/// </summary>
		public string CAUSE
		{
			get { return _CAUSE; }
			set { _CAUSE = value; }
		}
		private Nullable<double> _IS_DAMAGE;
		/// <summary>
		///	
		/// </summary>
		public Nullable<double> IS_DAMAGE
		{
			get { return _IS_DAMAGE; }
			set { _IS_DAMAGE = value; }
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
		private Nullable<DateTime> _RECEIVEDATE;
		/// <summary>
		///	
		/// </summary>
		public Nullable<DateTime> RECEIVEDATE
		{
			get { return _RECEIVEDATE; }
			set { _RECEIVEDATE = value; }
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
		private Nullable<double> _INBOUND_STD_QTY;
		/// <summary>
		///	
		/// </summary>
		public Nullable<double> INBOUND_STD_QTY
		{
			get { return _INBOUND_STD_QTY; }
			set { _INBOUND_STD_QTY = value; }
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
		private string _VERSION;
		/// <summary>
		///	
		/// </summary>
		public string VERSION
		{
			get { return _VERSION; }
			set { _VERSION = value; }
		}
		private Nullable<double> _PICK_DETAIL_ID;
		/// <summary>
		///	
		/// </summary>
		public Nullable<double> PICK_DETAIL_ID
		{
			get { return _PICK_DETAIL_ID; }
			set { _PICK_DETAIL_ID = value; }
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
		private Nullable<double> _VERSION_TRANSACTION;
		/// <summary>
		///	
		/// </summary>
		public Nullable<double> VERSION_TRANSACTION
		{
			get { return _VERSION_TRANSACTION; }
			set { _VERSION_TRANSACTION = value; }
		}
		private Nullable<double> _IS_VMI;
		/// <summary>
		///	
		/// </summary>
		public Nullable<double> IS_VMI
		{
			get { return _IS_VMI; }
			set { _IS_VMI = value; }
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
		private string _VTRNR;
		/// <summary>
		///	
		/// </summary>
		public string VTRNR
		{
			get { return _VTRNR; }
			set { _VTRNR = value; }
		}
		private string _CROSSING;
		/// <summary>
		///	
		/// </summary>
		public string CROSSING
		{
			get { return _CROSSING; }
			set { _CROSSING = value; }
		}
		private Nullable<double> _QC_FLAG;
		/// <summary>
		///	
		/// </summary>
		public Nullable<double> QC_FLAG
		{
			get { return _QC_FLAG; }
			set { _QC_FLAG = value; }
		}
		private Nullable<double> _CONSIGNMENT;
		/// <summary>
		///	
		/// </summary>
		public Nullable<double> CONSIGNMENT
		{
			get { return _CONSIGNMENT; }
			set { _CONSIGNMENT = value; }
		}
		private Nullable<double> _ASSEMPLY_FLAG;
		/// <summary>
		///	
		/// </summary>
		public Nullable<double> ASSEMPLY_FLAG
		{
			get { return _ASSEMPLY_FLAG; }
			set { _ASSEMPLY_FLAG = value; }
		}
		private Nullable<double> _FINANCE_FLAG;
		/// <summary>
		///	
		/// </summary>
		public Nullable<double> FINANCE_FLAG
		{
			get { return _FINANCE_FLAG; }
			set { _FINANCE_FLAG = value; }
		}
		private Nullable<float> _QTY;
		/// <summary>
		///	
		/// </summary>
		public Nullable<float> QTY
		{
			get { return _QTY; }
			set { _QTY = value; }
		}
		private string _UOM_NAME;
		/// <summary>
		///	
		/// </summary>
		public string UOM_NAME
		{
			get { return _UOM_NAME; }
			set { _UOM_NAME = value; }
		}

        private Nullable<float> _RV_QTY;
        /// <summary>
        ///	
        /// </summary>
        public Nullable<float> RV_QTY
        {
            get { return _RV_QTY; }
            set { _RV_QTY = value; }
        }

        private Nullable<float> _PQ_QTY;
        /// <summary>
        ///	
        /// </summary>
        public Nullable<float> PQ_QTY
        {
            get { return _PQ_QTY; }
            set { _PQ_QTY = value; }
        }
		#endregion
		
		public override bool SelectKey()
        {
			return false;
        }
	}
}