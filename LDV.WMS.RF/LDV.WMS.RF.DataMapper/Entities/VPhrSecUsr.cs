using System;

namespace LDV.WMS.RF.DataMapper
{
	/// <summary>
	/// 
	/// </summary>
	[Serializable]
	public class VPhrSecUsr : BaseEntity<VPhrSecUsr>
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
		private Nullable<double> _IS_DISABLED;
		/// <summary>
		///	
		/// </summary>
		public Nullable<double> IS_DISABLED
		{
			get { return _IS_DISABLED; }
			set { _IS_DISABLED = value; }
		}
		private Nullable<double> _IS_SYSTEM;
		/// <summary>
		///	
		/// </summary>
		public Nullable<double> IS_SYSTEM
		{
			get { return _IS_SYSTEM; }
			set { _IS_SYSTEM = value; }
		}
		private string _LOGIN_NAME;
		/// <summary>
        ///	登入名
		/// </summary>
		public string LOGIN_NAME
		{
			get { return _LOGIN_NAME; }
			set { _LOGIN_NAME = value; }
		}
		private string _ENCRYPTED_PASSWORD;
		/// <summary>
        ///	密码
		/// </summary>
		public string ENCRYPTED_PASSWORD
		{
			get { return _ENCRYPTED_PASSWORD; }
			set { _ENCRYPTED_PASSWORD = value; }
		}
		private string _FIRST_NAME;
		/// <summary>
		///	
		/// </summary>
		public string FIRST_NAME
		{
			get { return _FIRST_NAME; }
			set { _FIRST_NAME = value; }
		}
		private string _LAST_NAME;
		/// <summary>
		///	
		/// </summary>
		public string LAST_NAME
		{
			get { return _LAST_NAME; }
			set { _LAST_NAME = value; }
		}
		private Nullable<DateTime> _BIRTHDAY;
		/// <summary>
		///	
		/// </summary>
		public Nullable<DateTime> BIRTHDAY
		{
			get { return _BIRTHDAY; }
			set { _BIRTHDAY = value; }
		}
		private Nullable<double> _IS_FEMALE;
		/// <summary>
		///	
		/// </summary>
		public Nullable<double> IS_FEMALE
		{
			get { return _IS_FEMALE; }
			set { _IS_FEMALE = value; }
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
		private string _EMAIL;
		/// <summary>
		///	
		/// </summary>
		public string EMAIL
		{
			get { return _EMAIL; }
			set { _EMAIL = value; }
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
		private Nullable<double> _LOGIN_COUNT;
		/// <summary>
		///	
		/// </summary>
		public Nullable<double> LOGIN_COUNT
		{
			get { return _LOGIN_COUNT; }
			set { _LOGIN_COUNT = value; }
		}
		private Nullable<DateTime> _DISABLED_TIME;
		/// <summary>
		///	
		/// </summary>
		public Nullable<DateTime> DISABLED_TIME
		{
			get { return _DISABLED_TIME; }
			set { _DISABLED_TIME = value; }
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
		private Nullable<DateTime> _LAST_LOGIN;
		/// <summary>
		///	
		/// </summary>
		public Nullable<DateTime> LAST_LOGIN
		{
			get { return _LAST_LOGIN; }
			set { _LAST_LOGIN = value; }
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
        ///	登入时间
		/// </summary>
		public string EXTEND_COLUMN_0
		{
			get { return _EXTEND_COLUMN_0; }
			set { _EXTEND_COLUMN_0 = value; }
		}
		private string _EXTEND_COLUMN_1;
		/// <summary>
        ///	当前操作单号
		/// </summary>
		public string EXTEND_COLUMN_1
		{
			get { return _EXTEND_COLUMN_1; }
			set { _EXTEND_COLUMN_1 = value; }
		}
		private string _EXTEND_COLUMN_2;
		/// <summary>
		///	操作类型：收货、拣货、核料、盘点、其它
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
		private string _EXTEND_COLUMN_5;
		/// <summary>
		///	
		/// </summary>
		public string EXTEND_COLUMN_5
		{
			get { return _EXTEND_COLUMN_5; }
			set { _EXTEND_COLUMN_5 = value; }
		}
		private string _EXTEND_COLUMN_6;
		/// <summary>
		///	
		/// </summary>
		public string EXTEND_COLUMN_6
		{
			get { return _EXTEND_COLUMN_6; }
			set { _EXTEND_COLUMN_6 = value; }
		}
		private string _EXTEND_COLUMN_7;
		/// <summary>
		///	
		/// </summary>
		public string EXTEND_COLUMN_7
		{
			get { return _EXTEND_COLUMN_7; }
			set { _EXTEND_COLUMN_7 = value; }
		}
		private string _EXTEND_COLUMN_8;
		/// <summary>
		///	
		/// </summary>
		public string EXTEND_COLUMN_8
		{
			get { return _EXTEND_COLUMN_8; }
			set { _EXTEND_COLUMN_8 = value; }
		}
		private string _EXTEND_COLUMN_9;
		/// <summary>
		///	
		/// </summary>
		public string EXTEND_COLUMN_9
		{
			get { return _EXTEND_COLUMN_9; }
			set { _EXTEND_COLUMN_9 = value; }
		}
		#endregion
		
		public override bool SelectKey()
        {
			return false;
        }
	}
}