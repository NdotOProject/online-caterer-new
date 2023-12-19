using OnlineCaterer.Application.Contracts.Repositories.Generic;
using OnlineCaterer.Domain.Core;

namespace OnlineCaterer.Application.Contracts.Repositories.Core
{
    public interface IFoodRepository : IFullActionRepository<Food, int>
    {
        Task<IReadOnlyCollection<Food>> GetByCategoryId(int categoryId);
        Task<IReadOnlyCollection<Food>> GetByOrderId(int orderId);
    }
}
