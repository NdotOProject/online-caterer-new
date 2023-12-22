using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineCaterer.Persistence.Extensions;
using OnlineCaterer.Persistence.Initializations.Data.Identity;

namespace OnlineCaterer.Persistence.Configurations.Entities.Identity
{
	public class ObjectConfiguration
		: IEntityTypeConfiguration<Domain.Identity.Object>
	{
		public void Configure(EntityTypeBuilder<Domain.Identity.Object> entity)
		{
			entity.Initialize();

			entity.HasKey(obj => obj.Id);

			entity.ConfigureDescriptionProperty();

			entity.Property(obj => obj.Name)
				.HasColumnType("nvarchar")
				.HasMaxLength(100)
				.IsRequired(true);
		}
	}
}
