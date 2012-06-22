using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using NEST.Models;

namespace NEST.Controllers
{

    [HandleError]
    public class HomeController : Controller
    {

        private NESTV1Entities db = new NESTV1Entities();

        //public ActionResult Index(int id = 0)
        //{

        //    try
        //    {
        //        id = Int32.Parse(NEST.Common.LandingConfig.Current.PromotedArticleID);
        //    }
        //    catch
        //    {
        //        id = 5;
        //    }

        //    ContentBody contentbody = db.ContentBodies.Single(c => c.Id == id);
        //    return View("Home", contentbody);
        //}
        public ActionResult Index(int id = 1)
        {
            try
            {
                var contentbodies = db.ContentBodies.Where(c => c.ContentSection_ID == id).OrderBy(s => s.SortOrder);
                return View("Home",contentbodies.ToList());
            }
            catch
            {
                return View("Home");

            }
        }

        public ActionResult Admin()
        {
            return View("../Account");
        }





        #region External Links

        public ActionResult Facebook()
        {
            return new RedirectResult("http://www.facebook.com/BuryTheLines");
        }
        public ActionResult Twitter()
        {
            return new RedirectResult("http://www.twitter.com/BuryTheLines");
        }
        public ActionResult YouTube()
        {
            return new RedirectResult("http://www.youtube.com/BuryTheLines");
        }
        public ActionResult Flickr()
        {
            return new RedirectResult("http://www.flickr.com/BuryTheLines");
        }

        #endregion

    }




}
