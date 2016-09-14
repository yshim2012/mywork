using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using IBatisNet.Common;
using IBatisNet.DataMapper;

namespace LDV.WMS.RF.DataMapper
{
    /// <summary>
    /// 所有实体类的基类,提供了持久化的操作
    /// </summary>
    [Serializable]
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

        public virtual DataTable QueryDataTableByIDictionary(string statement,IDictionary queryParams)
        {
            ISqlMapper sqlmapper = Sql_Mapper.Instance();
            statement = String.Format("{0}.{1}", typeof(T).Name, statement);
            using (IDalSession session = sqlmapper.OpenConnection())
            {
                return sqlmapper.QueryForDataTable(statement, queryParams, "Table");
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
            using (IDalSession session = sqlmapper.OpenConnection())
            {
                return sqlmapper.QueryForDataTable(statement, paramhashmap, "Table");
            }
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
                return sqlmapper.QueryForPageing(statement, paramhashmap, skipResults * maxResults , maxResults, "Table");
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
                return sqlmapper.QueryForPageing(statement, paramhashmap, skipResults * maxResults, maxResults, "Table");
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
                DataTable datatable = sqlmapper.QueryForPageing(statement, paramhashmap, skipResults * maxResults, maxResults, "Table");
                rowcount = sqlmapper.QueryForCount(statement, paramhashmap);
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
        public static DataTable QueryPageing(string statement, IDictionary paramhashmap, int skipResults, int maxResults, out long rowcount)
        {
            ISqlMapper sqlmapper = Sql_Mapper.Instance();
            statement = String.Format("{0}.{1}", typeof(T).Name, statement);
            using (IDalSession session = sqlmapper.OpenConnection())
            {
                DataTable datatable = sqlmapper.QueryForPageing(statement, paramhashmap, skipResults * maxResults, maxResults, "Table");
                rowcount = sqlmapper.QueryForCount(statement, paramhashmap);
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
                    sqlmapper.Insert(statement, this);
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
                sqlmapper.Insert(statement, this);
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
			using ( IDalSession session = sqlmapper.BeginTransaction() )
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
    }
}