using System;
using System.Text;

namespace DataMapper
{
    public class Part : BaseEntity<Part>
    {
        public int ID { get; set; }
        public string PART_CODE { get; set; }
        public string PART_NAME { get; set; }
        public string PART_TYPE { get; set; }
        public Nullable<int> LENGTH { get; set; }
        public Nullable<int> WIDTH { get; set; }
        public Nullable<int> HEIGHT { get; set; }
        public int OUTERPACKAGE_ID { get; set; }
        public int PIECESPER_OUTPACKAGE { get; set; }
        public int SUPPLIER_ID { get; set; }
        public int ORIGINALPACKAGE_ID { get; set; }
        public int PIECESPER_ORIGINALPACKAGE { get; set; }
        public int WAREHOUSE_ID { get; set; }
        public string IS_FURNACE { get; set; }
        public string IS_MUTIL { get; set; }
        public string IS_REPACKAGING { get; set; }
        public decimal REPACKAGING_QTY { get; set; }
        public string IS_INSPECTION { get; set; }
        public string REMARK { get; set; }
        public string IS_DISABLE { get; set; }
        public System.DateTime CREATE_TIME { get; set; }
        public int CREATE_USER_ID { get; set; }
        public Nullable<System.DateTime> LAST_UPDATE { get; set; }
        public Nullable<int> UPDATE_USER_ID { get; set; }
        public string SUPPLIER_NAME { get; set; }
        public int STOCK_QTY { get; set; }
        public int PCS { get; set; }
        public string TRUCKTYPE_NAME { get; set; }
        public string LOC_CODE { get; set; }

        #region 批次
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
        #endregion


        //add 是否加工
        public string IS_PROCESSING
        {
            get;
            set;
        }

        //销售类型
        public string SALE_TYPE
        {
            get;
            set;
        }

        public int SAP_SUPPLIER_ID
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
