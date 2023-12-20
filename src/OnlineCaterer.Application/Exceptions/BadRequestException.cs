namespace OnlineCaterer.Application.Exceptions
{
	public class BadRequestException : ApplicationException
	{
		public BadRequestException() : base("Bad Request!")
		{
		}

		public BadRequestException(string message) : base(message)
		{
		}
	}
}
