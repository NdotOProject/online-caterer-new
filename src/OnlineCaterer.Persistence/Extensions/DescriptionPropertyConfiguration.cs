using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OnlineCaterer.Persistence.Extensions
{
	public static class DescriptionPropertyConfiguration
	{
		public static EntityTypeBuilder<T> ConfigureDescriptionProperty<T>(this EntityTypeBuilder<T> entity)
			where T : class
		{
			entity.Property<string>("Description")
				.HasColumnType("nvarchar(max)")
				.HasDefaultValue("No Description.")
				.IsRequired(true);
			return entity;
		}
	}
}
