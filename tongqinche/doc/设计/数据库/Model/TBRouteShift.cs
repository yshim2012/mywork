using System;
using System.Collections.Generic;
using System.Text;
using Castle.ActiveRecord;

namespace WY.Library.Model
{
	/// <summary>
	/// ·�߰�α� (���ݳ־ò����)
	/// </summary>
	[ActiveRecord("TB_Route_Shift")]
	public class TBRouteShift : BaseModel
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

		private int _route_id;
		/// <summary>
		/// ·��ID
		/// </summary>
		[Property()]
		public int Route_id
		{
			get { return this._route_id; }
			set { this._route_id = value; }
		}

		private string _table_name;
		/// <summary>
		/// ·��������
		/// </summary>
		[Property()]
		public string Table_name
		{
			get { return this._table_name; }
			set { this._table_name = value; }
		}

		private string _shift_code;
		/// <summary>
		/// ��α���
		/// </summary>
		[Property()]
		public string Shift_code
		{
			get { return this._shift_code; }
			set { this._shift_code = value; }
		}

		private string _shift_type_code;
		/// <summary>
		/// ������ͱ���
		/// </summary>
		[Property()]
		public string Shift_type_code
		{
			get { return this._shift_type_code; }
			set { this._shift_type_code = value; }
		}

		private string _car_type;
		/// <summary>
		/// ����
		/// </summary>
		[Property()]
		public string Car_type
		{
			get { return this._car_type; }
			set { this._car_type = value; }
		}

		private string _company_name;
		/// <summary>
		/// ������λ
		/// </summary>
		[Property()]
		public string Company_name
		{
			get { return this._company_name; }
			set { this._company_name = value; }
		}

		private int _plan_number;
		/// <summary>
		/// �ƻ�����
		/// </summary>
		[Property()]
		public int Plan_number
		{
			get { return this._plan_number; }
			set { this._plan_number = value; }
		}

		private string _departure_time;
		/// <summary>
		/// ����ʱ��
		/// </summary>
		[Property()]
		public string Departure_time
		{
			get { return this._departure_time; }
			set { this._departure_time = value; }
		}

		private int _space_time;
		/// <summary>
		/// ���ʱ��
		/// </summary>
		[Property()]
		public int Space_time
		{
			get { return this._space_time; }
			set { this._space_time = value; }
		}

		private string _end_time;
		/// <summary>
		/// ԤԼ��ֹʱ��
		/// </summary>
		[Property()]
		public string End_time
		{
			get { return this._end_time; }
			set { this._end_time = value; }
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
