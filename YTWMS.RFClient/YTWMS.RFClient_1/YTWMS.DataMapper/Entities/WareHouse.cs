using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataMapper
{
    /// <summary>
    /// LtUser
    /// </summary>
    [Serializable]
    public class WareHouse : BaseEntity<WareHouse>
    {
        #region property
        public int ID { get; set; }
        public string WAREHOUSE_CODE { get; set; }
        public string WAREHOUSE_NAME { get; set; }
        public string CONTACT { get; set; }
        public string PHONE { get; set; }
        public string ADDRESS { get; set; }
        public string E_MAIL { get; set; }
        public string TYPE { get; set; }
        public string IS_DISABLE { get; set; }
        public string REMARK { get; set; }
        public DateTime CREATE_TIME { get; set; }
        public int CREATE_USER_ID { get; set; }
        public Nullable<DateTime> LAST_UPDATE { get; set; }
        public Nullable<int> UPDATE_USER_ID { get; set; }

        public int WAREHOUSE_ID
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
