namespace OnlineCaterer.Application.Contracts.Persistence.Generic
{
	public interface IDeletableRepository<TEntity>
		where TEntity : class
	{
		void Delete(TEntity entity);
	}
}
