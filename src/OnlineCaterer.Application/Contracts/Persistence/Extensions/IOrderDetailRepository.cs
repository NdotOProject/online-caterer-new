using OnlineCaterer.Application.Contracts.Persistence.Generic;
using OnlineCaterer.Domain.Core;

namespace OnlineCaterer.Application.Contracts.Persistence.Extensions
{
	public interface IOrderDetailRepository : ICreatableRepository<OrderDetail>,
		IUpdatableRepository<OrderDetail>, IDeletableRepository<OrderDetail>
	{
		Task<IReadOnlyCollection<OrderDetail>> GetByOrderId(int orderId);
	}
}
