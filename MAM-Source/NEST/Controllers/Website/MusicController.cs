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
    public class MusicController : Controller
    {
        //
        // GET: /Music/

        private NESTV1Entities db = new NESTV1Entities();

        public ActionResult Index(string pagename)
        {
            if (pagename == "" || pagename == null)
            {
                pagename = NEST.Common.LandingConfig.Current.DefaultCatalogCategory;
            }

            try
            {
                var contentbodies = db.ContentBodies.Where(c => c.SEOUrl == pagename).OrderBy(s => s.SortOrder);
                ViewBag.Genre = pagename.ToUpper();
                return View(contentbodies.ToList());
            }
            catch
            {

                return View();

            }
        }



        public ActionResult Details(int id)
        {
            ContentBody contentbody = db.ContentBodies.Single(c => c.Id == id);
            return View(contentbody);
        }

    }
}
