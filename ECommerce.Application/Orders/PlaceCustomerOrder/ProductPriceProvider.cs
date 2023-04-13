using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using ECommerce.Domain.Products;

namespace ECommerce.Application.Orders.PlaceCustomerOrder
{
    public static class ProductPriceProvider
    {
        public static async Task<List<ProductPriceData>> GetAllProductPrices(IDbConnection connection)
        {
            var productPrices = await connection.QueryAsync<ProductPriceResponse>("SELECT " +
		   $"[Product].Id AS [{nameof(ProductPriceResponse.ProductId)}], " +
		   $"[Product].Price AS [{nameof(ProductPriceResponse.Price)}] " +
		   "FROM orders.Products AS [Product]");

            return productPrices.AsList()
                .Select(x => new ProductPriceData(
                    new ProductId(x.ProductId),
                    x.Price))
                .ToList();
        }

        private sealed class ProductPriceResponse
        {
            public Guid ProductId { get; set; }

            public decimal Price { get; set; }
        }
    }
}