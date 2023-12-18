using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineCaterer.Domain.Common;

namespace OnlineCaterer.Persistence.Extensions
{
	public static class AuditableEntityConfiguration
	{
		public static EntityTypeBuilder<T> ConfigureAuditableProperties<T>(this EntityTypeBuilder<T> entity)
			where T : class, IAuditableEntity
		{
			entity.Property(e => e.CreatedBy)
				.IsRequired(true);

			entity.Property(e => e.LastModifiedBy)
				.IsRequired(true);

			entity.Property(e => e.CreatedDate)
				.HasColumnType("datetime2")
				.IsRequired(true);

			entity.Property(e => e.LastModifiedDate)
				.HasColumnType("datetime2")
				.IsRequired(true);

			return entity;
		}
	}
}
