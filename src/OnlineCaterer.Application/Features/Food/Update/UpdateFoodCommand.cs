using MediatR;
using OnlineCaterer.Application.Models.Api.Request;
using OnlineCaterer.Application.Models.Api.Response;

namespace OnlineCaterer.Application.Features.Food.Update
{
	public class UpdateFoodCommand
		: IApiBodyRequest<UpdateFoodRequest>,
		IRequest<DataResponse<UpdateFoodResponse>>
	{
		public UpdateFoodRequest Body { get; set; }
	}
}
