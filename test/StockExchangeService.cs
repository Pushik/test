using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    class StockExchangeService : IStockExchangeService
    {
        public string Currency { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Adjclose { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string ExchangeName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void GetInfo(string data)
        {
            Console.WriteLine($"Биржа: {ExchangeName}\n" + $"Валюта: {Currency}\n" + $"Закрытие: {Adjclose}");
           
        }
    }
}
