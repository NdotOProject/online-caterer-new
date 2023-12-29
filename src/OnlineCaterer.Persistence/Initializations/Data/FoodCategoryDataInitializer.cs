using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineCaterer.Domain.Core;

namespace OnlineCaterer.Persistence.Initializations.Data
{
	public static class FoodCategoryDataInitializer
	{
		public static void Initialize(
			this EntityTypeBuilder<FoodCategory> entity)
		{
			entity.HasData(
				new[]
				{
					new FoodCategory
					{
						Id = 1,
						Name = "Chicken",
						Description = "",
					},
					new FoodCategory
					{
						Id = 2,
						Name = "Pizza",
						Description = "",
					},
					new FoodCategory
					{
						Id = 3,
						Name = "Cake",
						Description = "",
					},
					new FoodCategory
					{
						Id = 4,
						Name = "Fruit",
						Description = "",
					},
					new FoodCategory
					{
						Id = 5,
						Name = "Hamburger",
						Description = ""
					},
					new FoodCategory
					{
						Id = 6,
						Name = "Banh My",
						Description = ""
					},
					new FoodCategory
					{
						Id = 7,
						Name = "Pho",
						Description = ""
					},
				}
			);
		}
	}
}
