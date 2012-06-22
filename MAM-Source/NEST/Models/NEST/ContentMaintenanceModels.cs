using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Web.Mvc;
using System.Web.Security;

namespace NEST.Models
{

    public class DisplaySectionsModel
    {
        public string Header { get; set; }

        public string ContentTypeId { get; set; }

        public string Id { get; set; }
    }

    
}
