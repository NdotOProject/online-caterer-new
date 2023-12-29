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
					#region group id 1
					new GroupPermission
					{
						GroupId = 1,
						ActionId = 2,
						ObjectId = 1,
					},
					new GroupPermission
					{
						GroupId = 1,
						ActionId = 2,
						ObjectId = 2,
					},
					new GroupPermission
					{
						GroupId = 1,
						ActionId = 2,
						ObjectId = 3,
					},
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
						GroupId = 1,
						ActionId = 2,
						ObjectId = 12,
					},
					new GroupPermission
					{
						GroupId = 1,
						ActionId = 3,
						ObjectId = 12,
					},
					new GroupPermission
					{
						GroupId = 1,
						ActionId = 2,
						ObjectId = 13,
					},
					#endregion

					#region group id 2
					new GroupPermission
					{
						GroupId = 2,
						ActionId = 2,
						ObjectId = 1,
					},
					new GroupPermission
					{
						GroupId = 2,
						ActionId = 2,
						ObjectId = 2,
					},
					new GroupPermission
					{
						GroupId = 2,
						ActionId = 2,
						ObjectId = 3,
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
						ActionId = 3,
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
						ObjectId = 10,
					},
					new GroupPermission
					{
						GroupId = 2,
						ActionId = 2,
						ObjectId = 11,
					},
					new GroupPermission
					{
						GroupId = 2,
						ActionId = 2,
						ObjectId = 12,
					},
					new GroupPermission
					{
						GroupId = 2,
						ActionId = 3,
						ObjectId = 12,
					},
					#endregion

					#region group id 3
					new GroupPermission
					{
						GroupId = 3,
						ActionId = 2,
						ObjectId = 1,
					},
					new GroupPermission
					{
						GroupId = 3,
						ActionId = 2,
						ObjectId = 2,
					},
					new GroupPermission
					{
						GroupId = 3,
						ActionId = 2,
						ObjectId = 3,
					},
					new GroupPermission
					{
						GroupId = 3,
						ActionId = 3,
						ObjectId = 3,
					},
					new GroupPermission
					{
						GroupId = 3,
						ActionId = 1,
						ObjectId = 4,
					},
					new GroupPermission
					{
						GroupId = 3,
						ActionId = 2,
						ObjectId = 4,
					},
					new GroupPermission
					{
						GroupId = 3,
						ActionId = 3,
						ObjectId = 4,
					},
					new GroupPermission
					{
						GroupId = 3,
						ActionId = 4,
						ObjectId = 4,
					},
					new GroupPermission
					{
						GroupId = 3,
						ActionId = 2,
						ObjectId = 5,
					},
					new GroupPermission
					{
						GroupId = 3,
						ActionId = 1,
						ObjectId = 6,
					},
					new GroupPermission
					{
						GroupId = 3,
						ActionId = 2,
						ObjectId = 6,
					},
					new GroupPermission
					{
						GroupId = 3,
						ActionId = 3,
						ObjectId = 6,
					},
					new GroupPermission
					{
						GroupId = 3,
						ActionId = 4,
						ObjectId = 6,
					},
					new GroupPermission
					{
						GroupId = 3,
						ActionId = 2,
						ObjectId = 7,
					},
					new GroupPermission
					{
						GroupId = 3,
						ActionId = 2,
						ObjectId = 8,
					},
					new GroupPermission
					{
						GroupId = 3,
						ActionId = 2,
						ObjectId = 9,
					},
					new GroupPermission
					{
						GroupId = 3,
						ActionId = 2,
						ObjectId = 11,
					},
					new GroupPermission
					{
						GroupId = 3,
						ActionId = 2,
						ObjectId = 12,
					},
					new GroupPermission
					{
						GroupId = 3,
						ActionId = 3,
						ObjectId = 12,
					},
					#endregion

					#region group id 4
					new GroupPermission
					{
						GroupId = 4,
						ActionId = 2,
						ObjectId = 1,
					},
					new GroupPermission
					{
						GroupId = 4,
						ActionId = 3,
						ObjectId = 1,
					},
					new GroupPermission
					{
						GroupId = 4,
						ActionId = 4,
						ObjectId = 1,
					},
					new GroupPermission
					{
						GroupId = 4,
						ActionId = 2,
						ObjectId = 2,
					},
					new GroupPermission
					{
						GroupId = 4,
						ActionId = 2,
						ObjectId = 3,
					},
					new GroupPermission
					{
						GroupId = 4,
						ActionId = 2,
						ObjectId = 4,
					},
					new GroupPermission
					{
						GroupId = 4,
						ActionId = 2,
						ObjectId = 5,
					},
					new GroupPermission
					{
						GroupId = 4,
						ActionId = 2,
						ObjectId = 6,
					},
					new GroupPermission
					{
						GroupId = 4,
						ActionId = 1,
						ObjectId = 7,
					},
					new GroupPermission
					{
						GroupId = 4,
						ActionId = 2,
						ObjectId = 7,
					},
					new GroupPermission
					{
						GroupId = 4,
						ActionId = 1,
						ObjectId = 8,
					},
					new GroupPermission
					{
						GroupId = 4,
						ActionId = 2,
						ObjectId = 8,
					},
					new GroupPermission
					{
						GroupId = 4,
						ActionId = 1,
						ObjectId = 9,
					},
					new GroupPermission
					{
						GroupId = 4,
						ActionId = 2,
						ObjectId = 9,
					},
					new GroupPermission
					{
						GroupId = 4,
						ActionId = 2,
						ObjectId = 10,
					},
					new GroupPermission
					{
						GroupId = 4,
						ActionId = 2,
						ObjectId = 11,
					},
					new GroupPermission
					{
						GroupId = 4,
						ActionId = 2,
						ObjectId = 12,
					},
					new GroupPermission
					{
						GroupId = 4,
						ActionId = 3,
						ObjectId = 12,
					},
					new GroupPermission
					{
						GroupId = 4,
						ActionId = 4,
						ObjectId = 12,
					},
					#endregion
				}
			);
		}
	}
}
