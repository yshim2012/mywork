using System;

namespace LDV.WMS.RF.DataMapper
{
	/// <summary>
	/// 
	/// </summary>
	[Serializable]
	public class VWmsInvMu : BaseEntity<VWmsInvMu>
	{
		#region properties
		
		
		private Nullable<double> _ID;
		/// <summary>
		///	
		/// </summary>
		public Nullable<double> ID
		{
			get { return _ID; }
			set { _ID = value; }
		}
		private string _LP;
		/// <summary>
		///	
		/// </summary>
		public string LP
		{
			get { return _LP; }
			set { _LP = value; }
		}
		private Nullable<double> _WHSE_ID;
		/// <summary>
		///	
		/// </summary>
		public Nullable<double> WHSE_ID
		{
			get { return _WHSE_ID; }
			set { _WHSE_ID = value; }
		}
		private Nullable<double> _COMPANY_ID;
		/// <summary>
		///	
		/// </summary>
		public Nullable<double> COMPANY_ID
		{
			get { return _COMPANY_ID; }
			set { _COMPANY_ID = value; }
		}
		private Nullable<float> _WEIGHT;
		/// <summary>
		///	
		/// </summary>
		public Nullable<float> WEIGHT
		{
			get { return _WEIGHT; }
			set { _WEIGHT = value; }
		}
		private Nullable<float> _HEIGHT;
		/// <summary>
		///	
		/// </summary>
		public Nullable<float> HEIGHT
		{
			get { return _HEIGHT; }
			set { _HEIGHT = value; }
		}
		private Nullable<float> _LENGTH;
		/// <summary>
		///	
		/// </summary>
		public Nullable<float> LENGTH
		{
			get { return _LENGTH; }
			set { _LENGTH = value; }
		}
		private Nullable<float> _WIDTH;
		/// <summary>
		///	
		/// </summary>
		public Nullable<float> WIDTH
		{
			get { return _WIDTH; }
			set { _WIDTH = value; }
		}
		private string _PACK_CODE;
		/// <summary>
		///	
		/// </summary>
		public string PACK_CODE
		{
			get { return _PACK_CODE; }
			set { _PACK_CODE = value; }
		}
		private Nullable<double> _IS_DISABLED;
		/// <summary>
		///	
		/// </summary>
		public Nullable<double> IS_DISABLED
		{
			get { return _IS_DISABLED; }
			set { _IS_DISABLED = value; }
		}
		private Nullable<DateTime> _CREATED_TIME;
		/// <summary>
		///	
		/// </summary>
		public Nullable<DateTime> CREATED_TIME
		{
			get { return _CREATED_TIME; }
			set { _CREATED_TIME = value; }
		}
		private Nullable<DateTime> _LAST_MODIFIED;
		/// <summary>
		///	
		/// </summary>
		public Nullable<DateTime> LAST_MODIFIED
		{
			get { return _LAST_MODIFIED; }
			set { _LAST_MODIFIED = value; }
		}
		private string _PACKAGE_TYPE;
		/// <summary>
		///	
		/// </summary>
		public string PACKAGE_TYPE
		{
			get { return _PACKAGE_TYPE; }
			set { _PACKAGE_TYPE = value; }
		}
		private Nullable<double> _ITEM_ID;
		/// <summary>
		///	
		/// </summary>
		public Nullable<double> ITEM_ID
		{
			get { return _ITEM_ID; }
			set { _ITEM_ID = value; }
		}
		#endregion
		
		public override bool SelectKey()
        {
			return false;
        }
	}
}