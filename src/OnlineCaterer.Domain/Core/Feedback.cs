using OnlineCaterer.Domain.Common;

namespace OnlineCaterer.Domain.Core
{
	public class Feedback
		: IIdAutoIncrementEntity
	{
		public int Id { get; set; }
		public int CustomerId { get; set; }
		public int FoodId { get; set; }
		public string? Content { get; set; }
		public int RatingPoint { get; set; }

		// rel
		public Customer Customer { get; set; } = null!;
		public Food Food { get; set; } = null!;
	}
}
