using OnlineCaterer.Application.Contracts.Repositories.Identity;
using OnlineCaterer.Application.Models.Identity;
using OnlineCaterer.Domain.Identity;
using OnlineCaterer.Persistence.Repositories.Generic;

namespace OnlineCaterer.Persistence.Repositories.Identity
{
	public class GroupRepository : FullActionRepository<Group, int>, IGroupRepository
	{
		public GroupRepository(OnlineCatererDbContext dbContext) : base(dbContext)
		{
		}

		public async Task<IReadOnlyCollection<Permission>> GetPermissions(int groupId)
		{
			Group group = await Get(groupId);
			HashSet<Permission> permissions = new();
			foreach (var permission in group.Permissions)
			{
				permissions.Add(Permission.From(permission.Object, permission.Action));
			}
			return permissions;
		}
	}
}
