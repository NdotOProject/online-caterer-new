using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnlineCaterer.Application.DTOs.Event;
using OnlineCaterer.Application.Features.Events.Queries;
using OnlineCaterer.Application.Models.Api.Response;

namespace OnlineCaterer.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class EventController : ControllerBase
	{
		private readonly IMediator _mediator;

		public EventController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpGet]
		public async Task<ActionResult<ListResponse<EventDTO>>> Get()
		{
			var response = await _mediator.Send(
				new GetListEventQuery()
			);
			return Ok(response.ToJson());
		}
		/*
		[HttpGet("{id}")]
		public async Task<ActionResult<EventDTO>> Get(int id)
		{
			var response = await _mediator.Send(
				new GetEvent
			);
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
