using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NEST.Models;

namespace NEST.Controllers
{
    public class VolunteerController : Controller
    {

        private NESTV1Entities db = new NESTV1Entities();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ThankYou()
        {
            return View("VolunteerThankYou");
        }

        [HttpPost]
        public ActionResult Index(Registrant registrant)
        {
            if (ModelState.IsValid)
            {
                db.Registrants.AddObject(registrant);
                db.SaveChanges();

                return RedirectToAction("ThankYou");

            }

            return View(registrant);
        }

    }
}
