using System;
using DataMapper;

namespace DataMapper
{
    /// <summary>
    /// LtUser
    /// </summary>
    [Serializable]
    public class LtUser : BaseEntity<LtUser>
    {
        #region properties

        public int ID
        {
            get;
            set;
        }

        public string USER_NAME
        {
            get;
            set;
        }

        public string USER_ACCOUNT
        {
            get;
            set;
        }

        public string USER_PWD
        {
            get;
            set;
        }

        public string USER_EMAIL
        {
            get;
            set;
        }

        public string USER_TEL
        {
            get;
            set;
        }
        public string USER_MOBILE
        {
            get;
            set;
        }
        public string USER_ADDR
        {
            get;
            set;
        }
        public string IS_DELETE
        {
            get;
            set;
        }
        public string IS_LOCK
        {
            get;
            set;
        }
        public Nullable<DateTime> CREATE_TIME
        {
            get;
            set;
        }

        public int CREATE_USER
        {
            get;
            set;
        }

        public Nullable<DateTime> LAST_UPDATE
        {
            get;
            set;
        }

        public int LAST_UPDATOR
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        public int WAREHOUSE_ID
        {
            get;
            set;
        }

        public string WAREHOUSE_CODE
        {
            get;
            set;
        }

        public string WAREHOUSE_NAME
        {
            get;
            set;
        }

        /// <summary>
        /// 仓库
        /// </summary>
        public WareHouse House
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