using Microsoft.EntityFrameworkCore;
using OnlineCaterer.Application.Contracts.Repositories.Generic;

namespace OnlineCaterer.Persistence.Repositories.Generic
{
    public class UpdatableRepository<TEntity> : IUpdatableRepository<TEntity>
        where TEntity : class
    {
        private readonly OnlineCatererDbContext _dbContext;

        public UpdatableRepository(OnlineCatererDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Update(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            _dbContext.Entry(entity).State = EntityState.Modified;
        }
    }
}
