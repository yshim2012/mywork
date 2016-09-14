using System;

namespace LDV.WMS.RF.DataMapper
{
	/// <summary>
	/// 
	/// </summary>
	[Serializable]
	public class VWmsInvDetail : BaseEntity<VWmsInvDetail>
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
		private Nullable<double> _LOC_ID;
		/// <summary>
		///	
		/// </summary>
		public Nullable<double> LOC_ID
		{
			get { return _LOC_ID; }
			set { _LOC_ID = value; }
		}
		private Nullable<double> _MU_ID;
		/// <summary>
		///	
		/// </summary>
		public Nullable<double> MU_ID
		{
			get { return _MU_ID; }
			set { _MU_ID = value; }
		}
		private Nullable<double> _UID_ID;
		/// <summary>
		///	
		/// </summary>
		public Nullable<double> UID_ID
		{
			get { return _UID_ID; }
			set { _UID_ID = value; }
		}
		private string _STATUS;
		/// <summary>
		///	
		/// </summary>
		public string STATUS
		{
			get { return _STATUS; }
			set { _STATUS = value; }
		}
		private string _ITEM_STATUS;
		/// <summary>
		///	
		/// </summary>
		public string ITEM_STATUS
		{
			get { return _ITEM_STATUS; }
			set { _ITEM_STATUS = value; }
		}
		private Nullable<float> _QTY;
		/// <summary>
		///	
		/// </summary>
		public Nullable<float> QTY
		{
			get { return _QTY; }
			set { _QTY = value; }
		}
		private Nullable<double> _VERSION_TRANSACTION;
		/// <summary>
		///	
		/// </summary>
		public Nullable<double> VERSION_TRANSACTION
		{
			get { return _VERSION_TRANSACTION; }
			set { _VERSION_TRANSACTION = value; }
		}
        private Nullable<float> _PLAN_PICK_QTY;
        public Nullable<float> PLAN_PICK_QTY
        {
            get { return _PLAN_PICK_QTY; }
            set { _PLAN_PICK_QTY = value; }
        }
		#endregion
		
		public override bool SelectKey()
        {
			return false;
        }
	}
}