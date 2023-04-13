using System.Net;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ECommerce.Application.Customers;
using ECommerce.Application.Customers.RegisterCustomer;
using ECommerce.Application.Customers.GetCustomerDetails;
using System;

namespace ECommerce.API.Customers
{
    [Route("api/customers")]
    [ApiController]
    public class CustomersController : Controller
    {
        private readonly IMediator _mediator;

        public CustomersController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        /// <summary>
        /// Register customer.
        /// </summary>
        [Route("")]
        [HttpPost]
        [ProducesResponseType(typeof(CustomerDto), (int)HttpStatusCode.Created)]
        public async Task<IActionResult> RegisterCustomer([FromBody]RegisterCustomerRequest request)
        {
           var customer = await _mediator.Send(new RegisterCustomerCommand(request.Email, request.Name));

           return Created(string.Empty, customer);
        }

		/// <summary>
		/// Get customer details.
		/// </summary>
		/// <param name="customerId">Order ID.</param>
		[Route("{customerId}")]
		[HttpGet]
		[ProducesResponseType(typeof(CustomerDetailsDto), (int)HttpStatusCode.OK)]
		public async Task<IActionResult> GetCustomerDetails(
			[FromRoute] Guid customerId)
		{
			var orderDetails = await _mediator.Send(new GetCustomerDetailsQuery(customerId));

			return Ok(orderDetails);
		}
	}
}
