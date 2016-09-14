using System;
using System.Collections.Generic;
using System.Text;
using Castle.ActiveRecord;

namespace WY.Library.Model
{
	/// <summary>
	/// �����̱� (���ݳ־ò����)
	/// </summary>
	[ActiveRecord("TB_Carrier")]
	public class TBCarrier : BaseModel
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

		private string _carriername;
		/// <summary>
		/// ����������
		/// </summary>
		[Property()]
		public string Carriername
		{
			get { return this._carriername; }
			set { this._carriername = value; }
		}

		private string _contact;
		/// <summary>
		/// ��ϵ��
		/// </summary>
		[Property()]
		public string Contact
		{
			get { return this._contact; }
			set { this._contact = value; }
		}

		private string _mobile;
		/// <summary>
		/// �ֻ�
		/// </summary>
		[Property()]
		public string Mobile
		{
			get { return this._mobile; }
			set { this._mobile = value; }
		}

		private string _tel;
		/// <summary>
		/// �绰
		/// </summary>
		[Property()]
		public string Tel
		{
			get { return this._tel; }
			set { this._tel = value; }
		}

		private string _address;
		/// <summary>
		/// ��ַ
		/// </summary>
		[Property()]
		public string Address
		{
			get { return this._address; }
			set { this._address = value; }
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
