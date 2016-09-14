using System;

namespace LDV.WMS.RF.DataMapper
{
	/// <summary>
	/// 
	/// </summary>
	[Serializable]
	public class LdvPlanCheckDetail : BaseEntity<LdvPlanCheckDetail>
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
		private Nullable<double> _PLAN_CHECK_ID;
		/// <summary>
		///	计划盘点ID
		/// </summary>
		public Nullable<double> PLAN_CHECK_ID
		{
			get { return _PLAN_CHECK_ID; }
			set { _PLAN_CHECK_ID = value; }
		}
		private Nullable<double> _LOC_ID;
		/// <summary>
		///	库位ID
		/// </summary>
		public Nullable<double> LOC_ID
		{
			get { return _LOC_ID; }
			set { _LOC_ID = value; }
		}
		private Nullable<double> _ITEM_ID;
		/// <summary>
		///	商品ID
		/// </summary>
		public Nullable<double> ITEM_ID
		{
			get { return _ITEM_ID; }
			set { _ITEM_ID = value; }
		}
		private Nullable<double> _QTY;
		/// <summary>
		///	库存数量
		/// </summary>
		public Nullable<double> QTY
		{
			get { return _QTY; }
			set { _QTY = value; }
		}
		private Nullable<double> _CHECK_QTY;
		/// <summary>
		///	盘点数量
		/// </summary>
		public Nullable<double> CHECK_QTY
		{
			get { return _CHECK_QTY; }
			set { _CHECK_QTY = value; }
		}
		private Nullable<double> _CHECK_USER_ID;
		/// <summary>
		///	盘点人
		/// </summary>
		public Nullable<double> CHECK_USER_ID
		{
			get { return _CHECK_USER_ID; }
			set { _CHECK_USER_ID = value; }
		}
		private Nullable<DateTime> _CHECK_DATE;
		/// <summary>
		///	盘点时间
		/// </summary>
		public Nullable<DateTime> CHECK_DATE
		{
			get { return _CHECK_DATE; }
			set { _CHECK_DATE = value; }
		}
		private string _STATE;
		/// <summary>
		///	状态:OP新建，FI完成
		/// </summary>
		public string STATE
		{
			get { return _STATE; }
			set { _STATE = value; }
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
		private Nullable<DateTime> _LAST_MODIFY_DATE;
		/// <summary>
		///	最近修改时间
		/// </summary>
		public Nullable<DateTime> LAST_MODIFY_DATE
		{
			get { return _LAST_MODIFY_DATE; }
			set { _LAST_MODIFY_DATE = value; }
		}
		private Nullable<double> _LAST_MODIFY_USER_ID;
		/// <summary>
		///	最近修改人
		/// </summary>
		public Nullable<double> LAST_MODIFY_USER_ID
		{
			get { return _LAST_MODIFY_USER_ID; }
			set { _LAST_MODIFY_USER_ID = value; }
		}
		#endregion
		
		public override bool SelectKey()
        {
			return false;
        }
	}
}