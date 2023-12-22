namespace OnlineCaterer.Application.Contracts.Repositories.Generic
{
	public interface IDeletableRepository<TEntity>
		where TEntity : class
	{
		void Delete(TEntity entity);
	}
}
