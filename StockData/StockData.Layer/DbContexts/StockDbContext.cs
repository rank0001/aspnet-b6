using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockData.Layer.Entities;
using Microsoft.EntityFrameworkCore;

namespace StockData.Layer.DbContexts
{
    public class StockDbContext : DbContext, IStockDbContext
    {

        private readonly string _connectionString;
        private readonly string _assemblyName;
        public StockDbContext(string connectionString, string assemblyName)
        {

            _assemblyName = assemblyName;
            _connectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_connectionString, m => {
                    m.MigrationsAssembly(_assemblyName);
                });
            }

            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>()
                .HasMany(n => n.StockPrices)
                .WithOne(a => a.Company)
                .HasForeignKey(x => x.CompanyId);
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Company> Companies { get; set; }
        public DbSet<StockPrice> StockPrices { get; set; }

    }
}
