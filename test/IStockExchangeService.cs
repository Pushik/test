using System.Collections.Generic;
using test.Models;

namespace test
{
    public interface IStockExchangeService
    {
        ResultYohoo GetData(List<string> quoteCodes);
    }
}
