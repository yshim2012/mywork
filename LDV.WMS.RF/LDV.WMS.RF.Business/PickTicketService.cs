using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Collections;
using LDV.WMS.RF.DataMapper;
using LDV.WMS.RF.Utility;
using IBatisNet.DataMapper;

namespace LDV.WMS.RF.Business
{
    public class PickTicketService
    {
        /// <summary>
        /// 查询对像LIST
        /// </summary>
        /// <param name="param"></param>
        /// <returns>DataTable</returns>
        public static DataTable QueryDataTableByParam(string loginName,double UserId)
        {
            SqlParamSet sqlParam = new SqlParamSet();
            sqlParam.AddParam("LOGINNAME", loginName);
            sqlParam.AddParam("USER_ID", UserId);
            try
            {
                 return VWmsPickTicket.QueryDataTable("SelectForPickTickt", sqlParam.GetParams());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 查询对像LIST
        /// </summary>
        /// <param name="param"></param>
        /// <returns>DataTable</returns>
        public static DataTable SelectOrderBoxList(double UserId, string orderlist, string boxNolist)
        {
            string[] obxnum = boxNolist.Split(',');
            string[] ordernum = orderlist.Split(',');
            SqlParamSet sqlParam = new SqlParamSet();
            sqlParam.AddParam("USER_ID", UserId);
            sqlParam.AddParam("boxnum", obxnum);
            sqlParam.AddParam("PICK_TICKET_CODE", ordernum);
            try
            {
                return VWmsPickTicket.QueryDataTable("SelectForPickTicktBoxList", sqlParam.GetParams());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 查询对像LIST
        /// </summary>
        /// <param name="param"></param>
        /// <returns>DataTable</returns>
        public static DataTable SelectOrderBoxInfo(double UserId,string loginName, string boxnum)
        {
            SqlParamSet sqlParam = new SqlParamSet();
             sqlParam.AddParam("LOGINNAME", loginName);
            sqlParam.AddParam("USER_ID", UserId);
            sqlParam.AddParam("boxnum", boxnum);
            try
            {
                return VWmsPickTicket.QueryDataTable("SelectForPickTicktBox", sqlParam.GetParams());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

         /// <summary>
        /// 查询对像LIST
        /// </summary>
        /// <param name="param"></param>
        /// <returns>DataTable</returns>
        public static DataTable QueryDataTableByParam(string orderCode,string loginName,double UserId)
        {
            SqlParamSet sqlParam = new SqlParamSet();
            sqlParam.AddParam("PICK_TICKET_CODE", orderCode);
            sqlParam.AddParam("LOGINNAME", loginName);
            sqlParam.AddParam("USER_ID", UserId);
            try
            {
                
                DataTable dt= VWmsPickTicket.QueryDataTable("SelectForPickTicktBy", sqlParam.GetParams());
                return dt;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 查询对像LIST
        /// </summary>
        /// <param name="param"></param>
        /// <returns>DataTable</returns>
        public static DataTable QueryDataTableByParam(double vpa_id)
        {
            SqlParamSet sqlParam = new SqlParamSet();
            sqlParam.AddParam("VPA_ID", vpa_id);      
            try
            {

                DataTable dt = VWmsPickTicket.QueryDataTable("SelectForPickTicktBy", sqlParam.GetParams());
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 更新主表状态
        /// </summary>
        /// <param name="UserId"></param>
        /// <param name="NewPwd"></param>
        /// <returns></returns>
        public static int UpdateStatus(double id,ISqlMapper sqlMapper)
        {
            try
            {
                SqlParamSet sqlParam = new SqlParamSet();
                sqlParam.AddParam("ID", id);

                return VWmsPickTicket.Update(sqlMapper,"UpdateStatus", sqlParam.GetParams());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 更新主表状态
        /// </summary>
        /// <param name="UserId"></param>
        /// <param name="NewPwd"></param>
        /// <returns></returns>
        public static int UpdateStatus(string OrderNumber)
        {
            try
            {
                SqlParamSet sqlParam = new SqlParamSet();
                sqlParam.AddParam("PICK_TICKET_CODE", OrderNumber);

                return VWmsPickTicket.Update("UpdateStatus", sqlParam.GetParams());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

       
    }
}
