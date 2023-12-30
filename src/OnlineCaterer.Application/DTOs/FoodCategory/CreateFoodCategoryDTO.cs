using OnlineCaterer.Application.Models.Api.Request;

namespace OnlineCaterer.Application.DTOs.FoodCategory
{
	public class CreateFoodCategoryDTO
		: IRequestBody
	{
		public string Name { get; set; } = null!;
		public string? Description { get; set; }
	}
}
