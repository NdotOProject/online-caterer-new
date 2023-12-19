using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineCaterer.Domain.Identity.Relationship;

namespace OnlineCaterer.Persistence.Configurations.Entities.Identity.Relationship
{
    public class GroupPermissionConfiguration : IEntityTypeConfiguration<GroupPermission>
    {
        public void Configure(EntityTypeBuilder<GroupPermission> entity)
        {
            entity.HasKey(
                nameof(GroupPermission.ActionId),
                nameof(GroupPermission.GroupId),
                nameof(GroupPermission.ObjectId)
            );

            entity.HasOne(gp => gp.Action)
                .WithMany(action => action.Groups)
                .HasForeignKey(gp => gp.ActionId)
                .IsRequired(true);

            entity.HasOne(gp => gp.Group)
                .WithMany(group => group.Permissions)
                .HasForeignKey(gp => gp.GroupId)
                .IsRequired(true);

            entity.HasOne(gp => gp.Object)
                .WithMany(obj => obj.Groups)
                .HasForeignKey(gp => gp.ObjectId)
                .IsRequired(true);
        }
    }
}
