﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test.Models
{
    public class Chart
    {
        [JsonProperty("result")]
        public String Data { get; set; }

    }
}
