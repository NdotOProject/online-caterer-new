﻿using OnlineCaterer.Domain.Common;

namespace OnlineCaterer.Domain.Core
{
	public class FoodImage : IIdAutoIncrementEntity, IAuditableEntity
	{
		public int Id { get; set; }
		public int FoodId { get; set; }
		public string Name { get; set; } = null!;
		public bool Avatar { get; set; }

		// impl IAuditableEntity
		public int ModifiedByUserType { get; set; }
		public DateTime CreatedDate { get; set; }
		public int CreatedBy { get; set; }
		public DateTime LastModifiedDate { get; set; }
		public int LastModifiedBy { get; set; }

		// rel
		public Food Food { get; set; } = null!;
	}
}
