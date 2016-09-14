using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataMapper
{
    public class SapModel : BaseEntity<SapModel>
    {
        /// <summary>
        /// 
        /// </summary>
        public int Id
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        public string EmployeeNo
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        public string TicketType
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        public DateTime CreateTime
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        public int CreateUserid
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        public DateTime UpdateTime
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        public int UpdateUserid
        {
            get;
            set;
        }
    }
}
