using System;
using System.Collections.Generic;

namespace ECommerce.Application.Orders.GetCustomerOrderDetails
{
    public class OrderDetailsDto: OrderDto
    {
        public List<ProductDto> Products { get; set; }
    }
}