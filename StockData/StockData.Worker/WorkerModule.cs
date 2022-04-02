using Autofac;
using StockData.Worker.Models.Companies;

namespace StockData.Worker
{
    public class WorkerModule:Module
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;
        private readonly string _migrationAssembly;

        public WorkerModule(string connectionString, string migrationAssembly,
            IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = connectionString;
            _migrationAssembly = migrationAssembly;
        }

        protected override void Load(ContainerBuilder builder)
        {
           // builder.RegisterType<CompanyCreateModel>().AsSelf();
            base.Load(builder);
        }
    }
}

