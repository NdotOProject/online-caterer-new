using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineCaterer.Domain.Identity;
using OnlineCaterer.Persistence.Initializations.Data.Identity;

namespace OnlineCaterer.Persistence.Configurations.Entities.Identity
{
	public class UserTypeConfiguration
		: IEntityTypeConfiguration<UserType>
	{
		public void Configure(EntityTypeBuilder<UserType> entity)
		{
			entity.Initialize();

			entity.HasKey(ut => ut.Id);

			entity.Property(ut => ut.Name)
				.HasColumnType("nvarchar")
				.HasMaxLength(100)
				.IsRequired(true);
		}
	}
}
