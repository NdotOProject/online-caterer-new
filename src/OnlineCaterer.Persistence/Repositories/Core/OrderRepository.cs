using OnlineCaterer.Application.Contracts.Repositories.Core;
using OnlineCaterer.Application.Contracts.Repositories.Generic;
using OnlineCaterer.Application.Models.Identity;
using OnlineCaterer.Domain.Core;
using OnlineCaterer.Persistence.Repositories.Generic;

namespace OnlineCaterer.Persistence.Repositories.Core
{
	public class OrderRepository : ReadOnlyRepository<Order, int>, IOrderRepository
	{
		private readonly ICreatableRepository<Order> _creatableRepository;

		public OrderRepository(
			OnlineCatererDbContext dbContext,
			ICreatableRepository<Order> creatableRepository
		) : base(dbContext)
		{
			_creatableRepository = creatableRepository;
		}

		public async Task<Order> Add(Order entity)
		{
			return await _creatableRepository.Add(entity);
		}

		public async Task<IReadOnlyCollection<Order>> GetByUserId(UserTypes userType, int userId)
		{
			return userType switch
			{
				UserTypes.Employee => await GetAll(o => o.EmployeeId == userId),
				UserTypes.Customer => await GetAll(o => o.CustomerId == userId),
				UserTypes.Supplierr => await GetAll(o => o.SupplierId == userId),
				_ => new List<Order>()
			};
		}
	}
}
