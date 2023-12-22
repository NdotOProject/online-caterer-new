using MediatR;
using OnlineCaterer.Application.Models.Api.Request;
using OnlineCaterer.Application.Models.Api.Response;

namespace OnlineCaterer.Application.Features.Food.Create
{
	public class CreateFoodCommand
		: IApiBodyRequest<CreateFoodRequest>,
		IRequest<VoidResponse>
	{
		public CreateFoodRequest Body { get; set; }
	}
}
