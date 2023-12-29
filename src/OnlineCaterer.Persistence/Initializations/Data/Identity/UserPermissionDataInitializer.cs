using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineCaterer.Domain.Identity.Relationship;

namespace OnlineCaterer.Persistence.Initializations.Data.Identity
{
	public static class UserPermissionDataInitializer
	{
		public static void Initialize(this EntityTypeBuilder<UserPermission> entity)
		{
			/*entity.HasData(
				new[]
				{
					new UserPermission
					{

					},
				}
			);*/
		}
	}
}
