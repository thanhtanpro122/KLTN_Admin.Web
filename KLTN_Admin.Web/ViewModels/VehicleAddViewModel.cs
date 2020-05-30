using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KLTN_Admin.Web.ViewModels
{
    public class VehicleAddViewModel : VehicleViewModel
    {
        public string LocationFrom { get; set; }

        public double LatitudeStartLocation { get; set; }

        public double LongtitudeStartLocation { get; set; }

        public string LocationTo{ get; set; }

        public double LatitudeEndLocation { get; set; }

        public double LongtitudeEndLocation { get; set; }

        public string VehicleType { get; set; }

        public string VehicleAgent { get; set; }
    }
}
