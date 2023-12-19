using OnlineCaterer.Application.Models.Identity;
using OnlineCaterer.Domain.Identity;

namespace OnlineCaterer.Application.Contracts.Identity.Services
{
	public interface IUserService
	{
		Task<User> GetCurrentUser();

		Task<UserTypes> GetTypeOfCurrentUser();

		public async Task<bool> UserHasPermission(Permission permission)
		{
			User user = await GetCurrentUser();
			return user.Permissions.Where(p =>
				p.Object == permission.Object && p.Action == permission.Action
			).Any();
		}
	}
}
