using OnlineCaterer.Application.Contracts.Persistence.Generic;

namespace OnlineCaterer.Application.Contracts.Persistence.Identity
{
	public interface IActionRepository : IReadOnlyRepository<Domain.Identity.Action, int>
	{
	}
}
