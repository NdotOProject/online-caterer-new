using MediatR;
using OnlineCaterer.Application.Features.FoodCategory.Requests;
using OnlineCaterer.Application.Features.FoodCategory.Responses;
using OnlineCaterer.Application.Models.Api.Request;
using OnlineCaterer.Application.Models.Api.Response;

namespace OnlineCaterer.Application.Features.FoodCategory.Commands
{
    public class UpdateFoodCategoryCommand
		: IApiBodyRequest<UpdateFoodCategoryRequest>,
		IRequest<DataResponse<UpdateFoodCategoryResponse>>
	{
		public int Id { get; set; }
		public UpdateFoodCategoryRequest Body { get; set; }
	}
}
