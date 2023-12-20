namespace OnlineCaterer.Application.Features.Food.Create
{
	public class CreateFoodRequest
	{
		public int CategoryId { get; set; }
		public int EventId { get; set; }
		public int SupplierId { get; set; }
		public string Name { get; set; } = null!;
		public string Description { get; set; } = null!;
		public decimal UnitPrice { get; set; }
		public List<string> Images { get; set; } = null!;
	}
}
