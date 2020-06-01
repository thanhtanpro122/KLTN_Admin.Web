using Newtonsoft.Json;

namespace KLTN_Admin.SharedModels
{
    public class ResponseResult<TData> where TData : class, new()
    {
        [JsonProperty("statusCode")]
        public int StatusCode { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("data")]
        public TData Data { get; set; }
    }
}