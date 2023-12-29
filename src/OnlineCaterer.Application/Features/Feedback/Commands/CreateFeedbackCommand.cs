using MediatR;
using OnlineCaterer.Application.DTOs.Feedback;
using OnlineCaterer.Application.Models.Api.Request;
using OnlineCaterer.Application.Models.Api.Response;

namespace OnlineCaterer.Application.Features.Feedback.Commands
{
	public class CreateFeedbackCommand
		: IApiBodyRequest<CreateFeedbackDTO>,
		IRequest<VoidResponse>
	{
		public CreateFeedbackDTO Body { get; set; } = null!;
	}
}
