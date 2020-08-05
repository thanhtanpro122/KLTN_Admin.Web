using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace KLTN_Admin.SharedModels
{
    public class StatisticalSharedModel
    {
        [JsonProperty("date")]
        public string Date { get; set; }

        [JsonProperty("completeTickets")]
        public int CompleteTickets { get; set; }

        [JsonProperty("cancelTickets")]
        public int CancelTickets { get; set; }

        [JsonProperty("revenue")]
        public double Revenue { get; set; }
    }
}
