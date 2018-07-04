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
using System.Collections;


namespace test
{

    class Program
    {
        private static Timer aTimer;
        public static string codequote { get; set; }

        private static IStockExchangeService _stockуExchangeService;

        static void Main(string[] args)
        {
            _stockуExchangeService = new StockExchangeService();
            int timertime;
            
         // Чтение кода котировки
            Console.WriteLine("Enter Quote code:");
            codequote = Console.ReadLine();
         // Чтение интервала времени для запроса
            Console.WriteLine("Enter Time Period in second:");
            var interval = Console.ReadLine();
            timertime = Convert.ToInt16(interval);

        // Создание таймера с принимаемым интервалом в переменной timertime
            aTimer = new System.Timers.Timer();
            aTimer.Interval = (timertime * 1000);
            aTimer.Elapsed += OnTimedEvent;  // Событие по истечению таймера.
            aTimer.AutoReset = false;  // Повторить события таймера (true is the default)
            aTimer.Enabled = true;  // Start the timer
            aTimer.Start();

            Console.ReadKey();
         }
        // Событие по таймеру
          public static void OnTimedEvent(object source, System.Timers.ElapsedEventArgs e)
          {
            Console.WriteLine();
            Console.WriteLine("Данные от сервера");
            Console.WriteLine("Локальное время запроса {0}", e.SignalTime);

            try
            {
                var data = _stockуExchangeService.GetData(codequote);
                data.GetInfo();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                aTimer.Start();
            }
            
            Console.WriteLine();
                     
          }
        
    }
}
