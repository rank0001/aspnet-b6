using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSystem.Data;

namespace TicketSystem.Layer.Entities
{
    public class TicketPurchase:IEntity<int>
    {
        public int Id { get; set; }
        public string? CustomerName { get; set; }

        public string? CustomerAddress { get; set; }

        public string? SeatNumber { get; set; }

        public int TicketPrice { get; set; }

        public string? BusNumber { get; set; }
        public DateTime OnboardingTime { get; set; }


    }
}
