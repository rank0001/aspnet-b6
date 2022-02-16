using TicketSystem.Data;
using TicketSystem.Layer.Repositories;

namespace TicketSystem.Layer.UnitOfWorks
{
    public interface ITicketPurchaseUnitOfWork:IUnitOfWork
    {
        ITicketPurchaseRepository Tickets { get; }
    }
}
