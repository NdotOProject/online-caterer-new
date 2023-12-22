using MediatR;
using OnlineCaterer.Application.Features.Customers.Requests;
using OnlineCaterer.Application.Models.Api.Request;
using OnlineCaterer.Application.Models.Api.Response;

namespace OnlineCaterer.Application.Features.Customers.Commands
{
	public class CreateCustomerCommand
		: IApiBodyRequest<CreateCustomerRequest>,
		IRequest<VoidResponse>
	{
		public CreateCustomerRequest Body { get; set; }
	}
}
