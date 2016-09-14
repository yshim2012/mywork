using System;
using System.Collections.Generic;
using System.Text;
using Castle.ActiveRecord;

namespace WY.Library.Model
{
	/// <summary>
	/// 员工表 (数据持久层对象)
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
		/// 工号
		/// </summary>
		[Property()]
		public string Employeeno
		{
			get { return this._employeeno; }
			set { this._employeeno = value; }
		}

		private string _cardno;
		/// <summary>
		/// 胸卡卡号
		/// </summary>
		[Property()]
		public string Cardno
		{
			get { return this._cardno; }
			set { this._cardno = value; }
		}

		private string _name;
		/// <summary>
		/// 姓名
		/// </summary>
		[Property()]
		public string Name
		{
			get { return this._name; }
			set { this._name = value; }
		}

		private string _phone;
		/// <summary>
		/// 手机
		/// </summary>
		[Property()]
		public string Phone
		{
			get { return this._phone; }
			set { this._phone = value; }
		}

		private string _email;
		/// <summary>
		/// 邮箱
		/// </summary>
		[Property()]
		public string Email
		{
			get { return this._email; }
			set { this._email = value; }
		}

		private int _importtype;
		/// <summary>
		/// 导入类型
		/// </summary>
		[Property()]
		public int Importtype
		{
			get { return this._importtype; }
			set { this._importtype = value; }
		}

		private string _department;
		/// <summary>
		/// 所属部门
		/// </summary>
		[Property()]
		public string Department
		{
			get { return this._department; }
			set { this._department = value; }
		}

		private string _company;
		/// <summary>
		/// 所属公司
		/// </summary>
		[Property()]
		public string Company
		{
			get { return this._company; }
			set { this._company = value; }
		}

		private int _listtype;
		/// <summary>
		/// 名单类型
		/// </summary>
		[Property()]
		public int Listtype
		{
			get { return this._listtype; }
			set { this._listtype = value; }
		}

		private int _status;
		/// <summary>
		/// 状态
		/// </summary>
		[Property()]
		public int Status
		{
			get { return this._status; }
			set { this._status = value; }
		}

		private DateTime _createtime;
		/// <summary>
		/// 创建时间
		/// </summary>
		[Property()]
		public DateTime Createtime
		{
			get { return this._createtime; }
			set { this._createtime = value; }
		}

		private int _createuserid;
		/// <summary>
		/// 创建用户
		/// </summary>
		[Property()]
		public int Createuserid
		{
			get { return this._createuserid; }
			set { this._createuserid = value; }
		}

		private DateTime _updatetime;
		/// <summary>
		/// 最后更新时间
		/// </summary>
		[Property()]
		public DateTime Updatetime
		{
			get { return this._updatetime; }
			set { this._updatetime = value; }
		}

		private int _updateuserid;
		/// <summary>
		/// 最后更新用户
		/// </summary>
		[Property()]
		public int Updateuserid
		{
			get { return this._updateuserid; }
			set { this._updateuserid = value; }
		}

	}
}
