using Autofac;
using Autofac.Extensions.DependencyInjection;
using StockData.Layer;
using StockData.Worker;
using Serilog;
using Serilog.Events;
using StockData.Layer.DbContexts;
using Microsoft.EntityFrameworkCore;

var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json", false)
                .AddEnvironmentVariables()
                .Build();

var connectionString = configuration.GetConnectionString("DefaultConnection");

var migrationAssemblyName = typeof(Worker).Assembly.FullName;

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
    .Enrich.FromLogContext()
    .ReadFrom.Configuration(configuration)
    .CreateLogger();

try
{
    Log.Information("Application Starting up");

    IHost host = Host.CreateDefaultBuilder(args)
        .UseWindowsService()
        .UseServiceProviderFactory(new AutofacServiceProviderFactory())
        .UseSerilog()
        .ConfigureContainer<ContainerBuilder>(builder =>
        {
            builder.RegisterModule(new WorkerModule
                     (connectionString, migrationAssemblyName, configuration));
            builder.RegisterModule(new LayerModule(connectionString, migrationAssemblyName));

        })
        .ConfigureServices(services =>
        {
            services.AddDbContext<StockDbContext>(options =>
            options.UseSqlServer(connectionString, m => m.MigrationsAssembly(migrationAssemblyName)));
            services.AddHostedService<Worker>();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        })
        .Build();

    await host.RunAsync();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Application start-up failed");
}
finally
{
    Log.CloseAndFlush();
}


