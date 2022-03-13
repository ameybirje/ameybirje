using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RohiniTravels.BAL.Models
{
    public class Payment
    {

        public string StudentName { get; set; }
        public decimal TotalAmount { get; set; }
        public int StudentId { get; set; }
        public List<StudentService> Services { get; set; }
    }

    public class StudentService
    { 

        public int StudentId { get; set; }
        public string Standard { get; set; }
        public int StudentServiceId { get; set; }
        public decimal Amount { get; set; }
        public string EducationalInstitute { get; set; }
        public string Service { get; set; }

    }

    public class StudentPaymentList
    {
        public string StudentName { get; set; }
        public decimal TotalAmount { get; set; }
        public int StudentId { get; set; }
        public string Standard { get; set; }
        public int StudentServiceId { get; set; }
        public decimal Amount { get; set; }
        public string EducationalInstitute { get; set; }
        public string Service { get; set; }

    }


}