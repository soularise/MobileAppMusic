using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net.Mail;
using System.Configuration;
using System.Web;
using NEST.Models;
namespace NEST.Common
{
    public class MailHandler
    {

        string SMTPAddress = ConfigurationManager.AppSettings["MailUser"];
        string SMTPPassword = ConfigurationManager.AppSettings["MailPassword"];
        string SMTPHost = ConfigurationManager.AppSettings["MailHost"];
        string contactAddress = ConfigurationManager.AppSettings["ContactEmailAddress"];
        string emailBody = "";
        string emailSubject = "";
        string VolunteerHeader = "";
        string ContactHeader = "";
        string JoinHeader = "";

        // generic email sender
        public void SendEmail(string fromAddress, string toAddress, string subject, string body)
        {
            emailBody += "EMAIL: " + fromAddress;
            emailBody += "<br><br>";
            emailBody += "MESSAGE:";
            emailBody += "<br><br>";
            emailBody += body;

            var message = new MailMessage(fromAddress, contactAddress)
            {
                Subject = subject,
                IsBodyHtml = true,
                Body = emailBody
            };

            var mailer = new SmtpClient();
            mailer.Host = SMTPHost;
            mailer.Credentials = new System.Net.NetworkCredential(SMTPAddress, SMTPPassword);
            mailer.Send(message);

            return;
        }

        // email from contact form
        public void SendContactEmail(Registrant registrant, string formType)
        {

            switch (formType)
            {
                case "JOIN":
                    emailSubject = "Join Submission from Website";
                    JoinHeader = "NEW JOIN MEMBER<br><br>";
                    break;
                case "VOLUNTEER":
                    emailSubject = "Volunteer Submission from Website";
                    VolunteerHeader = "VOLUNTEER INTERESTS:<br><br>";
                    break;
                case "CONTACT":
                    emailSubject = "Contact Submission from Website";
                    ContactHeader = "COMMENTS:<br><br>";
                    break;
                default:
                    emailSubject = "Form Submission from Website";
                    break;
            }

            emailBody += JoinHeader;
            emailBody += "NAME: " + registrant.FirstName + " " + registrant.LastName;
            emailBody += "<br><br>";
            emailBody += "EMAIL: " + registrant.Email;
            emailBody += "<br><br>";
            if (registrant.ZipCode != "")
            {
                emailBody += "ZIP: " + registrant.ZipCode;
                emailBody += "<br><br>";
            }
            emailBody += VolunteerHeader;
            emailBody += "<br><br>";
            emailBody += ContactHeader;
            emailBody += populateEmailBody(":", registrant.Comments);

            var message = new MailMessage(SMTPAddress, contactAddress)
            {
                Subject = emailSubject,
                IsBodyHtml = true,
                Body = emailBody
            };

            var mailer = new SmtpClient();
            mailer.Host = SMTPHost;
            mailer.Credentials = new System.Net.NetworkCredential(SMTPAddress, SMTPPassword);
            mailer.Send(message);

            return;
        }

        public string populateEmailBody(string description, string value)
        {

            string field = null;

            if (value != null)
            {
                if (description.Contains(":"))
                {
                    field = value;
                }
                else
                {
                    field = description;
                }
                field += "<br>";
            }

            return field;

        }

    }
}