using Microsoft.EntityFrameworkCore;
using OnlineCaterer.Application.Contracts.Repositories.Identity;
using OnlineCaterer.Application.Models.Identity.Helper;
using OnlineCaterer.Domain.Identity;
using OnlineCaterer.Persistence.Repositories.Generic;

namespace OnlineCaterer.Persistence.Repositories.Identity
{
	public class GroupRepository
		: FullActionRepository<Group, int>,
		IGroupRepository
	{
		private readonly OnlineCatererDbContext _dbContext;

		public GroupRepository(
			OnlineCatererDbContext dbContext)
			: base(dbContext)
		{
			_dbContext = dbContext;
		}

		public new async Task<Group> Get(int key)
		{
			return await _dbContext.Groups
				.Include(g => g.Permissions)
				.Where(g => g.Id == key)
				.FirstAsync();
		}

		public async Task<ICollection<Group>> GetByUserType(int userTypeId)
		{
			return await _dbContext.GroupUsers
				.Include(gu => gu.Group)
				.Where(gu => gu.User.UserTypeId == userTypeId)
				.Select(gu => gu.Group)
				.ToListAsync();
		}

		public async Task<IReadOnlyCollection<Permission>>
			GetPermissions(int groupId)
		{
			Group group = await Get(groupId);
			HashSet<Permission> permissions = new();
			foreach (var permission in group.Permissions)
			{
				permissions.Add(
					Permission.From(
						permission.Object,
						permission.Action
					)
				);
			}
			return permissions;
		}
	}
}
