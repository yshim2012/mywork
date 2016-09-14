using System;
using System.Text;

namespace DataMapper
{
    public class Deliver : BaseEntity<Deliver>
    {
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
        public decimal PLAN_OUT_QTY
        {
            get;
            set;
        }
        public decimal REAL_OUT_QTY
        {
            get;
            set;
        }
        public decimal CUSTOMER_RECEIVE_QTY
        {
            get;
            set;
        }
        public string DELIVER_TYPE
        {
            get;
            set;
        }
        public string DELIVER_REMARK
        {
            get;
            set;
        }
        public string RECEIVE_STATE
        {
            get;
            set;
        }
        public string CUSTOMER_RECEIVE_REMARK
        {
            get;
            set;
        }
        public Nullable<DateTime> OUT_TIME
        {
            get;
            set;
        }
        public Nullable<DateTime> CUSTOMER_RECEIVE_TIME
        {
            get;
            set;
        }
        public Nullable<DateTime> DEAL_TIME
        {
            get;
            set;
        }
        public string IS_DEAL
        {
            get;
            set;
        }
        public int DEAL_USER_ID
        {
            get;
            set;
        }
        public int RECEIVE_USER_ID
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

        public string WAREHOUSE_NAME
        {
            get;
            set;
        }
        public string PART_code
        {
            get;
            set;
        }
        public string PART_name
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

        public string BATCH_NO
        {
            get;
            set;
        }
        public string FURNACE_NO
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
        public string ORDER_REMARK
        {
            get;
            set;
        }
        public string USER_NAME
        {
            get;
            set;
        }
        public string USER_MOBILE
        {
            get;
            set;
        }
        public string ORDER_STATE
        {
            get;
            set;
        }
        public string Supplier_NAME
        {
            get;
            set;
        }
        public string ORDER_NO
        {
            get;
            set;
        }
        public int WID
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


        public Nullable<DateTime> DeliverStartDate
        {
            get;
            set;
        }
        public Nullable<DateTime> DeliverEndDate
        {
            get;
            set;
        }

        public decimal QTY
        {
            get;
            set;
        }

        public int TYPE
        {
            get;
            set;
        }

        public int PACKAGE_CODE
        {
            get;
            set;
        }
        public int PACKAGE_NAME
        {
            get;
            set;
        }
        public int LENGTH
        {
            get;
            set;
        }
        public int WIDTH
        {
            get;
            set;
        }
        public int HEIGHT
        {
            get;
            set;
        }
        public int LOC_ID
        {
            get;
            set;
        }

        /// <summary>
        /// 计划单明细ID
        /// </summary>
        public int PLAN_DETAIL_ID
        {
            get;
            set;
        }

        public override bool SelectKey()
        {
            return true;
        } 
    }
}
