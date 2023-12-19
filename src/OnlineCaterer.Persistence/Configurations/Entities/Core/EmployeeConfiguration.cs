using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineCaterer.Domain.Core;
using OnlineCaterer.Persistence.Extensions;

namespace OnlineCaterer.Persistence.Configurations.Entities.Core
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> entity)
        {
            entity.IdAutoIncrement();

            entity.Property(emp => emp.FirstName)
                .HasColumnType("nvarchar")
                .HasMaxLength(100)
                .IsRequired(true);

            entity.Property(emp => emp.LastName)
                .HasColumnType("nvarchar")
                .HasMaxLength(100)
                .IsRequired(true);

            entity.Property(emp => emp.Address)
                .HasColumnType("nvarchar")
                .HasMaxLength(255)
                .IsRequired(true);

            entity.Property(supplier => supplier.RatingPoint)
                .IsRequired(true);

            entity.Property(supplier => supplier.Status)
                .IsRequired(true);
        }
    }
}
