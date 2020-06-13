using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace KLTN_Admin.SharedModels
{
    public class RouteScheduleSharedModel
    {
        [JsonProperty("_id")]
        public string Id { get; set; }

        [JsonProperty("route")]
        public RouteSharedModel Route { get; set; }

        [JsonProperty("dayOfWeek")]
        public int DayOfWeek { get; set; }
    }
}
