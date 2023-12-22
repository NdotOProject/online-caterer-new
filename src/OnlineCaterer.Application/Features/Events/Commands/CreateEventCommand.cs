using MediatR;
using OnlineCaterer.Application.Features.Events.Requests;
using OnlineCaterer.Application.Models.Api.Request;
using OnlineCaterer.Application.Models.Api.Response;

namespace OnlineCaterer.Application.Features.Events.Commands
{
	public class CreateEventCommand
		: IApiBodyRequest<CreateEventRequest>,
		IRequest<VoidResponse>
	{
		public CreateEventRequest Body { get; set; }
	}
}
