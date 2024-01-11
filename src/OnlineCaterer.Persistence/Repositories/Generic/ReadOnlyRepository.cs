using Microsoft.EntityFrameworkCore;
using OnlineCaterer.Application.Contracts.Repositories.Generic;
using System.Linq.Expressions;

namespace OnlineCaterer.Persistence.Repositories.Generic
{
	public class ReadOnlyRepository<TEntity, TKey>
		: IReadOnlyRepository<TEntity, TKey>
		where TEntity : class
		where TKey : IEquatable<TKey>
	{

		private readonly DbSet<TEntity> _entity;

		public ReadOnlyRepository(
			OnlineCatererDbContext dbContext)
		{
			_entity = dbContext.Set<TEntity>();
		}

		public async Task<TEntity?> Get(TKey key)
		{
			if (key == null)
			{
				throw new ArgumentNullException(nameof(key));
			}

			TEntity? entity = await _entity.FindAsync(key);
			return entity;
		}

		public async Task<TEntity?> Get(
			Expression<Func<TEntity, bool>> predicate)
		{
			if (predicate == null)
			{
				throw new ArgumentNullException(nameof(predicate));
			}

			IQueryable<TEntity> query = GetQueryable()
				.Where(predicate)
				.Take(1);

			return query.Any()
				? await query.SingleAsync()
				: null;
		}

		public async Task<IReadOnlyCollection<TEntity>> GetAll()
		{
			return await GetQueryable().ToListAsync();
		}

		public async Task<IReadOnlyCollection<TEntity>> GetAll(
			Expression<Func<TEntity, bool>> predicate)
		{
			if (predicate == null)
			{
				return await GetAll();
			}
			else
			{
				return await GetQueryable()
					.Where(predicate)
					.ToListAsync();
			}
		}

		public IQueryable<TEntity> GetQueryable()
		{
			return _entity.AsNoTracking();
		}
	}
}
