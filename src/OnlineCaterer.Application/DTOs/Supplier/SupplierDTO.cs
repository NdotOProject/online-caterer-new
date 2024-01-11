using OnlineCaterer.Application.DTOs.Food;

namespace OnlineCaterer.Application.DTOs.Supplier
{
	public class SupplierDTO
	{
		public int Id { get; set; }
		public string Name { get; set; } = null!;
		public string Address { get; set; } = null!;
		public string Introduction { get; set; } = null!;
		public int RatingPoint { get; set; }
		public int Status { get; set; }

		public ICollection<FoodDTO> Foods { get; set; } = new List<FoodDTO>();
	}
}
