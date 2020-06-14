using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace KLTN_Admin.SharedModels
{
    public class StationSharedModel
    {
        [JsonProperty("_id")]
        public string Id { get; set; }

        [JsonProperty("stationStop")]
        public LocationSharedModel StationStop { get; set; }

        [JsonProperty("province")]
        public LocationSharedModel Province { get; set; }

        [JsonProperty("vehicle")]
        public VehicleShareModel Vehicle { get; set; }

        [JsonProperty("orderRouteToStation")]
        public int OrderRouteToStation { get; set; }
    }
}
