using MediatR;
using OnlineCaterer.Application.Contracts.Identity.Services;
using OnlineCaterer.Application.Features.Customers.Commands;
using OnlineCaterer.Application.Features.Customers.Requests;
using OnlineCaterer.Application.Models.Api.Handler;
using OnlineCaterer.Application.Models.Api.Response;

namespace OnlineCaterer.Application.Features.Customers.Handlers
{
	public class UpdateCustomerHandler
		: PutHandler<UpdateCustomerCommand, UpdateCustomerRequest>,
		IRequestHandler<UpdateCustomerCommand, VoidResponse>
	{
		public UpdateCustomerHandler(
			IPermissionProvider permissonProvider, IUserService userService)
			: base(permissonProvider, userService)
		{
		}

		public async Task<VoidResponse> Handle(
			UpdateCustomerCommand request, CancellationToken cancellationToken)
		{
			return await GetResponse(request);
		}

		protected override Task Resolve(
			UpdateCustomerCommand request,
			VoidResponse response)
		{
			throw new NotImplementedException();
		}
	}
}
