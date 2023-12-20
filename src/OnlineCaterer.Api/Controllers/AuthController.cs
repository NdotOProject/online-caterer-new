using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnlineCaterer.Application.Features.Auth.Login;
using OnlineCaterer.Application.Features.Auth.Register;
using OnlineCaterer.Application.Models.Api.Response;

namespace OnlineCaterer.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AuthController : ControllerBase
	{
		private readonly IMediator _mediator;

		public AuthController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpPost("/login")]
		public async Task<ActionResult<DataResponse<LoginResponse>>> Login([FromBody] LoginRequest request)
		{
			var reponse = await _mediator.Send(
				new LoginCommand
				{
					LoginRequest = request,
				}
			);
			return reponse.Success
				? Ok(reponse.ToJson())
				: BadRequest(reponse.ToJson());
		}

		[HttpPost("/register")]
		public async Task<ActionResult<DataResponse<LoginResponse>>> Register([FromBody] RegistrationRequest request)
		{
			var reponse = await _mediator.Send(
				new RegistrationCommand
				{
					RegistrationRequest = request,
				}
			);
			return Ok(reponse.ToJson());
		}
	}
}
