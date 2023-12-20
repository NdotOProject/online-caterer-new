using MediatR;
using OnlineCaterer.Application.Models.Api.Request.Get;
using OnlineCaterer.Application.Models.Api.Response;

namespace OnlineCaterer.Application.Features.Food.Queries.All
{
	public class GetAllFoodCommand : GetRequest<List<FoodInformation>>,
		IRequest<DataResponse<List<FoodInformation>>>
	{
	}
}
