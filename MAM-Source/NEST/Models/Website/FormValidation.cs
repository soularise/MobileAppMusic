using System;
using System.Web.DynamicData;
using System.ComponentModel.DataAnnotations;


namespace NEST.Models
{

    [MetadataType(typeof(RegistrantValidation))]
    public partial class Registrant
    {


    }

    public class RegistrantValidation : Registrant
    {

        [Required(ErrorMessage = "* required")]
        new public object FirstName { get; set; }

        [Required(ErrorMessage = "* required")]
        new public object LastName { get; set; }

        [Required(ErrorMessage = "* required")]
        new public object Email { get; set; }

        [Required(ErrorMessage = "* required")]
        new public object Comments { get; set; }

    }


}