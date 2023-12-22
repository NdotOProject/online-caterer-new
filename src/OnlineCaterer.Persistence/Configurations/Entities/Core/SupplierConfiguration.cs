using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineCaterer.Domain.Core;
using OnlineCaterer.Persistence.Extensions;
using OnlineCaterer.Persistence.Initializations.Data;

namespace OnlineCaterer.Persistence.Configurations.Entities.Core
{
	public class SupplierConfiguration
		: IEntityTypeConfiguration<Supplier>
	{
		public void Configure(EntityTypeBuilder<Supplier> entity)
		{
			entity.Initialize();

			entity.IdAutoIncrement();

			entity.Property(supplier => supplier.Name)
				.HasColumnType("nvarchar")
				.HasMaxLength(255)
				.IsRequired(true);

			entity.Property(supplier => supplier.Address)
				.HasColumnType("nvarchar")
				.HasMaxLength(255)
				.IsRequired(true);

			entity.Property(supplier => supplier.Introduction)
				.HasColumnType("nvarchar(max)")
				.HasDefaultValue("Welcome")
				.IsRequired(true);

			entity.Property(supplier => supplier.RatingPoint)
				.IsRequired(true);

			entity.Property(supplier => supplier.Status)
				.IsRequired(true);
		}
	}
}
