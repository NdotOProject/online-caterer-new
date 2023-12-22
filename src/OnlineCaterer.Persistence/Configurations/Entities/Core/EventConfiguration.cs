using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineCaterer.Domain.Core;
using OnlineCaterer.Persistence.Extensions;
using OnlineCaterer.Persistence.Initializations.Data;

namespace OnlineCaterer.Persistence.Configurations.Entities.Core
{
	public class EventConfiguration
		: IEntityTypeConfiguration<Event>
	{
		public void Configure(EntityTypeBuilder<Event> entity)
		{
			entity.Initialize();

			entity.IdAutoIncrement();

			entity.ConfigureAuditableProperties();

			entity.ConfigureDescriptionProperty();

			entity.Property(ev => ev.Name)
				.HasColumnType("nvarchar")
				.HasMaxLength(100)
				.IsRequired(true);
		}
	}
}
