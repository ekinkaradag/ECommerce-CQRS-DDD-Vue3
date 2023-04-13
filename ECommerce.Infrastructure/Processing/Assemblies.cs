using System.Reflection;
using ECommerce.Application.Orders.PlaceCustomerOrder;

namespace ECommerce.Infrastructure.Processing
{
    internal static class Assemblies
    {
        public static readonly Assembly Application = typeof(PlaceCustomerOrderCommand).Assembly;
    }
}