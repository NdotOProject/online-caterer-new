﻿using OnlineCaterer.Application.Contracts.Persistence.Generic;

namespace OnlineCaterer.Persistence.Generic
{
    public class DeletableRepository<TEntity> : IDeletableRepository<TEntity>
        where TEntity : class
    {
        private readonly OnlineCatererDbContext _dbContext;

        public DeletableRepository(OnlineCatererDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Delete(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            _dbContext.Set<TEntity>().Remove(entity);
        }
    }
}
