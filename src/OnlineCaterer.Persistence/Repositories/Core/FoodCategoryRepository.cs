using OnlineCaterer.Application.Contracts.Repositories.Core;
using OnlineCaterer.Domain.Core;
using OnlineCaterer.Persistence.Repositories.Generic;

namespace OnlineCaterer.Persistence.Repositories.Core
{
	public class FoodCategoryRepository
		: FullActionRepository<FoodCategory, int>,
		IFoodCategoryRepository
	{
		public FoodCategoryRepository(
			OnlineCatererDbContext dbContext)
			: base(dbContext)
		{
		}
	}
}
