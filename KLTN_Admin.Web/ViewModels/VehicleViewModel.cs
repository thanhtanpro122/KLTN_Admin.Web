using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KLTN_Admin.Web.ViewModels
{
    public class VehicleViewModel
    {
        public string Id { get; set; }
        
        public ConstViewModel Type { get; set; }
        
        public string Name { get; set; }
        
        [Display(Name = "Tổng số ghế")]
        public string TotalSeats { get; set; }
        
        public string LicensePlates { get; set; }
        
        public LocationViewModel StartLocation { get; set; }

        public LocationViewModel StartProvince { get; set; }

        public LocationViewModel EndLocation { get; set; }

        public LocationViewModel EndProvince { get; set; }

        public int Status { get; set; }
        
        public AgentViewModel Agent { get; set; }

        public bool IsOnline { get; set; }

        public string CheckIsOnline { get; set; }
    }
}
