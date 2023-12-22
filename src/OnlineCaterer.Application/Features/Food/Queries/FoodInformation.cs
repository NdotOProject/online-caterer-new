namespace OnlineCaterer.Application.Features.Food.Queries
{
	public class FoodInformation
	{
		public int Id { get; set; }
		public int CategoryId { get; set; }
		public int EventId { get; set; }
		public int SupplierId { get; set; }
		public string Name { get; set; } = null!;
		public string Description { get; set; } = null!;
		public decimal UnitPrice { get; set; }
		public int RatingPoint { get; set; }
		public bool Discontinued { get; set; }
		public int CurrentQuantity { get; set; }

		public List<string> Images { get; set; } = new List<string>();
	}
}
