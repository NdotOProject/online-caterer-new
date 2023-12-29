using OnlineCaterer.Application.Contracts.Repositories.Core;
using OnlineCaterer.Domain.Core;
using OnlineCaterer.Persistence.Repositories.Generic;

namespace OnlineCaterer.Persistence.Repositories.Core
{
	public class EventRepository
		: FullActionRepository<Event, int>,
		IEventRepository
	{
		public EventRepository(
			OnlineCatererDbContext dbContext)
			: base(dbContext)
		{
		}
	}
}
