using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using test.Models;

namespace test
{
    interface IStockExchangeService
    {
         string Currency { get; set; }
         string Adjclose { get; set; }
         string ExchangeName { get; set; }

         void GetInfo(string data);
        
    }
}
