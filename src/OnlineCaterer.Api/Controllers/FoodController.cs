using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnlineCaterer.Application.Features.Food.Create;
using OnlineCaterer.Application.Features.Food.Queries;
using OnlineCaterer.Application.Features.Food.Queries.All;
using OnlineCaterer.Application.Features.Food.Queries.One;
using OnlineCaterer.Application.Features.Food.Update;

namespace OnlineCaterer.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class FoodController : ControllerBase
	{
		private readonly IMediator _mediator;
		private readonly IHttpContextAccessor _httpContextAccessor;

		public FoodController(IMediator mediator, IHttpContextAccessor httpContextAccessor)
		{
			_mediator = mediator;
			_httpContextAccessor = httpContextAccessor;
		}
		[HttpGet]
		public async Task<ActionResult<List<FoodInformation>>> Get()
		{
			var response = await _mediator.Send(new GetAllFoodCommand());
			return Ok(response.ToJson());
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<FoodInformation>> Get(int id)
		{
			var response = await _mediator.Send(
				new GetOneFoodCommand
				{
					Id = id,
				}
			);

			return response.Success
				? Ok(response.ToJson())
				: NotFound(response.ToJson());
		}

		[HttpPost]
		public async Task<ActionResult> Post([FromBody] CreateFoodRequest request)
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
		public async Task<ActionResult<UpdateFoodResponse>> Put(int id, [FromBody] UpdateFoodRequest request)
		{
			var response = await _mediator.Send(
				new UpdateFoodCommand
				{
					Body = request,
				}
			);

			return response.Success
				? Ok(response.ToJson())
				: Unauthorized(response.ToJson());
		}

		[HttpDelete("{id}")]
		public void Delete(int id)
		{
		}
	}
}
