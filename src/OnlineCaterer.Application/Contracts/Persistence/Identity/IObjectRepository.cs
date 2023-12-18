using OnlineCaterer.Application.Contracts.Persistence.Generic;

namespace OnlineCaterer.Application.Contracts.Persistence.Identity
{
	public interface IObjectRepository : IReadOnlyRepository<Domain.Identity.Object, int>
	{
	}
}
