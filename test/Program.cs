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
        
        public string code { get; set; }
        
        static void Main(string[] args)
        {
           int timertime;
            // Чтение кода котировки
            Console.WriteLine("Enter Quote code:");
            var code = Console.ReadLine();
            Console.WriteLine("Enter Time Period:");
            timertime = Convert.ToInt16(Console.ReadLine());
                        
            // Create a timer and set a two second interval.
            aTimer = new System.Timers.Timer();
            aTimer.Interval = (timertime*1000);
            aTimer.Elapsed +=  DataYohoo1;  // Hook up the Elapsed event for the timer.
            aTimer.AutoReset = true;  // Have the timer fire repeated events (true is the default)
            aTimer.Enabled = true;  // Start the timer
            Console.WriteLine(DataYohoo1(code));
                               
            // Получение данных от сервера Yahoo
            //  Console.WriteLine("Данные от сервера");
              WebRequest wrGETURL = WebRequest.Create($"https://query1.finance.yahoo.com/v8/finance/chart/{code.ToUpperInvariant()}?interval=1d");
              Stream objStream;
              objStream = wrGETURL.GetResponse().GetResponseStream();
              StreamReader objReader = new StreamReader(objStream);
              var json = objReader.ReadToEnd();
              var result = JsonConvert.DeserializeObject<Result>(json);

            // Попытка собрать в массив
            //decimal[] numbers = new decimal[5];
            //for (int b = 0; b < numbers.Length; b++)
            //    { numbers[b] = decimal.Parse(result.Chart.Data[0].Indicator.Quotes[0].Valueopen[0].ToString());
            //    }
            
            // Попытка вывести из массива
            //Console.WriteLine("Массив значений OpeN");
            //for (int b = 0; b < numbers.Length; b++)
            // {
            //    Console.WriteLine(numbers[b]);
            // }
            //Console.WriteLine("Press to exit");
            //Console.ReadKey();

            // вот тут выводится всё одной строкой
            // console.writeline("raw sever reponse:");
            // console.writeline(json);
                    

        }
          
        //public static void DataYohoo(Object source, System.Timers.ElapsedEventArgs e)
        //{
        //    Console.WriteLine("The Elapsed event was raised at {0}", e.SignalTime);
            
        //    // Получение данных от сервера Yahoo
        //    Console.WriteLine("Данные от сервера");
        //   // WebRequest wrGETURL = WebRequest.Create($"https://query1.finance.yahoo.com/v8/finance/chart/{code.ToUpperInvariant()}?interval=1d");
        //    WebRequest wrGETURL = WebRequest.Create($"https://query1.finance.yahoo.com/v8/finance/chart/MU?interval=1d");
        //    Stream objStream;
        //    objStream = wrGETURL.GetResponse().GetResponseStream();
        //    StreamReader objReader = new StreamReader(objStream);
        //    var json = objReader.ReadToEnd();
            
            
        //    try
        //    {
        //        // вот тут нужно запихнуть ответ от сервера и уже что-то будет ??? 
        //        var result = JsonConvert.DeserializeObject<Result>(json);


        //        if (result?.Chart?.Data == null || result.Chart.Data.Length == 0 ||
        //            result.Chart.Data[0].Indicator?.CurrentValue == null ||
        //            result.Chart.Data[0].Indicator?.CurrentValue.Length == 0 ||
        //            result.Chart.Data[0].Indicator?.CurrentValue[0].Value.Length == 0)
        //        {
        //            Console.WriteLine("Bad object format");
        //        }
        //        else
        //        {
        //            Console.WriteLine($"Current value for code: {result.Chart.Data[0].Indicator.CurrentValue[0].Value[0].ToString("#,#00.0000")}");
        //            Console.WriteLine($"Current Curency : {result.Chart.Data[0].Metadata.Currency.ToString()}");
        //            Console.WriteLine($"Exchange Name: {result.Chart.Data[0].Metadata.ExchangeName.ToString()}");
        //            Console.WriteLine($"Exchange Name: {result.Chart.Data[0].Metadata.Timezone.ToString()}");
        //            Console.WriteLine($"Exchange Time Zone :{result.Chart.Data[0].Metadata.ExchangeTimeZoneName.ToString()}");

        //            // Квота Открытие - закрытие
        //            Console.WriteLine($"Value Open for code: {result.Chart.Data[0].Indicator.Quotes[0].Valueopen[0].ToString("#,#00.0000")}");
        //            Console.WriteLine($"Value Close for code: {result.Chart.Data[0].Indicator.Quotes[0].Valueclose[0].ToString("#,#00.0000")}");

        //            // Разница между Open и Close  Quote 
        //            decimal a = ((result.Chart.Data[0].Indicator.Quotes[0].Valueopen[0]) - (result.Chart.Data[0].Indicator.Quotes[0].Valueclose[0]));
        //            Console.WriteLine($"Delta from Quote Open<->Close: {a}");
        //            Console.WriteLine();

        //            //Console.WriteLine("Press any key to exit!");
        //            //Console.ReadKey();

        //        }
               
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine($"Cannot deserialize string due an error {ex.Message}");
        //    }
        //    finally
        //    { //aTimer.AutoReset = true;
        //    }

        //}

        public static decimal DataYohoo1(string code, System.Timers.ElapsedEventArgs e)
        {
           // Console.WriteLine("The Elapsed event was raised at {0}", e.SignalTime);

            // Получение данных от сервера Yahoo
            Console.WriteLine("Данные от сервера");
            WebRequest wrGETURL = WebRequest.Create($"https://query1.finance.yahoo.com/v8/finance/chart/{code.ToUpperInvariant()}?interval=1d");
            // WebRequest wrGETURL = WebRequest.Create($"https://query1.finance.yahoo.com/v8/finance/chart/MU?interval=1d");
            Stream objStream;
            objStream = wrGETURL.GetResponse().GetResponseStream();
            StreamReader objReader = new StreamReader(objStream);
            var json = objReader.ReadToEnd();


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
                    Console.WriteLine($"Current value for code: {result.Chart.Data[0].Indicator.CurrentValue[0].Value[0].ToString("#,#00.0000")}");
                    Console.WriteLine($"Current Curency : {result.Chart.Data[0].Metadata.Currency.ToString()}");
                    Console.WriteLine($"Exchange Name: {result.Chart.Data[0].Metadata.ExchangeName.ToString()}");
                    Console.WriteLine($"Exchange Name: {result.Chart.Data[0].Metadata.Timezone.ToString()}");
                    Console.WriteLine($"Exchange Time Zone :{result.Chart.Data[0].Metadata.ExchangeTimeZoneName.ToString()}");

                    // Квота Открытие - закрытие
                    Console.WriteLine($"Value Open for code: {result.Chart.Data[0].Indicator.Quotes[0].Valueopen[0].ToString("#,#00.0000")}");
                    Console.WriteLine($"Value Close for code: {result.Chart.Data[0].Indicator.Quotes[0].Valueclose[0].ToString("#,#00.0000")}");

                    // Разница между Open и Close  Quote 
                    decimal a = ((result.Chart.Data[0].Indicator.Quotes[0].Valueopen[0]) - (result.Chart.Data[0].Indicator.Quotes[0].Valueclose[0]));
                    Console.WriteLine($"Delta from Quote Open<->Close: {a}");
                    Console.WriteLine();
                    var b = result.Chart.Data[0].Indicator.Quotes[0].Valueopen[0];
                    
                    return b;

                    //Console.WriteLine("Press any key to exit!");
                    //Console.ReadKey();

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Cannot deserialize string due an error {ex.Message}");
                return -1;
            }
            finally
            { //aTimer.AutoReset = true;
            }
            return - 1;
        }
    }

}
