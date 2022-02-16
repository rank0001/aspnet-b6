using AutoMapper;
using TicketSystem.Layer.BusinessObjects;
using TicketSystem.Web.Areas.Admin.Models;
namespace TicketSystem.Web.Areas.Profiles
{
    public class WebProfile:Profile
    {
        public WebProfile()
        {
            CreateMap<TicketPurchaseCreateModel,TicketPurchase>()
               .ReverseMap();
            CreateMap<TicketPurchaseEditModel, TicketPurchase>()
               .ReverseMap();
        }
    }
}
