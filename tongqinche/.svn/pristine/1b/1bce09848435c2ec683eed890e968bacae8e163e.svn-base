using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataMapper;

namespace tongqingche.Controllers
{
    public class LocController : Controller
    {
        //
        // GET: /Loc/
        public ActionResult LocIndex()
        {
            return View();
        } 

        //
        // GET: /Loc/Create
        public ActionResult LocCreate()
        {
            return View();
        }
      
        //
        // GET: /Loc/Edit/5
        public ActionResult LocEdit(int id)
        {
            Loc loc = new Loc();
            loc.Id = id;
            ViewBag.editLoc = loc.QueryObject("SelectById");

            return View();
        }

      

       

       
    }
}
