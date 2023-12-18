namespace OnlineCaterer.Domain.Identity.Relationship
{
	public class UserPermission
	{
		public int ActionId { get; set; }
		public int ObjectId { get; set; }
		public int UserId { get; set; }

		public Action Action { get; set; } = null!;
		public Object Object { get; set; } = null!;
		public User User { get; set; } = null!;
	}
}
