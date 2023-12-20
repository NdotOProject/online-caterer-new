namespace OnlineCaterer.Application.Features.Customer.Update
{
	public class UpdateCustomerRequest
	{
		// customer
		public int Id { get; set; }
		public string FirstName { get; set; } = null!;
		public string LastName { get; set; } = null!;
		public string Address { get; set; } = null!;

		// user
		public string UserName { get; set; } = null!;
		public string Password { get; set; } = null!;
		public string PhoneNumber { get; set; } = null!;
	}
}
