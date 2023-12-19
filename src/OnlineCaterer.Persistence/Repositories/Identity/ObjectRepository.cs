using OnlineCaterer.Application.Contracts.Repositories.Identity;
using OnlineCaterer.Persistence.Repositories.Generic;

namespace OnlineCaterer.Persistence.Repositories.Identity
{
    public class ObjectRepository : ReadOnlyRepository<Domain.Identity.Object, int>, IObjectRepository
    {
        public ObjectRepository(OnlineCatererDbContext dbContext) : base(dbContext)
        {
        }
    }
}
