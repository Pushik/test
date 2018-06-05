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
            Console.WriteLine("Котировка");
            WebRequest wrGETURL = WebRequest.Create("https://query1.finance.yahoo.com/v8/finance/chart/MU?interval=1d");
            Stream objStream;
            objStream = wrGETURL.GetResponse().GetResponseStream();
            StreamReader objReader = new StreamReader(objStream);

            Console.WriteLine(objReader.ReadToEnd());

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            
            // вот тут нужно запихнуть ответ от сервера и уже что-то будет 
            var quote = JsonConvert.DeserializeObject<Chart>(objReader.ReadToEnd());
           
            // string json = quote;
           // Data newdata = JsonConvert.DeserializeObject<Data>(json);
            


            Console.WriteLine(quote);
            Console.WriteLine("Press any key to exit!");
            Console.ReadKey();
        }
    }
}
