using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataMapper
{
    /// <summary>
    /// Truck
    /// </summary>
    [Serializable]
    public class Truck : BaseEntity<Truck>
    {
        #region property
        public int ID { get; set; }
        public string TRUCK_CODE { get; set; }
        public string TRUCK_NAME { get; set; }
        public string LICENCEPLATE { get; set; }
        public decimal LENGTH { get; set; }
        public decimal WIDTH { get; set; }
        public decimal HEIGHT { get; set; }
        public decimal WEIGHT { get; set; }
        public string IS_DISABLE { get; set; }
        public string REMARK { get; set; }
        public System.DateTime CREATE_TIME { get; set; }
        public int CREATE_USER_ID { get; set; }
        public Nullable<System.DateTime> LAST_UPDATE { get; set; }
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
