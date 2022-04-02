using Autofac;
using AutoMapper;
using StockData.Layer.Services;
using StockData.Layer.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockData.Worker.Models.Companies
{
    public class CompanyCreateModel
    {
        private ICompanyService _companyService;
        private ILifetimeScope _scope;
        private IMapper _mapper;


        public CompanyCreateModel()
        {

        }

        public CompanyCreateModel(ICompanyService companyService, IMapper mapper)
        {
            _mapper = mapper;
            _companyService = companyService;

        }

        public void Resolve(ILifetimeScope scope)
        {
            _scope = scope;
            _companyService = _scope.Resolve<ICompanyService>();
            _mapper = _scope.Resolve<IMapper>();

        }

        public void CreateCompany(Companies company)
        {
            var companies = _mapper.Map<Company>(company);

            _companyService.CreateCompany(companies);
        }
    }
}
