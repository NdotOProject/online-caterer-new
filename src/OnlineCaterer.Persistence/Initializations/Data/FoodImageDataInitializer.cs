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
						FoodId = 2,
						Name = "food_2_img.jpg",
						Avatar = true,
					},
					new FoodImage
					{
						Id = 3,
						FoodId = 3,
						Name = "PIZZA+SINGAPORE+CHILI+CRAB.jpg",
						Avatar = true,
					},
					new FoodImage
					{
						Id = 4,
						FoodId = 4,
						Name = "Menu+BG+1.jpg",
						Avatar = true,
					},
					new FoodImage
					{
						Id = 5,
						FoodId = 5,
						Name = "Wedding_Cake.jpg",
						Avatar = true,
					},
					new FoodImage
					{
						Id = 6,
						FoodId = 6,
						Name = "SPONGE_CAKE_CHOCOLATE_8P.jpg",
						Avatar = true,
					},
					new FoodImage
					{
						Id = 7,
						FoodId = 7,
						Name = "BAKED_CHEESECAKE_8-12P.jpg",
						Avatar = true,
					},
				}
			);
		}
	}
}
