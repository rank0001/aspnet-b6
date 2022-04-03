using Microsoft.EntityFrameworkCore;
using StockData.Data;
using StockData.Layer.DbContexts;
using StockData.Layer.Repositories;

namespace StockData.Layer.UnitOfWorks
{
    public class StockUnitOfWork: UnitOfWork, IStockUnitOfWork
    {
        public IStockRepository Stocks { get; private set; }

        public StockUnitOfWork(IStockDbContext dbContext,
            IStockRepository stockRepository
            ) : base((DbContext)dbContext)
        {
            Stocks = stockRepository;
        }
    }
}
