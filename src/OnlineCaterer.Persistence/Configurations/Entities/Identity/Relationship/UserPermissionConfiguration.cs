﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineCaterer.Domain.Identity.Relationship;
using OnlineCaterer.Persistence.Initializations.Data.Identity;

namespace OnlineCaterer.Persistence.Configurations.Entities.Identity.Relationship
{
	public class UserPermissionConfiguration
		: IEntityTypeConfiguration<UserPermission>
	{
		public void Configure(EntityTypeBuilder<UserPermission> entity)
		{
			entity.Initialize();

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
