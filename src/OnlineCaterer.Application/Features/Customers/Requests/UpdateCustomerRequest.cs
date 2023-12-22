using OnlineCaterer.Application.Models.Api.Request;

namespace OnlineCaterer.Application.Features.Customers.Requests
{
	public class UpdateCustomerRequest : IRequestBody
	{
		// customer
		public int Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Address { get; set; }

		// user
		public string UserName { get; set; }
		public string Password { get; set; }
		public string PhoneNumber { get; set; }
	}
}
