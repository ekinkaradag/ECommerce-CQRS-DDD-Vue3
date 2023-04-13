using System;
using System.Collections.Generic;
using MediatR;
using ECommerce.Application.Configuration.Commands;
using ECommerce.Domain.Products;
using ECommerce.Application.Orders.GetProducts;

namespace ECommerce.Application.Orders.ChangeCustomerOrder
{
    public class ChangeCustomerOrderCommand : CommandBase<Unit>
    {
        public Guid CustomerId { get; }

        public Guid OrderId { get; }

        public List<ProductDto> Products { get; }

        public ChangeCustomerOrderCommand(
            Guid customerId, 
            Guid orderId,
            List<ProductDto> products)
        {
            this.CustomerId = customerId;
            this.OrderId = orderId;
            this.Products = products;
        }
    }
}
