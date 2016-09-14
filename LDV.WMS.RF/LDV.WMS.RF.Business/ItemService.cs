using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using LDV.WMS.RF.Utility;
using LDV.WMS.RF.DataMapper;

namespace LDV.WMS.RF.Business
{
    public class ItemService
    {
        public static DataTable QueryDataTableByParam(string PartCode)
        {
            SqlParamSet sqlParam = new SqlParamSet();
            sqlParam.AddParam("ITEM_CODE", PartCode);
            try
            {
                return VWmsItem.QueryDataTable("SelectByItemId", sqlParam.GetParams());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
