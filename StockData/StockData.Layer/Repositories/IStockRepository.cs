using StockData.Data;
using StockData.Layer.Entities;
namespace StockData.Layer.Repositories
{
    public interface IStockRepository: IRepository<StockPrice, int>
    {

    }
}
