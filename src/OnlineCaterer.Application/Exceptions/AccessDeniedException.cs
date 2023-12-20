namespace OnlineCaterer.Application.Exceptions
{
	public class AccessDeniedException : ApplicationException
	{
		public AccessDeniedException() : base("You do not have access!")
		{
		}

		public AccessDeniedException(string message) : base(message)
		{
		}
	}
}
