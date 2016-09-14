using System;
using System.Collections.Generic;
using System.Text;
using Castle.ActiveRecord;

namespace WY.Library.Model
{
	/// <summary>
	/// �˳���¼�� (���ݳ־ò����)
	/// </summary>
	[ActiveRecord("TB_RideRecord")]
	public class TBRideRecord : BaseModel
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

		private DateTime _ride_date;
		/// <summary>
		/// �˳�ʱ��
		/// </summary>
		[Property()]
		public DateTime Ride_date
		{
			get { return this._ride_date; }
			set { this._ride_date = value; }
		}

		private int _employeeid;
		/// <summary>
		/// Ա��ID
		/// </summary>
		[Property()]
		public int Employeeid
		{
			get { return this._employeeid; }
			set { this._employeeid = value; }
		}

		private int _shift_type_code;
		/// <summary>
		/// �������
		/// </summary>
		[Property()]
		public int Shift_type_code
		{
			get { return this._shift_type_code; }
			set { this._shift_type_code = value; }
		}

		private string _source;
		/// <summary>
		/// ������Դ
		/// </summary>
		[Property()]
		public string Source
		{
			get { return this._source; }
			set { this._source = value; }
		}

		private DateTime _uptime;
		/// <summary>
		/// �ϳ�ʱ��
		/// </summary>
		[Property()]
		public DateTime Uptime
		{
			get { return this._uptime; }
			set { this._uptime = value; }
		}

		private Nullable<DateTime> _dowmtime;
		/// <summary>
		/// �³�ʱ��
		/// </summary>
		[Property()]
		public Nullable<DateTime> Dowmtime
		{
			get { return this._dowmtime; }
			set { this._dowmtime = value; }
		}

		private int _uploc;
		/// <summary>
		/// �ϳ�վ��
		/// </summary>
		[Property()]
		public int Uploc
		{
			get { return this._uploc; }
			set { this._uploc = value; }
		}

		private int _dowmloc;
		/// <summary>
		/// �³�վ��
		/// </summary>
		[Property()]
		public int Dowmloc
		{
			get { return this._dowmloc; }
			set { this._dowmloc = value; }
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

		private string _loctype;
		/// <summary>
		/// վ������
		/// </summary>
		[Property()]
		public string Loctype
		{
			get { return this._loctype; }
			set { this._loctype = value; }
		}

		private string _truckno;
		/// <summary>
		/// ���ƺ�
		/// </summary>
		[Property()]
		public string Truckno
		{
			get { return this._truckno; }
			set { this._truckno = value; }
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
