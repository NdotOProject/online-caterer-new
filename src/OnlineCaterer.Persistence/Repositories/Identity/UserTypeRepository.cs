using OnlineCaterer.Application.Contracts.Repositories.Identity;
using OnlineCaterer.Domain.Identity;
using OnlineCaterer.Persistence.Repositories.Generic;

namespace OnlineCaterer.Persistence.Repositories.Identity
{
	public class UserTypeRepository : ReadOnlyRepository<UserType, int>, IUserTypeRepository
	{
		public UserTypeRepository(OnlineCatererDbContext dbContext) : base(dbContext)
		{
		}
	}
}
