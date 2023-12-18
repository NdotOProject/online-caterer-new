using OnlineCaterer.Application.Contracts.Persistence.Identity;
using OnlineCaterer.Persistence.Generic;

namespace OnlineCaterer.Persistence.Identity.Repositories
{
	public class ActionRepository : ReadOnlyRepository<Domain.Identity.Action, int>, IActionRepository
	{
		public ActionRepository(OnlineCatererDbContext dbContext) : base(dbContext)
		{
		}
	}
}
