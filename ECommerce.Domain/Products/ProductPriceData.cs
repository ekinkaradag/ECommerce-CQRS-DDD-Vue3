using ECommerce.Domain.SeedWork;
using ECommerce.Domain.SharedKernel;

namespace ECommerce.Domain.Products
{
    public class ProductPriceData : ValueObject
    {
        public ProductPriceData(ProductId productId, decimal price)
        {
            ProductId = productId;
            Price = price;
        }

        public ProductId ProductId { get; }
        public decimal Price { get; }
    }
}