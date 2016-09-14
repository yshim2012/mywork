using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using LDV.WMS.RF.DataMapper;
using LDV.WMS.RF.Utility;

namespace LDV.WMS.RF.Business
{
    public class ShipmentsCheckService
    {
        public static DataTable LoadShipOrder(string PickCode, string UserId,out string Mesg)
        {
            Mesg = string.Empty;
            try
            {
                SqlParamSet sqlParam = new SqlParamSet();
                sqlParam.AddParam("ID", UserId);
                DataTable Result;
                if (PickCode == string.Empty)
                {
                    //窗口加载查询
                    Result = VWmsPickTicketDetail.QueryDataTable("SelectLoadShipOrderById", sqlParam.GetParams());
                    if (Result.Rows.Count < 1)
                    {
                        Mesg = "没有查询到要核料的订单!";
                        return null;
                    }
                    else
                    {
                        return Result;
                    }
                }
                else
                {
                    //按条件查询
                    sqlParam.AddParam("PICK_TICKET_CODE", PickCode);
                    Result = VWmsPickTicketDetail.QueryDataTable("SelectLoadShipOrderByPickCode", sqlParam.GetParams());
                    if (Result.Rows.Count < 1)
                    {
                        Mesg = "没有查询到订单或订单已完成!";
                        return Result;
                    }
                    if (Result.Select("ID<>" + UserId + " and ID>0 ").Length > 0)
                    {
                        Mesg = "此单正在被" + Result.Select("ID<>" + UserId + " AND ID>0 ")[0]["FIRST_NAME"].ToString() +
                        Result.Select("ID<>" + UserId + " AND ID>0 ")[0]["LAST_NAME"].ToString() + "操作";
                        return Result;
                    }
                    //if (Result.Select("STATUS<>'BL' AND STATUS<>'PI'").Length > 1)
                    //{
                    //    Mesg = "该单据已完成或未拣货!";
                    //    return Result;
                    //}
                    else
                    {
                        return Result;
                    }
                }
            }
            catch (Exception ex)
            { 
                throw ex;
            }
        }
    }
}
