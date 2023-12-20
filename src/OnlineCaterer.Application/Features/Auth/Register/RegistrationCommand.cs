using MediatR;
using OnlineCaterer.Application.Models.Api.Response;

namespace OnlineCaterer.Application.Features.Auth.Register
{
    public class RegistrationCommand : IRequest<DataResponse<RegistrationResponse>>
	{
		public RegistrationRequest RegistrationRequest { get; set; }
	}
}
