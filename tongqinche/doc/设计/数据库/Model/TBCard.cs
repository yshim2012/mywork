using System;
using System.Collections.Generic;
using System.Text;
using Castle.ActiveRecord;

namespace WY.Library.Model
{
	/// <summary>
	/// �˳��� (���ݳ־ò����)
	/// </summary>
	[ActiveRecord("TB_Card")]
	public class TBCard : BaseModel
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

		private string _cardno;
		/// <summary>
		/// �˳�������
		/// </summary>
		[Property()]
		public string Cardno
		{
			get { return this._cardno; }
			set { this._cardno = value; }
		}

		private string _serialno;
		/// <summary>
		/// �˳�����ˮ��
		/// </summary>
		[Property()]
		public string Serialno
		{
			get { return this._serialno; }
			set { this._serialno = value; }
		}

		private string _employeeid;
		/// <summary>
		/// Ա��Id
		/// </summary>
		[Property()]
		public string Employeeid
		{
			get { return this._employeeid; }
			set { this._employeeid = value; }
		}

		private int _cardtype;
		/// <summary>
		/// �˳�������
		/// </summary>
		[Property()]
		public int Cardtype
		{
			get { return this._cardtype; }
			set { this._cardtype = value; }
		}

		private int _deposit;
		/// <summary>
		/// Ѻ��
		/// </summary>
		[Property()]
		public int Deposit
		{
			get { return this._deposit; }
			set { this._deposit = value; }
		}

		private int _balance;
		/// <summary>
		/// ���
		/// </summary>
		[Property()]
		public int Balance
		{
			get { return this._balance; }
			set { this._balance = value; }
		}

		private int _count;
		/// <summary>
		/// ����
		/// </summary>
		[Property()]
		public int Count
		{
			get { return this._count; }
			set { this._count = value; }
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
