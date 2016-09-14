using System;
using DataMapper;

namespace DataMapper
{
    /// <summary>
    /// OrderNum
    /// </summary>
    [Serializable]
    public class OrderNum : BaseEntity<OrderNum>
    {
        #region property
        public int ID
        {
            get;
            set;
        }
        public string ORDER_NO
        {
            get;
            set;
        }
        public string DOCUMENT_NO
        {
            get;
            set;
        }
        public int WAREHOUSE_ID
        {
            get;
            set;
        }
        public Nullable<DateTime> ORDER_CREATE_TIME
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
        /// <summary>
        /// 新增
        /// </summary>
        public Nullable<DateTime> ORDER_END_TIME //完成时间
        {
            get;
            set;
        }
        public int SEND_LOC_ID//发货员
        {
            get;
            set;
        }
        public string ORDER_REMARK//单据备注
        {
            get;
            set;
        }
        public int PACKAGE_ID//工位器具
        {
            get;
            set;
        }
        public decimal QTY//数量
        {
            get;
            set;
        }
        public string RECEIVE_NAME//收货客户
        {
            get;
            set;
        }
        public string SEND_NAME//发货员
        {
            get;
            set;
        }
        public string PACKAGE_CODE { get; set; }
        public string PACKAGE_NAME { get; set; }
        public int LENGTH { get; set; }
        public int WIDTH { get; set; }
        public int HEIGHT { get; set; }
        public string ORDER_STATE
        {
            get;
            set;
        }
        public string ORDER_TYPE
        {
            get;
            set;
        }
        public string TYPE
        {
            get;
            set;
        }
        public string PART_CODE { get; set; }
        #endregion 

        public override bool SelectKey()
        {
            return true;
        }
    }
}
