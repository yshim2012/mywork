using System;

namespace LDV.WMS.RF.DataMapper
{
	/// <summary>
	/// LDV.WMS.RF.DataMapper
	/// </summary>
	[Serializable]
	public class VWmsItemLocationMap : BaseEntity<VWmsItemLocationMap>
	{
		#region properties
		
		
		private double _ID;
		/// <summary>
		///	
		/// </summary>
		public double ID
		{
			get { return _ID; }
			set { _ID = value; }
		}
		
		private Nullable<double> _ITEM_ID;
		/// <summary>
		///	商品id
		/// </summary>
		public Nullable<double> ITEM_ID
		{
			get { return _ITEM_ID; }
			set { _ITEM_ID = value; }
		}
		
		private Nullable<double> _SUPPLIER_ID;
		/// <summary>
		///	供应商id
		/// </summary>
		public Nullable<double> SUPPLIER_ID
		{
			get { return _SUPPLIER_ID; }
			set { _SUPPLIER_ID = value; }
		}
		
		private Nullable<double> _LOC_ID;
		/// <summary>
		///	位置id
		/// </summary>
		public Nullable<double> LOC_ID
		{
			get { return _LOC_ID; }
			set { _LOC_ID = value; }
		}
		
		private Nullable<double> _MAX_PUT_NUM;
		/// <summary>
		///	最大存放数量
		/// </summary>
		public Nullable<double> MAX_PUT_NUM
		{
			get { return _MAX_PUT_NUM; }
			set { _MAX_PUT_NUM = value; }
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
		///	最后更新时间
		/// </summary>
		public Nullable<DateTime> LAST_MODIFIED
		{
			get { return _LAST_MODIFIED; }
			set { _LAST_MODIFIED = value; }
		}
		
		private Nullable<double> _ORDER_NUM;
		/// <summary>
		///	排序
		/// </summary>
		public Nullable<double> ORDER_NUM
		{
			get { return _ORDER_NUM; }
			set { _ORDER_NUM = value; }
		}
		
		#endregion
		
		public override bool SelectKey()
        {
			return false;
        }
	}
}