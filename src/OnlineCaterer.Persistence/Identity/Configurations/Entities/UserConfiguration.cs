using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineCaterer.Application.Models.Identity;
using OnlineCaterer.Domain.Identity;
using OnlineCaterer.Persistence.Extensions;

namespace OnlineCaterer.Persistence.Identity.Configurations.Entities
{
	public class UserConfiguration : IEntityTypeConfiguration<User>
	{
		public void Configure(EntityTypeBuilder<User> entity)
		{
			entity.IdAutoIncrement();

			entity.ConfigureAuditableProperties();

			entity.Property(user => user.UserId)
				.IsRequired(true);

			entity.HasOne(user => user.UserType)
				.WithMany(userType => userType.Users)
				.HasForeignKey(user => user.UserTypeId)
				.IsRequired(true);

			entity.Property(user => user.UserName)
				.HasColumnType("nvarchar")
				.HasMaxLength(255)
				.IsRequired(true);

			entity.Property(user => user.Email)
				.HasColumnType("nvarchar")
				.HasMaxLength(255)
				.IsRequired(true);
			entity.HasIndex(user => user.Email)
				.IsUnique(true);

			entity.Property(user => user.Password)
				.HasColumnType("nvarchar")
				.HasMaxLength(255)
				.IsRequired(true);

			entity.Property(user => user.PhoneNumber)
				.HasColumnType("varchar")
				.HasMaxLength(15)
				.IsRequired(true);
			entity.HasIndex(user => user.PhoneNumber)
				.IsUnique(true);

			entity.Property(user => user.Status)
				.IsRequired(true);

			/*var admin = new User
            {
                Id = 1,
                Email = "admin@localhost.com",
                UserName = "admin",
                PhoneNumber = "0123456789",
            };*/
			//entity.HasData(PasswordHasher.HashPassword(admin, "123456"));
		}
	}
}
