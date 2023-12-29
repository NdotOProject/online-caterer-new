using MediatR;
using OnlineCaterer.Application.Models.Api.Response;

namespace OnlineCaterer.Application.Features.Auth.Login
{
    public class LoginCommand : IRequest<DataResponse<LoginResponse>>
	{
		public LoginRequest LoginRequest { get; set; } = null!;
	}
}
