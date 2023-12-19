using OnlineCaterer.Application.Contracts.Repositories.Generic;
using System.Linq.Expressions;

namespace OnlineCaterer.Persistence.Repositories.Generic
{
    public class FullActionRepository<TEntity, TKey> : IFullActionRepository<TEntity, TKey>
        where TEntity : class
        where TKey : IEquatable<TKey>
    {
        private readonly ICreatableRepository<TEntity> _creatableRepository;
        private readonly IDeletableRepository<TEntity> _deletableRepository;
        private readonly IReadOnlyRepository<TEntity, TKey> _readOnlyRepository;
        private readonly IUpdatableRepository<TEntity> _updatableRepository;

        public FullActionRepository(OnlineCatererDbContext dbContext)
        {
            _creatableRepository = new CreatableRepository<TEntity>(dbContext);
            _deletableRepository = new DeletableRepository<TEntity>(dbContext);
            _readOnlyRepository = new ReadOnlyRepository<TEntity, TKey>(dbContext);
            _updatableRepository = new UpdatableRepository<TEntity>(dbContext);
        }

        public async Task<TEntity> Add(TEntity entity)
        {
            return await _creatableRepository.Add(entity);
        }

        public async Task<bool> Contains(TKey key)
        {
            return await _readOnlyRepository.Contains(key);
        }

        public void Delete(TEntity entity)
        {
            _deletableRepository.Delete(entity);
        }

        public async Task<TEntity> Get(TKey key)
        {
            return await _readOnlyRepository.Get(key);
        }

        public async Task<TEntity> Get(Expression<Func<TEntity, bool>> predicate)
        {
            return await _readOnlyRepository.Get(predicate);
        }

        public async Task<IReadOnlyCollection<TEntity>> GetAll()
        {
            return await _readOnlyRepository.GetAll();
        }

        public async Task<IReadOnlyCollection<TEntity>> GetAll(Expression<Func<TEntity, bool>> predicate)
        {
            return await _readOnlyRepository.GetAll(predicate);
        }

        public void Update(TEntity entity)
        {
            _updatableRepository.Update(entity);
        }
    }
}
