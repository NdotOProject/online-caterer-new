using OnlineCaterer.Application.Contracts.Persistence;
using OnlineCaterer.Application.Contracts.Repositories.Core;
using OnlineCaterer.Domain.Core;
using OnlineCaterer.Persistence.Repositories.Generic;

namespace OnlineCaterer.Persistence.Repositories.Core
{
	public class FoodRepository : FullActionRepository<Food, int>, IFoodRepository
	{
		private readonly IOrderDetailRepository _orderDetailRepository;

		public FoodRepository(
			OnlineCatererDbContext dbContext,
			IOrderDetailRepository orderDetailRepository) : base(dbContext)
		{
			_orderDetailRepository = orderDetailRepository;
		}

		public async Task<IReadOnlyCollection<Food>> GetByCategoryId(int categoryId)
		{
			return await GetAll(food => food.CategoryId == categoryId);
		}

		public async Task<IReadOnlyCollection<Food>> GetByOrderId(int orderId)
		{
			var orderDetails = await _orderDetailRepository.GetByOrderId(orderId);
			return orderDetails.Select(od => od.Food).ToList();
		}
	}
}
