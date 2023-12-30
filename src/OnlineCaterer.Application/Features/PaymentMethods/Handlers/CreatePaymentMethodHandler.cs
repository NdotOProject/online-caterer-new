using AutoMapper;
using MediatR;
using OnlineCaterer.Application.Contracts.Identity.Services;
using OnlineCaterer.Application.Contracts.Repositories.Core;
using OnlineCaterer.Application.DTOs.PaymentMethod;
using OnlineCaterer.Application.DTOs.PaymentMethod.Validators;
using OnlineCaterer.Application.Features.PaymentMethods.Commands;
using OnlineCaterer.Application.Models.Api.Error;
using OnlineCaterer.Application.Models.Api.Handler;
using OnlineCaterer.Application.Models.Api.Response;
using OnlineCaterer.Application.Models.Identity.Conventions;
using OnlineCaterer.Application.Models.Identity.Helper;
using System.Net;

namespace OnlineCaterer.Application.Features.PaymentMethods.Handlers
{
	public class CreatePaymentMethodHandler
		: PostHandler<CreatePaymentMethodCommand, CreatePaymentMethodDTO>,
		IRequestHandler<CreatePaymentMethodCommand, VoidResponse>
	{
		private readonly IPaymentMethodRepository _paymentMethodRepository;
		private readonly IMapper _mapper;

		public CreatePaymentMethodHandler(
			IPermissionProvider permissonProvider,
			IUserService userService,
			IPaymentMethodRepository paymentMethodRepository,
			IMapper mapper)
			: base(permissonProvider, userService)
		{
			_paymentMethodRepository = paymentMethodRepository;
			_mapper = mapper;
		}

		public async Task<VoidResponse> Handle(
			CreatePaymentMethodCommand request,
			CancellationToken cancellationToken)
		{
			return await GetResponse(request);
		}

		protected override async Task Resolve(
			CreatePaymentMethodCommand request, VoidResponse response)
		{
			var paymentMethod = _mapper.Map<Domain.Core.PaymentMethod>(request.Body);
			paymentMethod = await _paymentMethodRepository.Add(paymentMethod);

			response.Id = paymentMethod.Id;
			response.Message = "Created new payment method successfully.";
		}

		protected override Task Reject(
			CreatePaymentMethodCommand request, VoidResponse response)
		{
			response.Message = "Create new payment method failed.";
			return Task.CompletedTask;
		}

		protected override async Task<Permission> GetPermission(
			IPermissionProvider provider)
		{
			return await provider.GetPermission(
				Objects.PaymentMethod,
				Actions.Create
			);
		}

		protected override async Task Validate(
			CreatePaymentMethodCommand request, ErrorList errorList)
		{
			var validator = new CreatePaymentMethodValidator();
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
	}
}
