using OnlineCaterer.Application.Contracts.Persistence.Identity;
using OnlineCaterer.Application.Models.Identity;
using OnlineCaterer.Domain.Identity;
using OnlineCaterer.Persistence.Generic;

namespace OnlineCaterer.Persistence.Identity.Repositories
{
	public class UserRepository : FullActionRepository<User, int>, IUserRepository
	{
		public UserRepository(OnlineCatererDbContext dbContext) : base(dbContext)
		{
		}

		public IReadOnlyCollection<Permission> GetPermissions(int userId)
		{
			throw new NotImplementedException();
		}
	}
}
