using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineCaterer.Domain.Core;
using OnlineCaterer.Persistence.Extensions;

namespace OnlineCaterer.Persistence.Configurations.Entities.Core
{
    public class PaymentMethodConfiguration : IEntityTypeConfiguration<PaymentMethod>
    {
        public void Configure(EntityTypeBuilder<PaymentMethod> entity)
        {
            entity.IdAutoIncrement();

            entity.ConfigureDescriptionProperty();

            entity.Property(pm => pm.Name)
                .HasColumnType("nvarchar")
                .HasMaxLength(100)
                .IsRequired(true);
        }
    }
}
