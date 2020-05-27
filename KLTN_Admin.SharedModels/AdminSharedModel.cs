using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace KLTN_Admin.SharedModels
{
    public class AdminSharedModel
    {
        [JsonProperty("_id")]
        public string Id { get; set; }

        [JsonProperty("username")]
        public string UserName { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("admintype")]
        public int Type { get; set; }
    }
}
