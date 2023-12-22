using MediatR;
using OnlineCaterer.Application.Features.Events.Responses;
using OnlineCaterer.Application.Models.Api.Request;
using OnlineCaterer.Application.Models.Api.Response;

namespace OnlineCaterer.Application.Features.Events.Queries
{
	public class GetListEventQuery
		: IApiRequest,
		IRequest<ListResponse<GetEventResponse>>
	{
	}
}
