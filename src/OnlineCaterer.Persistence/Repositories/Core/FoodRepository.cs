using Microsoft.EntityFrameworkCore;
using OnlineCaterer.Application.Contracts.Repositories.Core;
using OnlineCaterer.Application.Exceptions;
using OnlineCaterer.Domain.Core;
using OnlineCaterer.Persistence.Repositories.Generic;
using System.Linq.Expressions;

namespace OnlineCaterer.Persistence.Repositories.Core
{
	public class FoodRepository
		: FullActionRepository<Food, int>,
		IFoodRepository
	{
		private readonly OnlineCatererDbContext _dbContext;
		private readonly IOrderDetailRepository _orderDetailRepository;

		public FoodRepository(
			OnlineCatererDbContext dbContext,
			IOrderDetailRepository orderDetailRepository)
			: base(dbContext)
		{
			_dbContext = dbContext;
			_orderDetailRepository = orderDetailRepository;
		}

		public new async Task<Food> Get(int key)
		{
			return await Get(f => f.Id == key);
		}

		public new async Task<Food> Get(
			Expression<Func<Food, bool>> predicate)
		{
			if (predicate == null)
			{
				throw new ArgumentNullException(nameof(predicate));
			}

			IQueryable<Food> query = _dbContext.Foods
				.Where(predicate)
				.Include(f => f.Feedbacks)
				.Include(f => f.Images)
				.Take(1);

			return query.Any()
				? await query.SingleAsync()
				: throw new NotFoundException();
		}

		public new async Task<IReadOnlyCollection<Food>> GetAll()
		{
			return await _dbContext.Foods
				.Include(food => food.Images)
				.ToListAsync();
		}

		public new async Task<IReadOnlyCollection<Food>> GetAll(
			Expression<Func<Food, bool>> predicate)
		{
			if (predicate == null)
			{
				return await GetAll();
			}
			else
			{
				return await _dbContext.Foods
					.Where(predicate)
					.Include(food => food.Images)
					.ToListAsync();
			}
		}

		public async Task<IReadOnlyCollection<Food>>
			GetByCategoryId(int categoryId)
		{
			return await GetAll(food => food.CategoryId == categoryId);
		}

		public async Task<IReadOnlyCollection<Food>>
			GetByOrderId(int orderId)
		{
			var orderDetails = await _orderDetailRepository
				.GetByOrderId(orderId);
			return orderDetails
				.Select(od => od.Food)
				.ToList();
		}
	}
}
