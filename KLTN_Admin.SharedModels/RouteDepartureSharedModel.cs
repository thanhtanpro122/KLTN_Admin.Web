using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace KLTN_Admin.SharedModels
{
    public class RouteDepartureSharedModel
    {
        [JsonProperty("_id")]
        public string Id { get; set; }

        [JsonProperty("route")]
        public RouteSharedModel Route { get; set; }

        [JsonProperty("routeSchedule")]
        public RouteScheduleSharedModel RouteSchedule { get; set; }

        [JsonProperty("departureDate")]
        public DateTime DepartureDate { get; set; }
    }
}
