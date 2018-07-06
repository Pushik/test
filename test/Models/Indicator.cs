using Newtonsoft.Json;

namespace test.Models
{
    public class Indicator
    {
        [JsonProperty("quote")]
        public Quote[] Quotes { get; set; }

     //   [JsonProperty("close")]
     //   public QuoteValue[] CurrentValueClose { get; set; }

        [JsonProperty("adjclose")]
        public QuoteValue[] CurrentValue { get; set; }
    }
}
