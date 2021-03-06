﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace KLTN_Admin.SharedModels
{
    public class RouteSharedModel
    {
        [JsonProperty("_id")]
        public string Id { get; set; }

        [JsonProperty("vehicle")]
        public VehicleShareModel Vehicle { get; set; }

        [JsonProperty("startTime")]
        public string StartTime { get; set; }

        [JsonProperty("endTime")]
        public string EndTime { get; set; }

        [JsonProperty("startLocation")]
        public LocationSharedModel StartLocation { get; set; }

        [JsonProperty("startProvince")]
        public LocationSharedModel StartProvince { get; set; }

        [JsonProperty("endLocation")]
        public LocationSharedModel EndLocation { get; set; }

        [JsonProperty("endProvince")]
        public LocationSharedModel EndProvince { get; set; }

        [JsonProperty("price")]
        public int Price { get; set; }

        [JsonProperty("isCorrectRoute")]
        public bool IsCorrectRoute { get; set; }
    }
}
