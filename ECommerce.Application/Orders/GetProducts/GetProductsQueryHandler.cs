using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Dapper;
using ECommerce.Application.Configuration.Data;
using ECommerce.Application.Configuration.Queries;

namespace ECommerce.Application.Orders.GetProducts
{
    internal sealed class GetProductsQueryHandler : IQueryHandler<GetProductsQuery, List<ProductDto>>
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;

        internal GetProductsQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
        {
            this._sqlConnectionFactory = sqlConnectionFactory;
        }

        public async Task<List<ProductDto>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            var connection = this._sqlConnectionFactory.GetOpenConnection();
                const string sql = "SELECT " +
								   "[Product].[Id], " +
								   "[Product].[Name], " +
								   "[Product].[Price], " +
								   "[Product].[ImageUrl] " +
								   "FROM orders.Products AS [Product] ";
                var orders = await connection.QueryAsync<ProductDto>(sql);

                return orders.AsList();
        }
    }
}