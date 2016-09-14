using System;
using System.Collections.Generic;
using System.Text;
using Castle.ActiveRecord;

namespace WY.Library.Model
{
	/// <summary>
	/// 车载机表 (数据持久层对象)
	/// </summary>
	[ActiveRecord("TB_POS")]
	public class TBPOS : BaseModel
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

		private string _posno;
		/// <summary>
		/// 车载机编号
		/// </summary>
		[Property()]
		public string Posno
		{
			get { return this._posno; }
			set { this._posno = value; }
		}

		private string _ip;
		/// <summary>
		/// 车载机地址
		/// </summary>
		[Property()]
		public string Ip
		{
			get { return this._ip; }
			set { this._ip = value; }
		}

		private string _modelno;
		/// <summary>
		/// 型号
		/// </summary>
		[Property()]
		public string Modelno
		{
			get { return this._modelno; }
			set { this._modelno = value; }
		}

		private string _sn;
		/// <summary>
		/// S／N
		/// </summary>
		[Property()]
		public string Sn
		{
			get { return this._sn; }
			set { this._sn = value; }
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
