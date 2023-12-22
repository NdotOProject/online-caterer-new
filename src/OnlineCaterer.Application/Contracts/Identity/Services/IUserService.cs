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

		public async Task<bool> UserHasPermission(Permission permission)
		{
			try
			{
				User user = await GetCurrentUser();
				return user.Permissions.Where(p =>
					p.Object == permission.Object
					&& p.Action == permission.Action
				).Any();
			}
			catch
			{
				throw new UnauthorizedException();
			}
		}
	}
}
