using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KLTN_Admin.Web.ViewModels
{
    public class RouteViewModel
    {
        public string Id { get; set; }
        
        public string Vehicle { get; set; }

        public string NameVehicle { get; set; }

        public string TypeVehicle { get; set; }

        public string LicensePlates { get; set; }

        public string Agent { get; set; }

        public string NameAgent { get; set; }

        public string StartTime { get; set; }
        
        public string EndTime { get; set; }
        
        public string StartLocation { get; set; }
        
        public string EndLocation { get; set; }

        public string StartLocationString { get; set; }

        public string EndLocationString { get; set; }

        public int Status { get; set; }
        
        public int Price { get; set; }
        
        public DateTime DepartureDate { get; set; }
    }
}
