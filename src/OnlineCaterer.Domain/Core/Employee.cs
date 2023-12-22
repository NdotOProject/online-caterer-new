using OnlineCaterer.Domain.Common;

namespace OnlineCaterer.Domain.Core
{
	public class Employee : IUser, IIdAutoIncrementEntity
	{
		public int Id { get; set; }
		public string FirstName { get; set; } = null!;
		public string LastName { get; set; } = null!;
		public string Address { get; set; } = null!;
		public int RatingPoint { get; set; }
		public bool Status { get; set; }

		// rel
		public ICollection<Order> Orders { get; set; } = new HashSet<Order>();

		public IUser Identity() => this;
	}
}
