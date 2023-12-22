using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineCaterer.Domain.Identity;
using OnlineCaterer.Persistence.Extensions;
using OnlineCaterer.Persistence.Initializations.Data.Identity;

namespace OnlineCaterer.Persistence.Configurations.Entities.Identity
{
	public class GroupConfiguration
		: IEntityTypeConfiguration<Group>
	{
		public void Configure(EntityTypeBuilder<Group> entity)
		{
			entity.Initialize();

			entity.IdAutoIncrement();

			entity.ConfigureDescriptionProperty();

			entity.ConfigureAuditableProperties();

			entity.Property(group => group.Name)
				.HasColumnType("nvarchar")
				.HasMaxLength(100)
				.IsRequired(true);
		}
	}
}
