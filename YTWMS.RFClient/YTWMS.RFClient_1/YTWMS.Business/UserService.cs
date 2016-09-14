using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IBatisNet.Common;
using Utility;
using DataMapper;

namespace YTWMS.Business
{
    /// <summary>
    /// 用户服务类
    /// </summary>
    public class UserService
    {
        /// <summary>
        /// 登入
        /// </summary>
        /// <param name="Acount">登入帐户</param>
        /// <param name="Password">密码</param>
        /// <returns></returns>
        public static LtUser Login(string Acount, string Password)
        {
            try
            {              
                SqlParamSet sqlParam = new SqlParamSet();
                sqlParam.AddParam("USER_ACCOUNT", Acount);
                sqlParam.AddParam("USER_PWD", Password);
                sqlParam.AddParam("IS_DELETE", "0");

                LtUser user = LtUser.QueryObject("SelectUserHouseByParam", sqlParam.GetParams());
                return user;
            }
            catch (Exception ex)
            {
                RunTimeLogger.Debug(DateTime.Now.ToString() + ":" + ex.Message);
                return null;
            }
        }
    }
}
