using System.Linq.Expressions;

namespace OnlineCaterer.Application.Contracts.Repositories.Generic
{
	public interface IReadOnlyRepository<TEntity, TKey>
		where TEntity : class
		where TKey : IEquatable<TKey>
	{
		IQueryable<TEntity> GetQueryable();

		Task<TEntity?> Get(TKey key);
		Task<TEntity?> Get(Expression<Func<TEntity, bool>> predicate);
		Task<IReadOnlyCollection<TEntity>> GetAll();
		Task<IReadOnlyCollection<TEntity>> GetAll(
			Expression<Func<TEntity, bool>> predicate
		);

		public async Task<bool> Contains(TKey key)
		{
			TEntity? entity = await Get(key);
			return entity != null;
		}
	}
}
