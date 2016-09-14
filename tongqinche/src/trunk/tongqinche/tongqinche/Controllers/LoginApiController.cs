using Common;
using DataMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;


namespace tongqinche.Controllers
{
    public class LoginApiController : ApiController
    {
        [HttpPost]
        public string login(dynamic parm)
        {
            User user = new User();
            if (parm != null)
            {
                if (parm["Username"] != null)
                {
                    user.User_Name = parm["Username"].ToString().Trim();
                }
                if (parm["Password"] != null)
                {
                    user.Password = parm["Password"].ToString().Trim();
                }
            }

            var loginUser = user.QueryDataTable("SelectByParam");
            var jsonStr = string.Empty;

            if (loginUser != null && loginUser.Rows.Count > 0)
            {
                jsonStr = JsonSerializationHandler.Serialize<DataTable>(loginUser);
            }
            return "123";
        }

    }
}
