using System;
using DataMapper;

namespace DataMapper
{
    /// <summary>
    /// OrderNum
    /// </summary>
    [Serializable]
    public class PartStock : BaseEntity<PartStock>
    {
        #region property
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

        public int WAREHOUSE_LOCATION_ID
        {
            get;
            set;
        }

        public string QUALITY_STATE
        {
            get;
            set;
        }

        public decimal STOCK_QTY
        {
            get;
            set;
        }

        public decimal PICKING_QTY
        {
            get;
            set;
        }

        public int PACKAGE_QTY
        {
            get;
            set;
        }

        public string PART_OWNER
        {
            get;
            set;
        }

        public string FROZEN_STATE
        {
            get;
            set;
        }

        public int WAREHOUSE_ID
        {
            get;
            set;
        }

        public DateTime CREATE_TIME
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
        public string PART_CODE { get; set; }
        public string PART_NAME { get; set; }
        public decimal REPACKAGING_QTY { get; set; }
        public string PROJECT_NAME { get; set; }
        public string PROJECT_ITEM_NAME { get; set; }
        public string BATCH_NO { get; set; }
        public string FURNACE_NO { get; set; }
        public string LOC_CODE { get; set; }
        public string SUPPLIER_NAME { get; set; }
        public string IS_FURNACE { get; set; }
        public string IS_QUALIFIED { get; set; }
        public string LOC_TYPE { get; set; }
        public string PART_TYPE { get; set; }
        #endregion 

        
        public override bool SelectKey()
        {
            return true;
        }
    }
}
