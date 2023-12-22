using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineCaterer.Domain.Core;
using OnlineCaterer.Persistence.Extensions;
using OnlineCaterer.Persistence.Initializations.Data;

namespace OnlineCaterer.Persistence.Configurations.Entities.Core
{
	public class FoodConfiguration
		: IEntityTypeConfiguration<Food>
	{
		public void Configure(EntityTypeBuilder<Food> entity)
		{
			entity.Initialize();

			entity.IdAutoIncrement();

			entity.ConfigureAuditableProperties();

			entity.ConfigureDescriptionProperty();

			entity.HasOne(food => food.Supplier)
				.WithMany(supplier => supplier.Foods)
				.HasForeignKey(food => food.SupplierId)
				.IsRequired(true);

			entity.HasOne(food => food.Category)
				.WithMany(foodCategory => foodCategory.Foods)
				.HasForeignKey(food => food.CategoryId)
				.IsRequired(true);

			entity.HasOne(food => food.Event)
				.WithMany(ev => ev.Foods)
				.HasForeignKey(food => food.EventId)
				.IsRequired(true);

			entity.Property(food => food.Name)
				.HasColumnType("nvarchar")
				.HasMaxLength(100)
				.IsRequired(true);

			entity.Property(food => food.UnitPrice)
				.HasColumnType("money")
				.IsRequired(true);

			entity.Property(food => food.RatingPoint)
				.IsRequired(true);

			entity.Property(food => food.Discontinued)
				.HasDefaultValue(false)
				.IsRequired(true);

			entity.Property(food => food.CurrentQuantity)
				.IsRequired(true);
		}
	}
}
