using System;

namespace LDV.WMS.RF.DataMapper
{
    /// <summary>
    /// 移库计划
    /// </summary>
    [Serializable]
    public class LdvPlanMoveLoc : BaseEntity<LdvPlanMoveLoc>
    {
        #region property
        public Nullable<int> ID
        {
            get;
            set;
        }

        /// <summary>
        /// 移库凭证
        /// </summary>
        public string MOVE_LOC_NUM
        {
            get;
            set;
        }

        /// <summary>
        /// 计划移库日期
        /// </summary>
        public Nullable<DateTime> PLAN_MOVE_DATE
        {
            get;
            set;
        }

        /// <summary>
        /// 状态:OP新建，FI完成，CK移库中，IV无效
        /// </summary>
        public string STATE
        {
            get;
            set;
        }

        /// <summary>
        /// 创建时间
        /// </summary>
        public Nullable<DateTime> CREATE_DATE
        {
            get;
            set;
        }

        /// <summary>
        /// 创建人
        /// </summary>
        public Nullable<int> CREATE_USER_ID
        {
            get;
            set;
        }

        /// <summary>
        /// 最近修改时间
        /// </summary>
        public Nullable<DateTime> LAST_MODIFY_DATE
        {
            get;
            set;
        }

        /// <summary>
        /// 最近修改人
        /// </summary>
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
