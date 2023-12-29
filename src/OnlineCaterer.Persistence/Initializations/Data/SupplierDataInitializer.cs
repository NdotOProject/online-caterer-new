using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineCaterer.Domain.Core;

namespace OnlineCaterer.Persistence.Initializations.Data
{
	public static class SupplierDataInitializer
	{
		public static void Initialize(this EntityTypeBuilder<Supplier> entity)
		{
			entity.HasData(
				new[]
				{
					new Supplier
					{
						Id = 1,
						Name = "Aptech Food",
						Address = "19 Lê Thanh Nghị, Hai Bà Trưng, Hà Nội.",
						Introduction = @"With a long-standing brand, highly
							appreciated by famous chefs and customers around
							the world. We will provide the perfect service of
							a 5-star hotel at attractive prices.",
						RatingPoint = 5,
						Status = 1,
					},
					new Supplier
					{
						Id = 2,
						Name = "Lẩu Kiệt",
						Address = "Hà Nội, Việt Nam",
						Introduction = @"Lẩu Kiệt where to find the best
							dishes in Vietnam. Come to us, you will have the
							best experiences of your life.",
						RatingPoint = 0,
						Status = 1,
					}
				}
			);
		}
	}
}
