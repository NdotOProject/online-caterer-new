using Microsoft.EntityFrameworkCore;
using OnlineCaterer.Application.Contracts.Repositories.Core;
using OnlineCaterer.Application.Contracts.Repositories.Generic;
using OnlineCaterer.Application.Exceptions;
using OnlineCaterer.Application.Models.Identity.Conventions;
using OnlineCaterer.Domain.Core;
using OnlineCaterer.Persistence.Repositories.Generic;
using System.Linq.Expressions;

namespace OnlineCaterer.Persistence.Repositories.Core
{
	public class OrderRepository
		: ReadOnlyRepository<Order, int>,
		IOrderRepository
	{
		private readonly OnlineCatererDbContext _dbContext;
		private readonly ICreatableRepository<Order> _creatableRepository;

		public OrderRepository(
			OnlineCatererDbContext dbContext,
			ICreatableRepository<Order> creatableRepository)
			: base(dbContext)
		{
			_dbContext = dbContext;
			_creatableRepository = creatableRepository;
		}

		public async Task<Order> Add(Order entity)
		{
			return await _creatableRepository.Add(entity);
		}

		public new async Task<Order> Get(int key)
		{
			return await Get(o => o.Id == key);
		}

		public new async Task<Order> Get(
			Expression<Func<Order, bool>> predicate)
		{
			if (predicate == null)
			{
				throw new ArgumentNullException(nameof(predicate));
			}

			var query = _dbContext.Orders
				.Include(o => o.Customer)
				.Include(o => o.Employee)
				.Include(o => o.OrderDetails)
				.Include(o => o.PaymentMethod)
				.Include(o => o.Supplier)
				.Where(predicate)
				.Take(1);

			return query.Any()
				? await query.SingleAsync()
				: throw new NotFoundException();
		}

		public new async Task<IReadOnlyCollection<Order>> GetAll()
		{
			return await _dbContext.Orders
				.Include(o => o.Customer)
				.Include(o => o.Employee)
				.Include(o => o.OrderDetails)
				.Include(o => o.PaymentMethod)
				.Include(o => o.Supplier)
				.ToListAsync();
		}

		public new async Task<IReadOnlyCollection<Order>> GetAll(
			Expression<Func<Order, bool>> predicate)
		{
			if (predicate == null)
			{
				return await GetAll();
			}
			else
			{
				return await _dbContext.Orders
					.Include(o => o.Customer)
					.Include(o => o.Employee)
					.Include(o => o.OrderDetails)
					.Include(o => o.PaymentMethod)
					.Include(o => o.Supplier)
					.Where(predicate)
					.ToListAsync();
			}
		}

		public async Task<IReadOnlyCollection<Order>> GetByUserId(
			UserTypes userType, int userId)
		{
			return userType switch
			{
				UserTypes.Employee =>
					await GetAll(o => o.EmployeeId == userId),
				UserTypes.Customer =>
					await GetAll(o => o.CustomerId == userId),
				UserTypes.Supplier =>
					await GetAll(o => o.SupplierId == userId),
				_ => new List<Order>()
			};
		}
	}
}
