using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace KLTN_Admin.SharedModels
{
    public class LocationSharedModel
    {
        [JsonProperty("_id")]
        public string Id { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("timestamp")]
        public string Timestamp { get; set; }

        [JsonProperty("coords")]
        public Coord Coord { get; set; }
    }

    public class Coord
    {
        [JsonProperty("latitude")]
        public string Latitude { get; set; }

        [JsonProperty("longtitude")]
        public string Longtitude { get; set; }

        [JsonProperty("altitude")]
        public string Altitude { get; set; }

        [JsonProperty("accuracy")]
        public string Accuracy { get; set; }

        [JsonProperty("heading")]
        public string Heading { get; set; }

        [JsonProperty("speed")]
        public string Speed { get; set; }
    }
}
