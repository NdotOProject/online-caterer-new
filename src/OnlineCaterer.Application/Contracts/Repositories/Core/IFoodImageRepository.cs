using OnlineCaterer.Application.Contracts.Repositories.Generic;
using OnlineCaterer.Domain.Core;

namespace OnlineCaterer.Application.Contracts.Repositories.Core
{
    public interface IFoodImageRepository : IFullActionRepository<FoodImage, int>
    {
        Task<IReadOnlyCollection<FoodImage>> GetByFoodId(int foodId);
        Task AddRange(ICollection<FoodImage> images);
    }
}
