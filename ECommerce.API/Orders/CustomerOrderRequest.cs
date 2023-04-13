using System.Collections.Generic;
using ECommerce.Application.Orders;

namespace ECommerce.API.Orders
{
    public class CustomerOrderRequest
    {
        public List<ProductDto> Products { get; set; }
    }
}