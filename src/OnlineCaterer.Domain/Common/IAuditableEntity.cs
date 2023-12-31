﻿namespace OnlineCaterer.Domain.Common
{
	public interface IAuditableEntity
	{
		int ModifiedByUserType { get; set; }
		DateTime CreatedDate { get; set; }
		int CreatedBy { get; set; }
		DateTime LastModifiedDate { get; set; }
		int LastModifiedBy { get; set; }
	}
}
