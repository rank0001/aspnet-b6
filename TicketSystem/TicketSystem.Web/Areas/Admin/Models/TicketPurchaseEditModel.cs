using Autofac;
using AutoMapper;
using System.ComponentModel.DataAnnotations;
using TicketSystem.Layer.BusinessObjects;
using TicketSystem.Layer.Services;

namespace TicketSystem.Web.Areas.Admin.Models
{
    public class TicketPurchaseEditModel
    {
        private ITicketPurchaseService _ticketPurchaseService;
        private ILifetimeScope _scope;
        private IMapper _mapper;


        public int Id { get; set; }

        [StringLength(100, ErrorMessage = "Name should be less than 200 chars")]
        public string CustomerName { get; set; }

        [StringLength(1000, ErrorMessage = "Address should be less than 1000 chars")]
        public string CustomerAddress { get; set; }


        [StringLength(50, ErrorMessage = "SeatNumber should be less than 50 chars")]
        public string SeatNumber { get; set; }


        [Range(0, 20000, ErrorMessage = "Price should be between 0 to 20,000")]
        public int TicketPrice { get; set; }

        [StringLength(50, ErrorMessage = "Number should be less than 50 chars")]
        public string BusNumber { get; set; }

        public DateTime OnboardingTime { get; set; } 

        public TicketPurchaseEditModel()
        {

        }

        public TicketPurchaseEditModel(
            IMapper mapper,
            ITicketPurchaseService ticketPurchaseService)
        {
            _ticketPurchaseService = ticketPurchaseService;
            _mapper = mapper;
        }

        public void Resolve(ILifetimeScope scope)
        {
            _scope = scope;
            _ticketPurchaseService = _scope.Resolve<ITicketPurchaseService>();
            _mapper = _scope.Resolve<IMapper>();
        }


        public void EditTicket()
        {
            var ticket = _mapper.Map<TicketPurchase>(this);

            _ticketPurchaseService.EditTicket(ticket);
        }

        internal void LoadData(int id)
        {
            var ticket = _ticketPurchaseService.GetTicket(id);
            _mapper.Map(ticket, this);
        }


    }
}

