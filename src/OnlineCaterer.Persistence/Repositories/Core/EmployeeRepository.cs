using OnlineCaterer.Application.Contracts.Repositories.Core;
using OnlineCaterer.Domain.Core;
using OnlineCaterer.Persistence.Repositories.Generic;

namespace OnlineCaterer.Persistence.Repositories.Core
{
	public class EmployeeRepository : FullActionRepository<Employee, int>, IEmployeeRepository
	{
		public EmployeeRepository(OnlineCatererDbContext dbContext) : base(dbContext)
		{
		}
	}
}
