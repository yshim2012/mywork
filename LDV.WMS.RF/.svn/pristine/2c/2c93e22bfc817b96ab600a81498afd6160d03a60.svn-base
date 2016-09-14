using System;

namespace LDV.WMS.RF.DataMapper
{
    /// <summary>
    /// 移库计划明细
    /// </summary>
    [Serializable]
    public class LdvPlanMoveLocDetail : BaseEntity<LdvPlanMoveLocDetail>
    {
        #region property
        public Nullable<int> ID
        {
            get;
            set;
        }

       /// <summary>
       /// /计划移库ID
       /// </summary>
        public Nullable<int> PLAN_MOVE_LOC_ID
        {
            get;
            set;
        }
        /// <summary>
        /// 库存ID
        /// </summary>
        public Nullable<int> INV_DETAIL_ID
        {
            get;
            set;
        }

        /// <summary>
        /// 库位ID
        /// </summary>
        public Nullable<int> LOC_ID
        {
            get;
            set;
        }

        /// <summary>
        /// 移库库位ID
        /// </summary>
        public Nullable<int> MOVE_LOC_ID
        {
            get;
            set;
        }

        /// <summary>
        /// 商品ID
        /// </summary>
        public Nullable<int> ITEM_ID
        {
            get;
            set;
        }

        public Nullable<int> QTY
        {
            get;
            set;
        }

        public Nullable<int> MOVE_QTY
        {
            get;
            set;
        }

        public Nullable<int> MOVE_USER_ID
        {
            get;
            set;
        }

        public Nullable<DateTime> MOVE_DATE
        {
            get;
            set;
        }

        public string STATE
        {
            get;
            set;
        }

        public Nullable<DateTime> CREATE_DATE
        {
            get;
            set;
        }

        public Nullable<int> CREATE_USER_ID
        {
            get;
            set;
        }

        public Nullable<DateTime> LAST_MODIFY_DATE
        {
            get;
            set;
        }

        public Nullable<int> LAST_MODIFY_USER_ID
        {
            get;
            set;
        }
        #endregion

        public override bool SelectKey()
        {
            return false;
        }
    }
}
