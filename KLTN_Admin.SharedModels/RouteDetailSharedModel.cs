
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace KLTN_Admin.SharedModels
{
    public class RouteDetailSharedModel
    {
        [JsonProperty("_id")]
        public string Id { get; set; }

        [JsonProperty("route")]
        public RouteSharedModel Route { get; set; }

        [JsonProperty("station")]
        public StationSharedModel Station { get; set; }

        [JsonProperty("timeArrivingToStation")]
        public int TimeArrivingToStation { get; set; }

        [JsonProperty("orderRouteToStation")]
        public int OrderRouteToStation { get; set; }

        [JsonProperty("distanceToStation")]
        public int DistanceToStation { get; set; }

    }
}
