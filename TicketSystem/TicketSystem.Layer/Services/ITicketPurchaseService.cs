using TicketSystem.Layer.BusinessObjects;

namespace TicketSystem.Layer.Services
{
    public interface ITicketPurchaseService
    {

        void CreateTicket(TicketPurchase ticket);
        (int total, int totalDisplay, IList<TicketPurchase> records) GetTickets(int pageIndex, int pageSize,
            string searchText, string orderBy);
        void EditTicket(TicketPurchase ticket);
        TicketPurchase GetTicket(int id);
        void DeleteTicket(int id);
    }
}
