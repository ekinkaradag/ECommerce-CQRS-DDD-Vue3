using ECommerce.Domain.Products;
using ECommerce.Domain.SeedWork;

namespace ECommerce.Domain.Customers.Orders
{
    public class OrderProduct : Entity
    {
        public int Quantity { get; private set; }

        public ProductId ProductId { get; private set; }

        internal decimal Price { get; private set; }

        private OrderProduct()
        {

        }

        private OrderProduct(
            ProductPriceData productPrice,
            int quantity)
        {
            this.ProductId = productPrice.ProductId;
            this.Quantity = quantity;

            this.CalculateValue(productPrice);
        }

        internal static OrderProduct CreateForProduct(
            ProductPriceData productPrice, int quantity)
        {
            return new OrderProduct(productPrice, quantity);
        }

        internal void ChangeQuantity(ProductPriceData productPrice, int quantity)
        {
            this.Quantity = quantity;

            this.CalculateValue(productPrice);
        }

        private void CalculateValue(ProductPriceData productPrice)
        {
            this.Price = this.Quantity * productPrice.Price;
            
        }
    }
}