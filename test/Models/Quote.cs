using Newtonsoft.Json;

namespace test.Models
{
    public class Quote
    {
        [JsonProperty("open")]
        public decimal[] Valueopen { get; set; }

        [JsonProperty("close")]
        public decimal[] Valueclose { get; set; }

    }
}
