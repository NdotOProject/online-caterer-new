namespace OnlineCaterer.Application.Contracts.Persistence.Generic
{
	public interface IFullActionRepository<TEntity, TKey> : IReadOnlyRepository<TEntity, TKey>,
			ICreatableRepository<TEntity>, IUpdatableRepository<TEntity>, IDeletableRepository<TEntity>
		where TEntity : class
		where TKey : IEquatable<TKey>
	{
	}
}
