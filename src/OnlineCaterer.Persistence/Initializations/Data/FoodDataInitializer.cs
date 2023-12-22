﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
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
						UnitPrice = 49999,
						RatingPoint = 100,
						Discontinued = false,
						CurrentQuantity = 69,
					},
				}
			);
		}
	}
}
