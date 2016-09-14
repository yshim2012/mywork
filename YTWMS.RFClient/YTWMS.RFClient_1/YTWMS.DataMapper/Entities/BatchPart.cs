using System;
using System.Text;

namespace DataMapper
{
    public class BatchPart : BaseEntity<BatchPart>
    {
        public int ID
        {
            get;
            set;
        }
        public int PART_ID
        {
            get;
            set;
        }
        public string UNIT
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
        public int WAREHOUSE_ID
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

        public ReceiveCheckOrderItem ReceiveItem
        {
            get;
            set;
        }

        //批次备注
        public string REMARK
        {
            get;
            set;
        }

        public string BOX_NUMBER
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
