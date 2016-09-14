using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LDV.WMS.RF.DataMapper;

namespace LDV.WMS.RF.Business
{
    public class FreeDomCheckService
    {
        public static bool InsertFreeCheck(double LocId, double ItemId, double qty, double userId)
        {
            try
            {
                LdvFreedomCheck FreeCheck = new LdvFreedomCheck();
                FreeCheck.LOC_ID = LocId;
                FreeCheck.ITEM_ID = ItemId;
                FreeCheck.QTY = qty;
                FreeCheck.CREATE_DATE = DBDateTimeGenerator.GetDBDateTime();
                FreeCheck.CREATE_USER_ID = userId;
                FreeCheck.LAST_MODIFY_DATE = DBDateTimeGenerator.GetDBDateTime();
                FreeCheck.LAST_MODIFY_USER_ID = userId;
                FreeCheck.Save();
                return true;
            }
            catch(Exception ex) 
            {
                return false;
                throw ex;   
            }
        }
    }
}
