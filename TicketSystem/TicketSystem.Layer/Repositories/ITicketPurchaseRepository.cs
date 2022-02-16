using TicketSystem.Data;
using TicketSystem.Layer.Entities;

namespace TicketSystem.Layer.Repositories
{
    public interface ITicketPurchaseRepository : IRepository<TicketPurchase, int>
    {
    }
}
