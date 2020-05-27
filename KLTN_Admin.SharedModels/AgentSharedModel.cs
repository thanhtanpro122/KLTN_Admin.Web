using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace KLTN_Admin.SharedModels
{
    public class AgentSharedModel
    {
        [JsonProperty("_id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("cancelfee")]
        public int CancelFee { get; set; }
    }
}
