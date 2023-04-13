using System;

namespace ECommerce.Application.Orders
{
    public class ProductDto
    {
        public Guid Id { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }

        public string Name { get; set; }

        public string ImageUrl { get; set; }

        public ProductDto()
        {

        }

        public ProductDto(Guid id, int quantity, decimal price)
        {
            Id = id;
            Price = price;
            Quantity = quantity;
        }
    }
}