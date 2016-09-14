using System;
using System.Collections.Generic;
using System.Text;
using Castle.ActiveRecord;

namespace WY.Library.Model
{
	/// <summary>
	/// �û��� (���ݳ־ò����)
	/// </summary>
	[ActiveRecord("TB_User")]
	public class TBUser : BaseModel
	{
		private int _id;
		/// <summary>
		/// ID
		/// </summary>
		[PrimaryKey(PrimaryKeyType.Native)]
		public int Id
		{
			get { return this._id; }
			set { this._id = value; }
		}

		private string _user_name;
		/// <summary>
		/// �ǳ�
		/// </summary>
		[Property()]
		public string User_name
		{
			get { return this._user_name; }
			set { this._user_name = value; }
		}

		private string _real_name;
		/// <summary>
		/// ��ʵ����
		/// </summary>
		[Property()]
		public string Real_name
		{
			get { return this._real_name; }
			set { this._real_name = value; }
		}

		private string _icon_url;
		/// <summary>
		/// ͷ��
		/// </summary>
		[Property()]
		public string Icon_url
		{
			get { return this._icon_url; }
			set { this._icon_url = value; }
		}

		private string _employee_no;
		/// <summary>
		/// ����
		/// </summary>
		[Property()]
		public string Employee_no
		{
			get { return this._employee_no; }
			set { this._employee_no = value; }
		}

		private string _password;
		/// <summary>
		/// ����
		/// </summary>
		[Property()]
		public string Password
		{
			get { return this._password; }
			set { this._password = value; }
		}

		private string _department_name;
		/// <summary>
		/// ����
		/// </summary>
		[Property()]
		public string Department_name
		{
			get { return this._department_name; }
			set { this._department_name = value; }
		}

		private string _company_name;
		/// <summary>
		/// ��ְ��˾
		/// </summary>
		[Property()]
		public string Company_name
		{
			get { return this._company_name; }
			set { this._company_name = value; }
		}

		private string _tel;
		/// <summary>
		/// ��ϵ�绰
		/// </summary>
		[Property()]
		public string Tel
		{
			get { return this._tel; }
			set { this._tel = value; }
		}

		private string _email;
		/// <summary>
		/// ����
		/// </summary>
		[Property()]
		public string Email
		{
			get { return this._email; }
			set { this._email = value; }
		}

		private int _is_delete;
		/// <summary>
		/// �Ƿ�����
		/// </summary>
		[Property()]
		public int Is_delete
		{
			get { return this._is_delete; }
			set { this._is_delete = value; }
		}

		private Nullable<DateTime> _delete_date;
		/// <summary>
		/// ����ʱ��
		/// </summary>
		[Property()]
		public Nullable<DateTime> Delete_date
		{
			get { return this._delete_date; }
			set { this._delete_date = value; }
		}

		private Nullable<DateTime> _last_login_time;
		/// <summary>
		/// ����¼ʱ��
		/// </summary>
		[Property()]
		public Nullable<DateTime> Last_login_time
		{
			get { return this._last_login_time; }
			set { this._last_login_time = value; }
		}

	}
}
