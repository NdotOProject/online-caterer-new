using OnlineCaterer.Application.Contracts.Repositories.Generic;
using OnlineCaterer.Application.Models.Identity.Helper;
using OnlineCaterer.Domain.Identity;

namespace OnlineCaterer.Application.Contracts.Repositories.Identity
{
	public interface IGroupRepository
		: IFullActionRepository<Group, int>
	{
		Task<IReadOnlyCollection<Permission>> GetPermissions(int groupId);
		Task<ICollection<Group>> GetByUserType(int userTypeId);
	}
}
