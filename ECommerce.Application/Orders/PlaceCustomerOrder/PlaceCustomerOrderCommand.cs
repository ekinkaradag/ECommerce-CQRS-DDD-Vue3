using System;
using System.Collections.Generic;
using MediatR;
using ECommerce.Application.Configuration.Commands;
using ECommerce.Application.Orders.GetProducts;

namespace ECommerce.Application.Orders.PlaceCustomerOrder
{
    public class PlaceCustomerOrderCommand : CommandBase<Guid>
    {
        public Guid CustomerId { get; }

        public List<ProductDto> Products { get; }

        public PlaceCustomerOrderCommand(
            Guid customerId, 
            List<ProductDto> products)
        {
            this.CustomerId = customerId;
            this.Products = products;
        }
    }
}