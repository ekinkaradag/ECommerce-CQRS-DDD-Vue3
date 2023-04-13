using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ECommerce.Application.Configuration.Commands;
using ECommerce.Application.Configuration.Data;
using ECommerce.Application.Customers;
using ECommerce.Domain.Customers;
using ECommerce.Domain.Customers.Orders;
using ECommerce.Domain.Products;

namespace ECommerce.Application.Orders.AddNewProduct
{
    public class AddNewProductCommandHandler : ICommandHandler<AddNewProductCommand, Guid>
    {
        private readonly IProductRepository _productRepository;
        
        private readonly ISqlConnectionFactory _sqlConnectionFactory;

        public AddNewProductCommandHandler(
			IProductRepository productRepository,
            ISqlConnectionFactory sqlConnectionFactory)
        {
            this._productRepository = productRepository;
            _sqlConnectionFactory = sqlConnectionFactory;
        }

        public async Task<Guid> Handle(AddNewProductCommand command, CancellationToken cancellationToken)
		{
			var product = Product.AddNew(
                command.Name,
                command.Price,
                command.ImageUrl);

			await this._productRepository.AddAsync(product);

			return product.Id.Value;
        }
    }
}