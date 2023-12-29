using MediatR;
using OnlineCaterer.Application.Models.Api.Request;
using OnlineCaterer.Application.Models.Api.Response;

namespace OnlineCaterer.Application.Features.Foods.Commands
{
	public class DeleteFoodCommand
		: IApiRequest,
		IRequest<VoidResponse>
	{
		public int Id { get; set; }
	}
}
