using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LDV.WMS.RF.DataMapper
{
    public class RcvDocJson
    {
        private List<OrderJson> _orderList;
        public List<OrderJson> orderList
        {
            get;
            set;
        }

        private List<OrderItemJson> _orderlistentry;
        public List<OrderItemJson> orderlistentry
        {
            get;
            set;
        }
    }
}
