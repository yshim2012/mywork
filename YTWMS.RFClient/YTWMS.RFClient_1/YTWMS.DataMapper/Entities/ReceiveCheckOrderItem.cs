using System;
using System.Text;

namespace DataMapper
{
    public class ReceiveCheckOrderItem : BaseEntity<ReceiveCheckOrderItem>
    {
        public int ID
        {
            get;
            set;
        }
        public int BATCH_PART_ID
        {
            get;
            set;
        }
        public decimal PLAN_QTY
        {
            get;
            set;
        }
        public decimal OUT_QTY
        {
            get;
            set;
        }
        public decimal CHECK_QTY
        {
            get;
            set;
        }
        public string STATUS
        {
            get;
            set;
        }
        public int ORDER_SOURCE_ID
        {
            get;
            set;
        }
        public int ORDER_BUSINESS_ID
        {
            get;
            set;
        }
        public string DETAIL_TYPE
        {
            get;
            set;
        }
        public string OUT_LOC
        {
            get;
            set;
        }
        public string REMARK
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

        public BatchPart BatchPart
        {
            get;
            set;
        }

        public ReceiveOrderItem ReceiveItem
        {
            get;
            set;
        }

        public int PART_ID
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
