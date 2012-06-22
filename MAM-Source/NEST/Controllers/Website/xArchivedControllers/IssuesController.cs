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
    public class IssuesController : Controller
    {
        //
        // GET: /Issues/
        private NESTV1Entities db = new NESTV1Entities();

        public ActionResult Index(int id = 10)
        {
            ViewBag.Message = "Issues";
            var contentbodies = db.ContentBodies.Where(c => c.ContentSection_ID == id).OrderBy(s => s.SortOrder).ToList();
            return View(contentbodies.ToList());
        }


        public ActionResult IssuesDetail(int id)
        {
            try
            {
                ContentBody contentbody = db.ContentBodies.Single(c => c.Id == id);
                return View(contentbody);
            }
            catch
            {
                return View();

            }
        }


    }
}
