using MediatR;
using OnlineCaterer.Application.Features.Events.Requests;
using OnlineCaterer.Application.Features.Events.Responses;
using OnlineCaterer.Application.Models.Api.Request;
using OnlineCaterer.Application.Models.Api.Response;

namespace OnlineCaterer.Application.Features.Events.Commands
{
	public class UpdateEventCommand
		: IApiBodyRequest<UpdateEventRequest>,
		IRequest<DataResponse<UpdateEventResponse>>
	{
		public UpdateEventRequest Body { get; set; }
	}
}
