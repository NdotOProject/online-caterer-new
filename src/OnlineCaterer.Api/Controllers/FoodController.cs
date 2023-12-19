using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnlineCaterer.Application.Features.Food.Queries;
using OnlineCaterer.Application.Features.Food.Queries.All;
using OnlineCaterer.Domain.Core;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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
			this._httpContextAccessor = httpContextAccessor;
		}
		// GET: api/<FoodController>
		[HttpGet]
		public async Task<ActionResult<List<FoodInformation>>> Get()
		{
			var foods = await _mediator.Send(new GetAllFoodCommand());
			return Ok(foods);
		}

		// GET api/<FoodController>/5
		[HttpGet("{id}")]
		public string Get(int id)
		{
			return "value";
		}

		// POST api/<FoodController>
		[HttpPost]
		public void Post([FromBody] string value)
		{
		}

		// PUT api/<FoodController>/5
		[HttpPut("{id}")]
		public void Put(int id, [FromBody] string value)
		{
		}

		// DELETE api/<FoodController>/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
		}
	}
}
