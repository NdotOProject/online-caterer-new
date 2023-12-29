using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineCaterer.Domain.Core;

namespace OnlineCaterer.Persistence.Initializations.Data
{
	public static class FoodImageDataInitializer
	{
		public static void Initialize(this EntityTypeBuilder<FoodImage> entity)
		{
			entity.HasData(
				new[]
				{
					new FoodImage
					{
						Id = 1,
						FoodId = 1,
						Name = "food_1_avatar.png",
						Avatar = true,
					},
					new FoodImage
					{
						Id = 2,
						FoodId = 1,
						Name = "food_1.png",
						Avatar = false,
					}
				}
			);
		}
	}
}
