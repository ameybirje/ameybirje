using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RohiniTravels.BAL.Models
{
    public  class StudentsDetails : ParentsDetails
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public int Pincode { get; set; }
        public int Standared { get; set; }
        public string SchoolName { get; set; }
        public string Gender { get; set; }
        public string LoginID { get; set; }
        public string Password { get; set; }
        public DateTime DOB { get; set; }
    }
}