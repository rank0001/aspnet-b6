using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockData.Worker.Models.Companies
{
    public class Companies
    {
        public int Id { get; set; }
        public string? TradeCode { get; set; }

        public Companies(int id, string? tradeCode)
        {
            Id = id;
            TradeCode = tradeCode;
        }
    }
}
