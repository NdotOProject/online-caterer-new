using OnlineCaterer.Application.Contracts.Persistence.Generic;
using OnlineCaterer.Domain.Identity;

namespace OnlineCaterer.Application.Contracts.Persistence.Identity
{
	public interface IGroupRepository : IFullActionRepository<Group, int>
	{
	}
}
