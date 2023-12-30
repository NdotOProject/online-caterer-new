namespace OnlineCaterer.Application.Contracts.Repositories.Generic
{
	public interface IDeletableRepository<TEntity>
		where TEntity : class
	{
		Task Delete(TEntity entity);
	}
}
