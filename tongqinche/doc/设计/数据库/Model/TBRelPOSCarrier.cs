using System;
using System.Collections.Generic;
using System.Text;
using Castle.ActiveRecord;

namespace WY.Library.Model
{
	/// <summary>
	/// 车载机与承运商关系表 (数据持久层对象)
	/// </summary>
	[ActiveRecord("TB_Rel_POS_Carrier")]
	public class TBRelPOSCarrier : BaseModel
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

		private string _posid;
		/// <summary>
		/// 车载机ID
		/// </summary>
		[Property()]
		public string Posid
		{
			get { return this._posid; }
			set { this._posid = value; }
		}

		private string _carrierid;
		/// <summary>
		/// 承运商ID
		/// </summary>
		[Property()]
		public string Carrierid
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
