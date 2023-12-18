using OnlineCaterer.Domain.Common;

namespace OnlineCaterer.Domain.Core
{
	public class Supplier : IUser, IIdAutoIncrementEntity
	{
		public int Id { get; set; }
		public string Name { get; set; } = null!;
		public string Address { get; set; } = null!;
		public string Introduction { get; set; } = null!;
		public int RatingPoint { get; set; }
		public int Status { get; set; }

		// rel
		public ICollection<Food> Foods { get; set; } = new HashSet<Food>();
		public ICollection<Order> Orders { get; set;} = new HashSet<Order>();

		public IUser Identity() => this;
	}
}
