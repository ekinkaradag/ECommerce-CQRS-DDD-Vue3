using MediatR;
using ECommerce.Application;
using ECommerce.Application.Configuration.Commands;

namespace ECommerce.Infrastructure.Processing.Outbox
{
    public class ProcessOutboxCommand : CommandBase<Unit>, IRecurringCommand
    {

    }
}