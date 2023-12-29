using MediatR;
using OnlineCaterer.Application.DTOs.FoodCategory;
using OnlineCaterer.Application.Models.Api.Request;
using OnlineCaterer.Application.Models.Api.Response;

namespace OnlineCaterer.Application.Features.FoodCategories.Commands
{
	public class CreateFoodCategoryCommand
		: IApiBodyRequest<CreateFoodCategoryDTO>,
		IRequest<VoidResponse>
	{
		public CreateFoodCategoryDTO Body { get; set; } = null!;
	}
}
