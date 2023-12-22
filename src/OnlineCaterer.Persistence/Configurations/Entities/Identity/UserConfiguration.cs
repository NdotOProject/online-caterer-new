using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineCaterer.Domain.Identity;
using OnlineCaterer.Persistence.Extensions;
using OnlineCaterer.Persistence.Initializations.Data.Identity;

namespace OnlineCaterer.Persistence.Configurations.Entities.Identity
{
	public class UserConfiguration
		: IEntityTypeConfiguration<User>
	{
		public void Configure(EntityTypeBuilder<User> entity)
		{
			entity.Initialize();

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
		}
	}
}
