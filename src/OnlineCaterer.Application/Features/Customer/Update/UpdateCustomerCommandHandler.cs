using MediatR;
using OnlineCaterer.Application.Contracts.Identity.Services;
using OnlineCaterer.Application.Contracts.Persistence;
using OnlineCaterer.Application.Models.Api.Request.Put;
using OnlineCaterer.Application.Models.Api.Response;
using OnlineCaterer.Application.Models.Identity;

namespace OnlineCaterer.Application.Features.Customer.Update
{
	public class UpdateCustomerCommandHandler :
		PutRequestHandler<UpdateCustomerCommand, UpdateCustomerRequest, VoidResponse>,
		IRequestHandler<UpdateCustomerCommand, VoidResponse>
	{
		private readonly IUnitOfWork _unitOfWork;

		public UpdateCustomerCommandHandler(
			IPermissionProvider permissonProvider, IUserService userService,
			IUnitOfWork unitOfWork
		) : base(permissonProvider, userService)
		{
			_unitOfWork = unitOfWork;
		}

		public async Task<VoidResponse> Handle(
			UpdateCustomerCommand request, CancellationToken cancellationToken)
			=> await GetResponse(request);

		protected override async Task<Permission?> GetRequiredPermission(IPermissionProvider permissonProvider)
			=> await permissonProvider.GetPermission(Objects.Customer, Actions.Update);

		protected override Task Reject(DataResponse<VoidResponse> response)
		{
			response.Message = "Update Failed!";
			return Task.CompletedTask;
		}

		protected override Task Resolve(UpdateCustomerCommand request, DataResponse<VoidResponse> response)
		{
			throw new NotImplementedException();
		}
	}
}
