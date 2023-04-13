using System.Threading;
using System.Threading.Tasks;
using ECommerce.Domain.SeedWork;
using ECommerce.Infrastructure.Database;
using ECommerce.Infrastructure.Processing;

namespace ECommerce.Infrastructure.Domain
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private readonly IDomainEventsDispatcher _domainEventsDispatcher;

        public UnitOfWork(
            ApplicationDbContext context, 
            IDomainEventsDispatcher domainEventsDispatcher)
        {
            this._context = context;
            this._domainEventsDispatcher = domainEventsDispatcher;
        }

        public async Task<int> CommitAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            await this._domainEventsDispatcher.DispatchEventsAsync();
            return await this._context.SaveChangesAsync(cancellationToken);
        }
    }
}