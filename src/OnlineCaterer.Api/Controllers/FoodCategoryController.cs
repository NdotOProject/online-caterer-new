using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnlineCaterer.Application.DTOs.FoodCategory;
using OnlineCaterer.Application.Features.FoodCategories.Commands;
using OnlineCaterer.Application.Features.FoodCategories.Queries;
using OnlineCaterer.Application.Models.Api.Response;

namespace OnlineCaterer.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class FoodCategoryController : ControllerBase
	{
		private readonly IMediator _mediator;

		public FoodCategoryController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpGet]
		public async Task<ActionResult<ListResponse<FoodCategoryDTO>>> Get()
		{
			var response = await _mediator.Send(
				new GetListFoodCategoryQuery()
			);
			return Ok(response.ToJson());
		}
/*
		[HttpPost]
		public void Post([FromBody] string value)
		{
		}

		[HttpPut("{id}")]
		public void Put(int id, [FromBody] string value)
		{
			var cmd = new UpdateFoodCategoryCommand();

		}

		[HttpDelete("{id}")]
		public void Delete(int id)
		{
			var cmd = new DeleteFoodCategoryCommand();
		}*/
	}
}
