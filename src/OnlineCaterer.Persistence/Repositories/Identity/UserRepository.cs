using Microsoft.EntityFrameworkCore;
using OnlineCaterer.Application.Contracts.Repositories.Identity;
using OnlineCaterer.Application.Exceptions;
using OnlineCaterer.Application.Models.Identity.Helper;
using OnlineCaterer.Domain.Identity;
using OnlineCaterer.Domain.Identity.Relationship;
using OnlineCaterer.Persistence.Repositories.Generic;
using System.Linq.Expressions;

namespace OnlineCaterer.Persistence.Repositories.Identity
{
    public class UserRepository
		: FullActionRepository<User, int>, IUserRepository
	{
		private readonly OnlineCatererDbContext _dbContext;

		private readonly IGroupRepository _groupRepository;

		public UserRepository(
			OnlineCatererDbContext dbContext,
			IGroupRepository groupRepository)
			: base(dbContext)
		{
			_dbContext = dbContext;
			_groupRepository = groupRepository;
		}

		public new async Task<User> Add(User entity)
		{
			var user = await base.Add(entity);

			var groups = await _groupRepository
				.GetByUserType(user.UserTypeId);

			var groupUsers = new List<GroupUser>();

			foreach (var group in groups)
			{
				groupUsers.Add(new GroupUser
				{
					UserId = user.Id,
					User = user,
					GroupId = group.Id,
					Group = group,
				});
			}

			await _dbContext.AddRangeAsync(groupUsers);

			user.Groups = groupUsers;

			return user;
		}

		public async Task<bool> ExistsByEmail(string email)
		{
			try
			{
				await Get(user => user.Email == email);
				return true;
			}
			catch (NotFoundException)
			{
				return false;
			}
		}

		public new async Task<User> Get(int key)
		{
			return await Get(u => u.Id == key);
		}

		public new async Task<User> Get(
			Expression<Func<User, bool>> predicate)
		{
			if (predicate == null)
			{
				throw new ArgumentNullException(nameof(predicate));
			}

			var query = _dbContext.Users
				.Include(u => u.Permissions)
				.Include(u => u.Groups)
				.Where(predicate)
				.Take(1);

			return query.Any()
				? await query.SingleAsync()
				: throw new NotFoundException();
		}

		public async Task<IReadOnlyCollection<Permission>>
			GetPermissions(int userId)
		{
			User user = await Get(userId);

			HashSet<Permission> permissions = new();
			foreach (var permission in user.Permissions)
			{
				permissions.Add(
					Permission.From(
						permission.Object, permission.Action
					)
				);
			}

			foreach (var groupId in user.Groups
				.Select(g => g.GroupId))
			{
				var groupPermissions = await _groupRepository
					.GetPermissions(groupId);
				permissions.UnionWith(groupPermissions);
			}

			return permissions;
		}
	}
}
