using OnlineCaterer.Application.Contracts.Persistence.Generic;
using OnlineCaterer.Application.Models.Identity;
using OnlineCaterer.Domain.Identity;

namespace OnlineCaterer.Application.Contracts.Persistence.Identity
{
	public interface IUserRepository : IFullActionRepository<User, int>
	{
		IReadOnlyCollection<Permission> GetPermissions(int userId);
	}
}
