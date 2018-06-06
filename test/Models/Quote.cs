using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
