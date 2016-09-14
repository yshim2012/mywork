using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LDV.WMS.RF.DataMapper
{
    public class PickTicketJson
    {
        private List<PackOrderJson> _packingList;
        public List<PackOrderJson> packingList
        {
            get;
            set;
        }

        private List<PackOrderItemJson> _packinglistentry;
        public List<PackOrderItemJson> packinglistentry
        {
            get;
            set;
        }


    }
}
