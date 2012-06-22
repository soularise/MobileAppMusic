using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Web.Mvc;
using System.Web.Security;

namespace NEST.Models
{
    public class LetterModels
    {

        public class LetterModel
        {
            [Required]
            public string FirstName { get; set; }

            [Required]
            public string LastName { get; set; }

            [Required]
            [DataType(DataType.EmailAddress)]
            public string Email { get; set; }

            [Required]
            public string ZipCode { get; set; }

            [Required]
            public string EmailSubject { get; set; }

            [Required]
            public string OfficialIds { get; set; }

            [Required]
            public string Letter { get; set; }

        }

    }
}