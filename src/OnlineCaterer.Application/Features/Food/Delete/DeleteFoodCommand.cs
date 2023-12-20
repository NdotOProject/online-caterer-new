using MediatR;
using OnlineCaterer.Application.Models.Api.Request.Delete;
using OnlineCaterer.Application.Models.Api.Response;

namespace OnlineCaterer.Application.Features.Food.Delete
{
	public class DeleteFoodCommand : DeleteRequest, IRequest<VoidResponse>
	{
		public int Id { get; set; }
	}
}
