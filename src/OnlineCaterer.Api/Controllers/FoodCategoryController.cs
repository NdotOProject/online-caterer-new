using Microsoft.AspNetCore.Mvc;
using OnlineCaterer.Application.Features.FoodCategories.Commands;

namespace OnlineCaterer.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class FoodCategoryController : ControllerBase
	{
		[HttpGet]
		public IEnumerable<string> Get()
		{
			return new string[] { "value1", "value2" };
		}

		[HttpGet("{id}")]
		public string Get(int id)
		{
			return "value";
		}

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
		}
	}
}
