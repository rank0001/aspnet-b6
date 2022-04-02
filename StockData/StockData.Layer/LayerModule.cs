using Autofac;
using StockData.Layer.DbContexts;
using StockData.Layer.Repositories;
using StockData.Layer.Services;
using StockData.Layer.UnitOfWorks;

namespace StockData.Layer
{
    public class LayerModule : Module
    {
        private readonly string _connectionString;
        private readonly string _assemblyName;

        public LayerModule(string connectionString, string assemblyName)
        {
            _connectionString = connectionString;
            _assemblyName = assemblyName;
        }
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<IStockDbContext>().AsSelf()
                .WithParameter("connectionString", _connectionString)
                .WithParameter("assemblyName", _assemblyName)
                .InstancePerLifetimeScope();

            builder.RegisterType<StockDbContext>().
                As<IStockDbContext>()
               .WithParameter("connectionString", _connectionString)
               .WithParameter("assemblyName", _assemblyName)
               .InstancePerLifetimeScope();

            builder.RegisterType<CompanyUnitOfWork>().
                As<ICompanyUnitOfWork>()
                .InstancePerLifetimeScope();

            builder.RegisterType<CompanyRepository>().As<ICompanyRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<CompanyService>().As<ICompanyService>()
                .InstancePerLifetimeScope();

        }
    }
}
