using System;

namespace ECommerce.Application.Orders
{
    public class OrderDto
    {
        public Guid Id { get; set; }

        public decimal Price { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime? OrderChangeDate { get; set; }
        public bool IsRemoved { get; set; }
    }
}