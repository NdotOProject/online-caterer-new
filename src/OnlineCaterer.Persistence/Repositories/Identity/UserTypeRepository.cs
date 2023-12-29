using OnlineCaterer.Application.Contracts.Repositories.Identity;
using OnlineCaterer.Application.Models.Identity.Conventions;
using OnlineCaterer.Domain.Identity;
using OnlineCaterer.Persistence.Repositories.Generic;

namespace OnlineCaterer.Persistence.Repositories.Identity
{
	public class UserTypeRepository
		: ReadOnlyRepository<UserType, int>,
		IUserTypeRepository
	{
		public UserTypeRepository(
			OnlineCatererDbContext dbContext)
			: base(dbContext)
		{
		}

		public Task<UserTypes> AsEnum(int userTypeId)
		{
			return Task.FromResult(
				userTypeId switch
				{
					1 => UserTypes.Employee,
					2 => UserTypes.Customer,
					3 => UserTypes.Supplier,
					_ => throw new NotSupportedException(),
				}
			);
		}
	}
}
