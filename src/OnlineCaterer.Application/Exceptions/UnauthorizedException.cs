namespace OnlineCaterer.Application.Exceptions
{
	public class UnauthorizedException : ApplicationException
	{
		public UnauthorizedException() : base("You do not have access!")
		{
		}

		public UnauthorizedException(string message) : base(message)
		{
		}
	}
}
