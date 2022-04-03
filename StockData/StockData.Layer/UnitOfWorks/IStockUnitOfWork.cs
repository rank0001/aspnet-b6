using StockData.Data;
using StockData.Layer.Repositories;
namespace StockData.Layer.UnitOfWorks
{
    public interface IStockUnitOfWork:IUnitOfWork
    {
        IStockRepository Stocks { get; }
    }
}
