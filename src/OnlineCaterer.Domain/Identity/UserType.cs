namespace OnlineCaterer.Domain.Identity
{
	public class UserType
	{
		public int Id { get; set; }
		public string Name { get; set; } = null!;

		// rel
		public ICollection<User> Users { get; set;} = new HashSet<User>();
	}
}
