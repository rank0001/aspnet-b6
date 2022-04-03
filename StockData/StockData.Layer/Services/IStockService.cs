using StockData.Layer.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockData.Layer.Services
{
    public interface IStockService
    {

        void CreateStocks(StockPrice stockPrices);
    }
}
