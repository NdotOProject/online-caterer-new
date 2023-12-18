using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OnlineCaterer.Persistence.Identity.Configurations.Entities
{
	public class ActionConfiguration : IEntityTypeConfiguration<Domain.Identity.Action>
	{
		public void Configure(EntityTypeBuilder<Domain.Identity.Action> entity)
		{
			entity.HasKey(act => act.Id);

			entity.Property(act => act.Name)
				.HasColumnType("nvarchar")
				.HasMaxLength(50)
				.IsRequired(true);

			entity.HasData(
				new Domain.Identity.Action
				{
					Id = 1,
					Name = "Create",
				},
				new Domain.Identity.Action
				{
					Id = 2,
					Name = "Read",
				},
				new Domain.Identity.Action
				{
					Id = 3,
					Name = "Update",
				},
				new Domain.Identity.Action
				{
					Id = 4,
					Name = "Delete",
				}
			);
		}
	}
}
