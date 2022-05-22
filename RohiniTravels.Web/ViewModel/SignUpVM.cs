using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RohiniTravels.Web.ViewModel
{
    public class SignUpVM
    {
        [Required(ErrorMessage = "Enter first name")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Only letters are allowd")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Enter last Name")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Only letters are allowd")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Enter mobile number")]
        [RegularExpression(@"^[0-9]{10}$", ErrorMessage = "Only numbers are allowd")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "Invlid Mobile Number")]
        public string MobileNumber { get; set; }

        [Required(ErrorMessage = "Enter email address")]
        [RegularExpression(@"^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$", ErrorMessage = "Invalid email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Enter password")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,15}$", ErrorMessage = "Does not meet requirment")]
        public string Password { get; set; }

    }
}