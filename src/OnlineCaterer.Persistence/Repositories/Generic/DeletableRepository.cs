﻿using OnlineCaterer.Application.Contracts.Repositories.Generic;

namespace OnlineCaterer.Persistence.Repositories.Generic
{
	public class DeletableRepository<TEntity>
		: IDeletableRepository<TEntity>
		where TEntity : class
	{
		private readonly OnlineCatererDbContext _dbContext;

		public DeletableRepository(OnlineCatererDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public Task Delete(TEntity entity)
		{
			if (entity == null)
			{
				throw new ArgumentNullException(nameof(entity));
			}
			_dbContext.Remove(entity);
			return Task.CompletedTask;
		}
	}
}
