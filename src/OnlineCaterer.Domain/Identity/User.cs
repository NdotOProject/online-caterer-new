using OnlineCaterer.Domain.Common;
using OnlineCaterer.Domain.Identity.Relationship;

namespace OnlineCaterer.Domain.Identity
{
	public class User : IIdAutoIncrementEntity, IAuditableEntity
	{
		public int Id { get; set; }
		public int UserTypeId { get; set; }
		public int UserId { get; set; }
		public string UserName { get; set; } = null!;
		public string Email { get; set; } = null!;
		public string Password { get; set; } = null!;
		public string PhoneNumber { get; set; } = null!;
		public bool Status { get; set; }

		// impl IAuditableEntity
		public int ModifiedByUserType { get; set; }
		public DateTime CreatedDate { get; set; }
		public int CreatedBy { get; set; }
		public DateTime LastModifiedDate { get; set; }
		public int LastModifiedBy { get; set; }

		// rel
		public UserType UserType { get; set; } = null!;
		public ICollection<GroupUser> Groups { get; set; } = new HashSet<GroupUser>();
		public ICollection<UserPermission> Permissions { get; set; } = new HashSet<UserPermission>();
	}
}
