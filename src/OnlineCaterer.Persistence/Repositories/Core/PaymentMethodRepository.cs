using OnlineCaterer.Application.Contracts.Repositories.Core;
using OnlineCaterer.Domain.Core;
using OnlineCaterer.Persistence.Repositories.Generic;

namespace OnlineCaterer.Persistence.Repositories.Core
{
	public class PaymentMethodRepository
		: FullActionRepository<PaymentMethod, int>,
		IPaymentMethodRepository
	{
		public PaymentMethodRepository(
			OnlineCatererDbContext dbContext)
			: base(dbContext)
		{
		}
	}
}
