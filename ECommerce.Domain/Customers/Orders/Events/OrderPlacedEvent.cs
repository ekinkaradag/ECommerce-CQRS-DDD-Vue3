using ECommerce.Domain.SeedWork;

namespace ECommerce.Domain.Customers.Orders.Events
{
    public class OrderPlacedEvent : DomainEventBase
    {
        public OrderId OrderId { get; }

        public CustomerId CustomerId { get; }

        public decimal Price { get; }

        public OrderPlacedEvent(
            OrderId orderId, 
            CustomerId customerId, 
            decimal price)
        {
            this.OrderId = orderId;
            this.CustomerId = customerId;
			Price = price;
        }
    }
}