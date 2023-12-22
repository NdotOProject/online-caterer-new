using OnlineCaterer.Application.Contracts.Repositories.Generic;
using OnlineCaterer.Application.Models.Identity.Helper;
using OnlineCaterer.Domain.Identity;

namespace OnlineCaterer.Application.Contracts.Repositories.Identity
{
	public interface IUserRepository
		: IFullActionRepository<User, int>
	{
		Task<IReadOnlyCollection<Permission>> GetPermissions(int userId);

		Task<bool> ExistsByEmail(string email);
	}
}
