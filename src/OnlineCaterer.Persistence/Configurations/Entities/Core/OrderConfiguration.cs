using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineCaterer.Domain.Core;
using OnlineCaterer.Persistence.Extensions;

namespace OnlineCaterer.Persistence.Configurations.Entities.Core
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> entity)
        {
            entity.IdAutoIncrement();

            entity.HasOne(order => order.Customer)
                .WithMany(customer => customer.Orders)
                .HasForeignKey(order => order.CustomerId)
                .IsRequired(true);

            entity.HasOne(order => order.Employee)
                .WithMany(employee => employee.Orders)
                .HasForeignKey(order => order.EmployeeId)
                .IsRequired(true);

            entity.HasOne(order => order.Supplier)
                .WithMany(supplier => supplier.Orders)
                .HasForeignKey(order => order.SupplierId)
                .IsRequired(true);

            entity.HasOne(order => order.PaymentMethod)
                .WithMany(pm => pm.Orders)
                .HasForeignKey(order => order.PaymentMethodId)
                .IsRequired(true);

            entity.Property(order => order.PaymentInformation)
                .HasColumnType("nvarchar(max)")
                .HasDefaultValue("{}")
                .IsRequired(true);

            entity.Property(order => order.ReceivedDate)
                .HasColumnType("datetime2")
                .IsRequired(true);

            entity.Property(order => order.DeliveryAddress)
                .HasColumnType("nvarchar")
                .HasMaxLength(255)
                .IsRequired(true);

            entity.Property(order => order.TotalAmount)
                .HasColumnType("money")
                .IsRequired(true);

            entity.Property(order => order.Status)
                .IsRequired(true);
        }
    }
}
