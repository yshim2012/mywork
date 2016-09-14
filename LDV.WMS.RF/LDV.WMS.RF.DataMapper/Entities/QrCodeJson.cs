using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LDV.WMS.RF.DataMapper
{
    public class QrCodeJson
    {
        private List<QrOrderJson> _qrcodeList;
        public List<QrOrderJson> qrcodeList 
        {
            get;
            set;
        }
    }
}
