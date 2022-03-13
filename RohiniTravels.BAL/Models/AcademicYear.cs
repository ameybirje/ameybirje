using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RohiniTravels.BAL.Models
{
    public class AcademicYear
    {
        public int AcademicYearId { get; set; }
        public DateTime  AcademicYearFrom { get; set; }
        public DateTime AcademicYearTo { get; set; }
    }
}