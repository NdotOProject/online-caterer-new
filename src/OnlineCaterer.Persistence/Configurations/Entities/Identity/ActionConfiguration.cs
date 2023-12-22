using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineCaterer.Persistence.Initializations.Data.Identity;

namespace OnlineCaterer.Persistence.Configurations.Entities.Identity
{
	public class ActionConfiguration
		: IEntityTypeConfiguration<Domain.Identity.Action>
	{
		public void Configure(EntityTypeBuilder<Domain.Identity.Action> entity)
		{
			entity.Initialize();

			entity.HasKey(act => act.Id);

			entity.Property(act => act.Name)
				.HasColumnType("nvarchar")
				.HasMaxLength(50)
				.IsRequired(true);
		}
	}
}
