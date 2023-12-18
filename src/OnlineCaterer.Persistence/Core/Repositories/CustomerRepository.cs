using OnlineCaterer.Application.Contracts.Persistence.Extensions;
using OnlineCaterer.Domain.Core;
using OnlineCaterer.Persistence.Generic;

namespace OnlineCaterer.Persistence.Core.Repositories
{
    public class CustomerRepository : FullActionRepository<Customer, int>, ICustomerRepository
    {
        public CustomerRepository(OnlineCatererDbContext dbContext) : base(dbContext)
        {
        }
    }
}
