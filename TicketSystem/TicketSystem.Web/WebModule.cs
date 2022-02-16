using Autofac;
using TicketSystem.Web.Areas.Admin.Models;

namespace TicketSystem.Web
{
    public class WebModule:Module
    {

        protected override void Load(ContainerBuilder builder)
        {

            builder.RegisterType<TicketPurchaseCreateModel>().AsSelf();
            builder.RegisterType<TicketPurchaseListModel>().AsSelf();
            builder.RegisterType<TicketPurchaseEditModel>().AsSelf();

            base.Load(builder);
        }
    }
}
