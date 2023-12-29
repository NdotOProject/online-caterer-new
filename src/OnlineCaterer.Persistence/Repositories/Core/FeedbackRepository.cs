using OnlineCaterer.Application.Contracts.Repositories.Core;
using OnlineCaterer.Domain.Core;
using OnlineCaterer.Persistence.Repositories.Generic;

namespace OnlineCaterer.Persistence.Repositories.Core
{
	public class FeedbackRepository
		: FullActionRepository<Feedback, int>,
		IFeedbackRepository
	{
		public FeedbackRepository(
			OnlineCatererDbContext dbContext)
			: base(dbContext)
		{
		}
	}
}
