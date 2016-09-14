using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataMapper
{
    /// <summary>
    /// SendInfo
    /// </summary>
    [Serializable]
    public class SendInfo
    {
        #region property

        public int WarehouseId
        {
            get;
            set;
        }

        public string Dock
        {
            get;
            set;
        }

        public string Driver
        {
            get;
            set;
        }

        public int UserId
        {
            get;
            set;
        }

        public List<Queue> QueueList
        { 
            get;
            set;
        }
        #endregion
    }
}
