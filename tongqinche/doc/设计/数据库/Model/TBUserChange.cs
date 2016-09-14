using System;
using System.Collections.Generic;
using System.Text;
using Castle.ActiveRecord;

namespace WY.Library.Model
{
	/// <summary>
	/// �û���֤�� (���ݳ־ò����)
	/// </summary>
	[ActiveRecord("TB_User_Change")]
	public class TBUserChange : BaseModel
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

		private int _source;
		/// <summary>
		/// ������Դ
		/// </summary>
		[Property()]
		public int Source
		{
			get { return this._source; }
			set { this._source = value; }
		}

		private Nullable<DateTime> _inter_create_time;
		/// <summary>
		/// Ա������ʱ��
		/// </summary>
		[Property()]
		public Nullable<DateTime> Inter_create_time
		{
			get { return this._inter_create_time; }
			set { this._inter_create_time = value; }
		}

		private Nullable<DateTime> _inter_modify_time;
		/// <summary>
		/// �ӿ��޸�ʱ��
		/// </summary>
		[Property()]
		public Nullable<DateTime> Inter_modify_time
		{
			get { return this._inter_modify_time; }
			set { this._inter_modify_time = value; }
		}

		private string _user_key_num;
		/// <summary>
		/// ���֤��
		/// </summary>
		[Property()]
		public string User_key_num
		{
			get { return this._user_key_num; }
			set { this._user_key_num = value; }
		}

		private string _user_type;
		/// <summary>
		/// �û�����
		/// </summary>
		[Property()]
		public string User_type
		{
			get { return this._user_type; }
			set { this._user_type = value; }
		}

	}
}
