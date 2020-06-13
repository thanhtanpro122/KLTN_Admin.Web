using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KLTN_Admin.Web.ViewModels
{
    public class RouteAddViewModel :  RouteViewModel
    {
        public string VehicleId { get; set; }

        public string[] StationId { get; set; }

        public double[] StationTime { get; set; }

        public double[] StationDistance { get; set; }

        public int[] Day { get; set; }
    }
}
