using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KLTN_Admin.Web.ViewModels
{
    public class RouteScheduleViewModel
    {
        public string Id { get; set; }
        
        public RouteViewModel Route { get; set; }
        
        public int DayOfWeek { get; set; }
    }
}
