using DataMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataMapper;

namespace tongqinche.Controllers
{
    public class CarrierController : Controller
    {
        //
        // GET: /Carrier/
        public ActionResult CarrierIndex()
        {
            return View();
        }

        public ActionResult CarrierCreate()
        {
            return View();
        }


        public ActionResult CarrierEdit(int id)
        {
            Carrier carrier = new Carrier();
            carrier.ID = id;
            ViewBag.editCarrier = carrier.QueryObject("SelectById");
            return View();
        }
    }
}