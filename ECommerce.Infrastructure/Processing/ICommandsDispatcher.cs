using System;
using System.Threading.Tasks;

namespace ECommerce.Infrastructure.Processing
{
    public interface ICommandsDispatcher
    {
        Task DispatchCommandAsync(Guid id);
    }
}
