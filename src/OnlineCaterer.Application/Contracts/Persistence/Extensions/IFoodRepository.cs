using OnlineCaterer.Application.Contracts.Persistence.Generic;
using OnlineCaterer.Domain.Core;

namespace OnlineCaterer.Application.Contracts.Persistence.Extensions
{
	public interface IFoodRepository : IFullActionRepository<Food, int>
	{
		Task<IReadOnlyCollection<Food>> GetByCategoryId(int categoryId);
		Task<IReadOnlyCollection<Food>> GetByOrderId(int orderId);
	}
}
