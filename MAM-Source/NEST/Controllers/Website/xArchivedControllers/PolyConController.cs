using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NEST.Models;

namespace NEST.Controllers
{
    public class PolyConController : Controller
    {
        
        private NESTV1Entities db = new NESTV1Entities();

        public ActionResult Index()
        {
            var contacts = db.PolyCons.ToList();
            return View(contacts);
        }

        //
        // GET: /PolyCon/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /PolyCon/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /PolyCon/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
        //
        // GET: /PolyCon/Edit/5
 
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /PolyCon/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /PolyCon/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /PolyCon/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
