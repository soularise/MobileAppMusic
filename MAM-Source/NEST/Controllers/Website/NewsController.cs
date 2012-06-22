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
    public class NewsController : Controller
    {
        
        private NESTV1Entities db = new NESTV1Entities();

        public ActionResult Index(int id=7)
        {
            try
            {
                var contentbodies = db.ContentBodies.Where(c => c.ContentSection_ID == id).OrderBy(s => s.SortOrder);
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
