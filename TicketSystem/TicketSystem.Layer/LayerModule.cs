using Autofac;
using TicketSystem.Layer.DbContexts;
using TicketSystem.Layer.Repositories;
using TicketSystem.Layer.Services;
using TicketSystem.Layer.UnitOfWorks;

namespace TicketSystem.Layer
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
            builder.RegisterType<LayerDbContext>().AsSelf()
                .WithParameter("connectionString", _connectionString)
                .WithParameter("assemblyName", _assemblyName)
                .InstancePerLifetimeScope();

            builder.RegisterType<LayerDbContext>().As<ILayerDbContext>()
                .WithParameter("connectionString", _connectionString)
                .WithParameter("assemblyName", _assemblyName)
                .InstancePerLifetimeScope();

            builder.RegisterType<TicketPurchaseRepository>().As<ITicketPurchaseRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<TicketPurchaseUnitOfWork>().As<ITicketPurchaseUnitOfWork>()
                .InstancePerLifetimeScope();

            builder.RegisterType<TicketPurchaseService>().As<ITicketPurchaseService>()
                .InstancePerLifetimeScope();

            base.Load(builder);
        }
    }


}
