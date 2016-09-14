using System;
using System.Collections.Generic;
using System.Reflection;

namespace Common
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class MyComparer<T> : IComparer<T>
    {
        private string _name;
        private bool _sortBy;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="SortBy"></param>
        public MyComparer(string Name, bool SortBy)
        {
            _name = Name;
            _sortBy = SortBy;
        }

        /// <summary>
        /// 
        /// </summary>
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool SortBy
        {
            get { return _sortBy; }
            set { _sortBy = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public int Compare(T x, T y)
        {
            PropertyInfo property = typeof(T).GetProperty(Name);
            if (property.PropertyType == Type.GetType("System.Int32"))
            {
                int Member1 = 0;
                int Member2 = 0;
                if (property.GetValue(x, null) != null)
                {
                    Member1 = Convert.ToInt32(property.GetValue(x, null));
                }
                if (property.GetValue(y, null) != null)
                {
                    Member2 = Convert.ToInt32(property.GetValue(y, null));
                }
                if (_sortBy)
                {
                    return Member2.CompareTo(Member1);
                }
                else
                {
                    return Member1.CompareTo(Member2);
                }
            }
            else if (property.PropertyType == Type.GetType("System.Double"))
            {
                double Member1 = 0;
                double Member2 = 0;
                if (property.GetValue(x, null) != null)
                {
                    Member1 = Convert.ToDouble(property.GetValue(x, null));
                }
                if (property.GetValue(y, null) != null)
                {
                    Member2 = Convert.ToDouble(property.GetValue(y, null));
                }
                if (_sortBy)
                {
                    return Member2.CompareTo(Member1);
                }
                else
                {
                    return Member1.CompareTo(Member2);
                }
            }
            else if (property.PropertyType == Type.GetType("System.String"))
            {
                string Member1 = string.Empty;
                string Member2 = string.Empty;
                if (property.GetValue(x, null) != null)
                {
                    Member1 = property.GetValue(x, null).ToString();
                }
                if (property.GetValue(y, null) != null)
                {
                    Member2 = property.GetValue(y, null).ToString();
                }
                if (_sortBy)
                {
                    return Member2.CompareTo(Member1);
                }
                else
                {
                    return Member1.CompareTo(Member2);
                }
            }
            else if (property.PropertyType == Type.GetType("System.DateTime"))
            {
                DateTime Member1 = DateTime.Now;
                DateTime Member2 = DateTime.Now;
                if (property.GetValue(x, null) != null)
                {
                    Member1 = Convert.ToDateTime(property.GetValue(x, null));
                }
                if (property.GetValue(y, null) != null)
                {
                    Member2 = Convert.ToDateTime(property.GetValue(y, null));
                }
                if (_sortBy)
                {
                    return Member2.CompareTo(Member1);
                }
                else
                {
                    return Member1.CompareTo(Member2);
                }
            }

            return 0;
        }
    }
}
