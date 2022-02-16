using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSystem.Layer.BusinessObjects;
using TicketPurchaseEO = TicketSystem.Layer.Entities.TicketPurchase;
namespace TicketSystem.Layer.Profiles
{
    public class LayerProfile : Profile
    {
        public LayerProfile()
        {
            CreateMap<TicketPurchaseEO, TicketPurchase>().ReverseMap();
        }
    }
}
