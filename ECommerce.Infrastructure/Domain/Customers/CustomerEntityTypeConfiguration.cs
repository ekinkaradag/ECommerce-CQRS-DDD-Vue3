using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ECommerce.Domain.Customers;
using ECommerce.Domain.Customers.Orders;
using ECommerce.Domain.Products;
using ECommerce.Domain.SharedKernel;
using ECommerce.Infrastructure.Database;

namespace ECommerce.Infrastructure.Domain.Customers
{
    internal sealed class CustomerEntityTypeConfiguration : IEntityTypeConfiguration<Customer>
    {
        internal const string OrdersList = "_orders";
        internal const string OrderProducts = "_orderProducts";

        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customers", SchemaNames.Orders);
            
            builder.HasKey(b => b.Id);

            builder.Property("_welcomeEmailWasSent").HasColumnName("WelcomeEmailWasSent");
            builder.Property("_email").HasColumnName("Email");
            builder.Property("_name").HasColumnName("Name");
            
            builder.OwnsMany<Order>(OrdersList, x =>
            {
                x.WithOwner().HasForeignKey("CustomerId");

                x.ToTable("Orders", SchemaNames.Orders);
                
                x.Property<bool>("_isRemoved").HasColumnName("IsRemoved");
				x.Property<decimal>("_price").HasColumnType("decimal(18,2)").HasColumnName("Price");
				x.Property<DateTime>("_orderDate").HasColumnName("OrderDate");
                x.Property<DateTime?>("_orderChangeDate").HasColumnName("OrderChangeDate");
                x.Property<OrderId>("Id");
                x.HasKey("Id");

                x.Property("_status").HasColumnName("StatusId").HasConversion(new EnumToNumberConverter<OrderStatus, byte>());

                x.OwnsMany<OrderProduct>(OrderProducts, y =>
                {
                    y.WithOwner().HasForeignKey("OrderId");

                    y.ToTable("OrderProducts", SchemaNames.Orders);
                    y.Property<OrderId>("OrderId");
                    y.Property<ProductId>("ProductId");
                    
                    y.HasKey("OrderId", "ProductId");
                });
            });
        }
    }
}