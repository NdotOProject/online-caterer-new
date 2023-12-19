using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineCaterer.Domain.Core;
using OnlineCaterer.Domain.Identity;
using OnlineCaterer.Persistence.Extensions;

namespace OnlineCaterer.Persistence.Configurations.Entities.Identity
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
					Name = nameof(Customer),
					Description = "",
				},
				new Domain.Identity.Object
				{
					Id = 2,
					Name = nameof(Employee),
					Description = "",
				},
				new Domain.Identity.Object
				{
					Id = 3,
					Name = nameof(Supplier),
					Description = "",
				},
				new Domain.Identity.Object
				{
					Id = 4,
					Name = nameof(Food),
					Description = "",
				},
				new Domain.Identity.Object
				{
					Id = 5,
					Name = nameof(FoodCategory),
					Description = "",
				},
				new Domain.Identity.Object
				{
					Id = 6,
					Name = nameof(FoodImage),
					Description = "",
				},
				new Domain.Identity.Object
				{
					Id = 7,
					Name = nameof(Order),
					Description = "",
				},
				new Domain.Identity.Object
				{
					Id = 8,
					Name = nameof(OrderDetail),
					Description = "",
				},
				new Domain.Identity.Object
				{
					Id = 9,
					Name = nameof(Feedback),
					Description = "",
				},
				new Domain.Identity.Object
				{
					Id = 10,
					Name = nameof(PaymentMethod),
					Description = "",
				},
				new Domain.Identity.Object
				{
					Id = 11,
					Name = nameof(Event),
					Description = "",
				},
				new Domain.Identity.Object
				{
					Id = 12,
					Name = nameof(User),
					Description = "",
				},
				new Domain.Identity.Object
				{
					Id = 13,
					Name = nameof(Group),
					Description = "",
				}
			);
		}
	}
}
