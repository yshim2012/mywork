using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataMapper
{
    public class POSCarrier: BaseEntity<POSCarrier>
    {
        public int Id
        {
            get;
            set;
        }

        public int POSId
        {
            get;
            set;
        }

        public int CarrierId
        {
            get;
            set;
        }

        public int Status
        {
            get;
            set;
        }

        public DateTime CreateTime
        {
            get;
            set;
        }

        public int CreateUserId
        {
            get;
            set;
        }

        public DateTime UpdateTime
        {
            get;
            set;
        }

        public int UpdateUserId
        {
            get;
            set;
        }
    }
}
