using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace YTWMS.RFClient
{
    public class LoginInfo
    {
        private LoginInfo() { }
        private static LoginInfo instance = null;
        public static LoginInfo GetInstance()
        {
            if (instance == null)
            {
                instance = new LoginInfo();
            }

            return instance;
        }

        #region 属性
        private RFService.LtUser _LoginUser;
        /// <summary>
        /// 登入用户
        /// </summary>
        public RFService.LtUser LoginUser
        {
            get { return _LoginUser; }
        }

        #endregion

        #region 设置值
        /// <summary>
        /// 设置用户信息
        /// </summary>
        /// <param name="userId"></param>
        public void SetLoginUser(RFService.LtUser loginUser)
        {
            this._LoginUser = loginUser;
        }

        #endregion
    }
}
