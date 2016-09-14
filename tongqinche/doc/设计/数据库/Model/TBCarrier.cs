using System;
using System.Collections.Generic;
using System.Text;
using Castle.ActiveRecord;

namespace WY.Library.Model
{
	/// <summary>
	/// 承运商表 (数据持久层对象)
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
		/// 承运商名称
		/// </summary>
		[Property()]
		public string Carriername
		{
			get { return this._carriername; }
			set { this._carriername = value; }
		}

		private string _contact;
		/// <summary>
		/// 联系人
		/// </summary>
		[Property()]
		public string Contact
		{
			get { return this._contact; }
			set { this._contact = value; }
		}

		private string _mobile;
		/// <summary>
		/// 手机
		/// </summary>
		[Property()]
		public string Mobile
		{
			get { return this._mobile; }
			set { this._mobile = value; }
		}

		private string _tel;
		/// <summary>
		/// 电话
		/// </summary>
		[Property()]
		public string Tel
		{
			get { return this._tel; }
			set { this._tel = value; }
		}

		private string _address;
		/// <summary>
		/// 地址
		/// </summary>
		[Property()]
		public string Address
		{
			get { return this._address; }
			set { this._address = value; }
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
