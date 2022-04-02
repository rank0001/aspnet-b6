using StockData.Layer.BusinessObjects;
using AutoMapper;
using CompanyEO = StockData.Layer.Entities.Company;
using StockPriceEO = StockData.Layer.Entities.StockPrice;
namespace StockData.Layer.Profiles
{
    public class StockProfile : Profile
    {
        public StockProfile()
        {
            CreateMap<CompanyEO, Company>().ReverseMap();
            CreateMap<StockPriceEO, StockPrice>()
                  .ReverseMap();

        }

    }
}
