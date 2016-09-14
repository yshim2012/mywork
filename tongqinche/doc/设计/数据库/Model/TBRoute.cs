using System;
using System.Collections.Generic;
using System.Text;
using Castle.ActiveRecord;

namespace WY.Library.Model
{
	/// <summary>
	/// 线路表 (数据持久层对象)
	/// </summary>
	[ActiveRecord("TB_Route")]
	public class TBRoute : BaseModel
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

		private string _route_code;
		/// <summary>
		/// 路线编号
		/// </summary>
		[Property()]
		public string Route_code
		{
			get { return this._route_code; }
			set { this._route_code = value; }
		}

		private string _route_name;
		/// <summary>
		/// 线路名称
		/// </summary>
		[Property()]
		public string Route_name
		{
			get { return this._route_name; }
			set { this._route_name = value; }
		}

		private int _carrierid;
		/// <summary>
		/// 运营单位
		/// </summary>
		[Property()]
		public int Carrierid
		{
			get { return this._carrierid; }
			set { this._carrierid = value; }
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
