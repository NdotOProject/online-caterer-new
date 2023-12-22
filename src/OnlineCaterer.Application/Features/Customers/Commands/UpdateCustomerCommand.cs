using MediatR;
using OnlineCaterer.Application.Features.Customers.Requests;
using OnlineCaterer.Application.Features.Customers.Responses;
using OnlineCaterer.Application.Models.Api.Request;
using OnlineCaterer.Application.Models.Api.Response;

namespace OnlineCaterer.Application.Features.Customers.Commands
{
	public class UpdateCustomerCommand
		: IApiBodyRequest<UpdateCustomerRequest>,
		IRequest<DataResponse<UpdateCustomerResponse>>
	{
		public UpdateCustomerRequest Body { get; set; }
	}
}
