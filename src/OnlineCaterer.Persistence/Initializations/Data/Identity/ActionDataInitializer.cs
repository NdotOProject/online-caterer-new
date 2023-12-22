using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OnlineCaterer.Persistence.Initializations.Data.Identity
{
	public static class ActionDataInitializer
	{
		public static void Initialize(
			this EntityTypeBuilder<Domain.Identity.Action> entity)
		{
			entity.HasData(
				new[]
				{
					new Domain.Identity.Action
					{
						Id = 1,
						Name = "Create",
					},
					new Domain.Identity.Action
					{
						Id = 2,
						Name = "Read",
					},
					new Domain.Identity.Action
					{
						Id = 3,
						Name = "Update",
					},
					new Domain.Identity.Action
					{
						Id = 4,
						Name = "Delete",
					},
				}
			);
		}
	}
}
