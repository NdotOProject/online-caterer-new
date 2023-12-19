using OnlineCaterer.Application.Contracts.Repositories.Generic;
using OnlineCaterer.Domain.Core;

namespace OnlineCaterer.Application.Contracts.Repositories.Core
{
	public interface IOrderDetailRepository : ICreatableRepository<OrderDetail>,
		IUpdatableRepository<OrderDetail>, IDeletableRepository<OrderDetail>
	{
		Task AddRange(ICollection<OrderDetail> orderDetails);
		Task<IReadOnlyCollection<OrderDetail>> GetByOrderId(int orderId);
	}
}
