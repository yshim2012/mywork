using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataMapper
{
    public class RouteLoc : BaseEntity<RouteLoc>
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
        public int RouteId
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        public int LocId
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        public int Sequence
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        public string Status
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
        public string CreateUserId
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
        public string UpdateUserId
        {
            get;
            set;
        }
    }
}
