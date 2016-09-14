using System;
using System.Collections.Generic;
using System.Text;
using Castle.ActiveRecord;

namespace WY.Library.Model
{
	/// <summary>
	/// 意见反馈表 (数据持久层对象)
	/// </summary>
	[ActiveRecord("TB_Feedback")]
	public class TBFeedback : BaseModel
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

		private string _title;
		/// <summary>
		/// 标题
		/// </summary>
		[Property()]
		public string Title
		{
			get { return this._title; }
			set { this._title = value; }
		}

		private string _type_code;
		/// <summary>
		/// 类型ID
		/// </summary>
		[Property()]
		public string Type_code
		{
			get { return this._type_code; }
			set { this._type_code = value; }
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

		private DateTime _publish_date;
		/// <summary>
		/// 发布日期
		/// </summary>
		[Property()]
		public DateTime Publish_date
		{
			get { return this._publish_date; }
			set { this._publish_date = value; }
		}

		private int _publish_user_id;
		/// <summary>
		/// 发布人ID
		/// </summary>
		[Property()]
		public int Publish_user_id
		{
			get { return this._publish_user_id; }
			set { this._publish_user_id = value; }
		}

		private int _reply_num;
		/// <summary>
		/// 回复数
		/// </summary>
		[Property()]
		public int Reply_num
		{
			get { return this._reply_num; }
			set { this._reply_num = value; }
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
