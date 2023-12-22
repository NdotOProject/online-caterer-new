using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineCaterer.Domain.Core;

namespace OnlineCaterer.Persistence.Initializations.Data
{
	public static class FeedbackDataInitializer
	{
		public static void Initialize(this EntityTypeBuilder<Feedback> entity)
		{
			entity.HasData(
				new[]
				{
					new Feedback
					{
						Id = 1,
						CustomerId = 1,
						FoodId = 1,
						Content = "",
						RatingPoint = 5,
					},
				}
			); ;
		}
	}
}
