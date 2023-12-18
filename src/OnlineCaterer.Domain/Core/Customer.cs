using OnlineCaterer.Domain.Common;

namespace OnlineCaterer.Domain.Core
{
	public class Customer : IUser, IIdAutoIncrementEntity
	{
		public int Id { get; set; }
		public string FirstName { get; set; } = null!;
		public string LastName { get; set; } = null!;
		public string Address { get; set; } = null!;

		// rel
		public ICollection<Order> Orders { get; set; } = new HashSet<Order>();
		public ICollection<Feedback> Feedbacks { get; set; } = new HashSet<Feedback>();

		public IUser Identity() => this;
	}
}
