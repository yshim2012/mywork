using System;
using System.Collections.Generic;
using System.Text;
using Castle.ActiveRecord;

namespace WY.Library.Model
{
	/// <summary>
	/// 关于我们 (数据持久层对象)
	/// </summary>
	[ActiveRecord("TB_About")]
	public class TBAbout : BaseModel
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

		private string _content;
		/// <summary>
		/// 内容
		/// </summary>
		[Property()]
		public string Content
		{
			get { return this._content; }
			set { this._content = value; }
		}

	}
}
