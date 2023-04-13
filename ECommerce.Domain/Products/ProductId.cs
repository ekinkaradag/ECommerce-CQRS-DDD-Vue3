using System;
using ECommerce.Domain.SeedWork;

namespace ECommerce.Domain.Products
{
    public class ProductId : TypedIdValueBase
    {
        public ProductId(Guid value) : base(value)
        {
        }
    }
}