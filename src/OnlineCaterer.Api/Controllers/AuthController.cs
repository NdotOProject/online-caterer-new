using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnlineCaterer.Application.Features.Auth.Login;
using OnlineCaterer.Application.Features.Auth.Register;
using OnlineCaterer.Application.Features.Customers.Commands;
using OnlineCaterer.Application.Features.Customers.Requests;
using OnlineCaterer.Application.Models.Api.Response;

namespace OnlineCaterer.Api.Controllers
{
	[Route("api/auth")]
	[ApiController]
	public class AuthController : ControllerBase
	{
		private readonly IMediator _mediator;

		public AuthController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpPost("/login")]
		public async Task<ActionResult<DataResponse<LoginResponse>>> Login(
			[FromBody] LoginRequest request)
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
		public async Task<ActionResult<string>> Register(
			[FromBody] CreateCustomerRequest request)
		{
			var reponse = await _mediator.Send(
				new CreateCustomerCommand
				{
					Body = request
				}
			);
			return Ok(reponse.ToJson());
		}
	}
}
