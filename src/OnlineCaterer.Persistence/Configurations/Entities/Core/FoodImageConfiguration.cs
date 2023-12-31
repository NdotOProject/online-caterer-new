﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineCaterer.Domain.Core;
using OnlineCaterer.Persistence.Extensions;
using OnlineCaterer.Persistence.Initializations.Data;

namespace OnlineCaterer.Persistence.Configurations.Entities.Core
{
	public class FoodImageConfiguration
		: IEntityTypeConfiguration<FoodImage>
	{
		public void Configure(EntityTypeBuilder<FoodImage> entity)
		{
			entity.Initialize();

			entity.IdAutoIncrement();

			entity.HasOne(img => img.Food)
				.WithMany(food => food.Images)
				.HasForeignKey(img => img.FoodId)
				.IsRequired(true);

			entity.Property(img => img.Name)
				.HasColumnType("nvarchar")
				.HasMaxLength(100)
				.IsRequired(true);

			entity.Property(img => img.Avatar)
				.HasDefaultValue(false)
				.IsRequired(true);
		}
	}
}
