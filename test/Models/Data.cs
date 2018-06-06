using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test.Models
{
    public class Data
    {
        [JsonProperty("meta")]
        public Info Metadata { get; set; }

        [JsonProperty("quote")]
        public Quote Quotes { get; set; }
        
        [JsonProperty("indicators")]
        public Indicator Indicator { get; set; }
               

    }
}
