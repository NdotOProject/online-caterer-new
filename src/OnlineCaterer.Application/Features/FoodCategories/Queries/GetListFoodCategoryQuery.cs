using MediatR;
using OnlineCaterer.Application.DTOs.FoodCategory;
using OnlineCaterer.Application.Models.Api.Request;
using OnlineCaterer.Application.Models.Api.Response;

namespace OnlineCaterer.Application.Features.FoodCategories.Queries
{
	public class GetListFoodCategoryQuery
		: IApiRequest,
		IRequest<ListResponse<FoodCategoryDTO>>
	{
	}
}
