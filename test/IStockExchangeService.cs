using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using test.Models;

namespace test
{
    public interface IStockExchangeService
    {
        ResultYohoo GetData(string codequote);
    }
}
