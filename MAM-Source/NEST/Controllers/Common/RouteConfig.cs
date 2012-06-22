using System;
using System.Xml.Linq;
using System.Xml.XPath;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using NEST.Models;

namespace NEST.Controllers.Common
{
    public class FriendlyUrlRouteHandler : System.Web.Mvc.MvcRouteHandler
    {
        protected override IHttpHandler GetHttpHandler(System.Web.Routing.RequestContext requestContext)
        {
            var friendlyUrl = (string)requestContext.RouteData.Values["pageName"];

            PageItem page = null;

            if (!string.IsNullOrEmpty(friendlyUrl))
                page = PageManager.GetPageByFriendlyUrl(friendlyUrl);

            if (page == null)
                page = PageManager.GetPageByFriendlyUrl("default");

            requestContext.RouteData.Values["controller"] = page.ControllerName;
            requestContext.RouteData.Values["action"] = "index";
            requestContext.RouteData.Values["id"] = page.PageId;

            return base.GetHttpHandler(requestContext);
        }
    }

    public class PageItem
    {
        public int PageId { get; set; }
        public string FriendlyUrl { get; set; }
        public string ControllerName { get; set; }
    }

    public class PageManager
    {

        public static PageItem GetPageByFriendlyUrl(string friendlyUrl)
        {
            NESTV1Entities db = new NESTV1Entities();

            PageItem page = null;

            ContentBody contentbody = db.ContentBodies.Single(c => c.SEOUrl == friendlyUrl);

                        page = new PageItem();
                        page.PageId = (int)contentbody.Id;
                        page.ControllerName = "Contribute";
                        page.FriendlyUrl = contentbody.SEOUrl;


                return page;
            }
        }
}

