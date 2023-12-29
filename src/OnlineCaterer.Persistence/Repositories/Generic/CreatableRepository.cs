using OnlineCaterer.Application.Contracts.Repositories.Generic;

namespace OnlineCaterer.Persistence.Repositories.Generic
{
	public class CreatableRepository<TEntity>
		: ICreatableRepository<TEntity>
		where TEntity : class
	{
		private readonly OnlineCatererDbContext _dbContext;

		public CreatableRepository(OnlineCatererDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task<TEntity> Add(TEntity entity)
		{
			if (entity == null)
			{
				throw new ArgumentNullException(nameof(entity));
			}
			var entry = await _dbContext.AddAsync(entity);
			return entry.Entity;
		}
	}
}
