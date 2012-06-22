using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.IO;

namespace NEST.Controllers.Common
{
    public class Utils
    {
        static private string _ValidAliasChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890_-+%.";
        static private string _ValidDomainChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890-.";
        static private string _ValidNumerics = "1234567890-";

        static public bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email) || email.Length > 50)
                return false;

            int at = email.IndexOf('@');
            if (at == -1)
                return false;

            string alias = email.Substring(0, at);
            string host = email.Substring(at + 1);

            if (host.IndexOf('@') != -1)
                return false;

            foreach (var c in alias)
            {
                if (_ValidAliasChars.IndexOf(c) == -1)
                    return false;
            }

            foreach (var c in host)
            {
                if (_ValidDomainChars.IndexOf(c) == -1)
                    return false;
            }

            return true;
        }

        static public bool IsValidName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return true;

            if (name.Length > 50)
                return false;

            foreach (var c in name)
            {
                if (char.IsControl(c))
                    return false;
            }
            return true;
        }

        static public bool IsValidZip(string zip)
        {
            if (string.IsNullOrWhiteSpace(zip))
                return true;

            if (zip.Length > 10)
                return false;

            foreach (var c in zip)
            {
                if (_ValidNumerics.IndexOf(c) == -1)
                    return false;
            }
            return true;
        }



        public static void SaveStreamToFile(Byte[] stream, String fileName)
        {



            FileStream file = new FileStream(fileName, FileMode.Create);

            file.Write(stream, 0, stream.Length);

            file.Flush();

            file.Close();

        }


        public static void SaveToFile(string textUpdate, string textFileName)
        {
            using (StreamWriter w = File.AppendText(textFileName))
            {
                Log(textUpdate, w);
                // Close the writer and underlying file.
                w.Close();
            }
            // Open and read the file.
            using (StreamReader r = File.OpenText(textFileName))
            {
                DumpLog(r);
            }
        }

        public static void Log(string logMessage, TextWriter w)
        {
            w.Write("\r\nLog Entry : ");
            w.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(),
                DateTime.Now.ToLongDateString());
            w.WriteLine("  :");
            w.WriteLine("  :{0}", logMessage);
            w.WriteLine("-------------------------------");
            // Update the underlying file.
            w.Flush();
        }

        public static void DumpLog(StreamReader r)
        {
            // While not at the end of the file, read and write lines.
            string line;
            while ((line = r.ReadLine()) != null)
            {
                Console.WriteLine(line);
            }
            r.Close();
        }

    }
}