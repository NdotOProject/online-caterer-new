using OnlineCaterer.Application.Contracts.Repositories.Generic;
using OnlineCaterer.Application.Models.Identity;
using OnlineCaterer.Domain.Core;

namespace OnlineCaterer.Application.Contracts.Repositories.Core
{
	public interface IOrderRepository : IReadOnlyRepository<Order, int>, ICreatableRepository<Order>
	{
		Task<IReadOnlyCollection<Order>> GetByUserId(UserTypes userType, int userId);
	}
}
