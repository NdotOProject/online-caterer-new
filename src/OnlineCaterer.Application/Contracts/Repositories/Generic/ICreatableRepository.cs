namespace OnlineCaterer.Application.Contracts.Repositories.Generic
{
	public interface ICreatableRepository<TEntity>
		where TEntity : class
	{
		Task<TEntity> Add(TEntity entity);
	}
}
