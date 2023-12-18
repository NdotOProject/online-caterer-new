namespace OnlineCaterer.Domain.Identity.Relationship
{
	public class GroupUser
	{
		public int GroupId { get; set; }
		public int UserId { get; set; }

		public Group Group { get; set; } = null!;
		public User User { get; set; } = null!;
	}
}
