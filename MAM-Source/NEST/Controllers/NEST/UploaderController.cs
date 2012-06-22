using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace NEST.Controllers
{
	public class UploaderController : Controller
	{
		//
		// GET: /Uploader/
        [Authorize]
		public ActionResult Index()
		{

			return View();
		}

        public string Upload(HttpPostedFileBase fileData)
        {
            var fileName = this.Server.MapPath("~/UploadedFiles/" + System.IO.Path.GetFileName(fileData.FileName));
            fileData.SaveAs(fileName);

            return "ok";
        }
	}
}
