using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using NEST.Models;
using NEST.Common;

namespace NEST.Controllers
{
    public class LetterToEditorController : Controller
    {

        private NESTV1Entities db = new NESTV1Entities();


        public ActionResult Index()
        {
            var contacts = db.PolyCons.OrderBy(a => a.SortOrder);
            return View(contacts.ToList());
        }

        public ActionResult ThankYou()
        {
            return View("ThankYou");
        }

        [HttpPost]
        public ActionResult Index(FormCollection formCollection)
        {
            LetterToOfficial letterToOfficial = new LetterToOfficial
            {
                firstName = formCollection["FirstName"],
                lastName = formCollection["LastName"],
                email = formCollection["Email"],
                letter = formCollection["Letter"],
                emailSubject = formCollection["EmailSubject"],
                zipCode = formCollection["ZipCode"],
                officials = System.Text.RegularExpressions.Regex.Replace(formCollection["Officials"], @"\r\n+", " ")

            };
            string[] officialsArray = null;
            // now split the contacts that are selected and loop
            officialsArray = letterToOfficial.officials.Split(',');
            string[] nameValuePair = null;

            for (int i = 0; i < officialsArray.Length - 1; i++)
            {
                nameValuePair = officialsArray[i].Split('|');
                var thisEmail = nameValuePair[0];
                var thisName = nameValuePair[1];

                MailHandler thisMailer = new MailHandler();

                thisMailer.SendEmail(letterToOfficial.email, thisEmail, letterToOfficial.emailSubject, letterToOfficial.letter);
            }

            // do we save the submitee to the database?
            
            return View("ThankYou");
            
        }

    }


}
