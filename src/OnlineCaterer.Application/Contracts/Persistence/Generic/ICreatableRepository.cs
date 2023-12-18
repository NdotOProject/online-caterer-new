namespace OnlineCaterer.Application.Contracts.Persistence.Generic
{
	public interface ICreatableRepository<TEntity>
		where TEntity : class
	{
		Task<TEntity> Add(TEntity entity);
	}
}
