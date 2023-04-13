using System.Threading;
using System.Threading.Tasks;
using Dapper;
using MediatR;
using ECommerce.Application.Configuration.Data;
using ECommerce.Application.Configuration.Queries;

namespace ECommerce.Application.Orders.GetCustomerOrderDetails
{
    internal sealed class GetCustomerOrderDetailsQueryHandler : IQueryHandler<GetCustomerOrderDetailsQuery, OrderDetailsDto>
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;

        internal GetCustomerOrderDetailsQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
        {
            this._sqlConnectionFactory = sqlConnectionFactory;
        }

        public async Task<OrderDetailsDto> Handle(GetCustomerOrderDetailsQuery request, CancellationToken cancellationToken)
        {
            var connection = this._sqlConnectionFactory.GetOpenConnection();

            const string sql = "SELECT " +
                               "[Order].[Id], " +
                               "[Order].[IsRemoved], " +
							   "[Order].[Price], " +
							   "[Order].[OrderDate], " +
							   "[Order].[OrderChangeDate] " +
							   "FROM orders.v_Orders AS [Order] " +
                               "WHERE [Order].Id = @OrderId";
            var order = await connection.QuerySingleOrDefaultAsync<OrderDetailsDto>(sql, new { request.OrderId });

            const string sqlProducts = "SELECT " +
							   "[OrderProduct].[ProductId] AS [Id], " +
							   "[OrderProduct].[Quantity], " +
							   "[OrderProduct].[Name], " +
							   "[OrderProduct].[Price], " +
                               "[OrderProduct].[ImageUrl] " +
                               "FROM orders.v_OrderProducts AS [OrderProduct] " +
							   "WHERE [OrderProduct].OrderId = @OrderId";
            var products = await connection.QueryAsync<ProductDto>(sqlProducts, new { request.OrderId });

            order.Products = products.AsList();

            return order;
        }
    }
}