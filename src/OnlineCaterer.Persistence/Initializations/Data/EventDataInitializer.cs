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
						Name = "All",
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
					new Event
					{
						Id = 4,
						Name = "Christmas",
						Description = "",
					},
					new Event
					{
						Id = 5,
						Name = "New Year",
						Description = "",
					},
					new Event
					{
						Id = 6,
						Name = "Inauguration",
						Description = "",
					},
					new Event
					{
						Id = 7,
						Name = "Ceremony",
						Description = "",
					},
					new Event
					{
						Id = 8,
						Name = "Graduation",
						Description = "",
					},
				}
			);
		}
	}
}
