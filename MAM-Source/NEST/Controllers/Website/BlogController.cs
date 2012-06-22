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
    public class BlogController : Controller
    {
        


        public ActionResult Index(string pagename = "blog")
        {


            return View(NEST.Models.RSSReader.GetRssFeed());



        }


       
    }
}
