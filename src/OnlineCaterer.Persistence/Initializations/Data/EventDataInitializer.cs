using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineCaterer.Domain.Core;

namespace OnlineCaterer.Persistence.Initializations.Data
{
	public static class EventDataInitializer
	{
		public static void Initialize(this EntityTypeBuilder<Event> entity)
		{
			entity.HasData(
				new[]
				{
					new Event
					{
						Id = 1,
						Name = "Any",
						Description = "",
					},
					new Event
					{
						Id = 2,
						Name = "Birthday",
						Description = "",
					},
					new Event
					{
						Id = 3,
						Name = "Wedding",
						Description = "",
					},
				}
			);
		}
	}
}
