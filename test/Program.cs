using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using test.Models;


namespace test
{
  
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Quote code:");
            var code = Console.ReadLine();

            // Получение данных от сервера Yahoo
            Console.WriteLine("Данные от сервера");
            WebRequest wrGETURL = WebRequest.Create($"https://query1.finance.yahoo.com/v8/finance/chart/{code.ToUpperInvariant()}?interval=1d");
            Stream objStream;
            objStream = wrGETURL.GetResponse().GetResponseStream();
            StreamReader objReader = new StreamReader(objStream);
            var json = objReader.ReadToEnd();

            // Вот тут выводится всё одной строкой
            Console.WriteLine("Raw sever reponse:");
            Console.WriteLine(json);

            //Console.WriteLine("Press any key to continue...");
            //Console.ReadKey();

            try
            {
                // вот тут нужно запихнуть ответ от сервера и уже что-то будет ??? 
                var result = JsonConvert.DeserializeObject<Result>(json);

                if (result?.Chart?.Data == null || result.Chart.Data.Length == 0 || 
                    result.Chart.Data[0].Indicator?.CurrentValue == null ||
                    result.Chart.Data[0].Indicator?.CurrentValue.Length == 0 ||
                    result.Chart.Data[0].Indicator?.CurrentValue[0].Value.Length == 0)
                {
                    Console.WriteLine("Bad object format");
                }
                else
                {
                   
                    Console.WriteLine($"Current value for {code}: {result.Chart.Data[0].Indicator.CurrentValue[0].Value[0].ToString("#,#00.0000")}");
                    Console.WriteLine($"Current Curency : {result.Chart.Data[0].Metadata.Currency.ToString()}");
                    Console.WriteLine($"Exchange Name: {result.Chart.Data[0].Metadata.ExchangeName.ToString()}");
                    Console.WriteLine($"Exchange Name: {result.Chart.Data[0].Metadata.Timezone.ToString()}");
                    Console.WriteLine($"Exchange Time Zone :{result.Chart.Data[0].Metadata.ExchangeTimeZoneName.ToString()}");

                    // Квота Открытие - закрытие
                    Console.WriteLine($"Value Open for {code}: {result.Chart.Data[0].Indicator.Quotes[0].Valueopen[0].ToString("#,#00.0000")}");
                    Console.WriteLine($"Value Close for {code}: {result.Chart.Data[0].Indicator.Quotes[0].Valueclose[0].ToString("#,#00.0000")}");
                    
                   // Разница между Open и Close  Quote 
                    decimal a = ((result.Chart.Data[0].Indicator.Quotes[0].Valueopen[0]) - (result.Chart.Data[0].Indicator.Quotes[0].Valueclose[0]));
                    Console.WriteLine($"Delta from Quote Open<->Close: {a}");

                }
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Cannot deserialize string due an error {ex.Message}");
            }
                      
            Console.WriteLine("Press any key to exit!");
            Console.ReadKey();
        }
    }
}
