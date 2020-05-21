using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace KLTN_Admin.SharedModels
{
    public class ManagementSharedModel
    {
        [JsonProperty("_id")]
        public string Id { get; set; }

        [JsonProperty("agent")]
        public string Agent { get; set; }

        [JsonProperty("admin")]
        public string Admin { get; set; }

        [JsonProperty("isCreator")]
        public string IsCreator { get; set; }

        [JsonProperty("isroot")]
        public bool Isroot { get; set; }
    }
}
