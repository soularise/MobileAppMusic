using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NEST.Controllers
{
    public class FloridaController : Controller
    {


        public ActionResult Index()
        {
            ViewBag.Message = "FL - District 18";
            return View();
        }

    }
}
