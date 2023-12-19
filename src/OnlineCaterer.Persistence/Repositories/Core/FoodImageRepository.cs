using OnlineCaterer.Application.Contracts.Repositories.Core;
using OnlineCaterer.Domain.Core;
using OnlineCaterer.Persistence.Repositories.Generic;

namespace OnlineCaterer.Persistence.Repositories.Core
{
	public class FoodImageRepository : FullActionRepository<FoodImage, int>, IFoodImageRepository
	{
		private readonly OnlineCatererDbContext _dbContext;
		public FoodImageRepository(OnlineCatererDbContext dbContext) : base(dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task AddRange(ICollection<FoodImage> images)
		{
			await _dbContext.AddRangeAsync(images);
		}

		public async Task<IReadOnlyCollection<FoodImage>> GetByFoodId(int foodId)
		{
			return await GetAll(img => img.FoodId == foodId);
		}
	}
}
