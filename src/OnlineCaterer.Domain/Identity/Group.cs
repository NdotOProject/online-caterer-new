using OnlineCaterer.Domain.Common;
using OnlineCaterer.Domain.Identity.Relationship;

namespace OnlineCaterer.Domain.Identity
{
	public class Group : IIdAutoIncrementEntity, IAuditableEntity
	{
		public int Id { get; set; }
		public string Name { get; set; } = null!;
		public string Description { get; set; } = string.Empty;

		// impl IAuditableEntity
		public int ModifiedByUserType { get; set; }
		public DateTime CreatedDate { get; set; }
		public int CreatedBy { get; set; }
		public DateTime LastModifiedDate { get; set; }
		public int LastModifiedBy { get; set; }

		// rel
		public ICollection<GroupPermission> Permissions { get; set; } = new HashSet<GroupPermission>();
		public ICollection<GroupUser> Users { get; set; } = new HashSet<GroupUser>();
	}
}
