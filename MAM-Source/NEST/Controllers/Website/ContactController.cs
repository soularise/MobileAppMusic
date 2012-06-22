using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using NEST.Models;
using NEST.Common;

namespace NEST.Controllers
{
    public class ContactController : Controller
    {
        private NESTV1Entities db = new NESTV1Entities();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ThankYou()
        {
            return View("ContactThankYou");
        }

        [HttpPost]
        public ActionResult Index(Registrant registrant)
        {
            if (ModelState.IsValid)
            {
                db.Registrants.AddObject(registrant);
                db.SaveChanges();

                MailHandler thisMailer = new MailHandler();

                thisMailer.SendContactEmail(registrant, "CONTACT");

                return RedirectToAction("ThankYou");

            }

            return View(registrant);
        }

    }
}
