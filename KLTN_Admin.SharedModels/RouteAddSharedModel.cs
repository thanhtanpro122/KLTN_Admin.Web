using System;
using System.Collections.Generic;
using System.Text;

namespace KLTN_Admin.SharedModels
{
    public class RouteAddSharedModel : RouteSharedModel
    {
        public string VehicleId { get; set; }

        public string[] StationId { get; set; }

        public double[] StationTime { get; set; }

        public double[] StationDistance { get; set; }

        public double[] OrderStation { get; set; }

        public int[] Day { get; set; }
    }
}
