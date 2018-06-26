using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test.Models
{
    public class ResultYohoo
    {

        public String Currency;
        public String ExchangeName;
        public String Timezone;
        
        public void GetInfo()
        {
            Console.WriteLine($"ExchangeName: {ExchangeName}  Currency: {Currency} Timezone:{Timezone}");
        }
    }
}
