using Microsoft.AspNetCore.Mvc;
using OnlineCaterer.Application.Features.FoodCategory.Commands;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OnlineCaterer.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class FoodCategoryController : ControllerBase
	{
		// GET: api/<FoodCategoryController>
		[HttpGet]
		public IEnumerable<string> Get()
		{
			return new string[] { "value1", "value2" };
		}

		// GET api/<FoodCategoryController>/5
		[HttpGet("{id}")]
		public string Get(int id)
		{
			return "value";
		}

		// POST api/<FoodCategoryController>
		[HttpPost]
		public void Post([FromBody] string value)
		{
		}

		// PUT api/<FoodCategoryController>/5
		[HttpPut("{id}")]
		public void Put(int id, [FromBody] string value)
		{
			var cmd = new UpdateFoodCategoryCommand();

		}

		// DELETE api/<FoodCategoryController>/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
			var cmd = new DeleteFoodCategoryCommand();
		}
	}
}
