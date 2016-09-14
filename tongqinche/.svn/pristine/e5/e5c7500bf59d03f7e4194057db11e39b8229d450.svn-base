using DataMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace tongqinche.Controllers
{
    public class RouteShiftController : Controller
    {
        //
        // GET: /RouteShift/
        public ActionResult RouteShiftIndex()
        {
            return View();
        }

        //
       
        //
        // GET: /RouteShift/Create
        public ActionResult RouteShiftCreate()
        {
            return View();
        }

       
        // GET: /RouteShift/Edit/5
        public ActionResult RouteShiftEdit(int id)
        {
            RouteShift routeShift = new RouteShift();
            routeShift.Id = id;
            ViewBag.editRouteShift = routeShift.QueryObject("SelectById");

            return View();
        }

      

        //
        // GET: /RouteShift/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /RouteShift/Delete/5
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
