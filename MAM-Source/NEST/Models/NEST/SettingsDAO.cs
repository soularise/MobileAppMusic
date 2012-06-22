using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;


namespace NEST.Models
{
    public class SettingsDAO
    {


        // vars to get from the xml configuration
        public string activeEmailSender { get; set; }
        public string activeMailHost { get; set; }
        public string nestEmailSender { get; set; }
        public string nestMailHost { get; set; }
        public string nestEmailRecipient { get; set; }



    }
}