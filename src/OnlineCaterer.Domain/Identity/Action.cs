using OnlineCaterer.Domain.Identity.Relationship;

namespace OnlineCaterer.Domain.Identity
{
	public class Action
	{
		public int Id { get; set; }
		public string Name { get; set; } = null!;

		// rel
		public ICollection<GroupPermission> Groups { get; set; } = new HashSet<GroupPermission>();
		public ICollection<UserPermission> Users { get; set; } = new HashSet<UserPermission>();
	}
}
