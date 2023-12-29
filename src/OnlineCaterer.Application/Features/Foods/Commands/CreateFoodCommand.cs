using MediatR;
using OnlineCaterer.Application.DTOs.Food;
using OnlineCaterer.Application.Models.Api.Request;
using OnlineCaterer.Application.Models.Api.Response;

namespace OnlineCaterer.Application.Features.Foods.Commands
{
	public class CreateFoodCommand
		: IApiBodyRequest<CreateFoodDTO>,
		IRequest<VoidResponse>
	{
		public CreateFoodDTO Body { get; set; } = null!;
	}
}
