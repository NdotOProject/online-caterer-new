using MediatR;
using OnlineCaterer.Application.Models.Api.Response;

namespace OnlineCaterer.Application.Features.Food.Queries.One
{
    public class GetOneFoodCommand : IRequest<DataResponse<FoodInformation>>
	{
		public int FoodId { get; set; }
	}
}
