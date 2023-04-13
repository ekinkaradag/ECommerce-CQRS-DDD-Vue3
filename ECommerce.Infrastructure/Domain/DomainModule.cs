using Autofac;
using ECommerce.Application.Customers.DomainServices;
using ECommerce.Domain.Customers;

namespace ECommerce.Infrastructure.Domain
{
    public class DomainModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CustomerUniquenessChecker>()
                .As<ICustomerUniquenessChecker>()
                .InstancePerLifetimeScope();
        }
    }
}