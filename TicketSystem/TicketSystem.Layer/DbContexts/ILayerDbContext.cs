using TicketSystem.Layer.Entities;
using Microsoft.EntityFrameworkCore;

namespace TicketSystem.Layer.DbContexts
{
    public interface ILayerDbContext
    {
        DbSet<TicketPurchase> Tickets { get; set; }
    }
}