using System;
using System.Collections.Generic;
using System.Text;
using Castle.ActiveRecord;

namespace WY.Library.Model
{
	/// <summary>
	/// �û�վ��� (���ݳ־ò����)
	/// </summary>
	[ActiveRecord("TB_User_Loc")]
	public class TBUserLoc : BaseModel
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

		private int _user_id;
		/// <summary>
		/// �û�ID
		/// </summary>
		[Property()]
		public int User_id
		{
			get { return this._user_id; }
			set { this._user_id = value; }
		}

		private int _first_loc_id;
		/// <summary>
		/// ��վ��ID
		/// </summary>
		[Property()]
		public int First_loc_id
		{
			get { return this._first_loc_id; }
			set { this._first_loc_id = value; }
		}

		private int _second_loc_id;
		/// <summary>
		/// ��վ��ID
		/// </summary>
		[Property()]
		public int Second_loc_id
		{
			get { return this._second_loc_id; }
			set { this._second_loc_id = value; }
		}

		private int _is_delete;
		/// <summary>
		/// �Ƿ�����
		/// </summary>
		[Property()]
		public int Is_delete
		{
			get { return this._is_delete; }
			set { this._is_delete = value; }
		}

	}
}
