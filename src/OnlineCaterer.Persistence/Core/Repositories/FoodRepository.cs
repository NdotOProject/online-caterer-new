using OnlineCaterer.Application.Contracts.Persistence.Extensions;
using OnlineCaterer.Domain.Core;
using OnlineCaterer.Persistence.Generic;

namespace OnlineCaterer.Persistence.Core.Repositories
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
