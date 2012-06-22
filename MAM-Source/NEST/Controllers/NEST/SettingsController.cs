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
    public class SettingsController : Controller
    {
        private NESTV1Entities db = new NESTV1Entities();

        //
        // GET: /Settings/
        [Authorize]
        public ViewResult Index()
        {
            return View(db.Configurations.ToList());
        }

        //
        // GET: /Settings/Details/5
        [Authorize]
        public ViewResult Details(int id)
        {
            Configuration configuration = db.Configurations.Single(c => c.Id == id);
            return View(configuration);
        }

        //
        // GET: /Settings/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Settings/Create

        [HttpPost, Authorize]
        public ActionResult Create(Configuration configuration)
        {
            if (ModelState.IsValid)
            {
                db.Configurations.AddObject(configuration);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(configuration);
        }
        
        //
        // GET: /Settings/Edit/5
        [Authorize]
        public ActionResult Edit(int id)
        {
            Configuration configuration = db.Configurations.Single(c => c.Id == id);
            return View(configuration);
        }

        //
        // POST: /Settings/Edit/5

        [HttpPost, Authorize]
        public ActionResult Edit(Configuration configuration)
        {
            if (ModelState.IsValid)
            {
                db.Configurations.Attach(configuration);
                db.ObjectStateManager.ChangeObjectState(configuration, EntityState.Modified);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(configuration);
        }

        //
        // GET: /Settings/Delete/5
        [Authorize]
        public ActionResult Delete(int id)
        {
            Configuration configuration = db.Configurations.Single(c => c.Id == id);
            return View(configuration);
        }

        //
        // POST: /Settings/Delete/5

        [HttpPost, ActionName("Delete"), Authorize]
        public ActionResult DeleteConfirmed(int id)
        {            
            Configuration configuration = db.Configurations.Single(c => c.Id == id);
            db.Configurations.DeleteObject(configuration);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}