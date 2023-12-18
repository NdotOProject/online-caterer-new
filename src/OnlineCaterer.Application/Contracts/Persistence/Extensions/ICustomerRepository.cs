using OnlineCaterer.Application.Contracts.Persistence.Generic;
using OnlineCaterer.Domain.Core;

namespace OnlineCaterer.Application.Contracts.Persistence.Extensions
{
	public interface ICustomerRepository : IFullActionRepository<Customer, int>
	{
	}
}
