using MediatR;
using ECommerce.Application;
using ECommerce.Application.Configuration.Commands;
using ECommerce.Infrastructure.Processing.Outbox;

namespace ECommerce.Infrastructure.Processing.InternalCommands
{
    internal class ProcessInternalCommandsCommand : CommandBase<Unit>, IRecurringCommand
    {

    }
}