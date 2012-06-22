using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using NEST.Models;

namespace NEST.Controllers
{
    public class ContributeController : Controller
    {
        //
        // GET: /Contribute/
        private NESTV1Entities db = new NESTV1Entities();

        public ActionResult Index(string pageName = "")
        {
            ContentBody contentbody = db.ContentBodies.Single(c => c.SEOUrl == "default");
            return View("Index", contentbody);
        }


        public ActionResult Landing(string pagename = "default")
        {


            try
            {
                ContentBody contentbody = db.ContentBodies.Single(c => c.SEOUrl.ToLower() == pagename.ToLower());
                return View("Index", contentbody);
            }
            catch
            {

                ContentBody contentbody = db.ContentBodies.Single(c => c.SEOUrl == "default");
                return View("Index", contentbody);

            }

            
       }




    }

}
