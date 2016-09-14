using System;
using System.Collections.Generic;
using System.Text;
using Castle.ActiveRecord;

namespace WY.Library.Model
{
	/// <summary>
	/// 公告表 (数据持久层对象)
	/// </summary>
	[ActiveRecord("TB_Notice")]
	public class TBNotice : BaseModel
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

		private string _picture_server_host;
		/// <summary>
		/// 图片服务器地址
		/// </summary>
		[Property()]
		public string Picture_server_host
		{
			get { return this._picture_server_host; }
			set { this._picture_server_host = value; }
		}

		private string _picture_url;
		/// <summary>
		/// 图片URL
		/// </summary>
		[Property()]
		public string Picture_url
		{
			get { return this._picture_url; }
			set { this._picture_url = value; }
		}

		private int _source;
		/// <summary>
		/// 消息来源
		/// </summary>
		[Property()]
		public int Source
		{
			get { return this._source; }
			set { this._source = value; }
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
