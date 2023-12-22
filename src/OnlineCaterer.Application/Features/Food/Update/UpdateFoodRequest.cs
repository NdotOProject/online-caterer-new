using OnlineCaterer.Application.Features.Food.Create;
using OnlineCaterer.Application.Models.Api.Request;

namespace OnlineCaterer.Application.Features.Food.Update
{
	public class UpdateFoodRequest
		: CreateFoodRequest,
		IRequestBody
	{
		public int Id { get; set; }
		public int RatingPoint { get; set; }
		public bool Discontinued { get; set; }
		public int CurrentQuantity { get; set; }
	}
}
