using Microsoft.EntityFrameworkCore;
using StockData.Layer.Entities;

namespace StockData.Layer.DbContexts
{
    public interface IStockDbContext
    {
        DbSet<Company> Companies { get; set; }
        DbSet<StockPrice> StockPrices { get; set; }

    }
}
