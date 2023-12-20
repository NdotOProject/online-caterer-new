using OnlineCaterer.Application.Features.Auth.Login;
using OnlineCaterer.Application.Features.Auth.Register;

namespace OnlineCaterer.Application.Contracts.Identity.Services
{
	public interface IAuthService
	{
		Task<LoginResponse?> Login(LoginRequest request);
		Task<RegistrationResponse?> Register(RegistrationRequest request);
	}
}
