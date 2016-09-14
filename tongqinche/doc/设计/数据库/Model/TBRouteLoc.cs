using System;
using System.Collections.Generic;
using System.Text;
using Castle.ActiveRecord;

namespace WY.Library.Model
{
	/// <summary>
	/// 线路站点关联表 (数据持久层对象)
	/// </summary>
	[ActiveRecord("TB_Route_Loc")]
	public class TBRouteLoc : BaseModel
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
		/// 线路ID
		/// </summary>
		[Property()]
		public int Route_id
		{
			get { return this._route_id; }
			set { this._route_id = value; }
		}

		private int _loc_id;
		/// <summary>
		/// 站点ID
		/// </summary>
		[Property()]
		public int Loc_id
		{
			get { return this._loc_id; }
			set { this._loc_id = value; }
		}

		private int _sequence;
		/// <summary>
		/// 顺序
		/// </summary>
		[Property()]
		public int Sequence
		{
			get { return this._sequence; }
			set { this._sequence = value; }
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
