using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineCaterer.Domain.Common;

namespace OnlineCaterer.Persistence.Extensions
{
	public static class IdAutoIncrementEntityConfiguration
	{
		public static EntityTypeBuilder<T> IdAutoIncrement<T>(this EntityTypeBuilder<T> entity)
			where T : class, IIdAutoIncrementEntity
		{
			entity.HasKey(e => e.Id);
			entity.Property(e => e.Id)
				.UseIdentityColumn(seed: 1, increment: 1)
				.ValueGeneratedOnAdd()
				.IsRequired(true);

			return entity;
		}
	}
}
