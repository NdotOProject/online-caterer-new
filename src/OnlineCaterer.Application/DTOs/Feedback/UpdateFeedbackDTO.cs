using OnlineCaterer.Application.Models.Api.Request;

namespace OnlineCaterer.Application.DTOs.Feedback
{
	public class UpdateFeedbackDTO
		: IRequestBody
	{
		public int Id { get; set; }
		public string? Content { get; set; }
		public int RatingPoint { get; set; }
	}
}
