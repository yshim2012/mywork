using System;
using System.Text;

namespace DataMapper
{
    public class PartLoc : BaseEntity<PartLoc>
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
        public int LOC_ID
        {
            get;
            set;
        }
        public string LOC_TYPE
        {
            get;
            set;
        }
        public int LOC_MIN
        {
            get;
            set;
        }
        public int LOC_MAX
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
        public int SUPPLIER_ID
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
