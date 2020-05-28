using Newtonsoft.Json;

namespace KLTN_Admin.SharedModels
{
    public class AddtionalAgentShardeModel
    {
        [JsonProperty("orderTypes")]
        public ConstSharedModel[] OrderTypes { get; set; }
    }
}
