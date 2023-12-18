namespace OnlineCaterer.Application.Contracts.Persistence.Generic
{
	public interface IUpdatableRepository<TEntity>
		where TEntity : class
	{
		void Update(TEntity entity);
	}
}
