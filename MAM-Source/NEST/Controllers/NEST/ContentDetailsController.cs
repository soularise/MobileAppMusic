using System;
using System.Xml.Linq;
using System.Xml.XPath;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NEST.Models;

namespace NEST.Controllers
{ 
    public class ContentDetailsController : Controller
    {
        private NESTV1Entities db = new NESTV1Entities();

        public string Upload(HttpPostedFileBase fileData)
        {
            var fileName = this.Server.MapPath("~/uploads/" + System.IO.Path.GetFileName(fileData.FileName));
            fileData.SaveAs(fileName);
            return "ok";
        }


        public ViewResult Index()
        {
            var contentbodies = db.ContentBodies.Include("ContentSection");
            return View(contentbodies.ToList());
        }

        //
        // GET: /ContentDetails/Details/5

        public ViewResult Details(int id)
        {
            ContentBody contentbody = db.ContentBodies.Single(c => c.Id == id);
            return View(contentbody);
        }

        //
        // GET: /ContentDetails/Create

        public ActionResult Create()
        {
            ViewBag.ContentSection_ID = new SelectList(db.ContentSections, "Id", "Header");
            return View();
        } 

        //
        // POST: /ContentDetails/Create

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(ContentBody contentbody)
        {
            if (ModelState.IsValid)
            {
                db.ContentBodies.Attach(contentbody);
                db.ObjectStateManager.ChangeObjectState(contentbody, EntityState.Added);

                if (contentbody.Promote == "Y")
                {
                    UpdatePromotedArticle(contentbody.Id);
                }
                else
                {
                    contentbody.Promote = "N";
                    UpdatePromotedArticle(5); // article 5 is the dfault
                }

                db.SaveChanges();
            }
            ContentSection contentSection = db.ContentSections.Single(c => c.Id == contentbody.ContentSection_ID);
            ViewBag.SectionTitle = contentSection.Header;
            ViewData.Model = db.ContentBodies.Where(c => c.ContentSection_ID == contentbody.ContentSection_ID).ToList();
            return RedirectToAction("../ContentMaintenance/GetSectionItems/" + contentbody.ContentSection_ID);
        }
        
        //
        // GET: /ContentDetails/Edit/5
 
        public ActionResult Edit(int id)
        {
            ContentBody contentbody = db.ContentBodies.Single(c => c.Id == id);
            ViewBag.ContentSection_ID = new SelectList(db.ContentSections, "Id", "Header", contentbody.ContentSection_ID);
            return View(contentbody);
        }

        //
        // POST: /ContentDetails/Edit/5

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(ContentBody contentbody)
        {
            if (ModelState.IsValid)
            {
                db.ContentBodies.Attach(contentbody);
                db.ObjectStateManager.ChangeObjectState(contentbody, EntityState.Modified);
                
                if (contentbody.Promote == "Y")
                {
                    UpdatePromotedArticle(contentbody.Id);
                }
                else
                {
                    contentbody.Promote = "N";
                    UpdatePromotedArticle(5); // article 5 is the dfault
                }
                db.SaveChanges();
            }
            ContentSection contentSection = db.ContentSections.Single(c => c.Id == contentbody.ContentSection_ID);
            ViewBag.SectionTitle = contentSection.Header;
            ViewData.Model = db.ContentBodies.Where(c => c.ContentSection_ID == contentbody.ContentSection_ID).ToList();
            return RedirectToAction("../ContentMaintenance/GetSectionItems/" + contentbody.ContentSection_ID);
        }

        public void UpdatePromotedArticle(int id)
        {
            XDocument xmldoc = XDocument.Load(Server.MapPath("/App_Data/LandingConfig.xml"));
            XElement xElement = xmldoc.XPathSelectElement("LandingConfig/PromotedArticleID");

            // a) Value = text
            xElement.Value = id.ToString();

            xmldoc.Save(Server.MapPath("/App_Data/LandingConfig.xml"));
        }

        //
        // GET: /ContentDetails/Delete/5
 
        public ActionResult Delete(int id)
        {
            ContentBody contentbody = db.ContentBodies.Single(c => c.Id == id);
            return View(contentbody);
        }

        //
        // POST: /ContentDetails/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            ContentBody contentbody = db.ContentBodies.Single(c => c.Id == id);
            db.ContentBodies.DeleteObject(contentbody);
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