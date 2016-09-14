using System;

namespace LDV.WMS.RF.DataMapper
{
	/// <summary>
	/// 
	/// </summary>
	[Serializable]
	public class VWmsPickQueue : BaseEntity<VWmsPickQueue>
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
		private Nullable<double> _BATCH_ID;
		/// <summary>
		///	捡货批号
		/// </summary>
		public Nullable<double> BATCH_ID
		{
			get { return _BATCH_ID; }
			set { _BATCH_ID = value; }
		}
		private Nullable<double> _PICK_TICKET_ID;
		/// <summary>
		///	捡货单号
		/// </summary>
		public Nullable<double> PICK_TICKET_ID
		{
			get { return _PICK_TICKET_ID; }
			set { _PICK_TICKET_ID = value; }
		}
		private string _LINE_NO;
		/// <summary>
		///	行号
		/// </summary>
		public string LINE_NO
		{
			get { return _LINE_NO; }
			set { _LINE_NO = value; }
		}
		private Nullable<double> _ITEM_ID;
		/// <summary>
		///	货物ID
		/// </summary>
		public Nullable<double> ITEM_ID
		{
			get { return _ITEM_ID; }
			set { _ITEM_ID = value; }
		}
		private string _LOT;
		/// <summary>
		///	批号
		/// </summary>
		public string LOT
		{
			get { return _LOT; }
			set { _LOT = value; }
		}
		private string _SERIAL;
		/// <summary>
		///	序列号
		/// </summary>
		public string SERIAL
		{
			get { return _SERIAL; }
			set { _SERIAL = value; }
		}
		private Nullable<DateTime> _XDATE;
		/// <summary>
		///	保质期
		/// </summary>
		public Nullable<DateTime> XDATE
		{
			get { return _XDATE; }
			set { _XDATE = value; }
		}
		private Nullable<double> _ORDER_QTY;
		/// <summary>
		///	订单数量
		/// </summary>
		public Nullable<double> ORDER_QTY
		{
			get { return _ORDER_QTY; }
			set { _ORDER_QTY = value; }
		}
		private Nullable<double> _ALLOC_QTY;
		/// <summary>
		///	分配数量
		/// </summary>
		public Nullable<double> ALLOC_QTY
		{
			get { return _ALLOC_QTY; }
			set { _ALLOC_QTY = value; }
		}
		private Nullable<double> _PICKED_QTY;
		/// <summary>
		///	捡货数量
		/// </summary>
		public Nullable<double> PICKED_QTY
		{
			get { return _PICKED_QTY; }
			set { _PICKED_QTY = value; }
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
		private Nullable<DateTime> _CREATED_TIME;
		/// <summary>
		///	创建时间
		/// </summary>
		public Nullable<DateTime> CREATED_TIME
		{
			get { return _CREATED_TIME; }
			set { _CREATED_TIME = value; }
		}
		private Nullable<DateTime> _LAST_MODIFIED;
		/// <summary>
		///	最后修改时间
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
		#endregion
		
		public override bool SelectKey()
        {
			return false;
        }
	}
}