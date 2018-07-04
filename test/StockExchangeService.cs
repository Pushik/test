using System;
using Newtonsoft.Json;
using System.IO;
using System.Net;
using test.Models;
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

        public string ResultYohoo(string codequote)
        {
            WebRequest wrGETURL = WebRequest.Create($"https://query1.finance.yahoo.com/v8/finance/chart/{codequote.ToUpperInvariant()}?interval=1d");
            // Пример получение данных по указанной котировке - MU
            // WebRequest wrGETURL = WebRequest.Create($"https://query1.finance.yahoo.com/v8/finance/chart/MU?interval=1d");
            Stream objStream;
            objStream = wrGETURL.GetResponse().GetResponseStream();
            StreamReader objReader = new StreamReader(objStream);
            var json = objReader.ReadToEnd();


            try
            {
                // присваиваем ответ от сервера 
                var result = JsonConvert.DeserializeObject<Result>(json);

                if (result?.Chart?.Data == null || result.Chart.Data.Length == 0 ||
                    result.Chart.Data[0].Indicator?.CurrentValue == null ||
                    result.Chart.Data[0].Indicator?.CurrentValue.Length == 0 ||
                    result.Chart.Data[0].Indicator?.CurrentValue[0].Value.Length == 0)
                {
                    Console.WriteLine("Bad object format");
                }
                else
                {   // заполняем модель ResultYohoo 
                    var data1 = new ResultYohoo();
                    data1.Currency = result.Chart.Data[0].Metadata.Currency.ToString();
                    data1.ExchangeName = result.Chart.Data[0].Metadata.ExchangeName.ToString();
                    data1.Adjclose = result.Chart.Data[0].Indicator.Quotes[0].Valueclose[0].ToString("#,#00.000");
                    // возврат модели
                    return data1;

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Cannot deserialize string due an error {ex.Message}");
                return null;
            }
            finally
            {
                
            }
            return null;
        }
    }
    }
}
