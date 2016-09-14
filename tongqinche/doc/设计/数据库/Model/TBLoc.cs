using System;
using System.Collections.Generic;
using System.Text;
using Castle.ActiveRecord;

namespace WY.Library.Model
{
	/// <summary>
	/// 站点表 (数据持久层对象)
	/// </summary>
	[ActiveRecord("TB_Loc")]
	public class TBLoc : BaseModel
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

		private string _loc_code;
		/// <summary>
		/// 站点编号
		/// </summary>
		[Property()]
		public string Loc_code
		{
			get { return this._loc_code; }
			set { this._loc_code = value; }
		}

		private string _loc_name;
		/// <summary>
		/// 站点名称
		/// </summary>
		[Property()]
		public string Loc_name
		{
			get { return this._loc_name; }
			set { this._loc_name = value; }
		}

		private string _province_code;
		/// <summary>
		/// 所属省份
		/// </summary>
		[Property()]
		public string Province_code
		{
			get { return this._province_code; }
			set { this._province_code = value; }
		}

		private string _city_code;
		/// <summary>
		/// 所属市
		/// </summary>
		[Property()]
		public string City_code
		{
			get { return this._city_code; }
			set { this._city_code = value; }
		}

		private string _district_code;
		/// <summary>
		/// 所属区域
		/// </summary>
		[Property()]
		public string District_code
		{
			get { return this._district_code; }
			set { this._district_code = value; }
		}

		private string _locaddress;
		/// <summary>
		/// 站点地址
		/// </summary>
		[Property()]
		public string Locaddress
		{
			get { return this._locaddress; }
			set { this._locaddress = value; }
		}

		private string _loctype;
		/// <summary>
		/// 站点类型
		/// </summary>
		[Property()]
		public string Loctype
		{
			get { return this._loctype; }
			set { this._loctype = value; }
		}

		private string _longitude;
		/// <summary>
		/// 经度
		/// </summary>
		[Property()]
		public string Longitude
		{
			get { return this._longitude; }
			set { this._longitude = value; }
		}

		private string _latitude;
		/// <summary>
		/// 纬度
		/// </summary>
		[Property()]
		public string Latitude
		{
			get { return this._latitude; }
			set { this._latitude = value; }
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
