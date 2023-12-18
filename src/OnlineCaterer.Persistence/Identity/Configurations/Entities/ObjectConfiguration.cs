using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineCaterer.Persistence.Extensions;

namespace OnlineCaterer.Persistence.Identity.Configurations.Entities
{
	public class ObjectConfiguration : IEntityTypeConfiguration<Domain.Identity.Object>
	{
		public void Configure(EntityTypeBuilder<Domain.Identity.Object> entity)
		{
			entity.HasKey(obj => obj.Id);

			entity.Property(obj => obj.Name)
				.HasColumnType("nvarchar")
				.HasMaxLength(100)
				.IsRequired(true);

			entity.ConfigureDescriptionProperty();

			entity.HasData(
				new Domain.Identity.Object
				{
					Id = 1,
					Name = "Object",
					Description = "",
				},
				new Domain.Identity.Object
				{
					Id = 2,
					Name = "Employee",
					Description = "",
				},
				new Domain.Identity.Object
				{
					Id = 3,
					Name = "Customer",
					Description = "",
				},
				new Domain.Identity.Object
				{
					Id = 4,
					Name = "Supplier",
					Description = "",
				},
				new Domain.Identity.Object
				{
					Id = 5,
					Name = "Food",
					Description = "",
				},
				new Domain.Identity.Object
				{
					Id = 6,
					Name = "FoodCategory",
					Description = "",
				}
			);
		}
	}
}
