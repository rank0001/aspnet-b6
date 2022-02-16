using Microsoft.EntityFrameworkCore;
using TicketSystem.Data;
using TicketSystem.Layer.DbContexts;
using TicketSystem.Layer.Repositories;

namespace TicketSystem.Layer.UnitOfWorks
{
    public class TicketPurchaseUnitOfWork : UnitOfWork,ITicketPurchaseUnitOfWork
    {
        public ITicketPurchaseRepository Tickets { get; private set; }

        public TicketPurchaseUnitOfWork(ILayerDbContext dbContext,
            ITicketPurchaseRepository ticketRepository) : base((DbContext)dbContext)
        {
            Tickets = ticketRepository;
        }
    }
}
