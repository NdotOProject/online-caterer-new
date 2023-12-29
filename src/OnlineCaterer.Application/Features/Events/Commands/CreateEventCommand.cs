using MediatR;
using OnlineCaterer.Application.DTOs.Event;
using OnlineCaterer.Application.Models.Api.Request;
using OnlineCaterer.Application.Models.Api.Response;

namespace OnlineCaterer.Application.Features.Events.Commands
{
	public class CreateEventCommand
		: IApiBodyRequest<CreateEventDTO>,
		IRequest<VoidResponse>
	{
		public CreateEventDTO Body { get; set; } = null!;
	}
}
