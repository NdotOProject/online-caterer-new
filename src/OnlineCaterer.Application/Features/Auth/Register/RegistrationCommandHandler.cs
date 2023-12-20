using MediatR;
using OnlineCaterer.Application.Contracts.Identity.Services;
using OnlineCaterer.Application.Models.Api.Response;
namespace OnlineCaterer.Application.Features.Auth.Register
{
    public class RegistrationCommandHandler
		: IRequestHandler<RegistrationCommand, DataResponse<RegistrationResponse>>
	{
		private readonly IAuthService _authService;

		public RegistrationCommandHandler(IAuthService authService)
		{
			_authService = authService;
		}

		public async Task<DataResponse<RegistrationResponse>> Handle(
			RegistrationCommand request, CancellationToken cancellationToken
		)
		{
			var regisResp = await _authService.Register(request.RegistrationRequest);
			return new DataResponse<RegistrationResponse>
			{
				Message = "Craete Successful.",
				Payload = regisResp,
			};
		}
	}
}
