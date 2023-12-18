using OnlineCaterer.Application.Contracts.Persistence.Generic;
using OnlineCaterer.Domain.Core;

namespace OnlineCaterer.Application.Contracts.Persistence.Extensions
{
	public interface IOrderRepository : IReadOnlyRepository<Order, int>, ICreatableRepository<Order>
	{
		Task<IReadOnlyCollection<Order>> GetByUserId(int userId);
	}
}
