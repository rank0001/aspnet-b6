using TicketSystem.Layer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketSystem.Layer.DbContexts
{
    public class LayerDbContext : DbContext, ILayerDbContext
    {
        private readonly string _connectionString;
        private readonly string _assemblyName;

        public LayerDbContext(string connectionString, string assemblyName)
        {
            _assemblyName = assemblyName;
            _connectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(_connectionString, m => m.MigrationsAssembly(_assemblyName));

            base.OnConfiguring(optionsBuilder);
        }


        public DbSet<TicketPurchase> Tickets { get; set; }
    }
}
