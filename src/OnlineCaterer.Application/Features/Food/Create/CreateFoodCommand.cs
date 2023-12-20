using MediatR;
using OnlineCaterer.Application.Models.Api.Request.Post;
using OnlineCaterer.Application.Models.Api.Response;

namespace OnlineCaterer.Application.Features.Food.Create
{
	public class CreateFoodCommand : PostRequest<CreateFoodRequest>,
		IRequest<VoidResponse>
	{
	}
}
