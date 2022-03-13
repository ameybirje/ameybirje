using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RohiniTravels.BAL.Models
{
    public class Services : Fees
    {
        public DateTime ServiceStartDate { get; set; }
        public DateTime ServiceEndDate { get; set; }
        public TimeSpan PickUpTime { get; set; }
        public TimeSpan DropTime { get; set; }
        public string PickupDropLocation { get; set; }
        public int ServicesId { get; set; }
        public int ServicesName { get; set; }
        public string TravelType { get; set; }

    }
}