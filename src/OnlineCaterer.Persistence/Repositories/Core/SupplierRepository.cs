using OnlineCaterer.Application.Contracts.Repositories.Core;
using OnlineCaterer.Domain.Core;
using OnlineCaterer.Persistence.Repositories.Generic;

namespace OnlineCaterer.Persistence.Repositories.Core
{
	public class SupplierRepository : FullActionRepository<Supplier, int>, ISupplierRepository
	{
		public SupplierRepository(OnlineCatererDbContext dbContext) : base(dbContext)
		{
		}
	}
}
