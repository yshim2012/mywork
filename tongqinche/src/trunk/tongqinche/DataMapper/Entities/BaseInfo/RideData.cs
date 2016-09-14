using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataMapper
{
    public class RideData : BaseEntity<RideData>
    {
        public int Id
        {
            get;
            set;
        }

        public int POS_NO
        {
            get;
            set;
        }

        public string CARD_PIN
        {
            get;
            set;
        }

        public decimal BOARDING_LONGITUDE
        {
            get;
            set;
        }

        public decimal BOARDING_LATITUDE
        {
            get;
            set;
        }

        public decimal ALIGHTING_LONGITUDE
        {
            get;
            set;
        }

        public decimal ALIGHTING_LATITUDE
        {
            get;
            set;
        }

        public DateTime BOARDING_TIME
        {
            get;
            set;
        }

        public DateTime ALIGHTING_TIME
        {
            get;
            set;
        }

        public int ALIGHTING_LOC_ID
        {
            get;
            set;
        }

        public int BOARDING_LOC_ID
        {
            get;
            set;
        }

        public int ROUTE_ID
        {
            get;
            set;
        }

        public char TICKET_TYPE
        {
            get;
            set;
        }

        public decimal AMOUNT
        {
            get;
            set;
        }

        public string JOB_NUMBER
        {
            get;
            set;
        }

        public string NAME
        {
            get;
            set;
        }

        public string DEPT
        {
            get;
            set;
        }

        public string CO
        {
            get;
            set;
        }

        public string CARD_TYPE
        {
            get;
            set;
        }

        public string COMMUTE_TYPE
        {
            get;
            set;
        }

        public int CARRIER_ID
        {
            get;
            set;
        }


        public DateTime CREATED_TIME
        {
            get;
            set;
        }

        public int CREATED_USER
        {
            get;
            set;
        }

        public DateTime UPDATED_TIME
        {
            get;
            set;
        }

        public int UPDATED_USER
        {
            get;
            set;
        }
    }
}
