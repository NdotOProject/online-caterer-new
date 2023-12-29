using OnlineCaterer.Application.Contracts.Repositories.Identity;
using OnlineCaterer.Persistence.Repositories.Generic;

namespace OnlineCaterer.Persistence.Repositories.Identity
{
	public class ActionRepository
		: ReadOnlyRepository<Domain.Identity.Action, int>,
		IActionRepository
	{
		public ActionRepository(
			OnlineCatererDbContext dbContext)
			: base(dbContext)
		{
		}
	}
}
