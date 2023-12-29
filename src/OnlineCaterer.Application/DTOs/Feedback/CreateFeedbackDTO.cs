using OnlineCaterer.Application.Models.Api.Request;

namespace OnlineCaterer.Application.DTOs.Feedback
{
	public class CreateFeedbackDTO
		: IRequestBody
	{
		public int CustomerId { get; set; }
		public int FoodId { get; set; }
		public string? Content { get; set; }
		public int RatingPoint { get; set; }
	}
}
