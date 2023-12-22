using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineCaterer.Domain.Identity.Relationship;

namespace OnlineCaterer.Persistence.Initializations.Data.Identity
{
	public static class GroupUserDataInitializer
	{
		public static void Initialize(this EntityTypeBuilder<GroupUser> entity)
		{
			entity.HasData(
				new[]
				{
					new GroupUser
					{
						GroupId = 1,
						UserId = 1,
					},
				}
			);
		}
	}
}
