using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataMapper
{
    public class BaseInfo
    {

    }


    [Serializable]
    public class BoxInfo
    {
        public string PART_CODE
        {
            get;
            set;
        }

        public string BOX_CODE
        {
            get;
            set;
        }

        public string BATCH_NO
        {
            get;
            set;
        }

        public string FURNACE_NO
        {
            get;
            set;
        }

        public int QTY
        {
            get;
            set;
        }


        public int PROJECT_ID
        {
            get;
            set;
        }

        public int PROJECT_ITEM_ID
        {
            get;
            set;
        }
    }

    [Serializable]
    public class MessageInfo
    {
        public string ResultState
        {
            get;
            set;
        }

        public string Info
        {
            get;
            set;
        }
    }
}
