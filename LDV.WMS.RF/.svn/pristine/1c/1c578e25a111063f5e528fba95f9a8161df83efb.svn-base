using System;

namespace LDV.WMS.RF.DataMapper
{
	/// <summary>
	/// 
	/// </summary>
	[Serializable]
	public class LdvPlanCheck : BaseEntity<LdvPlanCheck>
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
		private string _CHECK_CREDENCE;
		/// <summary>
		///	盘点凭证
		/// </summary>
		public string CHECK_CREDENCE
		{
			get { return _CHECK_CREDENCE; }
			set { _CHECK_CREDENCE = value; }
		}
		private Nullable<DateTime> _PLAN_CHECK_DATE;
		/// <summary>
		///	计划盘点日期
		/// </summary>
		public Nullable<DateTime> PLAN_CHECK_DATE
		{
			get { return _PLAN_CHECK_DATE; }
			set { _PLAN_CHECK_DATE = value; }
		}
		private string _STATE;
		/// <summary>
		///	状态:OP新建，FI完成，CK盘点中，IV无效
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