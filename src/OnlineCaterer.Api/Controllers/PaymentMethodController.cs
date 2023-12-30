using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnlineCaterer.Application.DTOs.PaymentMethod;
using OnlineCaterer.Application.Features.PaymentMethods.Queries;
using OnlineCaterer.Application.Models.Api.Response;

namespace OnlineCaterer.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PaymentMethodController : ControllerBase
	{
		private readonly IMediator _mediator;

		public PaymentMethodController(
			IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpGet]
		public async Task<ActionResult<ListResponse<PaymentMethodDTO>>> Get()
		{
			var response = await _mediator.Send(
				new GetListPaymentMethodQuery()
			);

			return Ok(response.ToJson());
		}
		/*
		[HttpGet("{id}")]
		public string Get(int id)
		{
			return "value";
		}
		*/
		[HttpPost]
		public void Post([FromBody] string value)
		{
		}

		[HttpPut("{id}")]
		public void Put(int id, [FromBody] string value)
		{
		}

		[HttpDelete("{id}")]
		public void Delete(int id)
		{
		}
	}
}
