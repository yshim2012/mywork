using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataMapper
{
    /// <summary>
    /// LtUser
    /// </summary>
    [Serializable]
    public class OrderBusiness : BaseEntity<OrderBusiness>
    {
        #region property
        public int ID
        {
            get;
            set;
        }
        public int ORDER_NUM_ID
        {
            get;
            set;
        }
        public int SEND_LOC_ID
        {
            get;
            set;
        }
        public int RECEIVE_LOC_ID
        {
            get;
            set;
        }
        public string DOCK
        {
            get;
            set;
        }
        public string DRIVER_NAME
        {
            get;
            set;
        }
        public string TRUCK_NO
        {
            get;
            set;
        }
        public string ORDER_STATE
        {
            get;
            set;
        }
        public string ORDER_TYPE
        {
            get;
            set;
        }
        public string PART_OWNER
        {
            get;
            set;
        }
        public string PRODUCTION_STEP
        {
            get;
            set;
        }
        public Nullable<DateTime> ORDER_DELIVER_TIME
        {
            get;
            set;
        }
        public Nullable<DateTime> ORDER_END_TIME
        {
            get;
            set;
        }
        public string ORDER_REMARK
        {
            get;
            set;
        }
        public int USER_ID
        {
            get;
            set;
        }
        public Nullable<DateTime> CREATE_TIME
        {
            get;
            set;
        }
        public int CREATE_USER_ID
        {
            get;
            set;
        }
        public Nullable<DateTime> LAST_UPDATE
        {
            get;
            set;
        }
        public int UPDATE_USER_ID
        {
            get;
            set;
        }
        public string ORDER_NO
        {
            get;
            set;
        }
        public string USER_NAME
        {
            get;
            set;
        }
        public Nullable<DateTime> TOTAL_TIME
        {
            get;
            set;
        }
        public string PACKAGE_TYPE
        {
            get;
            set;
        }
        public string FURNACE_NO
        {
            get;
            set;
        }
        public string BATCH_NO
        {
            get;
            set;
        }
        public string PART_NAME
        {
            get;
            set;
        }
        public string PART_CODE
        {
            get;
            set;
        }
        public string WAREHOUSE_NAME
        {
            get;
            set;
        }


        /// <summary>
        ///  计划时间
        /// </summary>
        public Nullable<DateTime> PLAN_TIME
        {
            get;
            set;
        }
        #endregion

        public override bool SelectKey()
        {
            return true;
        } 
    }
}
