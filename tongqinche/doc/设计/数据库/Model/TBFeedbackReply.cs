using System;
using System.Collections.Generic;
using System.Text;
using Castle.ActiveRecord;

namespace WY.Library.Model
{
	/// <summary>
	/// 意见反馈回复表 (数据持久层对象)
	/// </summary>
	[ActiveRecord("TB_Feedback_Reply")]
	public class TBFeedbackReply : BaseModel
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

		private int _feedback_id;
		/// <summary>
		/// 主消息ID
		/// </summary>
		[Property()]
		public int Feedback_id
		{
			get { return this._feedback_id; }
			set { this._feedback_id = value; }
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

		private int _user_id;
		/// <summary>
		/// 发布人ID
		/// </summary>
		[Property()]
		public int User_id
		{
			get { return this._user_id; }
			set { this._user_id = value; }
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
