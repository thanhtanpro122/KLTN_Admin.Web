using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KLTN_Admin.Web.ViewModels
{
    public class VehicleAddViewModel : VehicleViewModel
    {
        public string[] Location { get; set; }

        public double[] LatitudeLocation { get; set; }

        public double[] LongtitudeLocation { get; set; }

        public int[] OrderToStation { get; set; }

        public string[] LocationProvince { get; set; }

        public double[] LatitudeProvince { get; set; }

        public double[] LongtitudeProvince { get; set; }

        public string[] LocationAddStation { get; set; }

        public string[] LocationAddProvince { get; set; }

        public double[] LatitudeLocationAddStation { get; set; }

        public double[] LongitudeLocationAddStation { get; set; }

        public double[] LatitudeLocationAddProvince { get; set; }

        public double[] LongitudeLocationAddProvince { get; set; }

        public int[] OrderToAddStation { get; set; }

        public string VehicleType { get; set; }

        public string VehicleAgent { get; set; }

        public string[] NumberSeats { get; set; }
    }
}
