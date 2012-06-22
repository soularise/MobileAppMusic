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
    public class StoreController : Controller
    {
        
        private NESTV1Entities db = new NESTV1Entities();

        public ActionResult Index(string page="store")
        {
            try
            {
                var contentbodies = db.ContentBodies.Where(c => c.SEOUrl == page).OrderBy(s => s.SortOrder);
                return View(contentbodies.ToList());
            }
            catch
            {
                return View();
            
            }
        }



        public ActionResult NewsDetails(int id)
        {
            ContentBody contentbody = db.ContentBodies.Single(c => c.Id == id);
            return View(contentbody);
        }



       
    }
}
