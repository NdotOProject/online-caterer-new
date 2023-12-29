using MediatR;
using OnlineCaterer.Application.Models.Api.Request;
using OnlineCaterer.Application.Models.Api.Response;

namespace OnlineCaterer.Application.Features.Feedback.Commands
{
	public class DeleteFeedbackCommand
		: IApiRequest,
		IRequest<VoidResponse>
	{
		public int Id { get; set; }
	}
}
