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
					new GroupUser
					{
						GroupId = 2,
						UserId = 2,
					},
					new GroupUser
					{
						GroupId = 3,
						UserId = 3,
					},
					new GroupUser
					{
						GroupId = 3,
						UserId = 4,
					},
					new GroupUser
					{
						GroupId = 4,
						UserId = 5,
					},
					new GroupUser
					{
						GroupId = 4,
						UserId = 6,
					}
				}
			);
		}
	}
}
