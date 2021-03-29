using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mvc.Models
{
    public class mvcCustomerModel
    {
        public int CustID { get; set; }

        [Required(ErrorMessage ="Mandatory")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Mandatory")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Mandatory")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Mandatory")]
        public string Password { get; set; }
    }
}