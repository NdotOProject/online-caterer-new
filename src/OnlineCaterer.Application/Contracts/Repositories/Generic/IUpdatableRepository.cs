namespace OnlineCaterer.Application.Contracts.Repositories.Generic
{
	public interface IUpdatableRepository<TEntity>
		where TEntity : class
	{
		void Update(TEntity entity);
	}
}
