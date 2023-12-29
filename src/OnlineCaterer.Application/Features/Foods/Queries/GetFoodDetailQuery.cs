using MediatR;
using OnlineCaterer.Application.DTOs.Food;
using OnlineCaterer.Application.Models.Api.Request;
using OnlineCaterer.Application.Models.Api.Response;

namespace OnlineCaterer.Application.Features.Foods.Queries
{
	public class GetFoodDetailQuery
		: IApiRequest,
		IRequest<DataResponse<FoodDTO>>
	{
		public int Id { get; set; }
	}
}
