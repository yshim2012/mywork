using System;
using System.Text;

namespace DataMapper
{
    public class PROJECT : BaseEntity<PROJECT>
    {
        public int ID { get; set; }
        public string PROJECT_CODE { get; set; }
        public string PROJECT_NAME { get; set; }
        public string PROJECT_TYPE { get; set; }
        public string IS_DISABLE { get; set; }
        public string REMARK { get; set; }
        public System.DateTime CREATE_TIME { get; set; }
        public int CREATE_USER_ID { get; set; }
        public Nullable<System.DateTime> LAST_UPDATE { get; set; }
        public Nullable<int> UPDATE_USER_ID { get; set; }

        public int WAREHOUSE_ID { get; set; }


        public override bool SelectKey()
        {
            return true;
        }
    }
}
