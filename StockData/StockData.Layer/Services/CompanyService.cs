using AutoMapper;
using StockData.Layer.BusinessObjects;
using StockData.Layer.UnitOfWorks;
using CompanyEntity = StockData.Layer.Entities.Company;

namespace StockData.Layer.Services
{
    public class CompanyService:ICompanyService
    {
        private readonly ICompanyUnitOfWork _companyUnitOfWork;

        private readonly IMapper _mapper;

        public CompanyService(IMapper mapper,
             ICompanyUnitOfWork companyUnitOfWork)
        {
            _companyUnitOfWork = companyUnitOfWork;
            _mapper = mapper;
        }
        public void CreateCompany(Company company)
        {
            var companiesCount = _companyUnitOfWork.
                            Companies.GetCount();
            if (companiesCount == 0)
            {
                var entity = _mapper.Map<CompanyEntity>(company);
                _companyUnitOfWork.Companies.Add(entity);
                _companyUnitOfWork.Save();
            }
            
        }
    }
}
