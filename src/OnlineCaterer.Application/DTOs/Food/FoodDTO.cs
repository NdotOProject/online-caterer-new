using OnlineCaterer.Application.DTOs.Event;
using OnlineCaterer.Application.DTOs.FoodCategory;

namespace OnlineCaterer.Application.DTOs.Food
{
	public class FoodDTO
	{
		public int Id { get; set; }
		public FoodCategoryDTO? Category { get; set; }
		public EventDTO? Event { get; set; }
		public int SupplierId { get; set; }
		//public Supplier
		public string Name { get; set; } = null!;
		public string Description { get; set; } = null!;
		public decimal UnitPrice { get; set; }
		public int RatingPoint { get; set; }
		public bool Discontinued { get; set; }
		public int CurrentQuantity { get; set; }

		public List<string> Images { get; set; } = new();
	}
}
