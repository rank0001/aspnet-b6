using TicketSystem.Layer.Services;
using TicketSystem.Web.Models;

namespace TicketSystem.Web.Areas.Admin.Models
{
    public class TicketPurchaseListModel
    {
        private readonly ITicketPurchaseService _ticketPurchaseService;

        public TicketPurchaseListModel(ITicketPurchaseService ticketPurchaseService)
        {
            _ticketPurchaseService = ticketPurchaseService;
        }

        public object GetPagedTickets(DataTablesAjaxRequestModel model)
        {
            var data = _ticketPurchaseService.GetTickets(
                model.PageIndex,
                model.PageSize,
                model.SearchText,
                model.GetSortText(new string[] {"CustomerName","CustomerAddress", 
                "TicketPrice", ",", ",","OnboardingTime" }));

            return new
            {
                recordsTotal = data.total,
                recordsFiltered = data.totalDisplay,
                data = (from record in data.records
                        select new string[]
                        {
                                record.CustomerName,
                                record.CustomerAddress,
                                record.TicketPrice.ToString(),
                                record.SeatNumber,
                                record.BusNumber,
                                record.OnboardingTime.ToString(),
                                record.Id.ToString()
                        }
                    ).ToArray()
            };
        }

        internal void DeleteTicket(int id)
        {
            _ticketPurchaseService.DeleteTicket(id);
        }

    }
}
