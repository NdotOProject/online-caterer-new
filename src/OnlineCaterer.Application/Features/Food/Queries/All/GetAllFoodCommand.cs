using MediatR;
using OnlineCaterer.Application.Models.Api.Request;
using OnlineCaterer.Application.Models.Api.Response;

namespace OnlineCaterer.Application.Features.Food.Queries.All
{
	public class GetAllFoodCommand
		: IApiRequest,
		IRequest<ListResponse<FoodInformation>>
	{
	}
}
