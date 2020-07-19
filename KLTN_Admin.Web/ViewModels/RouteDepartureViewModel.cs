using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KLTN_Admin.Web.ViewModels
{
    public class RouteDepartureViewModel
    {
        public string Id { get; set; }

        public RouteViewModel Route { get; set; }

        public RouteScheduleViewModel RouteSchedule { get; set; }

        public DateTime DepartureDate { get; set; }

        public ConstViewModel Status { get; set; }
    }
}
