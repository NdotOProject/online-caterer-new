using MediatR;
using OnlineCaterer.Application.Models.Api.Request;
using OnlineCaterer.Application.Models.Api.Response;

namespace OnlineCaterer.Application.Features.Food.Queries.One
{
	public class GetOneFoodCommand
		: IApiRequest,
		IRequest<DataResponse<FoodInformation>>
	{
		public int Id { get; set; }
	}
}
