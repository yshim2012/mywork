using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataMapper
{
    public class PartOprateHistory : BaseEntity<PartOprateHistory>
    {
        #region 
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

        public string OPERATE_TYPE
        {
            get;
            set;
        }

        public string PART_OWNER
        {
            get;
            set;
        }

        public int ORIGINAL_LOCATION_ID
        {
            get;
            set;
        }

        public int TARGET_LOCATION_ID
        {
            get;
            set;
        }

        public decimal FORMER_STORAGE_QTY
        {
            get;
            set;
        }

        public decimal AFTER_STORAGE_QTY
        {
            get;
            set;
        }

        public decimal OPERATE_QTY
        {
            get;
            set;
        }

        public int OPERATE_USER_ID
        {
            get;
            set;
        }

        public Nullable<DateTime> OPERATE_TIME
        {
            get;
            set;
        }

        public int ORDER_SOURCE_ID
        {
            get;
            set;
        }

        public int WAREHOUSE_ID
        {
            get;
            set;
        }

        public Nullable<DateTime> CREATE_TIME
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
