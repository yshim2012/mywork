using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LDV.WMS.RF.DataMapper
{
    [Serializable]
    public class QrOrderJson : BaseEntity<QrOrderJson>
    {
        #region Properties
        public string qrcode { get; set; }
        #endregion

        public override bool SelectKey()
        {
            return false;
        }
    }
}
