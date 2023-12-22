using MediatR;
using OnlineCaterer.Application.Contracts.Identity.Services;
using OnlineCaterer.Application.Contracts.Persistence;
using OnlineCaterer.Application.Features.Customers.Commands;
using OnlineCaterer.Application.Features.Customers.Requests;
using OnlineCaterer.Application.Features.Customers.Validators;
using OnlineCaterer.Application.Models.Api.Error;
using OnlineCaterer.Application.Models.Api.Handler;
using OnlineCaterer.Application.Models.Api.Response;
using OnlineCaterer.Application.Models.Identity.Conventions;
using OnlineCaterer.Application.Models.Identity.Helper;
using OnlineCaterer.Domain.Core;
using OnlineCaterer.Domain.Identity;
using System.Net;

namespace OnlineCaterer.Application.Features.Customers.Handlers
{
	public class CreateCustomerHandler
		: PostHandler<CreateCustomerCommand, CreateCustomerRequest>,
		IRequestHandler<CreateCustomerCommand, VoidResponse>
	{
		private readonly IUnitOfWork _unitOfWork;

		public CreateCustomerHandler(
			IPermissionProvider permissonProvider,
			IUserService userService,
			IUnitOfWork unitOfWork)
			: base(permissonProvider, userService)
		{
			_unitOfWork = unitOfWork;
		}

		public async Task<VoidResponse> Handle(
			CreateCustomerCommand request,
			CancellationToken cancellationToken)
		{
			return await GetResponse(request);
		}

		protected override async Task Validate(
			CreateCustomerCommand request, ErrorList errorList)
		{
			var validator = new CreateCustomerValidator(_unitOfWork);

			var result = await validator.ValidateAsync(request.Body);

			if (!result.IsValid)
			{
				foreach (var error in result.Errors)
				{
					errorList.Add(
						HttpStatusCode.BadRequest,
						error.ErrorMessage
					);
				}
			}
		}

		protected override Task Reject(
			CreateCustomerCommand request, VoidResponse response)
		{
			return base.Reject(request, response);
		}

		protected override async Task Resolve(
			CreateCustomerCommand request, VoidResponse response)
		{
			var customer = new Customer
			{
				Address = request.Body.Address,
				FirstName = request.Body.FirstName,
				LastName = request.Body.LastName,
			};

			customer = await _unitOfWork.
				CustomerRepository.Add(customer);

			var user = PasswordHasher.HashPassword(
				new User
				{
					Email = request.Body.Email,
					UserName = request.Body.Email,
					PhoneNumber = request.Body.PhoneNumber,
					Status = true,
					UserTypeId = UserService.GetUserTypeId(
						UserTypes.Customer
					),
					UserId = customer.Id,
				},
				request.Body.Password
			);
			await _unitOfWork.UserRepository.Add(user);

			await _unitOfWork.SaveChanges(user);
		}
	}
}
