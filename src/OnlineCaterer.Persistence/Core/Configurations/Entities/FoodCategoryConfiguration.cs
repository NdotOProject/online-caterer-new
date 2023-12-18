using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineCaterer.Domain.Core;
using OnlineCaterer.Persistence.Extensions;

namespace OnlineCaterer.Persistence.Core.Configurations.Entities
{
    public class FoodCategoryConfiguration : IEntityTypeConfiguration<FoodCategory>
    {
        public void Configure(EntityTypeBuilder<FoodCategory> entity)
        {
            entity.IdAutoIncrement();

            entity.ConfigureAuditableProperties();

            entity.ConfigureDescriptionProperty();

            entity.Property(foodCategory => foodCategory.Name)
                .HasColumnType("nvarchar")
                .HasMaxLength(100)
                .IsRequired(true);
        }
    }
}
