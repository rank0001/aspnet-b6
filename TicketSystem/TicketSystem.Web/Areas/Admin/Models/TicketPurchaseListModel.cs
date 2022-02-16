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

        public object GetPagedCourses(DataTablesAjaxRequestModel model)
        {
            var data = _ticketPurchaseService.GetTickets(
                model.PageIndex,
                model.PageSize,
                model.SearchText,
                model.GetSortText(new string[] { "CustomerName", "TicketPrice" }));

            return new
            {
                recordsTotal = data.total,
                recordsFiltered = data.totalDisplay,
                data = (from record in data.records
                        select new string[]
                        {
                                record.CustomerName,
                                record.CustomerAddress,
                                record.SeatNumber,
                                record.TicketPrice.ToString(),
                                record.BusNumber,
                                record.OnboardingTime.ToString(),
                                record.Id.ToString()
                        }
                    ).ToArray()
            };
        }

        internal void DeleteCourse(int id)
        {
            _ticketPurchaseService.DeleteTicket(id);
        }

    }
}
