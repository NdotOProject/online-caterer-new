using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineCaterer.Domain.Core;
using OnlineCaterer.Persistence.Extensions;
using OnlineCaterer.Persistence.Initializations.Data;

namespace OnlineCaterer.Persistence.Configurations.Entities.Core
{
	public class CustomerConfiguration
		: IEntityTypeConfiguration<Customer>
	{
		public void Configure(EntityTypeBuilder<Customer> entity)
		{
			entity.Initialize();

			entity.IdAutoIncrement();

			entity.Property(customer => customer.FirstName)
				.HasColumnType("nvarchar")
				.HasMaxLength(100)
				.IsRequired(true);

			entity.Property(customer => customer.LastName)
				.HasColumnType("nvarchar")
				.HasMaxLength(100)
				.IsRequired(true);

			entity.Property(customer => customer.Address)
				.HasColumnType("nvarchar")
				.HasMaxLength(255)
				.IsRequired(true);
		}
	}
}
