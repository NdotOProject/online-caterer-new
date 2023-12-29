using MediatR;
using OnlineCaterer.Application.DTOs.Feedback;
using OnlineCaterer.Application.Models.Api.Request;
using OnlineCaterer.Application.Models.Api.Response;

namespace OnlineCaterer.Application.Features.Feedback.Queries
{
	public class GetListFeedbackQuery
		: IApiRequest,
		IRequest<ListResponse<FeedbackDTO>>
	{
		public int FoodId { get; set; }
	}
}
