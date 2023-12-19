using OnlineCaterer.Application.Contracts.Repositories.Core;
using OnlineCaterer.Domain.Core;
using OnlineCaterer.Persistence.Repositories.Generic;

namespace OnlineCaterer.Persistence.Repositories.Core
{
    public class FoodRepository : FullActionRepository<Food, int>, IFoodRepository
    {
        public FoodRepository(OnlineCatererDbContext dbContext) : base(dbContext)
        {
        }

        public Task<IReadOnlyCollection<Food>> GetByCategoryId(int categoryId)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyCollection<Food>> GetByOrderId(int orderId)
        {
            throw new NotImplementedException();
        }
    }
}
