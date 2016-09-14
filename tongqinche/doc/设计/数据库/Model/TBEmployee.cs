using System;
using System.Collections.Generic;
using System.Text;
using Castle.ActiveRecord;

namespace WY.Library.Model
{
	/// <summary>
	/// Ա���� (���ݳ־ò����)
	/// </summary>
	[ActiveRecord("TB_Employee")]
	public class TBEmployee : BaseModel
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

		private string _employeeno;
		/// <summary>
		/// ����
		/// </summary>
		[Property()]
		public string Employeeno
		{
			get { return this._employeeno; }
			set { this._employeeno = value; }
		}

		private string _cardno;
		/// <summary>
		/// �ؿ�����
		/// </summary>
		[Property()]
		public string Cardno
		{
			get { return this._cardno; }
			set { this._cardno = value; }
		}

		private string _name;
		/// <summary>
		/// ����
		/// </summary>
		[Property()]
		public string Name
		{
			get { return this._name; }
			set { this._name = value; }
		}

		private string _phone;
		/// <summary>
		/// �ֻ�
		/// </summary>
		[Property()]
		public string Phone
		{
			get { return this._phone; }
			set { this._phone = value; }
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

		private int _importtype;
		/// <summary>
		/// ��������
		/// </summary>
		[Property()]
		public int Importtype
		{
			get { return this._importtype; }
			set { this._importtype = value; }
		}

		private string _department;
		/// <summary>
		/// ��������
		/// </summary>
		[Property()]
		public string Department
		{
			get { return this._department; }
			set { this._department = value; }
		}

		private string _company;
		/// <summary>
		/// ������˾
		/// </summary>
		[Property()]
		public string Company
		{
			get { return this._company; }
			set { this._company = value; }
		}

		private int _listtype;
		/// <summary>
		/// ��������
		/// </summary>
		[Property()]
		public int Listtype
		{
			get { return this._listtype; }
			set { this._listtype = value; }
		}

		private int _status;
		/// <summary>
		/// ״̬
		/// </summary>
		[Property()]
		public int Status
		{
			get { return this._status; }
			set { this._status = value; }
		}

		private DateTime _createtime;
		/// <summary>
		/// ����ʱ��
		/// </summary>
		[Property()]
		public DateTime Createtime
		{
			get { return this._createtime; }
			set { this._createtime = value; }
		}

		private int _createuserid;
		/// <summary>
		/// �����û�
		/// </summary>
		[Property()]
		public int Createuserid
		{
			get { return this._createuserid; }
			set { this._createuserid = value; }
		}

		private DateTime _updatetime;
		/// <summary>
		/// ������ʱ��
		/// </summary>
		[Property()]
		public DateTime Updatetime
		{
			get { return this._updatetime; }
			set { this._updatetime = value; }
		}

		private int _updateuserid;
		/// <summary>
		/// �������û�
		/// </summary>
		[Property()]
		public int Updateuserid
		{
			get { return this._updateuserid; }
			set { this._updateuserid = value; }
		}

	}
}
