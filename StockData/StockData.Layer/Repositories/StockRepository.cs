using Microsoft.EntityFrameworkCore;
using StockData.Data;
using StockData.Layer.DbContexts;
using StockData.Layer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockData.Layer.Repositories
{
    public class StockRepository: Repository<StockPrice, int>, IStockRepository
    {
        public StockRepository(IStockDbContext context) : base((DbContext)context)
        {

        }
    }
}
