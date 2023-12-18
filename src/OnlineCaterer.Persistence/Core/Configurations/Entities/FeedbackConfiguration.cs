using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineCaterer.Domain.Core;
using OnlineCaterer.Persistence.Extensions;

namespace OnlineCaterer.Persistence.Core.Configurations.Entities
{
    public class FeedbackConfiguration : IEntityTypeConfiguration<Feedback>
    {
        public void Configure(EntityTypeBuilder<Feedback> entity)
        {
            entity.IdAutoIncrement();

            entity.HasOne(fb => fb.Customer)
                .WithMany(cus => cus.Feedbacks)
                .HasForeignKey(fb => fb.CustomerId)
                .IsRequired(true);

            entity.HasOne(fb => fb.Food)
                .WithMany(food => food.Feedbacks)
                .HasForeignKey(fb => fb.FoodId)
                .IsRequired(true);

            entity.Property(fb => fb.Content)
                .HasColumnType("nvarchar(max)")
                .IsRequired(true);

            entity.Property(fb => fb.RatingPoint)
                .IsRequired(true);
        }
    }
}
