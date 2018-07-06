using Newtonsoft.Json;

namespace test.Models
{
    public class Result
    {
        [JsonProperty("chart")]
        public chart Chart { get; set; }
    }
}
