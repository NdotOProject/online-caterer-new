using AutoMapper;
using MediatR;
using OnlineCaterer.Application.Contracts.Identity.Services;
using OnlineCaterer.Application.Contracts.Repositories.Core;
using OnlineCaterer.Application.DTOs.PaymentMethod;
using OnlineCaterer.Application.Features.PaymentMethods.Queries;
using OnlineCaterer.Application.Models.Api.Handler;
using OnlineCaterer.Application.Models.Api.Response;

namespace OnlineCaterer.Application.Features.PaymentMethods.Handlers
{
	public class GetListPaymentMethodHandler
		: GetListHandler<GetListPaymentMethodQuery, PaymentMethodDTO>,
		IRequestHandler<GetListPaymentMethodQuery, ListResponse<PaymentMethodDTO>>
	{
		private readonly IMapper _mapper;
		private readonly IPaymentMethodRepository _paymentMethodRepository;

		public GetListPaymentMethodHandler(
			IPermissionProvider permissonProvider,
			IUserService userService,
			IPaymentMethodRepository paymentMethodRepository,
			IMapper mapper)
			: base(permissonProvider, userService)
		{
			_paymentMethodRepository = paymentMethodRepository;
			_mapper = mapper;
		}

		public async Task<ListResponse<PaymentMethodDTO>> Handle(
			GetListPaymentMethodQuery request,
			CancellationToken cancellationToken)
		{
			return await GetResponse(request);
		}

		protected override async Task Resolve(
			GetListPaymentMethodQuery request,
			ListResponse<PaymentMethodDTO> response)
		{
			var paymentMethods = await _paymentMethodRepository.GetAll();

			response.Payload = _mapper.Map<List<PaymentMethodDTO>>(paymentMethods);
		}
	}
}
