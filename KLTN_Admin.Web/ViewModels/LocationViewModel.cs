using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KLTN_Admin.Web.ViewModels
{
    public class LocationViewModel
    {
        public string Id { get; set; }
        
        public string Address { get; set; }
        
        public string Timestamp { get; set; }
        
        public string CoordLatitude { get; set; }

        public string CoordLongtitude { get; set; }

        public string CoordAltitude { get; set; }

        public string CoordAccuracy { get; set; }

        public string CoordHeading { get; set; }

        public string CoordSpeed { get; set; }
    }
}
