﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DataMapper;
using Common;

namespace tongqinche.Controllers
{
    public class DictApiController : ApiController
    {

        [HttpPost]
        public string ShowDictList(dynamic parm)
        {
            Dict dict = new Dict();
            if (parm != null)
            {
                if (parm["DictCode"] != null)
                {
                    dict.Code = parm["DictCode"].ToString().Trim();
                }
                if (parm["DictName"] != null)
                {
                    dict.Name = parm["DictName"].ToString().Trim();
                }
                if (parm["ParentCode"] != null)
                {
                    dict.ParentCode = parm["ParentCode"].ToString().Trim();
                }
                if (parm["Status"] != null)
                {
                    dict.Status = int.Parse(parm["Status"].ToString().Trim());
                }
            }

            var dataList = dict.QueryList("SelectByParam");
            var jsonStr = JsonSerializationHandler.Serialize<IList<Dict>>(dataList);
            return jsonStr;
        }

        [HttpPost]
        public void CreateDict(dynamic parm)
        {
            Dict dict = new Dict();
            if (parm != null)
            {
                if (parm["DictCode"] != null)
                {
                    dict.Code = parm["DictCode"].ToString().Trim();
                }
                if (parm["DictName"] != null)
                {
                    dict.Name = parm["DictName"].ToString().Trim();
                }
                if (parm["ParentCode"] != null)
                {
                    dict.ParentCode = parm["ParentCode"].ToString().Trim();
                }

            }
            //dict.Status = 0;
            //dict.CreateTime = DateTime.Now;
            //dict.CreateUserId = 1;
            //dict.UpdateTime = DateTime.Now;
            //dict.UpdateUserId = 1;
            dict.Save();
        }

        public string GetChrildDictList(dynamic parent)
        {
            Dict dict = new Dict();
            dict.ParentCode = parent["code"].ToString();
            var list = dict.QueryList();
            var jsonStr = JsonSerializationHandler.Serialize<IList<Dict>>(list);
            return jsonStr;
        }
    }
}