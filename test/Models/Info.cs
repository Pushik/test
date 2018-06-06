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
        public String Currency { get; set; }

        [JsonProperty("ExchangeName")]
        public String ExchangeName { get; set; }

        [JsonProperty("Timezone")]
        public String Timezone { get; set; }

        [JsonProperty("ExchangeTimeZoneName")]
        public String ExchangeTimeZoneName { get; set; }


    }
}
