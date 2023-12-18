using Microsoft.EntityFrameworkCore;
using OnlineCaterer.Application.Contracts.Persistence.Generic;
using OnlineCaterer.Application.Exceptions;
using System.Linq.Expressions;

namespace OnlineCaterer.Persistence.Generic
{
    public class ReadOnlyRepository<TEntity, TKey> : IReadOnlyRepository<TEntity, TKey>
        where TEntity : class
        where TKey : IEquatable<TKey>
    {

        private readonly DbSet<TEntity> _entity;

        public ReadOnlyRepository(OnlineCatererDbContext dbContext)
        {
            _entity = dbContext.Set<TEntity>();
        }

        public async Task<TEntity> Get(TKey key)
        {
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }

            TEntity? entity = await _entity.FindAsync(key);
            return entity ?? throw new NotFoundException();
        }

        public async Task<TEntity> Get(Expression<Func<TEntity, bool>> predicate)
        {
            if (predicate == null)
            {
                throw new ArgumentNullException(nameof(predicate));
            }

            IQueryable<TEntity> query = _entity
                .Where(predicate)
                .Take(1);

            return query.Any()
                ? await query.SingleAsync()
                : throw new NotFoundException();
        }

        public async Task<IReadOnlyCollection<TEntity>> GetAll()
        {
            return await _entity.ToListAsync();
        }

        public async Task<IReadOnlyCollection<TEntity>> GetAll(Expression<Func<TEntity, bool>> predicate)
        {
            if (predicate == null)
            {
                return await GetAll();
            }
            else
            {
                return await _entity
                    .Where(predicate)
                    .ToListAsync();
            }
        }
    }
}
