using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace KLTN_Admin.SharedModels
{
    public class MapSharedModel
    {
        [JsonProperty("_id")]
        public string Id { get; set; }

        [JsonProperty("type")]
        public ConstSharedModel Type { get; set; }

        [JsonProperty("width")]
        public int Width { get; set; }

        [JsonProperty("height")]
        public int Height { get; set; }

        [JsonProperty("orderType")]
        public ConstSharedModel OrderType { get; set; }
    }
}