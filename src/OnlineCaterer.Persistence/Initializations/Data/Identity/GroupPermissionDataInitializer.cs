using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineCaterer.Domain.Identity.Relationship;

namespace OnlineCaterer.Persistence.Initializations.Data.Identity
{
	public static class GroupPermissionDataInitializer
	{
		public static void Initialize(this EntityTypeBuilder<GroupPermission> entity)
		{
			entity.HasData(
				new[]
				{
					new GroupPermission
					{
						GroupId = 1,
						ActionId = 2,
						ObjectId = 4,
					},
					new GroupPermission
					{
						GroupId = 1,
						ActionId = 2,
						ObjectId = 5,
					},
					new GroupPermission
					{
						GroupId = 1,
						ActionId = 2,
						ObjectId = 6,
					},
					new GroupPermission
					{
						GroupId = 1,
						ActionId = 2,
						ObjectId = 9,
					},
					new GroupPermission
					{
						GroupId = 1,
						ActionId = 2,
						ObjectId = 10,
					},
					new GroupPermission
					{
						GroupId = 1,
						ActionId = 2,
						ObjectId = 11,
					},
					new GroupPermission
					{
						GroupId = 2,
						ActionId = 2,
						ObjectId = 4,
					},
					new GroupPermission
					{
						GroupId = 2,
						ActionId = 2,
						ObjectId = 5,
					},
					new GroupPermission
					{
						GroupId = 2,
						ActionId = 2,
						ObjectId = 6,
					},
					new GroupPermission
					{
						GroupId = 2,
						ActionId = 2,
						ObjectId = 7,
					},
					new GroupPermission
					{
						GroupId = 2,
						ActionId = 2,
						ObjectId = 8,
					},
					new GroupPermission
					{
						GroupId = 2,
						ActionId = 2,
						ObjectId = 9,
					},
					new GroupPermission
					{
						GroupId = 2,
						ActionId = 2,
						ObjectId = 12,
					},
				}
			);
		}
	}
}
