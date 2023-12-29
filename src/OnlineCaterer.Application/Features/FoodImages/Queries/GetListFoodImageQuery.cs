using MediatR;
using OnlineCaterer.Application.DTOs.FoodImage;
using OnlineCaterer.Application.Models.Api.Request;
using OnlineCaterer.Application.Models.Api.Response;

namespace OnlineCaterer.Application.Features.FoodImages.Queries
{
	public class GetListFoodImageQuery
		: IApiRequest,
		IRequest<ListResponse<FoodImageDTO>>
	{
		public int FoodId { get; set; }
	}
}
