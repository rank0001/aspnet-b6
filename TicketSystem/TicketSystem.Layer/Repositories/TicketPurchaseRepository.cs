using Microsoft.EntityFrameworkCore;
using TicketSystem.Data;
using TicketSystem.Layer.DbContexts;
using TicketSystem.Layer.Entities;

namespace TicketSystem.Layer.Repositories
{
    public class TicketPurchaseRepository : Repository<TicketPurchase, int>, ITicketPurchaseRepository
    {
        public TicketPurchaseRepository(ILayerDbContext context) : base((DbContext)context)
        {

        }
    }
}
