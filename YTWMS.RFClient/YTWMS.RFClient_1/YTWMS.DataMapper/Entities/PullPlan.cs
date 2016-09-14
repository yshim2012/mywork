using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataMapper
{
    /// <summary>
    /// PullPlan
    /// </summary>
    [Serializable]
    public class PullPlan : BaseEntity<PullPlan>
   {
       #region property
       public int ID
       {
           get;
           set;
       }
       public string PULL_ORDER_NO
       {
           get;
           set;
       }
       public Nullable<DateTime> PULL_TIME
       {
           get;
           set;
       }
       public string CONTACT
       {
           get;
           set;
       }
       public string PHONE
       {
           get;
           set;
       }
       public string APPLICANT
       {
           get;
           set;
       }
       public string DELIVER_DOCK
       {
           get;
           set;
       }
       public int CUSTOMER_ID
       {
           get;
           set;
       }
       public Nullable<DateTime> PLAN_DELIVER_TIME
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
       public string PULL_TYPE
       {
           get;
           set;
       }

       public string PULL_STATE
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
       public int PULL_QTY
       {
           get;
           set;
       }
       public string WAREHOUSE_NAME
       {
           get;
           set;
       }
       public Nullable<DateTime> PullStartDate
       {
           get;
           set;
       }
       public Nullable<DateTime> PullEndDate
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
       public string PIECESPER_OUTPACKAGE
       {
           get;
           set;
       }
       public string OUT_QTY
       {
           get;
           set;
       }

       public string PULL_TITLE
       {
           get;
           set;
       }

       public string PULL_BOX_COUNT
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
