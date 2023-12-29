using OnlineCaterer.Application.Models.Api.Request;

namespace OnlineCaterer.Application.DTOs.Food
{
	public class UpdateFoodDTO
		: CreateFoodDTO,
		IRequestBody
	{
		public int Id { get; set; }
		public int RatingPoint { get; set; }
		public bool Discontinued { get; set; }
		public int CurrentQuantity { get; set; }
	}
}
