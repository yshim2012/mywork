using System;

namespace LDV.WMS.RF.DataMapper
{
	/// <summary>
	/// 
	/// </summary>
	[Serializable]
	public class VWmsBaseCustomer : BaseEntity<VWmsBaseCustomer>
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
		private string _CUST_CODE;
		/// <summary>
		///	客户代码
		/// </summary>
		public string CUST_CODE
		{
			get { return _CUST_CODE; }
			set { _CUST_CODE = value; }
		}
		private string _CUST_NAME;
		/// <summary>
		///	客户名字
		/// </summary>
		public string CUST_NAME
		{
			get { return _CUST_NAME; }
			set { _CUST_NAME = value; }
		}
		private Nullable<double> _PARENT_CUST_ID;
		/// <summary>
		///	母公司号
		/// </summary>
		public Nullable<double> PARENT_CUST_ID
		{
			get { return _PARENT_CUST_ID; }
			set { _PARENT_CUST_ID = value; }
		}
		private Nullable<double> _ADDRESS_ID;
		/// <summary>
		///	地址编号
		/// </summary>
		public Nullable<double> ADDRESS_ID
		{
			get { return _ADDRESS_ID; }
			set { _ADDRESS_ID = value; }
		}
		private string _COMMENTS;
		/// <summary>
		///	备注
		/// </summary>
		public string COMMENTS
		{
			get { return _COMMENTS; }
			set { _COMMENTS = value; }
		}
		private Nullable<double> _IS_DISABLED;
		/// <summary>
		///	是否已失效(默认0)
		/// </summary>
		public Nullable<double> IS_DISABLED
		{
			get { return _IS_DISABLED; }
			set { _IS_DISABLED = value; }
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
		#endregion
		
		public override bool SelectKey()
        {
			return false;
        }
	}
}