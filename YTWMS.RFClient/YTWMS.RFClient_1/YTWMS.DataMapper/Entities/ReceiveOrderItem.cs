using System;
using System.Text;

namespace DataMapper
{
    public class ReceiveOrderItem : BaseEntity<ReceiveOrderItem>
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
        public int BATCH_PART_ID
        {
            get;
            set;
        }
        public decimal PLAN_IN_QTY
        {
            get;
            set;
        }
        public decimal REAL_IN_QTY
        {
            get;
            set;
        }
        public string TYPE
        {
            get;
            set;
        }
        public int RECOMMEND_LOC_ID
        {
            get;
            set;
        }
        public int LOCATION_ID
        {
            get;
            set;
        }
        public int ORDER_SOURCE_ID
        {
            get;
            set;
        }
        public string STATE
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
        public int BeginRowNum
        {
            get;
            set;
        }
        public int EndRowNum
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
