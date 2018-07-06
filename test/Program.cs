using System;
using System.Collections;
using System.Collections.Generic;
using System.Timers;


namespace test
{

    class Program
    {
        private static Timer aTimer;
        public static List<string> quoteCodes = new List<string>();
        private static IStockExchangeService _stockExchangeService;
                
        static void Main(string[] args)
        {
            _stockExchangeService = new StockExchangeService();
            int timertime;
            
        // Чтение списка кодов для котировки
            Console.WriteLine("Enter New Code or Press Q to exit");

            //var array = new List<string>();
            while (true)
             {
                string a = Console.ReadLine();
                if (a == "q") break;
                quoteCodes.Add(a);
             }
        
        //Вывод списка котировок
        //    Console.WriteLine("Array Code Quote:");
        //   for (int i = 0; i < quoteCodes.Count; i++)
        //     {
        //        Console.WriteLine(quoteCodes[i]);
        //     }

        // Чтение интервала времени для запроса с Yohoo
            Console.WriteLine("Enter Time Period in second:");
            var interval = Console.ReadLine();
            timertime = Convert.ToInt16(interval);

        // Создание таймера с принимаемым интервалом в переменной timertime
            aTimer = new System.Timers.Timer();
            aTimer.Interval = (timertime * 1000);
        //    aTimer.Elapsed += OnTimedEvent;  // Событие по истечению таймера.
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

                var data = _stockExchangeService.GetData(quoteCodes);
              //  data.GetInfo();
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
