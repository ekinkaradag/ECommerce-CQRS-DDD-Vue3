using System;
using MediatR;
using Newtonsoft.Json;
using ECommerce.Application.Configuration.Commands;
using ECommerce.Domain.Customers;

namespace ECommerce.Application.Customers
{
    public class MarkCustomerAsWelcomedCommand : InternalCommandBase<Unit>
    {
        [JsonConstructor]
        public MarkCustomerAsWelcomedCommand(Guid id, CustomerId customerId) : base(id)
        {
            CustomerId = customerId;
        }

        public CustomerId CustomerId { get; }
    }
}