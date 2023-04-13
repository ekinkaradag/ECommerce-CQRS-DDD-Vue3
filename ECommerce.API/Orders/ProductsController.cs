using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ECommerce.Application.Orders.GetProducts;
using ECommerce.Application.Orders.PlaceCustomerOrder;
using System;
using ECommerce.Application.Orders.AddNewProduct;
using ECommerce.Application.Customers;
using ECommerce.Application.Orders;

namespace ECommerce.API.Orders
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : Controller
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            this._mediator = mediator;
        }

		/// <summary>
		/// Get products.
		/// </summary>
		/// <returns>List of customer orders.</returns>
		[Route("")]
        [HttpGet]
        [ProducesResponseType(typeof(List<OrderDto>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetCustomerOrders()
        {
            var orders = await _mediator.Send(new GetProductsQuery());

            return Ok(orders);
        }

		/// <summary>
		/// Add product.
		/// </summary>
		/// <param name="request">Product details.</param>
		[Route("")]
		[HttpPost]
		[ProducesResponseType((int)HttpStatusCode.Created)]
		public async Task<IActionResult> AddNewProduct(
			[FromBody] ProductRequest request)
		{
			await _mediator.Send(
				new AddNewProductCommand(
					request.Price,
					request.Name,
					request.ImageUrl));

			return Created(string.Empty, null);
		}
	}
}
