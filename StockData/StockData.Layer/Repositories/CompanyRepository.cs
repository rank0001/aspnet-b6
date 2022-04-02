using StockData.Data;
using StockData.Layer.DbContexts;
using StockData.Layer.Entities;
using Microsoft.EntityFrameworkCore;
namespace StockData.Layer.Repositories
{
    public class CompanyRepository: Repository<Company, int>, ICompanyRepository
    {
        public CompanyRepository(IStockDbContext context) : base((DbContext)context)
        {

        }
    }
}
