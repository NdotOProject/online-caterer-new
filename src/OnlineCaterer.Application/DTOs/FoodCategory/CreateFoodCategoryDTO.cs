using OnlineCaterer.Application.Models.Api.Request;

namespace OnlineCaterer.Application.DTOs.FoodCategory
{
	public class CreateFoodCategoryDTO
		: IRequestBody
	{
		public string? Name { get; set; }
		public string? Description { get; set; }
	}
}
