using System.Threading.Tasks;
using MediatR;
using ECommerce.Application.Configuration.Commands;

namespace ECommerce.Application.Configuration.Processing
{
    public interface ICommandsScheduler
    {
        Task EnqueueAsync<T>(ICommand<T> command);
    }
}