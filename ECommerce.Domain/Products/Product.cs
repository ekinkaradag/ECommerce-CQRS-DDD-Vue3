using System;
using System.Collections.Generic;
using System.Linq;
using ECommerce.Domain.Customers.Orders;
using ECommerce.Domain.SeedWork;
using ECommerce.Domain.SharedKernel;

namespace ECommerce.Domain.Products
{
    public class Product : Entity, IAggregateRoot
    {
        public ProductId Id { get; private set; }

        public string Name { get; private set; }

        public decimal Price { get; private set; }

		public string ImageUrl { get; private set; }

		private Product()
        {

        }

		private Product(
			string name,
			decimal price,
			string imageUrl)
		{
			this.Id = new ProductId(Guid.NewGuid());
			this.Name = name;
			this.Price = price;
			this.ImageUrl = imageUrl;
		}

		public static Product AddNew(string name, decimal price, string imageUrl)
		{
			return new Product(name, price, imageUrl);
		}
	}
}