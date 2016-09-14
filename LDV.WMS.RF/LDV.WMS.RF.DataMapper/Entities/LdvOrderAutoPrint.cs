using System;

namespace LDV.WMS.RF.DataMapper
{
    /// <summary>
    /// 移库计划
    /// </summary>
    [Serializable]
    public class LdvOrderAutoPrint : BaseEntity<LdvOrderAutoPrint>
    {
        #region property
        public Nullable<double> ID
        {
            get;
            set;
        }

        public string ORDER_NO
        {
            get;
            set;
        }
        public Nullable<int> USER_ID
        {
            get;
            set;
        }
        public string IS_PRINT
        {
            get;
            set;
        }
       
        public Nullable<DateTime> PRINT_DATE
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
