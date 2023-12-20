namespace OnlineCaterer.Application.Features.Auth.Register
{
	public class RegistrationRequest
	{
		// user
		public string Email { get; set; } = null!;
		public string Password { get; set; } = null!;

		// customer
		public string FirstName { get; set; } = null!;
		public string LastName { get; set; } = null!;
		public string Address { get; set; } = null!;
	}
}
