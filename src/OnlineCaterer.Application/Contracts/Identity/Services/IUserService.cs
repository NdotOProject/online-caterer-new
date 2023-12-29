using OnlineCaterer.Application.Exceptions;
using OnlineCaterer.Application.Models.Identity.Conventions;
using OnlineCaterer.Application.Models.Identity.Helper;
using OnlineCaterer.Domain.Identity;

namespace OnlineCaterer.Application.Contracts.Identity.Services
{
    public interface IUserService
	{
		Task<User> GetCurrentUser();

		Task<UserTypes> GetTypeOfCurrentUser();

		int GetUserTypeId(UserTypes userType);

		Task<bool> UserHasPermission(Permission permission);
	}
}
