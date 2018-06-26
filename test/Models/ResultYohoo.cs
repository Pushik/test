using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test.Models
{
    public class ResultYohoo
    {

        public string Currency { get; set; }
        public string ExchangeName { get; set; }
        public string Timezone { get; set; }
        
        public void GetInfo()
        {
            Console.WriteLine($"ExchangeName: {ExchangeName}  Currency: {Currency} Timezone:{Timezone}");
        }
    }
}
