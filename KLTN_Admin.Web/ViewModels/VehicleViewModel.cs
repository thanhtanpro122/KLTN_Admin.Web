using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KLTN_Admin.Web.ViewModels
{
    public class VehicleViewModel
    {
        public string Id { get; set; }
        
        // 0 là ghế cứng , 1 là giường nằm
        public int Type { get; set; }
        
        public string Name { get; set; }
        
        public string TotalSeats { get; set; }
        
        public string LicensePlates { get; set; }
        
        public string StartLocation { get; set; }
        
        public string EndLocation { get; set; }
        
        public int Status { get; set; }
        
        public string Agent { get; set; }
    }
}
