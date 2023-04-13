using System;
using System.Reflection;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ECommerce.Application.Configuration.Processing;
using ECommerce.Application.Customers;
using ECommerce.Infrastructure.Database;

namespace ECommerce.Infrastructure.Processing.InternalCommands
{
    public class CommandsDispatcher : ICommandsDispatcher
    {
        private readonly IMediator _mediator;
        private readonly ApplicationDbContext _context;

        public CommandsDispatcher(
            IMediator mediator, 
            ApplicationDbContext context)
        {
            this._mediator = mediator;
            this._context = context;
        }

        public async Task DispatchCommandAsync(Guid id)
        {
            var internalCommand = await this._context.InternalCommands.SingleOrDefaultAsync(x => x.Id == id);

            Type type = Assembly.GetAssembly(typeof(MarkCustomerAsWelcomedCommand)).GetType(internalCommand.Type);
            dynamic command = JsonConvert.DeserializeObject(internalCommand.Data, type);

            internalCommand.ProcessedDate = DateTime.UtcNow;

            await this._mediator.Send(command);
        }
    }
}