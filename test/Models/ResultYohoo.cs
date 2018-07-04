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
        public string Adjclose { get; set; }
        public string ExchangeName { get; set; }


        public void GetInfo()
        {
            Console.WriteLine($"Биржа: {ExchangeName}\n" + $"Валюта: {Currency}\n" + $"Закрытие: {Adjclose}");
        }
    }
}
