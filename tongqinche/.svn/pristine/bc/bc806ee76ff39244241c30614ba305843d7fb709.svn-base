using DataMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace tongqinche.Controllers
{
    public class POSController : Controller
    {
        //
        // GET: /POS/
        public ActionResult POSIndex()
        {
            return View();
        }

       
        //
        // GET: /POS/Create
        public ActionResult POSCreate()
        {
            return View();
        }

       
        //
        // GET: /POS/Edit/5
        public ActionResult POSEdit(int id)
        {
            Loc loc = new Loc();
            loc.Id = id;
            ViewBag.editLoc = loc.QueryObject("SelectById");

            return View();
        }

       

        //
        // GET: /POS/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /POS/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
