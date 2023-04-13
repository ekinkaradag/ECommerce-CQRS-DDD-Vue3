using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ECommerce.Domain.Products;
using ECommerce.Infrastructure.Database;
using ECommerce.Infrastructure.SeedWork;

namespace ECommerce.Infrastructure.Domain.Products
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;
        public ProductRepository(ApplicationDbContext context)
        {
            this._context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<List<Product>> GetByIdsAsync(List<ProductId> ids)
        {
            return await this._context
                .Products
                .IncludePaths("_prices")
                .Where(x => ids.Contains(x.Id)).ToListAsync();
        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await this._context
                .Products
                .IncludePaths("_prices")
                .ToListAsync();
        }

		public async Task AddAsync(Product product)
		{
			await this._context.Products.AddAsync(product);
		}
	}
}