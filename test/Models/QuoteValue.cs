using Newtonsoft.Json;

namespace test.Models
{
    public class QuoteValue
    {
        [JsonProperty("adjclose")]
        public decimal[] Value { get; set; }

     }
}
