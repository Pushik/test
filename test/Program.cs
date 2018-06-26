using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using test.Models;
using System.Timers;


namespace test
{

    class Program
    {
        private static Timer aTimer;

        static string code { get; set; }

        static void Main(string[] args)
        {
            int timertime;
            // Чтение кода котировки
            Console.WriteLine("Enter Quote code:");
            code = Console.ReadLine();
            Console.WriteLine("Enter Time Period in second:");
            timertime = Convert.ToInt16(Console.ReadLine());

            // Создание таймера с принимаемым интервалом в переменной timertime
            aTimer = new System.Timers.Timer();
            aTimer.Interval = (timertime * 1000);
            aTimer.Elapsed += OnTimedEvent;  // Hook up the Elapsed event for the timer.
            aTimer.AutoReset = true;  // Have the timer fire repeated events (true is the default)
            aTimer.Enabled = true;  // Start the timer

            Console.WriteLine("Press any key to exit!");
            Console.ReadKey();
                       
                
        }
        // Событие по таймеру
        public static void OnTimedEvent(object source, System.Timers.ElapsedEventArgs e)
        {
            Console.WriteLine("the elapsed event was raised at {0}", e.SignalTime);
            var data = DataYohoo1(code);
            data.GetInfo();
            
        }
        // Получение данных от сервера Yahoo
        public static ResultYohoo DataYohoo1(string code)
        {
            Console.WriteLine("Данные от сервера");
            WebRequest wrGETURL = WebRequest.Create($"https://query1.finance.yahoo.com/v8/finance/chart/{code.ToUpperInvariant()}?interval=1d");
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
                    data1.Timezone = result.Chart.Data[0].Metadata.Timezone.ToString();
                    // возврат модели
                    return data1;
                    
                    Console.WriteLine("Press any key to exit!");
                    Console.ReadKey();

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Cannot deserialize string due an error {ex.Message}");
                return null;
            }
            finally
            {
                aTimer.AutoReset = true;
            }

            return null;
        }

    }
}
