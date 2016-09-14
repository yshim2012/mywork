using System;
using System.Collections.Generic;
using System.Text;
using Castle.ActiveRecord;

namespace WY.Library.Model
{
	/// <summary>
	/// 字典表 (数据持久层对象)
	/// </summary>
	[ActiveRecord("TB_Dict")]
	public class TBDict : BaseModel
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

		private string _code;
		/// <summary>
		/// 编码
		/// </summary>
		[Property()]
		public string Code
		{
			get { return this._code; }
			set { this._code = value; }
		}

		private string _name;
		/// <summary>
		/// 名称
		/// </summary>
		[Property()]
		public string Name
		{
			get { return this._name; }
			set { this._name = value; }
		}

		private string _parent_code;
		/// <summary>
		/// 上级编码
		/// </summary>
		[Property()]
		public string Parent_code
		{
			get { return this._parent_code; }
			set { this._parent_code = value; }
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

	}
}
