using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NEST.Common;

namespace NEST.Controllers
{
    public class SplashHomeController : Controller
    {
        static private object SyncRoot = "";

        static private Dictionary<string, string> _SeenEmails = new Dictionary<string, string>();
        static private Dictionary<string, int> _IPCount = new Dictionary<string, int>();
        static private int _MaxEntriesPerIP = 1000;

        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddE()
        {
            ContentResult r = new ContentResult();
            r.Content = "OK";

            SaveEmail(Request.Form["e"], Request.Form["f"], Request.Form["l"], Request.Form["z"], Request.UserHostAddress);

            return r;
        }

        private void SaveEmail(string email, string fname, string lname, string zip, string ipAddress)
        {
            lock (SyncRoot)
            {
                string path = Server.MapPath(@"/App_Data/QuickJoins.txt");

                bool existed = System.IO.File.Exists(path);
                using (StreamWriter sw = new StreamWriter(path, true, System.Text.Encoding.UTF8))
                {
                    if (!existed)
                    {
                        sw.WriteLine("Email\tFName\tLName\tZip\tIP\tDate");
                    }
                    if (!Utils.IsValidName(fname))
                        fname = null;

                    if (!Utils.IsValidName(lname))
                        lname = null;

                    if (!Utils.IsValidEmail(email))
                        return;
                    if (!Utils.IsValidZip(zip))
                        return;

                    int ipCount = 0;
                    if (_IPCount.TryGetValue(ipAddress, out ipCount) && ipCount > _MaxEntriesPerIP)
                        return;

                    _IPCount[ipAddress] = ipCount + 1;

                    string el = email.ToLower().Trim();
                    if (_SeenEmails.ContainsKey(el))
                        return;

                    sw.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t{5}", email, fname, lname, zip, ipAddress, DateTime.Now.ToString("r"));
                    _SeenEmails[el] = el;
                    sw.Flush();
                }
            }

        }





    }
}
