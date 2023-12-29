using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnlineCaterer.Application.Constants;
using OnlineCaterer.Application.DTOs.Food;
using OnlineCaterer.Application.Features.Foods.Commands;
using OnlineCaterer.Application.Features.Foods.Queries;
using OnlineCaterer.Application.Models.Api.Response;

namespace OnlineCaterer.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class FoodController : ControllerBase
	{
		private readonly IMediator _mediator;

		public FoodController(IMediator mediator, IHttpContextAccessor httpContextAccessor)
		{
			_mediator = mediator;
		}
		[HttpGet]
		public async Task<ActionResult<List<FoodDTO>>> Get()
		{
			var response = await _mediator.Send(
				new GetListFoodQuery()
			);
			return Ok(response.ToJson());
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<FoodDTO>> Get(int id)
		{
			var response = await _mediator.Send(
				new GetFoodDetailQuery
				{
					Id = id,
				}
			);

			return response.Success
				? Ok(response.ToJson())
				: NotFound(response.ToJson());
		}

		[HttpPost]
		public async Task<ActionResult> Post(
			[FromBody] CreateFoodDTO request)
		{
			var response = await _mediator.Send(
				new CreateFoodCommand
				{
					Body = request,
				}
			);

			return response.Success
				? Created("", null)
				: BadRequest(response.ToJson());
		}

		[HttpPut("{id}")]
		public async Task<ActionResult<VoidResponse>> Put(
			int id, [FromBody] UpdateFoodDTO request)
		{
			var response = await _mediator.Send(
				new UpdateFoodCommand
				{
					Id = id,
					Body = request,
				}
			);

			return response.Success
				? Ok(response.ToJson())
				: Unauthorized(response.ToJson());
		}

		[HttpDelete("{id}")]
		public async Task<ActionResult<VoidResponse>> Delete(int id)
		{
			var response = await _mediator.Send(
				new DeleteFoodCommand
				{
					Id = id,
				}
			);

			return response.Success
				? Ok(response.ToJson())
				: Unauthorized(response.ToJson());
		}
	}
}
