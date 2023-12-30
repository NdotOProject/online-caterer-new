using OnlineCaterer.Application.Models.Api.Request;

namespace OnlineCaterer.Application.DTOs.FoodCategory
{
	public class FoodCategoryDTO
		: IRequestBody
	{
		public int Id { get; set; }
		public string Name { get; set; } = null!;
		public string Description { get; set; } = null!;
	}
}
