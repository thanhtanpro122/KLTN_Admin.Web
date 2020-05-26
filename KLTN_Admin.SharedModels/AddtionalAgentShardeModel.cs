using Newtonsoft.Json;

namespace KLTN_Admin.SharedModels
{
    public class AddtionalAgentShardeModel
    {
        [JsonProperty("defaultMaps")]
        public MapSharedModel[] DefaultMaps { get; set; }

        [JsonProperty("vehicleAndOrderTypes")]
        public ConstSharedModel[] VehicleAndOrderTypes { get; set; }
    }
}
