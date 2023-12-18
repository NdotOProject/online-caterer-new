using OnlineCaterer.Domain.Common;

namespace OnlineCaterer.Domain.Core
{
	public class PaymentMethod :IIdAutoIncrementEntity
	{
		public int Id { get; set; }
		public string Name { get; set; } = null!;
		public string Description { get; set; } = null!;

		// rel
		public ICollection<Order> Orders { get; set; } = new HashSet<Order>();
	}
}
