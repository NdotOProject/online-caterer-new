namespace OnlineCaterer.Domain.Identity.Relationship
{
	public class GroupPermission
	{
		public int ActionId { get; set; }
		public int GroupId { get; set; }
		public int ObjectId { get; set; }

		public Action Action { get; set; } = null!;
		public Group Group { get; set; } = null!;
		public Object Object { get; set; } = null!;
	}
}
