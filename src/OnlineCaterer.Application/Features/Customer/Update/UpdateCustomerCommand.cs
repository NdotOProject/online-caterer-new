using MediatR;
using OnlineCaterer.Application.Models.Api.Request.Put;
using OnlineCaterer.Application.Models.Api.Response;

namespace OnlineCaterer.Application.Features.Customer.Update
{
	public class UpdateCustomerCommand : PutRequest<UpdateCustomerRequest>,
		IRequest<VoidResponse>
	{
	}
}
