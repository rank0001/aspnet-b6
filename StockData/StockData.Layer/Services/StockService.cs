using AutoMapper;
using StockData.Layer.BusinessObjects;
using StockData.Layer.UnitOfWorks;

using StockEntity = StockData.Layer.Entities.StockPrice;

namespace StockData.Layer.Services
{
    public class StockService : IStockService
    {
        private readonly IStockUnitOfWork _stockUnitOfWork;

        private readonly IMapper _mapper;

        public StockService(IMapper mapper,
             IStockUnitOfWork stockUnitOfWork)
        {
            _stockUnitOfWork = stockUnitOfWork;
            _mapper = mapper;
        }
        public void CreateStocks(StockPrice stockPrices)
        {
            var entity = _mapper.Map<StockEntity>(stockPrices);
            _stockUnitOfWork.Stocks.Add(entity);
            _stockUnitOfWork.Save();
        }
    }
}
