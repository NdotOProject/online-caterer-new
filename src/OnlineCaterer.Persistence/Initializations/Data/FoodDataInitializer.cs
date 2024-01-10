using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineCaterer.Domain.Core;

namespace OnlineCaterer.Persistence.Initializations.Data
{
	public static class FoodDataInitializer
	{
		public static void Initialize(this EntityTypeBuilder<Food> entity)
		{
			entity.HasData(
				new[]
				{
					new Food
					{
						Id = 1,
						CategoryId = 1,
						EventId = 1,
						SupplierId = 1,
						Name = "Fried Chicken",
						Description = "",
						UnitPrice = 499000,
						RatingPoint = 5,
						Discontinued = false,
						CurrentQuantity = 5,
					},
					new Food
					{
						Id = 2,
						CategoryId = 1,
						EventId = 1,
						SupplierId = 1,
						Name = "Boiled Chicken",
						Description = "Boiled chicken is a simple," +
							" attractive, light and healthy dish.",
						UnitPrice = 299000,
						RatingPoint = 0,
						Discontinued = false,
						CurrentQuantity = 5,
					},
					new Food
					{
						Id = 3,
						CategoryId = 2,
						EventId = 1,
						SupplierId = 2,
						Name = "Singapore Chili Crab",
						Description = "Crab Meat, Tailed Shrimp," +
							" Singapore Chilli Sauce, Mayonnaise Sauce," +
							" Mozzarella Cheese, Tomato, Onion",
						UnitPrice = 215000,
						RatingPoint = 0,
						Discontinued = false,
						CurrentQuantity = 5,
					},
					new Food
					{
						Id = 4,
						CategoryId = 2,
						EventId = 1,
						SupplierId = 2,
						Name = "New York CheeseSteak",
						Description = "Beefsteak, Demi-Glace Sauce" +
							" (Steak Sauce), Sour Cream Sauce," +
							" Mozzarella Cheese, Mushrooms, Tomatoes," +
							" Onions, Seaweed Powder.",
						UnitPrice = 250000,
						RatingPoint = 0,
						Discontinued = false,
						CurrentQuantity = 5,
					},
					new Food
					{
						Id = 5,
						CategoryId = 3,
						EventId = 3,
						SupplierId = 2,
						Name = "Wedding Cake",
						Description = @"We love nothing more than designing
							an original cake for your special day with your
							personal style and theme in mind. There are many
							variables when it comes to setting a price for a
							wedding cake – the complexity of design, the number
							of servings, among other things.
							Because each cake features a custom design to meet
							the needs of each of our clients, there is no set
							price on custom cakes and are individually quoted
							and tailored based upon your cake come true. Please
							contact us for any inquiries for a more accurate quote.",
						UnitPrice = 599000,
						RatingPoint = 0,
						Discontinued = false,
						CurrentQuantity = 5,
					},
					new Food
					{
						Id = 6,
						CategoryId = 3,
						EventId = 2,
						SupplierId = 1,
						Name = "SPONGE CAKE CHOCOLATE 8P",
						Description = @"This chocolate sponge cake has a deep
							chocolate infused sponge that is sandwiches
							together with a thick chocolate frosting that melts
							in the mouth. Decorated with cute macarons and
							black star-shaped chocolate, the cake absolutely
							please your taste buds.",
						UnitPrice = 480000,
						RatingPoint = 0,
						Discontinued = false,
						CurrentQuantity = 5,
					},
					new Food
					{
						Id = 7,
						CategoryId = 3,
						EventId = 2,
						SupplierId = 1,
						Name = "BAKED CHEESECAKE 8-12P",
						Description = @"A signature recipe, our Baked Cheeesecake,
							having a smooth creamy texture, stands tall on a
							coconut flakes base, with a pinch of cinnamon
							flavor. This rich cheesecake is topped with our
							homemade biscuit crust that is toasted to glory!",
						UnitPrice = 660000,
						RatingPoint = 0,
						Discontinued = false,
						CurrentQuantity = 5,
					},
				}
			);
		}
	}
}
