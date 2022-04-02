using StockData.Data;
using StockData.Layer.DbContexts;
using StockData.Layer.Repositories;
using Microsoft.EntityFrameworkCore;
namespace StockData.Layer.UnitOfWorks
{
    public class CompanyUnitOfWork: UnitOfWork, ICompanyUnitOfWork
    {
        public ICompanyRepository Companies { get; private set; }

        public CompanyUnitOfWork(IStockDbContext dbContext,
            ICompanyRepository companyRepository
            ) : base((DbContext)dbContext)
        {
            Companies = companyRepository;
            
        }
    }
}
