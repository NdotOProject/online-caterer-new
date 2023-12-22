using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineCaterer.Domain.Core;
using OnlineCaterer.Domain.Identity;

namespace OnlineCaterer.Persistence.Initializations.Data.Identity
{
	public static class UserTypeDataInitializer
	{
		public static void Initialize(this EntityTypeBuilder<UserType> entity)
		{
			entity.HasData(
				new[]
				{
					new UserType
					{
						Id = 1,
						Name = nameof(Employee),
					},
					new UserType
					{
						Id = 2,
						Name = nameof(Customer),
					},
					new UserType
					{
						Id = 3,
						Name = nameof(Supplier),
					},
				}
			);
		}
	}
}
