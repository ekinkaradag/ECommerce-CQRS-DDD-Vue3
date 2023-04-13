using Microsoft.EntityFrameworkCore;
using ECommerce.Domain.Customers;
using ECommerce.Domain.Payments;
using ECommerce.Domain.Products;
using ECommerce.Infrastructure.Processing.InternalCommands;
using ECommerce.Infrastructure.Processing.Outbox;

namespace ECommerce.Infrastructure.Database
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<OutboxMessage> OutboxMessages { get; set; }

        public DbSet<InternalCommand> InternalCommands { get; set; }

        public DbSet<Payment> Payments { get; set; }

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }
    }
}
