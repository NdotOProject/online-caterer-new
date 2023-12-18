using OnlineCaterer.Application.Contracts.Persistence.Generic;
using OnlineCaterer.Domain.Core;

namespace OnlineCaterer.Application.Contracts.Persistence.Extensions
{
	public interface IFoodImageRepository : IFullActionRepository<FoodImage, int>
	{
		Task<IReadOnlyCollection<FoodImage>> GetByFoodId(int foodId);
		Task AddRange(ICollection<FoodImage> images);
	}
}
