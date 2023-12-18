using OnlineCaterer.Application.Contracts.Persistence.Extensions;
using OnlineCaterer.Domain.Core;
using OnlineCaterer.Persistence.Generic;

namespace OnlineCaterer.Persistence.Core.Repositories
{
    public class FoodCategoryRepository : FullActionRepository<FoodCategory, int>, IFoodCategoryRepository
    {
        public FoodCategoryRepository(OnlineCatererDbContext dbContext) : base(dbContext)
        {
        }
    }
}
