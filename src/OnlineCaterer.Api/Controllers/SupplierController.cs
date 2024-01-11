using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnlineCaterer.Application.DTOs.Supplier;
using OnlineCaterer.Application.Features.Supplier.Queries;
using OnlineCaterer.Application.Models.Api.Response;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OnlineCaterer.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class SupplierController : ControllerBase
	{
		private readonly IMediator _mediator;

		public SupplierController(IMediator mediator)
		{
			_mediator = mediator;
		}

		// GET: api/<SupplierController>
		[HttpGet]
		public async Task<ActionResult<ListResponse<SupplierDTO>>> Get()
		{
			var response = await _mediator.Send(
				new GetListSupplierQuery()
			);
			return Ok(response.ToJson());
		}
/*
		// GET api/<SupplierController>/5
		[HttpGet("{id}")]
		public string Get(int id)
		{
			return "value";
		}

		// POST api/<SupplierController>
		[HttpPost]
		public void Post([FromBody] string value)
		{
		}

		// PUT api/<SupplierController>/5
		[HttpPut("{id}")]
		public void Put(int id, [FromBody] string value)
		{
		}

		// DELETE api/<SupplierController>/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
		}*/
	}
}
