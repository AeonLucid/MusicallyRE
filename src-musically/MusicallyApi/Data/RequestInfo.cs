using Newtonsoft.Json;

namespace MusicallyApi.Data
{
    internal class RequestInfo
    {
        [JsonProperty("os")]
        public string Os { get; set; }

        [JsonProperty("version")]
        public string Version { get; set; }

        [JsonProperty("slider-show-cookie")]
        public string SliderShowCookie { get; set; }

        [JsonProperty("X-Request-ID")]
        public string XRequestId { get; set; }

        [JsonProperty("method")]
        public string Method { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("ostype")]
        public string OsType { get; set; }

        [JsonProperty("deviceid")]
        public string DeviceId { get; set; }

        [JsonProperty("timestamp")]
        public long Timestamp { get; set; }
    }
}
