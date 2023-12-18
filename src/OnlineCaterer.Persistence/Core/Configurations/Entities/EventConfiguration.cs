using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineCaterer.Domain.Core;
using OnlineCaterer.Persistence.Extensions;

namespace OnlineCaterer.Persistence.Core.Configurations.Entities
{
    public class EventConfiguration : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> entity)
        {
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
