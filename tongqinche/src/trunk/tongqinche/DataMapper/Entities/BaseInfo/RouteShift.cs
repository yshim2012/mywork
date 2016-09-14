using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataMapper
{
    public class RouteShift : BaseEntity<RouteShift>
    {
        public int Id
        {
            get;
            set;
        }

        public int Route_Id
        {
            get;
            set;
        }

        public string Table_Name
        {
            get;
            set;
        }

        public string Shift_Code
        {
            get;
            set;
        }

        public string Shift_Type_Code
        {
            get;
            set;
        }

        public string Car_Type
        {
            get;
            set;
        }

        public string Company_Name
        {
            get;
            set;
        }

        public int Plan_Number
        {
            get;
            set;
        }

        public string Departure_Time
        {
            get;
            set;
        }

        public int Space_Time
        {
            get;
            set;
        }

        public string End_Time
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

        public int CreateUserid
        {
            get;
            set;
        }

        public DateTime UpdateTime
        {
            get;
            set;
        }

        public int UpdateUserid
        {
            get;
            set;
        }


    }
}
