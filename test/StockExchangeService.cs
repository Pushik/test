using System;
using Newtonsoft.Json;
using System.IO;
using System.Net;
using test.Models;
using System.Collections.Generic;

namespace test
{
    public class StockExchangeService : IStockExchangeService
    {
        
        public string a;
        public List<ResultYohoo> GetResRequest(List<string> quoteCodes)
        { 
            List<ResultYohoo> ResRequestList = new List<ResultYohoo>();
            
            for (int i = 0; i < quoteCodes.Count; i++)
            {
                a = quoteCodes[i];
                var data = GetData(a);
                ResRequestList.Add(data);
            }
            return ResRequestList;
        }

        private ResultYohoo GetData(string a)
        {
            
                WebRequest wrGETURL = WebRequest.Create($"https://query1.finance.yahoo.com/v8/finance/chart/{a}?interval=1d");
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
                        throw new Exception("Bad object format");
                    }
                    else
                    {
                        // заполняем модель ResultYohoo 
                        var data = new ResultYohoo();
                        data.Currency = result.Chart.Data[0].Metadata.Currency.ToString();
                        data.ExchangeName = result.Chart.Data[0].Metadata.ExchangeName.ToString();
                        data.Adjclose = result.Chart.Data[0].Indicator.Quotes[0].Valueclose[0].ToString("#,#00.000");
                        // возврат модели ResultYohoo
                        return data;
                    }
                }

                catch (Exception ex)
                {
                    throw new Exception($"Cannot deserialize string due an error {ex.Message}");
                }
       
        }
    }
}
