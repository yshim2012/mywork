using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace tongqinche.Controllers
{
    public class WhiteListController : Controller
    {
        //
        // GET: /WhiteList/
        public ActionResult WhiteListIndex()
        {
            return View();
        }

        //
        // GET: /WhiteList/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /WhiteList/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /WhiteList/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /WhiteList/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /WhiteList/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /WhiteList/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /WhiteList/Delete/5
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
