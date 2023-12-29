using OnlineCaterer.Application.Models.Api.Request;

namespace OnlineCaterer.Application.DTOs.FoodCategory
{
	public class UpdateFoodCategoryDTO
		: IRequestBody
	{
		public int Id { get; set; }
		public string? Name { get; set; }
		public string? Description { get; set; }
	}
}
