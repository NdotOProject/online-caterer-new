using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineCaterer.Domain.Identity;
using OnlineCaterer.Persistence.Extensions;

namespace OnlineCaterer.Persistence.Identity.Configurations.Entities
{
	public class GroupConfiguration : IEntityTypeConfiguration<Group>
	{
		public void Configure(EntityTypeBuilder<Group> entity)
		{
			entity.IdAutoIncrement();

			entity.Property(group => group.Name)
				.HasColumnType("nvarchar")
				.HasMaxLength(100)
				.IsRequired(true);

			entity.ConfigureDescriptionProperty();

			entity.ConfigureAuditableProperties();
		}
	}
}
