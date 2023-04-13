using ECommerce.Domain.SharedKernel;

namespace ECommerce.Domain.Products
{
    public class ProductPrice
    {
        public decimal Price { get; private set; }

        private ProductPrice()
        {
            
        }
    }
}