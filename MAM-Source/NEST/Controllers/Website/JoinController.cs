using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Net.Mail;
using System.Web.Mvc;
using NEST.Common;
using NEST.Models;
using NEST.Controllers.Common;

namespace NEST.Controllers
{
    public class JoinController : Controller
    {

        private NESTV1Entities db = new NESTV1Entities();
        static private object SyncRoot = "";

        static private Dictionary<string, string> _SeenEmails = new Dictionary<string, string>();
        static private Dictionary<string, int> _IPCount = new Dictionary<string, int>();
        static private int _MaxEntriesPerIP = 1000;

        //
        // GET: /Home/

        public ActionResult Index()
        {
            ContentResult r = new ContentResult();
            r.Content = "OK";

            SaveEmail(Request.Form["em"], Request.Form["fin"], Request.Form["lan"], Request.Form["zip"], Request.UserHostAddress);

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

                    //send email notice
                    MailHandler thisMailer = new MailHandler();

                    Registrant registrant = new Registrant();

                    registrant.Email = email;
                    registrant.FirstName = fname;
                    registrant.LastName = lname;
                    registrant.ZipCode = zip;

                    thisMailer.SendContactEmail(registrant, "JOIN");


                    sw.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t{5}", email, fname, lname, zip, ipAddress, DateTime.Now.ToString("r"));
                    _SeenEmails[el] = el;
                    sw.Flush();

            
                }
            }

        }






        // send off to Email Program..

        //<div id="mc_embed_signup">
        //<form action="http://soularise.us2.list-manage.com/subscribe/post?u=6f506e9c9863828128da6ec9d&amp;id=f7d422a786" method="post" id="mc-embedded-subscribe-form" name="mc-embedded-subscribe-form" class="validate" target="_blank">
        //    <label for="mce-EMAIL">mailing list</label>
        //    <input type="email" value="" name="EMAIL" class="email" id="mce-EMAIL" placeholder="email address" required>
        //    <div class="clear"><input type="submit" value="Subscribe" name="subscribe" id="mc-embedded-subscribe" class="button"></div>
        //</form>
        //</div>


    }
}
