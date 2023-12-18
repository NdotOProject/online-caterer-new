namespace OnlineCaterer.Domain.Core
{
	public class OrderDetail
	{
		public int OrderId { get; set; }
		public int FoodId { get; set; }
		public int Quantity { get; set; }
		public decimal UnitPrice { get; set; }
		public int Discount { get; set; }

		// rel
		public Order Order { get; set; } = null!;
		public Food Food { get; set; } = null!;
	}
}
