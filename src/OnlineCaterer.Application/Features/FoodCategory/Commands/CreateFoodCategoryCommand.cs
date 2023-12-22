using MediatR;
using OnlineCaterer.Application.Features.FoodCategory.Requests;
using OnlineCaterer.Application.Models.Api.Request;
using OnlineCaterer.Application.Models.Api.Response;

namespace OnlineCaterer.Application.Features.FoodCategory.Commands
{
	public class CreateFoodCategoryCommand
		: IApiBodyRequest<CreateFoodCategoryRequest>,
		IRequest<VoidResponse>
	{
		public CreateFoodCategoryRequest Body { get; set; }
	}
}
