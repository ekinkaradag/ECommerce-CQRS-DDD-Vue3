using System;
using ECommerce.Domain.SeedWork;

namespace ECommerce.Domain.Customers
{
    public class CustomerId : TypedIdValueBase
    {
        public CustomerId(Guid value) : base(value)
        {
        }
    }
}