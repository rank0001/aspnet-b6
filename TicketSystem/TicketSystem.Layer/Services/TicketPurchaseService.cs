using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSystem.Layer.BusinessObjects;
using TicketSystem.Layer.Exceptions;
using TicketSystem.Layer.UnitOfWorks;
using TicketEO = TicketSystem.Layer.Entities.TicketPurchase;
namespace TicketSystem.Layer.Services
{
    public class TicketPurchaseService : ITicketPurchaseService
    {

        private readonly ITicketPurchaseUnitOfWork _ticketPurchaseUnifOfWork;
        private readonly IMapper _mapper;

        public TicketPurchaseService(IMapper mapper,
           ITicketPurchaseUnitOfWork ticketPurchaseUnitOfWork)
        {
            _ticketPurchaseUnifOfWork = ticketPurchaseUnitOfWork;
            _mapper = mapper;
        }

        public void CreateTicket(TicketPurchase ticket)
        {

            var ticketCount = _ticketPurchaseUnifOfWork.Tickets
                .GetCount(x => x.BusNumber == ticket.BusNumber && x.SeatNumber==ticket.SeatNumber);
            if (ticket.OnboardingTime >= DateTime.Now)
            {
                if (ticketCount == 0)
                {
                    var entity = _mapper.Map<TicketEO>(ticket);
                    _ticketPurchaseUnifOfWork.Tickets.Add(entity);
                    _ticketPurchaseUnifOfWork.Save();
                }
                else
                    throw new DuplicateException("Sorry! The Seat is booked!");
            }
            else
                throw new InvalidDateException("Sorry! Invalid date provided!");
        }

        public void DeleteTicket(int id)
        {

            _ticketPurchaseUnifOfWork.Tickets.Remove(id);
            _ticketPurchaseUnifOfWork.Save();
        }

        public void EditTicket(TicketPurchase ticket)
        {
            var ticketCount = _ticketPurchaseUnifOfWork.Tickets
                .GetCount(x => x.BusNumber == ticket.
                BusNumber && x.SeatNumber == ticket.SeatNumber && x.Id!=ticket.Id);
            if (ticket.OnboardingTime >= DateTime.Now)
            {
                if (ticketCount == 0)
                {
                    var ticketEntity = _ticketPurchaseUnifOfWork.Tickets.GetById(ticket.Id);

                    _mapper.Map(ticket, ticketEntity);

                    _ticketPurchaseUnifOfWork.Save();
                }
                else
                    throw new DuplicateException("Seat is booked!");
            }
            else
                throw new InvalidDateException("Sorry! Invalid date provided!");
        }

        public TicketPurchase GetTicket(int id)
        {
            var ticketEntity = _ticketPurchaseUnifOfWork.Tickets.GetById(id);

            var ticket = _mapper.Map<TicketPurchase>(ticketEntity);

            return ticket;
        }

        public (int total, int totalDisplay, IList<TicketPurchase> records) GetTickets(int pageIndex, int pageSize, string searchText, string orderBy)
        {
            var result = _ticketPurchaseUnifOfWork.Tickets.GetDynamic(x => x.CustomerName.Contains(searchText),
            orderBy, string.Empty, pageIndex, pageSize, true);

            List<TicketPurchase> tickets = new List<TicketPurchase>();
            foreach (TicketEO ticket in result.data)
            {
                tickets.Add(_mapper.Map<TicketPurchase>(ticket));
            }

            return (result.total, result.totalDisplay, tickets);
        }
    }
}
