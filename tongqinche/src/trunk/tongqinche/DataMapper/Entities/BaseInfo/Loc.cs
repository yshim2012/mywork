﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataMapper
{
    public class Loc : BaseEntity<Loc>
    {
        public int Id
        {
            get;
            set;
        }

        public string LocCode
        {
            get;
            set;
        }

        public string LocName
        {
            get;
            set;
        }

        public string LocType
        {
            get;
            set;
        }

        public string ProvinceCode
        {
            get;
            set;
        }

        public string DistrictCode
        {
            get;
            set;
        }

        public string Remark
        {
            get;
            set;
        }

        public string Longitude
        {
            get;
            set;
        }

        public string Latitude
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

        public string CityCode
        {
            get;
            set;
        }
    }
}
