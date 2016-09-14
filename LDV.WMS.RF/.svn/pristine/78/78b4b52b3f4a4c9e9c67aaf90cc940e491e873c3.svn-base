using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LDV.WMS.RF.DataMapper;
using LDV.WMS.RF.Utility;
using System.Data;

namespace LDV.WMS.RF.Business
{
    /// <summary>
    /// 用户操作类
    /// </summary>
    public class VPhrSecUsrService
    {
        /// <summary>
        /// 登入
        /// </summary>
        /// <param name="LoginCount"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public static VPhrSecUsr Login(string LoginName, string pwd)
        {
            SqlParamSet sqlParam = new SqlParamSet();
            sqlParam.AddParam("LOGIN_NAME", LoginName.PadRight(30, ' '));
            sqlParam.AddParam("ENCRYPTED_PASSWORD", pwd);

            try
            {
                VPhrSecUsr user = VPhrSecUsr.QueryObject("SelectByParam", sqlParam.GetParams());
                return user;
            }
            catch (Exception ex) 
            {
                throw ex;
            }
        }
        public static DataTable GetUserAll()
        {
            SqlParamSet sqlParam = new SqlParamSet();

            try
            {
                return VPhrSecUsr.QueryDataTable("SelectByextend", sqlParam.GetParams()); 
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataTable GetUserOrder(string orderNum)
        {
            SqlParamSet sqlParam = new SqlParamSet();
            //sqlParam.AddParam("EXTEND_COLUMN_1", "%"+orderNum+"%");
            sqlParam.AddParam("EXTEND_COLUMN_1",  orderNum );
            try
            {
                return VPhrSecUsr.QueryDataTable("SelectByColumn", sqlParam.GetParams());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }       

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static int UpdateUser(VPhrSecUsr user)
        {
            try
            {
                return user.Update();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 更新密码
        /// </summary>
        /// <param name="UserId"></param>
        /// <param name="NewPwd"></param>
        /// <returns></returns>
        public static int UpdatePwd(double UserId, string NewPwd)
        {
            try
            {
                SqlParamSet sqlParam = new SqlParamSet();
                sqlParam.AddParam("ID", UserId);
                sqlParam.AddParam("ENCRYPTED_PASSWORD", NewPwd);

                return VPhrSecUsr.Update("UpdateSection", sqlParam.GetParams());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 根据用户ID修改用户当前正在进行的操作跟单号
        /// </summary>
        /// <param name="Userid"></param>
        /// <param name="CurrOrder">操作单号</param>
        /// <param name="OpState">操作状态</param>
        /// <returns></returns>
        public static bool UpdateUserState(double Userid, string CurrOrder, string OpState)
        {
            try
            {
                VPhrSecUsr usr = new VPhrSecUsr();
                usr.ID = Userid;
                usr.EXTEND_COLUMN_1 = CurrOrder;
                usr.EXTEND_COLUMN_2=OpState;
                if (usr.Update("UpdateOpState") > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 用户是否异地登入
        /// </summary>
        /// <param name="LoginName"></param>
        /// <param name="LoginTime"></param>
        /// <returns></returns>
        public static bool IsUserLoginOtherDevice(string LoginName, string LoginTime)
        {
            SqlParamSet sqlParam = new SqlParamSet();
            sqlParam.AddParam("LOGIN_NAME", LoginName);

            try
            {
                VPhrSecUsr user = VPhrSecUsr.QueryObject("SelectByParam", sqlParam.GetParams());
                if (user != null && user.EXTEND_COLUMN_0 == LoginTime)
                    return true;

                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
