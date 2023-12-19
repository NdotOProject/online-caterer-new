using OnlineCaterer.Application.Contracts.Repositories.Identity;
using OnlineCaterer.Application.Models.Identity;
using OnlineCaterer.Domain.Identity;
using OnlineCaterer.Persistence.Repositories.Generic;

namespace OnlineCaterer.Persistence.Repositories.Identity
{
	public class UserRepository : FullActionRepository<User, int>, IUserRepository
	{
		private readonly IGroupRepository _groupRepository;
		public UserRepository(
			OnlineCatererDbContext dbContext,
			IGroupRepository groupRepository) : base(dbContext)
		{
			_groupRepository = groupRepository;
		}

		public async Task<IReadOnlyCollection<Permission>> GetPermissions(int userId)
		{
			User user = await Get(userId);

			HashSet<Permission> permissions = new();
			foreach (var permission in user.Permissions)
			{
				permissions.Add(Permission.From(permission.Object, permission.Action));
			}

			foreach (var groupId in user.Groups.Select(g => g.GroupId))
			{
				var groupPermissions = await _groupRepository.GetPermissions(groupId);
				permissions.UnionWith(groupPermissions);
			}

			return permissions;
		}
	}
}
