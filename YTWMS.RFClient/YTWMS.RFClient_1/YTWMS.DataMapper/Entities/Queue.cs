using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataMapper
{
    /// <summary>
    /// Queue
    /// </summary>
    [Serializable]
    public class Queue : BaseEntity<Queue>
    {
        #region property
        public int ID
        {
            get;
            set;
        }
        public int ORDER_BUSINESS_ID
        {
            get;
            set;
        }
        public int PART_ID
        {
            get;
            set;
        }
        public int SUPPLIER_ID
        {
            get;
            set;
        }
        public int PROJECT_ID
        {
            get;
            set;
        }
        public int PROJECT_ITEM_ID
        {
            get;
            set;
        }
        public decimal PLAN_QUEUE_QTY
        {
            get;
            set;
        }
        public string QUEUE_NO
        {
            get;
            set;
        }
        public Nullable<DateTime> QUEUE_TIME
        {
            get;
            set;
        }
        public int WAREHOUSE_ID
        {
            get;
            set;
        }
        public string IS_DISABLE
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
        public Nullable<DateTime> ORDER_DELIVER_TIME
        {
            get;
            set;
        }


        public string WAREHOUSE_NAME
        {
            get;
            set;
        }
        public string PART_CODE
        {
            get;
            set;
        }
        public string PART_NAME
        {
            get;
            set;
        }
        public string ORDER_STATE
        {
            get;
            set;
        }

        public string ORDER_NO
        {
            get;
            set;
        }
        public string PROJECT_NAME
        {
            get;
            set;
        }
        public string PROJECT_ITEM_NAME
        {
            get;
            set;
        }

        public int ORDER_SOURCE_ID
        {
            get;
            set;
        }

        public int BATCH_PART_ID
        {
            get;
            set;
        }

        public int WAREHOUSE_LOCATION_ID
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
