using OnlineCaterer.Domain.Common;

namespace OnlineCaterer.Domain.Core
{
	public class Event : IIdAutoIncrementEntity, IAuditableEntity
	{
		public int Id { get; set; }
		public string Name { get; set; } = null!;
		public string Description { get; set; } = null!;

		// impl IAuditableEntity
		public DateTime CreatedDate { get; set; }
		public int CreatedBy { get; set; }
		public DateTime LastModifiedDate { get; set; }
		public int LastModifiedBy { get; set; }

		// rel
		public ICollection<Food> Foods { get; set; } = new HashSet<Food>();
	}
}
