using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KLTN_Admin.Web.ViewModels
{
    public class RouteViewModel
    {
        public string Id { get; set; }
        
        public VehicleViewModel Vehicle { get; set; }

        public AgentViewModel VehicleAgent { get; set; }

        public LocationViewModel VehicleStartLocation { get; set; }

        public LocationViewModel VehicleEndLocation { get; set; }
        
        public string StartTime { get; set; }
        
        public string EndTime { get; set; }
        
        public LocationViewModel StartLocation { get; set; }

        public LocationViewModel StartProvince { get; set; }

        public LocationViewModel EndLocation { get; set; }

        public LocationViewModel EndProvince { get; set; }
        
        public int Price { get; set; }

        public bool IsCorrectRoute { get; set; }
    }
}
