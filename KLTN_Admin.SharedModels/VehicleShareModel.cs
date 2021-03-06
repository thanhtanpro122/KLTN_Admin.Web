﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace KLTN_Admin.SharedModels
{
    public class VehicleShareModel
    {
        [JsonProperty("_id")]
        public string Id { get; set; }

        [JsonProperty("type")]
        public ConstSharedModel Type { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("totalSeats")]
        public string TotalSeats { get; set; }

        [JsonProperty("licensePlates")]
        public string LicensePlates { get; set; }

        [JsonProperty("startLocation")]
        public LocationSharedModel StartLocation { get; set; }

        [JsonProperty("startProvince")]
        public LocationSharedModel StartProvince { get; set; }

        [JsonProperty("endLocation")]
        public LocationSharedModel EndLocation { get; set; }

        [JsonProperty("endProvince")]
        public LocationSharedModel EndProvince { get; set; }

        [JsonProperty("status")]
        public int Status { get; set; }

        [JsonProperty("agent")]
        public AgentSharedModel Agent { get; set; }

        [JsonProperty("isOnline")]
        public bool IsOnline { get; set; }
    }
}
