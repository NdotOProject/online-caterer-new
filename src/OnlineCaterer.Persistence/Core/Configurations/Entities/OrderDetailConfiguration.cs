using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineCaterer.Domain.Core;

namespace OnlineCaterer.Persistence.Core.Configurations.Entities
{
    public class OrderDetailConfiguration : IEntityTypeConfiguration<OrderDetail>
    {
        public void Configure(EntityTypeBuilder<OrderDetail> entity)
        {
            entity.HasKey(nameof(OrderDetail.OrderId), nameof(OrderDetail.FoodId));

            entity.HasOne(orderDetail => orderDetail.Order)
                .WithMany(order => order.OrderDetails)
                .HasForeignKey(orderDetail => orderDetail.OrderId)
                .IsRequired(true);

            entity.HasOne(orderDetail => orderDetail.Food)
                .WithMany(food => food.OrderDetails)
                .HasForeignKey(orderDetail => orderDetail.FoodId)
                .IsRequired(true);

            entity.Property(orderDetail => orderDetail.Quantity)
                .HasDefaultValue(1)
                .IsRequired(true);

            entity.Property(orderDetail => orderDetail.UnitPrice)
                .HasColumnType("money")
                .IsRequired(true);

            entity.Property(orderDetail => orderDetail.Discount)
                .HasColumnType("real")
                .HasDefaultValue(0)
                .IsRequired(true);
        }
    }
}
