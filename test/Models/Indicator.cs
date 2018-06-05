using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test.Models
{
    public class Indicator
    {
        [JsonProperty("quote")]
        public Quote[] Quotes { get; set; }

        [JsonProperty("adjclose")]
        public QuoteValue[] CurrentValue { get; set; }
    }
}
