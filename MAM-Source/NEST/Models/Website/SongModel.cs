using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;

namespace NEST.Models
{
    public class SongModel
    {

        [Required]
        public string SongTitle { get; set; }

        public string Lyrics { get; set; }

        public string Credits { get; set; }

        public string SongEmbedCode { get; set; }

        [Required]
        public string Catalog { get; set; }

    }
}