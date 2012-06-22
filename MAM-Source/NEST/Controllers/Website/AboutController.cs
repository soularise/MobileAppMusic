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
    public class AboutController : Controller
    {
        private NESTV1Entities db = new NESTV1Entities();


        public ActionResult Index(string pageName = "")
        {
            ContentBody contentbody = db.ContentBodies.Single(c => c.SEOUrl == "about");
            return View("Index", contentbody);
        }


    }
}
