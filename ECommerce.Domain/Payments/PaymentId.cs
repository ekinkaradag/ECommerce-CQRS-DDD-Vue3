using System;
using ECommerce.Domain.SeedWork;

namespace ECommerce.Domain.Payments
{
    public class PaymentId : TypedIdValueBase
    {
        public PaymentId(Guid value) : base(value)
        {
        }
    }
}