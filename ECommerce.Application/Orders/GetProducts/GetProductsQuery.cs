using System;
using System.Collections.Generic;
using ECommerce.Application.Configuration.Queries;

namespace ECommerce.Application.Orders.GetProducts
{
    public class GetProductsQuery : IQuery<List<ProductDto>>
    {
        public GetProductsQuery()
        {
        }
    }
}