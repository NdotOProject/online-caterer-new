using System.Linq.Expressions;

namespace OnlineCaterer.Application.Contracts.Repositories.Generic
{
	public interface IReadOnlyRepository<TEntity, TKey>
		where TEntity : class
		where TKey : IEquatable<TKey>
	{
		Task<TEntity> Get(TKey key);
		Task<TEntity> Get(Expression<Func<TEntity, bool>> predicate);
		Task<IReadOnlyCollection<TEntity>> GetAll();
		Task<IReadOnlyCollection<TEntity>> GetAll(
			Expression<Func<TEntity, bool>> predicate
		);
		Task<bool> Contains(TKey key);
	}
}
