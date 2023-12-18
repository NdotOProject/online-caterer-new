using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineCaterer.Domain.Identity.Relationship;

namespace OnlineCaterer.Persistence.Identity.Configurations.Entities.Relationship
{
    public class UserPermissionConfiguration : IEntityTypeConfiguration<UserPermission>
    {
        public void Configure(EntityTypeBuilder<UserPermission> entity)
        {
            entity.HasKey(
                nameof(UserPermission.ActionId),
                nameof(UserPermission.ObjectId),
                nameof(UserPermission.UserId)
            );

            entity.HasOne(up => up.Action)
                .WithMany(act => act.Users)
                .HasForeignKey(up => up.ActionId)
                .IsRequired(true);

            entity.HasOne(up => up.Object)
                .WithMany(obj => obj.Users)
                .HasForeignKey(up => up.ObjectId)
                .IsRequired(true);

            entity.HasOne(up => up.User)
                .WithMany(user => user.Permissions)
                .HasForeignKey(up => up.UserId)
                .IsRequired(true);
        }
    }
}
