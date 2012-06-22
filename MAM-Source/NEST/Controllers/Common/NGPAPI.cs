using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NEST.Models;
using System.Configuration;
using System.IO;
using System.Net;
using System.Web.Mvc;
using System.Text;


namespace NEST.Controllers.Common
{
    public class NGPAPI
    {

        public void postUserToNGP(Registrant registrant)
        {

            string MyRequest = "<lastName>" + registrant.LastName + "</lastName>";
            MyRequest = MyRequest + "<firstName>" + registrant.FirstName + "</firstName>";
            MyRequest = MyRequest + "<email>" + registrant.Email + "</email>";
            MyRequest = MyRequest + "<zip>" + registrant.ZipCode + "</zip>";


            //credentials
            string strCredentials = ConfigurationManager.AppSettings["NGPJoinToken"];
            //url
            string url = ConfigurationManager.AppSettings["NGPURL"];
            //
            //create the soap envelope and add request to it
            string Post = "<soap:Envelope xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance'";
            Post = Post + " xmlns:xsd='http://www.w3.org/2001/XMLSchema' xmlns:soap='http://schemas.xmlsoap.org/soap/envelope/'>";
            Post = Post + "<soap:Body><EmailSignUp xmlns='http://ngpsoftware.com/NGP.Services.UI/OnlineContribService'>";
            Post = Post + "<credentials>" + strCredentials + "</credentials>" + MyRequest + " <SendEmail>true</SendEmail></EmailSignUp>";
            Post = Post + "</soap:Body></soap:Envelope>";

            string SOAPAction = "http://ngpsoftware.com/NGP.Services.UI/OnlineContribService/EmailSignUp";

            // Create a request using a URL that can receive a post. 
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            // Set the Method property of the request to POST.
            request.Method = "POST";
            // Create POST data and convert it to a byte array.
            string postData = Post;
            byte[] byteArray = Encoding.UTF8.GetBytes(postData);
            // Set the ContentType property of the WebRequest.
            request.ContentType = "text/xml; charset=utf-8";
            // Set the ContentLength property of the WebRequest.
            request.ContentLength = byteArray.Length;
            // add SoapAction Header
            request.Headers.Add("SOAPAction:" + SOAPAction);
            // Get the request stream.
            Stream dataStream = request.GetRequestStream();
            // Write the data to the request stream.
            dataStream.Write(byteArray, 0, byteArray.Length);
            // Close the Stream object.
            dataStream.Close();
            // Get the response.
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            // log the content.

            //var fileName = System.IO.Path.Combine(HttpRuntime.AppDomainAppPath, @"LOGS\NGP.LOG");

            //byte[] result = null;

            //int byteCount = Convert.ToInt32(response.ContentLength);

            //using (BinaryReader reader = new BinaryReader(response.GetResponseStream()))
            //{

            //    result = reader.ReadBytes(byteCount);
            //    reader.Close();
            //}
            //// log the content.
            //Utils.SaveStreamToFile(result, fileName);
            //Utils.SaveToFile(response.GetResponseStream().ToString(), fileName);
            //Utils.SaveToFile(response.Headers.ToString(), fileName);
            //Utils.SaveToFile(response.StatusDescription, fileName);

            // Clean up the streams.
            response.Close();

            return;
        }



    }
}