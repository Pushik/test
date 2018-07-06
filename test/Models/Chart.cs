using Newtonsoft.Json;

namespace test.Models
{
    public class chart
    {
        [JsonProperty("result")]
        public Data[] Data { get; set; }

    }
}
