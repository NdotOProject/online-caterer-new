using OnlineCaterer.Application.Contracts.Repositories.Core;
using OnlineCaterer.Domain.Core;
using OnlineCaterer.Persistence.Repositories.Generic;

namespace OnlineCaterer.Persistence.Repositories.Core
{
    public class CustomerRepository : FullActionRepository<Customer, int>, ICustomerRepository
    {
        public CustomerRepository(OnlineCatererDbContext dbContext) : base(dbContext)
        {
        }
    }
}
