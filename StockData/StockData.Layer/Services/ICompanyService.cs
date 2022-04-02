using StockData.Layer.BusinessObjects;

namespace StockData.Layer.Services
{
    public interface ICompanyService
    {
        void CreateCompany(Company company);
        int GetCompanyCount();
     
    }
}
