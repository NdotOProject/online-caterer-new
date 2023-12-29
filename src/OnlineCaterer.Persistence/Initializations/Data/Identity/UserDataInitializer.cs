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
					#region employees
					PasswordHasher.HashPassword(
						new User
						{
							Id = 1,
							UserId = 1,
							UserTypeId = 1,
							UserName = "Vũ Tuấn Anh",
							Email = "anh.vt@aptechlearning.edu.vn",
							PhoneNumber = "0123456789",
							Status = true,
						},
						"123456"
					),
					PasswordHasher.HashPassword(
						new User
						{
							Id = 2,
							UserId = 2,
							UserTypeId = 1,
							UserName = "Lê Thành Thắng",
							Email = "thang.lt@aptechlearning.edu.vn",
							PhoneNumber = "1234567890",
							Status = true,
						},
						"123456"
					),
					#endregion

					#region suppliers
					PasswordHasher.HashPassword(
						new User
						{
							Id = 3,
							UserId = 1,
							UserTypeId = 3,
							UserName = "Aptech Food",
							Email = "aptechfood@gmail.com",
							PhoneNumber = "0923456789",
							Status = true,
						},
						"123456"
					),
					PasswordHasher.HashPassword(
						new User
						{
							Id = 4,
							UserId = 2,
							UserTypeId = 3,
							UserName = "Lẩu Kiệt",
							Email = "kiet.bt@aptechlearning.edu.vn",
							PhoneNumber = "0956784321",
							Status = true,
						},
						"123456"
					),
					#endregion

					#region customers
					PasswordHasher.HashPassword(
						new User
						{
							Id = 5,
							UserId = 1,
							UserTypeId = 2,
							UserName = "Lê Đức Anh",
							Email = "anh.ld@aptechlearning.edu.vn",
							PhoneNumber = "0917236485",
							Status = true,
						},
						"123456"
					),
					PasswordHasher.HashPassword(
						new User
						{
							Id = 6,
							UserId = 2,
							UserTypeId = 2,
							UserName = "Trần Minh Nam",
							Email = "nam.tm@aptechlearning.edu.vn",
							PhoneNumber = "0193284675",
							Status = true,
						},
						"123456"
					),
					#endregion
				}
			);
		}
	}
}
