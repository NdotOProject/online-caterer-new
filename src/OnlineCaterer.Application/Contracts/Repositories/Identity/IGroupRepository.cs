using OnlineCaterer.Application.Contracts.Repositories.Generic;
using OnlineCaterer.Application.Models.Identity;
using OnlineCaterer.Domain.Identity;

namespace OnlineCaterer.Application.Contracts.Repositories.Identity
{
	public interface IGroupRepository : IFullActionRepository<Group, int>
	{
		Task<IReadOnlyCollection<Permission>> GetPermissions(int groupId);
	}
}
