using MediatR;
using OnlineCaterer.Application.Contracts.Identity.Services;
using OnlineCaterer.Application.Exceptions;
using OnlineCaterer.Application.Models.Api.Response;

namespace OnlineCaterer.Application.Features.Auth.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, DataResponse<LoginResponse>>
	{
		private readonly IAuthService _authService;

		public LoginCommandHandler(IAuthService authService)
		{
			_authService = authService;
		}

		public async Task<DataResponse<LoginResponse>> Handle(LoginCommand request, CancellationToken cancellationToken)
		{
			try
			{
				var loginResp = await _authService.Login(request.LoginRequest);
				return new DataResponse<LoginResponse>
				{
					Message = "Welcome Back.",
				};
			}
			catch (NotFoundException)
			{
				return new DataResponse<LoginResponse>
				{
					Message = "Your username or password invalid.",
				};
			}
		}
	}
}
