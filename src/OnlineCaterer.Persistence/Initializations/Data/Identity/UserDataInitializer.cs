using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineCaterer.Application.Models.Identity.Helper;
using OnlineCaterer.Domain.Identity;

namespace OnlineCaterer.Persistence.Initializations.Data.Identity
{
    public static class UserDataInitializer
	{
		public static void Initialize(this EntityTypeBuilder<User> entity)
		{
			entity.HasData(
				new[]
				{
					PasswordHasher.HashPassword(
						new User
						{
							Id = 1,
							UserTypeId = 1,
							UserId = 1,
							UserName = "Admin",
							Email = "onlinecaterer.admin@gmail.com",
							PhoneNumber = "0123456789",
							Status = true,
						},
						"123456"
					),
				}
			);
		}
	}
}
