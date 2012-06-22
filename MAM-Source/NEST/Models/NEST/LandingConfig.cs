using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.Xml.Serialization;

namespace NEST.Common
{
    public class LandingConfig
    {
        static public LandingConfig Current { get; private set; }

        static LandingConfig()
        {
            XmlSerializer xs = new XmlSerializer(typeof(LandingConfig));

            string path = System.IO.Path.Combine(HttpRuntime.AppDomainAppPath, @"App_Data\LandingConfig.xml");
            using (XmlReader xr = XmlReader.Create(path))
            {
                LandingConfig lc = (LandingConfig)xs.Deserialize(xr);
                LandingConfig.Current = lc;
            }

        }
        public string SiteTitle { get; set; }
        public string Tagline { get; set; }
        public string LogoUrl { get; set; }

        public string BackgroundImageUrl { get; set; }
        public string BackgroundAttribution { get; set; }
        public string BackgroundAttributionLink { get; set; }

        public string BlogLink { get; set; }
        public string RssFeed { get; set; }

        public string TwitterAnywhereAPIKey { get; set; }
        public string TwitterAccount { get; set; }

        public string FacebookPage { get; set; }

        public string GoogleAnalyticsAccount { get; set; }

        public string PromotedArticleID { get; set; }
        public string ICOImage { get; set; }
        public string WebsiteDomainName { get; set; }
        public string JoinThanksMessage { get; set; }
        public string DefaultCatalogCategory {get; set;}

    }
}