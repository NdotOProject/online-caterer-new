using MediatR;
using OnlineCaterer.Application.Models.Api.Request;
using OnlineCaterer.Application.Models.Api.Response;

namespace OnlineCaterer.Application.Features.FoodCategories.Commands
{
	public class DeleteFoodCategoryCommand
		: IApiRequest,
		IRequest<VoidResponse>
	{
		public int Id { get; set; }
	}
}
