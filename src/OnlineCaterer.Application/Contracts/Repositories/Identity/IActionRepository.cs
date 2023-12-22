using OnlineCaterer.Application.Contracts.Repositories.Generic;

namespace OnlineCaterer.Application.Contracts.Repositories.Identity
{
	public interface IActionRepository
		: IReadOnlyRepository<Domain.Identity.Action, int>
	{
	}
}
