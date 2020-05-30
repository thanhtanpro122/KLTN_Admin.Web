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
        public ConstViewModel Type { get; set; }
        
        public string Name { get; set; }
        
        public string TotalSeats { get; set; }
        
        public string LicensePlates { get; set; }
        
        public LocationViewModel StartLocation { get; set; }
        
        public LocationViewModel EndLocation { get; set; }
        
        public int Status { get; set; }
        
        public AgentViewModel Agent { get; set; }
    }
}
