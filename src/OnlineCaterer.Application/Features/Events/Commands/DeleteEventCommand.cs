using MediatR;
using OnlineCaterer.Application.Models.Api.Request;
using OnlineCaterer.Application.Models.Api.Response;

namespace OnlineCaterer.Application.Features.Events.Commands
{
	public class DeleteEventCommand
		: IApiRequest,
		IRequest<VoidResponse>
	{
		public int Id { get; set; }
	}
}
