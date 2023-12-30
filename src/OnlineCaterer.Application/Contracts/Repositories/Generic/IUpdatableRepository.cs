namespace OnlineCaterer.Application.Contracts.Repositories.Generic
{
	public interface IUpdatableRepository<TEntity>
		where TEntity : class
	{
		Task Update(TEntity entity);
	}
}
