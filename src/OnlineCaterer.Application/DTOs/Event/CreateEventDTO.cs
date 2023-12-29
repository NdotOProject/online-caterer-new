using OnlineCaterer.Application.Models.Api.Request;

namespace OnlineCaterer.Application.DTOs.Event
{
	public class CreateEventDTO : IRequestBody
	{
		public string? Name { get; set; }
		public string? Description { get; set; }
	}
}
