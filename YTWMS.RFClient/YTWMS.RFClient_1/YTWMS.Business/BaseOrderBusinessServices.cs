using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IBatisNet.Common;
using Utility;
using DataMapper;
using IBatisNet.DataMapper;

namespace YTWMS.Business
{
   public  class BaseOrderBusinessServices
    {
        /// <summary>
        /// 保存ORDER,ORDER_BUSINESS,返回business_ID
        /// </summary>
        /// <param name="sqlMap"></param>
        /// <param name="order"></param>
        /// <param name="business"></param>
        /// <returns></returns>
        public static int SaveOrderBusiness(ISqlMapper sqlMap, OrderNum order, OrderBusiness business)
        {
            try
            {
                int iOrder = (int)sqlMap.Insert("OrderNum.Insert", order);
                if (iOrder <= 0)
                    throw new Exception("订单保存失败！");

                business.ORDER_NUM_ID = iOrder;
                int iBusiness = (int)sqlMap.Insert("OrderBusiness.Insert", business);
                if (iBusiness <= 0)
                    throw new Exception("业务订单保存失败！");

                return iBusiness;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
