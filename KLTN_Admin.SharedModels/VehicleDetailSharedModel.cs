using Newtonsoft.Json;

namespace KLTN_Admin.SharedModels
{
    public class VehicleDetailSharedModel
    {
        [JsonProperty("vehicles")]
        public VehicleShareModel Vehicle { get; set; }

        [JsonProperty("listStations")]
        public StationSharedModel[] Stations { get; set; }
    }
}
