using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ECommerce.Domain.Products;
using ECommerce.Infrastructure.Database;

namespace ECommerce.Infrastructure.Domain.Products
{
    internal sealed class ProductEntityTypeConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products", SchemaNames.Orders);
            
            builder.HasKey(b => b.Id);
        }
    }
}