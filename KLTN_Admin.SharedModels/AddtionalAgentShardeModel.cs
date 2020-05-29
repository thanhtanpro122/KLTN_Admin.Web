using Newtonsoft.Json;

namespace KLTN_Admin.SharedModels
{
    public class AddtionalAgentShardeModel
    {
        [JsonProperty("vehicleAndOrderTypes")]
        public ConstSharedModel[] VehicleAndOrderTypes { get; set; }
    }
}
