using System;
using MediatR;
using ECommerce.Application.Configuration.Commands;

namespace ECommerce.Application.Orders.AddNewProduct
{
    public class AddNewProductCommand : CommandBase<Guid>
    {

		public decimal Price { get; set; }

		public string Name { get; set; }

		public string ImageUrl { get; set; }

		public AddNewProductCommand(
            decimal price,
            string name,
            string imageUrl)
        {
            this.Price = price;
            this.Name = name;
            this.ImageUrl = imageUrl;
        }
    }
}