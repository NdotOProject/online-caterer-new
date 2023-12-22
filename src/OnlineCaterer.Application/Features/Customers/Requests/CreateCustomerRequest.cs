using OnlineCaterer.Application.Models.Api.Request;

namespace OnlineCaterer.Application.Features.Customers.Requests
{
	public class CreateCustomerRequest : IRequestBody
	{
		// customer
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Address { get; set; }

		// user
		public string Email { get; set; }
		public string Password { get; set; }
		public string PhoneNumber { get; set; }
	}
}
