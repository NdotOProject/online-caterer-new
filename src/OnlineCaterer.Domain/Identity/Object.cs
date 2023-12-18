using OnlineCaterer.Domain.Identity.Relationship;

namespace OnlineCaterer.Domain.Identity
{
	public class Object
	{
		public int Id { get; set; }
		public string Name { get; set; } = null!;
		public string Description { get; set; } = string.Empty;

		// rel
		public ICollection<GroupPermission> Groups { get; set; } = new HashSet<GroupPermission>();
		public ICollection<UserPermission> Users { get; set; } = new HashSet<UserPermission>();
	}
}
