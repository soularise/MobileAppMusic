using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Web;
using System.Text.RegularExpressions;

namespace NEST.Models
{
    public class RSSModel
    {
        public string Link { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }


    public class RSSReader
    {
        private static string _blogURL = NEST.Common.LandingConfig.Current.RssFeed;

        private static string XName(string elementName) { 
            return string.Concat("{http://www.w3.org/2005/Atom}", elementName); 
        }

        // tumblr format

        //public static IEnumerable<RSSModel> GetRssFeed()
        //{
        //    XDocument xdoc = XDocument.Load(_blogURL);

        //    var items = from i in xdoc.Descendants("item")
        //                select new RSSModel
        //                {
        //                    Title = i.Element("title").Value,
        //                    Link = i.Element("link").Value,
        //                    Description = i.Element("description").Value
        //                };


        //    return items;
        //}

        // blogger format

        public static IEnumerable<RSSModel> GetRssFeed()
        {
            XDocument xdoc = XDocument.Load(_blogURL);

            var items = from i in xdoc.Descendants(XName("entry"))
                        select new RSSModel
                        {
                            Title = i.Element(XName("title")).Value,
                            Link = i.Element(XName("link")).Value,
                            Description = i.Element(XName("content")).Value
                        };


            return items;
        }

    }

}