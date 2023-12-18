using OnlineCaterer.Application.Contracts.Persistence.Identity;
using OnlineCaterer.Persistence.Generic;

namespace OnlineCaterer.Persistence.Identity.Repositories
{
	public class ObjectRepository : ReadOnlyRepository<Domain.Identity.Object, int>, IObjectRepository
	{
		public ObjectRepository(OnlineCatererDbContext dbContext) : base(dbContext)
		{
		}
	}
}
