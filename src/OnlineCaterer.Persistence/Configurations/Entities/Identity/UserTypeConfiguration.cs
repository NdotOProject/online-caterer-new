using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineCaterer.Domain.Core;
using OnlineCaterer.Domain.Identity;

namespace OnlineCaterer.Persistence.Configurations.Entities.Identity
{
	public class UserTypeConfiguration : IEntityTypeConfiguration<UserType>
	{
		public void Configure(EntityTypeBuilder<UserType> entity)
		{
			entity.HasKey(ut => ut.Id);

			entity.Property(ut => ut.Name)
				.HasColumnType("nvarchar")
				.HasMaxLength(100)
				.IsRequired(true);

			entity.HasData(
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
				}
			);
		}
	}
}
