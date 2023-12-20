using MediatR;
using OnlineCaterer.Application.Models.Api.Request.Put;
using OnlineCaterer.Application.Models.Api.Response;

namespace OnlineCaterer.Application.Features.Food.Update
{
	public class UpdateFoodCommand :
		PutRequest<UpdateFoodRequest>,
		IRequest<DataResponse<UpdateFoodResponse>>
	{
	}
}
