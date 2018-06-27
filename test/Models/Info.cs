using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test.Models
{
    public class Info
    {
        [JsonProperty("Currency")]
        public string Currency { get; set; }

        [JsonProperty("ExchangeName")]
        public string ExchangeName { get; set; }

        [JsonProperty("Timezone")]
        public string Timezone { get; set; }

        [JsonProperty("ExchangeTimeZoneName")]
        public string ExchangeTimeZoneName { get; set; }


    }
}
