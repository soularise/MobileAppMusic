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
    public class ServicesController : Controller
    {
        
        private NESTV1Entities db = new NESTV1Entities();

        public ActionResult Index(string page="services")
        {

                ContentBody contentbody = db.ContentBodies.Single(c => c.SEOUrl == page);
                return View(contentbody);


        }



        public ActionResult Details(int id)
        {
            ContentBody contentbody = db.ContentBodies.Single(c => c.Id == id);
            return View(contentbody);
        }



       
    }
}
