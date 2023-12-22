using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineCaterer.Domain.Identity.Relationship;
using OnlineCaterer.Persistence.Initializations.Data.Identity;

namespace OnlineCaterer.Persistence.Configurations.Entities.Identity.Relationship
{
	public class GroupUserConfiguration
		: IEntityTypeConfiguration<GroupUser>
	{
		public void Configure(EntityTypeBuilder<GroupUser> entity)
		{
			entity.Initialize();

			entity.HasKey(
				nameof(GroupUser.GroupId),
				nameof(GroupUser.UserId)
			);

			entity.HasOne(gu => gu.Group)
				.WithMany(group => group.Users)
				.HasForeignKey(gu => gu.GroupId)
				.IsRequired(true);

			entity.HasOne(gu => gu.User)
				.WithMany(user => user.Groups)
				.HasForeignKey(gu => gu.UserId)
				.IsRequired(true);
		}
	}
}
