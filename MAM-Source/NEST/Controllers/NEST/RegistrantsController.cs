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
    public class RegistrantsController : Controller
    {
        private NESTV1Entities db = new NESTV1Entities();

        //
        // GET: /Registrants/
        [Authorize]
        public ViewResult Index()
        {

            try
            {
                return View(db.Registrants.ToList());
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Registrants/Details/5
        [Authorize]
        public ViewResult Details(int id)
        {
            Registrant registrant = db.Registrants.Single(r => r.Id == id);
            return View(registrant);
        }

        //
        // GET: /Registrants/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Registrants/Create

        [HttpPost]
        public ActionResult Create(Registrant registrant)
        {
            if (ModelState.IsValid)
            {
                db.Registrants.AddObject(registrant);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(registrant);
        }
        
        //
        // GET: /Registrants/Edit/5
 
        public ActionResult Edit(int id)
        {
            Registrant registrant = db.Registrants.Single(r => r.Id == id);
            return View(registrant);
        }

        //
        // POST: /Registrants/Edit/5

        [HttpPost]
        public ActionResult Edit(Registrant registrant)
        {
            if (ModelState.IsValid)
            {
                db.Registrants.Attach(registrant);
                db.ObjectStateManager.ChangeObjectState(registrant, EntityState.Modified);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(registrant);
        }

        //
        // GET: /Registrants/Delete/5
 
        public ActionResult Delete(int id)
        {
            Registrant registrant = db.Registrants.Single(r => r.Id == id);
            return View(registrant);
        }

        //
        // POST: /Registrants/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Registrant registrant = db.Registrants.Single(r => r.Id == id);
            db.Registrants.DeleteObject(registrant);
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