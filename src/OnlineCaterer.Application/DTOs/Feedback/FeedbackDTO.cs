using OnlineCaterer.Application.Models.Api.Request;

namespace OnlineCaterer.Application.DTOs.Feedback
{
	public class FeedbackDTO
		: IRequestBody
	{
		public int Id { get; set; }
		public int CustomerId { get; set; }
		public string? Content { get; set; }
		public int RatingPoint { get; set; }
	}
}
