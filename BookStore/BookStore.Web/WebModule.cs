using Autofac;
using BookStore.Web.Models;

namespace BookStore.Web
{
    public class WebModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<TestClass>().As<ITestClass>()
                .InstancePerLifetimeScope();

            builder.RegisterType<BookModel>().AsSelf();

            base.Load(builder);
        }
    }
}