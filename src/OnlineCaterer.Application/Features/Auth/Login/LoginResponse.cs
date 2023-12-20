namespace OnlineCaterer.Application.Features.Auth.Login
{
	public class LoginResponse
	{
		public int Id { get; set; }
		public int UserType { get; set; }
		public string Username { get; set; } = null!;
		public string Email { get; set; } = null!;
		public string Token { get; set; } = null!;
	}
}
