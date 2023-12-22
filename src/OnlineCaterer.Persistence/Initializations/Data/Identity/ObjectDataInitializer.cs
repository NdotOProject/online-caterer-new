using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineCaterer.Domain.Core;
using OnlineCaterer.Domain.Identity;

namespace OnlineCaterer.Persistence.Initializations.Data.Identity
{
	public static class ObjectDataInitializer
	{
		public static void Initialize(
			this EntityTypeBuilder<Domain.Identity.Object> entity)
		{
			entity.HasData(
				new[]
				{
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
					},
				}
			);
		}
	}
}
