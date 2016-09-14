using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using IBatisNet.Common;
using IBatisNet.DataMapper;

namespace DataMapper
{
    /// <summary>
    /// 所有实体类的基类,提供了持久化的操作
    /// </summary>
    public class BaseEntity<T>
    {
		#region QueryObjectByPrimayKey

        /// <summary>
        /// 
        /// </summary>
        /// <param name="primaryKey"></param>
        /// <returns></returns>
        public static T QueryObject(object primaryKey)
        {
            ISqlMapper sqlmapper = Sql_Mapper.Instance();
            string statement = String.Format("{0}.SelectById", typeof(T).Name);
            using (IDalSession session = sqlmapper.OpenConnection())
            {
                return sqlmapper.QueryForObject<T>(statement, primaryKey);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sqlmapper"></param>
        /// <param name="primaryKey"></param>
        /// <returns></returns>
        public static T QueryObject(ISqlMapper sqlmapper, object primaryKey)
        {
            string statement = String.Format("{0}.SelectById", typeof(T).Name);
            return sqlmapper.QueryForObject<T>(statement, primaryKey);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="statement"></param>
        /// <param name="primaryKey"></param>
        /// <returns></returns>
        public static T QueryObject(string statement, object primaryKey)
		{
            ISqlMapper sqlmapper = Sql_Mapper.Instance();
            statement = String.Format("{0}.{1}", typeof(T).Name, statement);
            using (IDalSession session = sqlmapper.OpenConnection())
			{
                return sqlmapper.QueryForObject<T>(statement, primaryKey);
			}
		}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sqlmapper"></param>
        /// <param name="statement"></param>
        /// <param name="primaryKey"></param>
        /// <returns></returns>
        public static T QueryObject(ISqlMapper sqlmapper, string statement, object primaryKey)
        {
            statement = String.Format("{0}.{1}", typeof(T).Name, statement);
            return sqlmapper.QueryForObject<T>(statement, primaryKey);
        }

        #endregion

        #region QueryObjectByParamClass

        /// <summary>
        /// 
        /// </summary>
        /// <param name="statement"></param>
        /// <returns></returns>
        public virtual T QueryObject(string statement)
        {
            ISqlMapper sqlmapper = Sql_Mapper.Instance();
            statement = String.Format("{0}.{1}", typeof(T).Name, statement);
            using (IDalSession session = sqlmapper.OpenConnection())
            {
                return sqlmapper.QueryForObject<T>(statement, this);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sqlmapper"></param>
        /// <param name="statement"></param>
        /// <returns></returns>
        public virtual T QueryObject(ISqlMapper sqlmapper, string statement)
        {
            statement = String.Format("{0}.{1}", typeof(T).Name, statement);
            return sqlmapper.QueryForObject<T>(statement, this);
        }

        #endregion

        #region QueryObjectByParamHahstable

        /// <summary>
        /// 
        /// </summary>
        /// <param name="statement"></param>
        /// <param name="paramhashmap"></param>
        /// <returns></returns>
        public static T QueryObject(string statement, IDictionary paramhashmap)
		{
			ISqlMapper sqlmapper = Sql_Mapper.Instance();
			statement = String.Format("{0}.{1}", typeof(T).Name, statement);
            using (IDalSession session = sqlmapper.OpenConnection())
			{
            return sqlmapper.QueryForObject<T>(statement, paramhashmap);
			}
		}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sqlmapper"></param>
        /// <param name="statement"></param>
        /// <param name="paramhashmap"></param>
        /// <returns></returns>
        public static T QueryObject(ISqlMapper sqlmapper, string statement, IDictionary paramhashmap)
        {
            statement = String.Format("{0}.{1}", typeof(T).Name, statement);
            return sqlmapper.QueryForObject<T>(statement, paramhashmap);
        }

        #endregion

        #region QueryListByParamClass

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public virtual IList<T> QueryList()
        {
            ISqlMapper sqlmapper = Sql_Mapper.Instance();
            string statement = String.Format("{0}.SelectByParam", typeof(T).Name);
            using (IDalSession session = sqlmapper.OpenConnection())
			{
                return sqlmapper.QueryForList<T>(statement, this);
			}
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sqlmapper"></param>
        /// <returns></returns>
        public virtual IList<T> QueryList(ISqlMapper sqlmapper)
        {
            string statement = String.Format("{0}.SelectByParam", typeof(T).Name);
            return sqlmapper.QueryForList<T>(statement, this);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="statement"></param>
        /// <returns></returns>
        public virtual IList<T> QueryList(string statement)
        {
            ISqlMapper sqlmapper = Sql_Mapper.Instance();
            statement = String.Format("{0}.{1}", typeof(T).Name, statement);
            using (IDalSession session = sqlmapper.OpenConnection())
            {
                return sqlmapper.QueryForList<T>(statement, this);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sqlmapper"></param>
        /// <param name="statement"></param>
        /// <returns></returns>
        public virtual IList<T> QueryList(ISqlMapper sqlmapper, string statement)
        {
            statement = String.Format("{0}.{1}", typeof(T).Name, statement);
            return sqlmapper.QueryForList<T>(statement, this);
        }

        #endregion

        #region QueryListByParamHashtable

        /// <summary>
        /// 
        /// </summary>
        /// <param name="statement"></param>
        /// <param name="paramhashmap"></param>
        /// <returns></returns>
        public static IList<T> QueryList(string statement, IDictionary paramhashmap)
        {
            ISqlMapper sqlmapper = Sql_Mapper.Instance();
            statement = String.Format("{0}.{1}", typeof(T).Name, statement);
            using (IDalSession session = sqlmapper.OpenConnection())
			{
                return sqlmapper.QueryForList<T>(statement, paramhashmap);
			}
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sqlmapper"></param>
        /// <param name="statement"></param>
        /// <param name="paramhashmap"></param>
        /// <returns></returns>
        public static IList<T> QueryList(ISqlMapper sqlmapper, string statement, IDictionary paramhashmap)
        {
            statement = String.Format("{0}.{1}", typeof(T).Name, statement);
            return sqlmapper.QueryForList<T>(statement, paramhashmap);
        }

        #endregion
		
		#region QueryListByParamObject
		
		/// <summary>
        /// 
        /// </summary>
        /// <param name="statement"></param>
        /// <param name="paramobject"></param>
        /// <returns></returns>
        public static IList<T> QueryList(string statement, object paramobject)
        {
            ISqlMapper sqlmapper = Sql_Mapper.Instance();
            statement = String.Format("{0}.{1}", typeof(T).Name, statement);
            using (IDalSession session = sqlmapper.OpenConnection())
			{
                return sqlmapper.QueryForList<T>(statement, paramobject);
			}
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sqlmapper"></param>
        /// <param name="statement"></param>
        /// <param name="paramobject"></param>
        /// <returns></returns>
        public static IList<T> QueryList(ISqlMapper sqlmapper, string statement, object paramobject)
        {
            statement = String.Format("{0}.{1}", typeof(T).Name, statement);
            return sqlmapper.QueryForList<T>(statement, paramobject);
        }
		
		#endregion

        #region QueryDataTableByParamClass

        /// <summary>
        /// 
        /// </summary>
        /// <param name="statement"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public virtual DataTable QueryDataTable(string statement)
        {
            ISqlMapper sqlmapper = Sql_Mapper.Instance();
			statement = String.Format("{0}.{1}", typeof(T).Name, statement);
            using (IDalSession session = sqlmapper.OpenConnection())
			{
                return sqlmapper.QueryForDataTable(statement, this, "Table");
			}
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sqlmapper"></param>
        /// <param name="statement"></param>
        /// <returns></returns>
        public virtual DataTable QueryDataTable(ISqlMapper sqlmapper, string statement)
        {
            statement = String.Format("{0}.{1}", typeof(T).Name, statement);
            return sqlmapper.QueryForDataTable(statement, this, "Table");
        }

        #endregion

        #region QueryDataTableByParamHashtable

        /// <summary>
        /// 
        /// </summary>
        /// <param name="statement"></param>
        /// <param name="paramhashmap"></param>
        /// <returns></returns>
        public static DataTable QueryDataTable(string statement, IDictionary paramhashmap)
        {
            ISqlMapper sqlmapper = Sql_Mapper.Instance();
            statement = String.Format("{0}.{1}", typeof(T).Name, statement);
            //using (IDalSession session = sqlmapper.OpenConnection())
            //{
               return sqlmapper.QueryForDataTable(statement, paramhashmap, "Table");
            //}
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sqlmapper"></param>
        /// <param name="statement"></param>
        /// <param name="paramhashmap"></param>
        /// <returns></returns>
        public static DataTable QueryDataTable(ISqlMapper sqlmapper, string statement, IDictionary paramhashmap)
        {
            statement = String.Format("{0}.{1}", typeof(T).Name, statement);
            return sqlmapper.QueryForDataTable(statement, paramhashmap, "Table");
        }

        #endregion
		
		#region QueryDataTableByParamObject

        /// <summary>
        /// 
        /// </summary>
        /// <param name="statement"></param>
        /// <param name="paramobject"></param>
        /// <returns></returns>
        public static DataTable QueryDataTable(string statement, object paramobject)
        {
            ISqlMapper sqlmapper = Sql_Mapper.Instance();
            statement = String.Format("{0}.{1}", typeof(T).Name, statement);
            using (IDalSession session = sqlmapper.OpenConnection())
            {
                return sqlmapper.QueryForDataTable(statement, paramobject, "Table");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sqlmapper"></param>
        /// <param name="statement"></param>
        /// <param name="paramobject"></param>
        /// <returns></returns>
        public static DataTable QueryDataTable(ISqlMapper sqlmapper, string statement, object paramobject)
        {
            statement = String.Format("{0}.{1}", typeof(T).Name, statement);
            return sqlmapper.QueryForDataTable(statement, paramobject, "Table");
        }

        #endregion

        #region QueryDataSetByParamClass

        /// <summary>
        /// 
        /// </summary>
        /// <param name="statement"></param>
        /// <param name="tablename"></param>
        /// <returns></returns>
        public virtual DataSet QueryDataSet(string statement, string tablename)
        {
            ISqlMapper sqlmapper = Sql_Mapper.Instance();
			statement = String.Format("{0}.{1}", typeof(T).Name, statement);
            using (IDalSession session = sqlmapper.OpenConnection())
			{
                return sqlmapper.QueryForDataSet(statement, this, tablename);
			}
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="statement"></param>
        /// <param name="ds"></param>
        /// <param name="tablename"></param>
        /// <returns></returns>
        public virtual DataSet QueryDataSet(string statement, DataSet ds, string tablename)
        {
            ISqlMapper sqlmapper = Sql_Mapper.Instance();
            statement = String.Format("{0}.{1}", typeof(T).Name, statement);
            using (IDalSession session = sqlmapper.OpenConnection())
            {
                return sqlmapper.QueryForDataSet(statement, this, ds, tablename);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sqlmapper"></param>
        /// <param name="statement"></param>
        /// <param name="tablename"></param>
        /// <returns></returns>
        public virtual DataSet QueryDataSet(ISqlMapper sqlmapper, string statement, string tablename)
        {
            statement = String.Format("{0}.{1}", typeof(T).Name, statement);
            return sqlmapper.QueryForDataSet(statement, this, tablename);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sqlmapper"></param>
        /// <param name="statement"></param>
        /// <param name="ds"></param>
        /// <param name="tablename"></param>
        /// <returns></returns>
        public virtual DataSet QueryDataSet(ISqlMapper sqlmapper, string statement, DataSet ds, string tablename)
        {
            statement = String.Format("{0}.{1}", typeof(T).Name, statement);
            return sqlmapper.QueryForDataSet(statement, this, ds, tablename);
        }

        #endregion

        #region QueryDataSetByParamHashtable

        /// <summary>
        /// 
        /// </summary>
        /// <param name="statement"></param>
        /// <param name="paramhashmap"></param>
        /// <param name="tablename"></param>
        /// <returns></returns>
        public static DataSet QueryDataSet(string statement, IDictionary paramhashmap, string tablename)
        {
            ISqlMapper sqlmapper = Sql_Mapper.Instance();
			statement = String.Format("{0}.{1}", typeof(T).Name, statement);
            using (IDalSession session = sqlmapper.OpenConnection())
			{
                return sqlmapper.QueryForDataSet(statement, paramhashmap, tablename);
			}
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="statement"></param>
        /// <param name="paramhashmap"></param>
        /// <param name="ds"></param>
        /// <param name="tablename"></param>
        /// <returns></returns>
        public static DataSet QueryDataSet(string statement, IDictionary paramhashmap, DataSet ds, string tablename)
        {
            ISqlMapper sqlmapper = Sql_Mapper.Instance();
            statement = String.Format("{0}.{1}", typeof(T).Name, statement);
            using (IDalSession session = sqlmapper.OpenConnection())
            {
                return sqlmapper.QueryForDataSet(statement, paramhashmap, ds, tablename);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sqlmapper"></param>
        /// <param name="statement"></param>
        /// <param name="paramhashmap"></param>
        /// <param name="tablename"></param>
        /// <returns></returns>
        public static DataSet QueryDataSet(ISqlMapper sqlmapper, string statement, IDictionary paramhashmap, string tablename)
        {
            statement = String.Format("{0}.{1}", typeof(T).Name, statement);
            return sqlmapper.QueryForDataSet(statement, paramhashmap, tablename);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sqlmapper"></param>
        /// <param name="statement"></param>
        /// <param name="paramhashmap"></param>
        /// <param name="ds"></param>
        /// <param name="tablename"></param>
        /// <returns></returns>
        public static DataSet QueryDataSet(ISqlMapper sqlmapper, string statement, IDictionary paramhashmap, DataSet ds, string tablename)
        {
            statement = String.Format("{0}.{1}", typeof(T).Name, statement);
            return sqlmapper.QueryForDataSet(statement, paramhashmap, ds, tablename);
        }

        #endregion
		
		#region QueryDataSetByParamObject

        /// <summary>
        /// 
        /// </summary>
        /// <param name="statement"></param>
        /// <param name="paramobject"></param>
        /// <param name="tablename"></param>
        /// <returns></returns>
        public static DataSet QueryDataSet(string statement, object paramobject, string tablename)
        {
            ISqlMapper sqlmapper = Sql_Mapper.Instance();
			statement = String.Format("{0}.{1}", typeof(T).Name, statement);
            using (IDalSession session = sqlmapper.OpenConnection())
			{
                return sqlmapper.QueryForDataSet(statement, paramobject, tablename);
			}
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="statement"></param>
        /// <param name="paramobject"></param>
        /// <param name="ds"></param>
        /// <param name="tablename"></param>
        /// <returns></returns>
        public static DataSet QueryDataSet(string statement, object paramobject, DataSet ds, string tablename)
        {
            ISqlMapper sqlmapper = Sql_Mapper.Instance();
            statement = String.Format("{0}.{1}", typeof(T).Name, statement);
            using (IDalSession session = sqlmapper.OpenConnection())
            {
                return sqlmapper.QueryForDataSet(statement, paramobject, ds, tablename);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sqlmapper"></param>
        /// <param name="statement"></param>
        /// <param name="paramobject"></param>
        /// <param name="tablename"></param>
        /// <returns></returns>
        public static DataSet QueryDataSet(ISqlMapper sqlmapper, string statement, object paramobject, string tablename)
        {
            statement = String.Format("{0}.{1}", typeof(T).Name, statement);
            return sqlmapper.QueryForDataSet(statement, paramobject, tablename);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sqlmapper"></param>
        /// <param name="statement"></param>
        /// <param name="paramobject"></param>
        /// <param name="ds"></param>
        /// <param name="tablename"></param>
        /// <returns></returns>
        public static DataSet QueryDataSet(ISqlMapper sqlmapper, string statement, object paramobject, DataSet ds, string tablename)
        {
            statement = String.Format("{0}.{1}", typeof(T).Name, statement);
            return sqlmapper.QueryForDataSet(statement, paramobject, ds, tablename);
        }

        #endregion

        #region QueryPageingByParamHashtable

        /// <summary>
        /// 
        /// </summary>
        /// <param name="paramhashmap"></param>
        /// <param name="skipResults"></param>
        /// <param name="maxResults"></param>
        /// <returns></returns>
        public static DataTable QueryPageing(IDictionary paramhashmap, int skipResults, int maxResults)
        {
            ISqlMapper sqlmapper = Sql_Mapper.Instance();
			string statement = String.Format("{0}.SelectForPageing", typeof(T).Name);
            using (IDalSession session = sqlmapper.OpenConnection())
            {
                return sqlmapper.QueryForDataSet(statement, paramhashmap, skipResults * maxResults, maxResults, "Table").Tables[0];
                //return sqlmapper.QueryForPageing(statement, paramhashmap, skipResults * maxResults, maxResults, "Table");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="statement"></param>
        /// <param name="paramhashmap"></param>
        /// <param name="skipResults"></param>
        /// <param name="maxResults"></param>
        /// <returns></returns>
        public static DataTable QueryPageing(string statement, IDictionary paramhashmap, int skipResults, int maxResults)
        {
            ISqlMapper sqlmapper = Sql_Mapper.Instance();
            statement = String.Format("{0}.{1}", typeof(T).Name, statement);
            using (IDalSession session = sqlmapper.OpenConnection())
            {
                return sqlmapper.QueryForDataSet(statement, paramhashmap, skipResults * maxResults, maxResults, "Table").Tables[0];
                //return sqlmapper.QueryForPageing(statement, paramhashmap, skipResults * maxResults, maxResults, "Table");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="paramhashmap"></param>
        /// <param name="skipResults"></param>
        /// <param name="maxResults"></param>
        /// <param name="rowcount"></param>
        /// <returns></returns>
        public static DataTable QueryPageing(IDictionary paramhashmap, int skipResults, int maxResults, out long rowcount)
        {
            ISqlMapper sqlmapper = Sql_Mapper.Instance();
			string statement = String.Format("{0}.SelectForPageing", typeof(T).Name);
            using (IDalSession session = sqlmapper.OpenConnection())
            {
                DataTable datatable = sqlmapper.QueryForDataSet(statement, paramhashmap, skipResults * maxResults, maxResults, "Table").Tables[0];
                //DataTable datatable = sqlmapper.QueryForPageing(statement, paramhashmap, skipResults * maxResults, maxResults, "Table");
                rowcount = QueryForCount(sqlmapper, session, statement, paramhashmap);
                return datatable;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="statement"></param>
        /// <param name="paramhashmap"></param>
        /// <param name="skipResults"></param>
        /// <param name="maxResults"></param>
        /// <param name="rowcount"></param>
        /// <returns></returns>
        public static DataTable QueryPageing(IDictionary paramhashmap)
        {
            ISqlMapper sqlmapper = Sql_Mapper.Instance();
            string statement = String.Format("{0}.SelectForDetail", typeof(T).Name);
            using(IDalSession session = sqlmapper.OpenConnection())
            {
                DataTable datatable = sqlmapper.QueryForDataTable(statement,paramhashmap,"Table");
                return datatable;
            }
        }
        public static DataTable QueryPageing(string statement, IDictionary paramhashmap, int skipResults, int maxResults, out long rowcount)
        {
            ISqlMapper sqlmapper = Sql_Mapper.Instance();
            statement = String.Format("{0}.{1}", typeof(T).Name, statement);
            using (IDalSession session = sqlmapper.OpenConnection())
            {
                DataTable datatable = sqlmapper.QueryForDataSet(statement, paramhashmap, skipResults * maxResults, maxResults, "Table").Tables[0];
                //DataTable datatable = sqlmapper.QueryForPageing(statement, paramhashmap, skipResults * maxResults, maxResults, "Table");
                rowcount = QueryForCount(sqlmapper, session, statement, paramhashmap);
                return datatable;
            }
        }
        public static DataTable QueryPageingNotCount(string statement, IDictionary paramhashmap, int skipResults, int maxResults, out long rowcount)
        {
            ISqlMapper sqlmapper = Sql_Mapper.Instance();
            statement = String.Format("{0}.{1}", typeof(T).Name, statement);
            using (IDalSession session = sqlmapper.OpenConnection())
            {
                DataTable datatable = sqlmapper.QueryForDataSet(statement, paramhashmap, skipResults * maxResults, maxResults, "Table").Tables[0];
                //DataTable datatable = sqlmapper.QueryForPageing(statement, paramhashmap, skipResults * maxResults, maxResults, "Table");
                rowcount = datatable.Rows.Count;
                return datatable;
            }
        }
        public static DataTable QueryPageingInOrderBy(string statement, IDictionary paramhashmap, int skipResults, int maxResults, out long rowcount)
        {
            ISqlMapper sqlmapper = Sql_Mapper.Instance();
            statement = String.Format("{0}.{1}", typeof(T).Name, statement);
            using (IDalSession session = sqlmapper.OpenConnection())
            {
                DataTable datatable = sqlmapper.QueryForDataSet(statement, paramhashmap, skipResults * maxResults, maxResults, "Table").Tables[0];
                //DataTable datatable = sqlmapper.QueryForPageing(statement, paramhashmap, skipResults * maxResults, maxResults, "Table");
                rowcount = QueryForCountOrderby(sqlmapper, session, statement, paramhashmap);
                return datatable;
            }
        }

        #endregion

        #region Save

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public virtual object Save()
        {
            ISqlMapper sqlmapper = Sql_Mapper.Instance();
			string statement = String.Format("{0}.Insert", typeof(T).Name);
            object result = null;
            using ( IDalSession session = sqlmapper.BeginTransaction() )
			{
                if (SelectKey())
                {
				    result = sqlmapper.Insert(statement, this);
                }
				else
				{
                   result= sqlmapper.Insert(statement, this);
				}
				session.Complete(); // Commit
			}
			return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sqlmapper"></param>
        /// <returns></returns>
        public virtual object Save(ISqlMapper sqlmapper)
        {
            string statement = String.Format("{0}.Insert", typeof(T).Name);
            object result = null;
            if (SelectKey())
            {
                result = sqlmapper.Insert(statement, this);
            }
            else
            {
                result= sqlmapper.Insert(statement, this);
            }
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="statement"></param>
        /// <returns></returns>
        public virtual object Save(string statement)
        {
			statement = String.Format("{0}.{1}", typeof(T).Name, statement);
            ISqlMapper sqlmapper = Sql_Mapper.Instance();
			object result = null;
			using ( IDalSession session = sqlmapper.BeginTransaction())
			{
                if (SelectKey())
				{
                    result = sqlmapper.Insert(statement, this);
				}
				else
				{
                    sqlmapper.Insert(statement, this);
				}
				session.Complete();
			}
			return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sqlmapper"></param>
        /// <param name="statement"></param>
        /// <returns></returns>
        public virtual object Save(ISqlMapper sqlmapper, string statement)
        {
            statement = String.Format("{0}.{1}", typeof(T).Name, statement);
            object result = null;
            if (SelectKey())
            {
                result = sqlmapper.Insert(statement, this);
            }
            else
            {
                sqlmapper.Insert(statement, this);
            }
            return result;
        }

        #endregion

        #region Update

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public virtual int Update()
        {
            ISqlMapper sqlmapper = Sql_Mapper.Instance();
			string statement = String.Format("{0}.Update", typeof(T).Name);
			int result = 0;
			using ( IDalSession session = sqlmapper.BeginTransaction() )
			{
				result = (int)sqlmapper.Update(statement, this);
				session.Complete(); // Commit
			}
			return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sqlmapper"></param>
        /// <returns></returns>
        public virtual int Update(ISqlMapper sqlmapper)
        {
            string statement = String.Format("{0}.Update", typeof(T).Name);
            int result = 0;
            result = (int)sqlmapper.Update(statement, this);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="statement"></param>
        /// <returns></returns>
        public virtual int Update(string statement)
        {
            ISqlMapper sqlmapper = Sql_Mapper.Instance();
			statement = String.Format("{0}.{1}", typeof(T).Name, statement);
			int result = 0;
			using ( IDalSession session = sqlmapper.BeginTransaction() )
			{
				result = (int)sqlmapper.Update(statement, this);
				session.Complete();
			}
			return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sqlmapper"></param>
        /// <param name="statement"></param>
        /// <returns></returns>
        public virtual int Update(ISqlMapper sqlmapper, string statement)
        {
            statement = String.Format("{0}.{1}", typeof(T).Name, statement);
            int result = 0;
            result = (int)sqlmapper.Update(statement, this);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="statement"></param>
        /// <param name="paramhashmap"></param>
        /// <returns></returns>
        public static int Update(string statement, IDictionary paramhashmap)
        {
            ISqlMapper sqlmapper = Sql_Mapper.Instance();
			statement = String.Format("{0}.{1}", typeof(T).Name, statement);
			int result = 0;
			using ( IDalSession session = sqlmapper.BeginTransaction() )
			{
                result = (int)sqlmapper.Update(statement, paramhashmap);
				session.Complete(); // Commit
			}
			return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sqlmapper"></param>
        /// <param name="statement"></param>
        /// <param name="paramhashmap"></param>
        /// <returns></returns>
        public static int Update(ISqlMapper sqlmapper, string statement, IDictionary paramhashmap)
        {
            statement = String.Format("{0}.{1}", typeof(T).Name, statement);
            int result = 0;
            result = (int)sqlmapper.Update(statement, paramhashmap);
            return result;
        }

        #endregion

        #region Delete

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public virtual int Delete()
        {
            ISqlMapper sqlmapper = Sql_Mapper.Instance();
			string statement = String.Format("{0}.Delete", typeof(T).Name);
			int result = 0;
			using ( IDalSession session = sqlmapper.BeginTransaction() )
			{
				result = (int)sqlmapper.Delete(statement, this);
				session.Complete();
			}
			return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sqlmapper"></param>
        /// <returns></returns>
        public virtual int Delete(ISqlMapper sqlmapper)
        {
            string statement = String.Format("{0}.Delete", typeof(T).Name);
            int result = 0;
            result = (int)sqlmapper.Delete(statement, this);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="statement"></param>
        /// <returns></returns>
        public virtual int Delete(string statement)
        {
            ISqlMapper sqlmapper = Sql_Mapper.Instance();
			statement = String.Format("{0}.{1}", typeof(T).Name, statement);
			int result = 0;
			using ( IDalSession session = sqlmapper.BeginTransaction() )
			{
				result = (int)sqlmapper.Delete(statement, this);
				session.Complete();
			}
			return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sqlmapper"></param>
        /// <param name="statement"></param>
        /// <returns></returns>
        public virtual int Delete(ISqlMapper sqlmapper, string statement)
        {
            statement = String.Format("{0}.{1}", typeof(T).Name, statement);
            int result = 0;
            result = (int)sqlmapper.Delete(statement, this);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="statement"></param>
        /// <param name="paramhashmap"></param>
        /// <returns></returns>
        public static int Delete(string statement, IDictionary paramhashmap)
        {
            ISqlMapper sqlmapper = Sql_Mapper.Instance();
			statement = String.Format("{0}.{1}", typeof(T).Name, statement);
			int result = 0;
			using ( IDalSession session = sqlmapper.BeginTransaction() )
			{
                result = (int)sqlmapper.Delete(statement, paramhashmap);
				session.Complete();
			}
			return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sqlmapper"></param>
        /// <param name="statement"></param>
        /// <param name="paramhashmap"></param>
        /// <returns></returns>
        public static int Delete(ISqlMapper sqlmapper, string statement, IDictionary paramhashmap)
        {
            statement = String.Format("{0}.{1}", typeof(T).Name, statement);
            int result = 0;
            result = (int)sqlmapper.Delete(statement, paramhashmap);
            return result;
        }

        #endregion

        #region Execute Sql

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="paramNames"></param>
        /// <param name="paramValues"></param>
        /// <returns></returns>
        public static DataSet ExecuteWithQueryDataSet(string sql, string[] paramNames, object[] paramValues)
        {
            ISqlMapper sqlmapper = Sql_Mapper.Instance();
            using (IDalSession session = sqlmapper.OpenConnection())
            {
                return sqlmapper.ExecuteSqlWithQueryDataSet(sql, paramNames, paramValues, "Table");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static DataSet ExecuteWithQueryDataSet(string sql)
        {
            ISqlMapper sqlmapper = Sql_Mapper.Instance();
            using (IDalSession session = sqlmapper.OpenConnection())
            {
                return sqlmapper.ExecuteSqlWithQueryDataSet(sql, "Table");
            }
        }
      
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sqlmapper"></param>
        /// <param name="sql"></param>
        /// <param name="paramNames"></param>
        /// <param name="paramValues"></param>
        /// <returns></returns>
        public static DataSet ExecuteWithQueryDataSet(ISqlMapper sqlmapper, string sql, string[] paramNames, object[] paramValues)
        {
            return sqlmapper.ExecuteSqlWithQueryDataSet(sql, paramNames, paramValues, "Table");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sqlmapper"></param>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static DataSet ExecuteWithQueryDataSet(ISqlMapper sqlmapper, string sql)
        {
            return sqlmapper.ExecuteSqlWithQueryDataSet(sql, "Table");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="paramNames"></param>
        /// <param name="paramValues"></param>
        /// <returns></returns>
        public static DataTable ExecuteWithQueryDataTable(string sql, string[] paramNames, object[] paramValues)
        {
            ISqlMapper sqlmapper = Sql_Mapper.Instance();
            using (IDalSession session = sqlmapper.OpenConnection())
            {
                return sqlmapper.ExecuteSqlWithQueryDataTable(sql, paramNames, paramValues, "Table");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static DataTable ExecuteWithQueryDataTable(string sql)
        {
            ISqlMapper sqlmapper = Sql_Mapper.Instance();
            using (IDalSession session = sqlmapper.OpenConnection())
            {
                return sqlmapper.ExecuteSqlWithQueryDataTable(sql, "Table");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sqlmapper"></param>
        /// <param name="sql"></param>
        /// <param name="paramNames"></param>
        /// <param name="paramValues"></param>
        /// <returns></returns>
        public static DataTable ExecuteWithQueryDataTable(ISqlMapper sqlmapper, string sql, string[] paramNames, object[] paramValues)
        {
            return sqlmapper.ExecuteSqlWithQueryDataTable(sql, paramNames, paramValues, "Table");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sqlmapper"></param>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static DataTable ExecuteWithQueryDataTable(ISqlMapper sqlmapper, string sql)
        {
            return sqlmapper.ExecuteSqlWithQueryDataTable(sql, "Table");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="paramNames"></param>
        /// <param name="paramValues"></param>
        /// <returns></returns>
        public static int ExecuteNonQuery(string sql, string[] paramNames, object[] paramValues)
        {
            ISqlMapper sqlmapper = Sql_Mapper.Instance();
            int result = 0;
            using (IDalSession session = sqlmapper.BeginTransaction())
            {
                result = sqlmapper.ExecuteSqlNonQuery(sql, paramNames,  paramValues);
                session.Complete();
            }
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static int ExecuteNonQuery(string sql)
        {
            ISqlMapper sqlmapper = Sql_Mapper.Instance();
            int result = 0;
            using (IDalSession session = sqlmapper.BeginTransaction())
            {
                result = sqlmapper.ExecuteSqlNonQuery(sql);
                session.Complete();
            }
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sqlmapper"></param>
        /// <param name="sql"></param>
        /// <param name="paramNames"></param>
        /// <param name="paramValues"></param>
        /// <returns></returns>
        public static int ExecuteNonQuery(ISqlMapper sqlmapper, string sql, string[] paramNames, object[] paramValues)
        {
            return sqlmapper.ExecuteSqlNonQuery(sql, paramNames, paramValues);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sqlmapper"></param>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static int ExecuteNonQuery(ISqlMapper sqlmapper, string sql)
        {
            return sqlmapper.ExecuteSqlNonQuery(sql);
        }

        #endregion

        #region SelectKey

        public virtual bool SelectKey()
        {
            return false;
        }

        #endregion

        public static long QueryForCount(IDictionary paramhashmap)
        {
            ISqlMapper sqlmapper = Sql_Mapper.Instance();
            string statement = String.Format("{0}.{1}", typeof(T).Name, "SelectByParam");
            using (IDalSession session = sqlmapper.OpenConnection())
            {
                return QueryForCount(sqlmapper, session, statement, paramhashmap);
            }
        }

        public static long QueryForCount(ISqlMapper sqlMapper, IDalSession session, string statementName, object paramObject)
        {
            bool flag = false;
            if (session == null)
            {
                session = new SqlMapSession(sqlMapper);
                session.OpenConnection();
                flag = true;
            }
            try
            {
                IBatisNet.DataMapper.MappedStatements.IMappedStatement statement = sqlMapper.GetMappedStatement(statementName);
                IBatisNet.DataMapper.Scope.RequestScope scope = statement.Statement.Sql.GetRequestScope(statement, paramObject, sqlMapper.LocalSession);
                statement.PreparedCommand.Create(scope, sqlMapper.LocalSession, statement.Statement, paramObject);
                using (IDbCommand cmd = scope.IDbCommand)
                {
                    string sql = cmd.CommandText;
                    if (sql.ToUpper().IndexOf("ORDER BY") > 0)
                    {
                        sql = sql.Substring(0, sql.ToUpper().LastIndexOf("ORDER BY"));
                    }
                    if (statementName == "BookingSheet.SelectByCrateOil")
                    {
                        string conSql = sql.Substring(sql.IndexOf("FROM OPENROWSET"), sql.IndexOf("(bs.BOOKING_SHEET_NUMBER=a.BOOKING_SHEET_TRIP)") - sql.IndexOf("FROM OPENROWSET"));
                        cmd.CommandText = string.Format("select count(1) as rowscount FROM (select A.BOOKING_SHEET_ID {0} (bs.TMS_BOOKING_SHEET_ID=a.id) "
                            + " group by A.BOOKING_SHEET_ID,A.ID,A.MID,A.SOLUTION_DATE,A.BOOKING_SHEET_TRIP,a.MID,A.ACTUAL_TRUCK_CODE,A.TRUCK_DRIVER,A.FACTORY_CODE "
                            +" ,c.name,ty.FUEL_CONSUMPTION_PER_KILOMETER )t", conSql);
                            
                    }
                    else
                    {
                        cmd.CommandText = string.Format("select count(1) as rowscount from ({0}) t ", sql);
                    }

                    using (IDataReader dr = cmd.ExecuteReader())
                    {
                        dr.Read();
                        return (long)dr.GetInt32(0);
                    }
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                if (flag)
                {
                    session.CloseConnection();
                }
            }
        }

        public static long QueryForCountOrderby(ISqlMapper sqlMapper, IDalSession session, string statementName, object paramObject)
        {
            bool flag = false;
            if (session == null)
            {
                session = new SqlMapSession(sqlMapper);
                session.OpenConnection();
                flag = true;
            }
            try
            {
                IBatisNet.DataMapper.MappedStatements.IMappedStatement statement = sqlMapper.GetMappedStatement(statementName);
                IBatisNet.DataMapper.Scope.RequestScope scope = statement.Statement.Sql.GetRequestScope(statement, paramObject, sqlMapper.LocalSession);
                statement.PreparedCommand.Create(scope, sqlMapper.LocalSession, statement.Statement, paramObject);
                using (IDbCommand cmd = scope.IDbCommand)
                {
                    string sql = cmd.CommandText;
                    //if (sql.ToUpper().IndexOf("ORDER BY") > 0)
                    //{
                    //    sql = sql.Substring(0, sql.ToUpper().LastIndexOf("ORDER BY"));
                    //}
                    cmd.CommandText = string.Format("select count(1) as rowscount from ({0}) t ", sql);

                    using (IDataReader dr = cmd.ExecuteReader())
                    {
                        dr.Read();
                        return (long)dr.GetInt32(0);
                    }
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                if (flag)
                {
                    session.CloseConnection();
                }
            }
        }

        public static long QueryForCount(ISqlMapper sqlmapper, string statementName, object paramObject)
        {


            IBatisNet.DataMapper.MappedStatements.IMappedStatement statement = sqlmapper.GetMappedStatement(statementName);
            IDbCommand cmd = null;
            try
            {
                if (!sqlmapper.IsSessionStarted)
                {
                    sqlmapper.OpenConnection();
                }
                IBatisNet.DataMapper.Scope.RequestScope scope = statement.Statement.Sql.GetRequestScope(statement, paramObject, sqlmapper.LocalSession);
                statement.PreparedCommand.Create(scope, sqlmapper.LocalSession, statement.Statement, paramObject);
                cmd = scope.IDbCommand;
                cmd.Connection = scope.Session.Connection;

                string sql = cmd.CommandText;
                if (sql.ToUpper().IndexOf("ORDER BY") > 0)
                {
                    sql = sql.Substring(0, sql.ToUpper().LastIndexOf("ORDER BY"));
                }
                cmd.CommandText = string.Format("select count(1) as rowscount from ({0}) t ", sql);

                using (IDataReader dr = cmd.ExecuteReader())
                {
                    dr.Read();
                    return (long)dr.GetInt32(0);
                }
            }
            finally
            {
                if (cmd != null && cmd.Connection != null && cmd.Connection.State != ConnectionState.Closed) cmd.Connection.Close();
            }
        }

    }
}