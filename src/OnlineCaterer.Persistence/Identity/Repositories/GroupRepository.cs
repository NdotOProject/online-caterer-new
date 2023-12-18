using OnlineCaterer.Application.Contracts.Persistence.Identity;
using OnlineCaterer.Domain.Identity;
using OnlineCaterer.Persistence.Generic;

namespace OnlineCaterer.Persistence.Identity.Repositories
{
	public class GroupRepository : FullActionRepository<Group, int>, IGroupRepository
	{
		public GroupRepository(OnlineCatererDbContext dbContext) : base(dbContext)
		{
		}
	}
}
