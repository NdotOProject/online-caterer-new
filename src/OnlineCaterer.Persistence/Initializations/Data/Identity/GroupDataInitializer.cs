using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineCaterer.Domain.Identity;

namespace OnlineCaterer.Persistence.Initializations.Data.Identity
{
	public static class GroupDataInitializer
	{
		public static void Initialize(this EntityTypeBuilder<Group> entity)
		{
			entity.HasData(
				new[]
				{
					new Group
					{
						Id = 1,
						Name = "System Manager",
						Description = "",
					},
					new Group
					{
						Id = 2,
						Name = "Delivery Person",
						Description = "",
					},
					new Group
					{
						Id = 3,
						Name = "Supplier",
						Description = "",
					},
					new Group
					{
						Id = 4,
						Name = "Customer",
						Description = "",
					},
					new Group
					{
						Id = 5,
						Name = "Features Updater",
						Description = "",
					},
				}
			);
		}
	}
}
