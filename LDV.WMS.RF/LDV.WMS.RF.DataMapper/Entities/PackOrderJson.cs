using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LDV.WMS.RF.DataMapper
{
    [Serializable]
    public class PackOrderJson : BaseEntity<PackOrderJson>
    {
        public string id { get; set; }
        public string packingno { get; set; }
        public string customerno { get; set; }
        public string customername { get; set; }
        public string date { get; set; }
    }
}
