using Newtonsoft.Json;

namespace hive_admin_web.Models
{
    public class ApiResponse
    {
        [JsonProperty("success")]
        public bool Success { get; set; }
        [JsonProperty("code")]
        public int Code { get; set; }
        [JsonProperty("data")]
        public PayloadResponse? Data { get; set; }
        [JsonProperty("traceId")]
        public string? TraceId { get; set; }
    }
}
